using System;
using System.Collections;
using System.Text;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Diagnostics; // Trace sýnýfý...
using RTCCORELib;

namespace RTCClient
{
    public class Motor
    {
        #region Genel Deðiþkenler
        private RTCClientClass istemci;
        private IRTCProfile2 profil;

        private Hashtable htPencereler;
        private ArrayList Oturumlar;

        private RTC_REGISTRATION_STATE kayitDurumu; // Sunucudan gelen cevaplara göre deðiþir
        private bool bulunmaDurumu;

        private AnaPencere anaPencere;

        private IVideoWindow gelenMedia = null;
        private IVideoWindow gidenMedia = null;

        string mediaKatilimci = String.Empty; // MediaEvent fonksiyonunda pencerenin Handle'ýný elde etmek için SessionStateChangeEvent'ten alýyoruz
        string IMKatilimci = String.Empty;

        public string istemciAdi
        {
            get { return profil.UserName; }
        }

        public string istemciURI
        {
            get { return profil.UserURI; }
        }
        #endregion

        public Motor(AnaPencere anapencere)
        {
            this.anaPencere = anapencere;
            this.bulunmaDurumu = false; // bulunma durumu(çevrimiçi,meþgul vs.) ayarlanmadý
            this.kayitDurumu = RTC_REGISTRATION_STATE.RTCRS_NOT_REGISTERED; // Henüz kayýt olmadýk
            htPencereler = new Hashtable(); // uri key leri ile pencereler takip edilir
            Oturumlar = new ArrayList(); // açýlan oturumlarla(sessionEvent.Sessison) oturumlar takip edilir
            try
            {
                istemci = new RTCClientClass();
                istemci.Initialize();
                istemci.EventFilter = Sabitler.RTC_EVENTFILTERS;
                istemci.ListenForIncomingSessions = RTC_LISTEN_MODE.RTCLM_BOTH; // Gelen mesajlarý dinle, SIP portunu açar(5060)
                istemci.IRTCEventNotification_Event_Event += new IRTCEventNotification_EventEventHandler(istemci_IRTCEventNotification_Event_Event);

                istemci.SetPreferredMediaTypes(Sabitler.RTC_MEDIA_SABITLERI, true);
                gelenMedia = istemci.get_IVideoWindow(RTC_VIDEO_DEVICE.RTCVD_RECEIVE);
                gidenMedia = istemci.get_IVideoWindow(RTC_VIDEO_DEVICE.RTCVD_PREVIEW);
                istemci.ClientName = "RTCClient";
                istemci.ClientCurVer = "1.0";
            }
            catch(COMException hata)
            {
                this.anaPencere.MesajGoster(hata.ToString(), "Hata");
            }
        }

        #region Ýstemci Olaylarý
        private void istemci_IRTCEventNotification_Event_Event(RTC_EVENT RTCEvent, object pEvent)
        {
            switch (RTCEvent)
            {
                case RTC_EVENT.RTCE_PROFILE: // istemci.GetProfile() metodu tetikler. profil oluþturuluyor...
                    this.ProfileEvent((IRTCProfileEvent2)pEvent); // Olayý cast et...
                    break;

                case RTC_EVENT.RTCE_REGISTRATION_STATE_CHANGE: // client.EnableProfileEx() metodu tetikler
                    this.RegistrationStateChangeEvent((IRTCRegistrationStateChangeEvent)pEvent);
                    break;

                case RTC_EVENT.RTCE_CLIENT: // client.PrepareForShutdown() metodu tetikler
                    this.ClientEvent((IRTCClientEvent)pEvent);
                    break;

                case RTC_EVENT.RTCE_BUDDY:  // client.EnablePresenceEx() metodu tetikler
                    this.BuddyEvent((IRTCBuddyEvent2)pEvent);
                    break;

                case RTC_EVENT.RTCE_ROAMING: // server da tutulan kiþilerimizin otomatikman alýnmasý
                    break;

                case RTC_EVENT.RTCE_MESSAGING: // arkadaþdan im mesaj geldi..
                    this.MessagingEvent((IRTCMessagingEvent)pEvent);
                    break;

                case RTC_EVENT.RTCE_SESSION_STATE_CHANGE: // oturum açma, media akýþý baþladý, duraklatýldý, bitti vb.
                    this.SessionStateChangeEvent((IRTCSessionStateChangeEvent)pEvent);
                    break;

                case RTC_EVENT.RTCE_MEDIA: // media akýþý baþladý, duraklatýldý, bitti vb.
                    this.MediaEvent((IRTCMediaEvent)pEvent);
                    break;

                case RTC_EVENT.RTCE_PRESENCE_PROPERTY:
                    break;

                case RTC_EVENT.RTCE_PRESENCE_DATA:
                    break;

                case RTC_EVENT.RTCE_PARTICIPANT_STATE_CHANGE:
                    this.ParticipantStateChangeEvent((IRTCParticipantStateChangeEvent)pEvent);
                    break;

                default:
                    break;
            }
        }

        private void ParticipantStateChangeEvent(IRTCParticipantStateChangeEvent participantEvent)
        {
            RTC_PARTICIPANT_STATE katilimciDurumu = participantEvent.State;
            Trace.WriteLine("p");
            switch (katilimciDurumu)
            {
                case RTC_PARTICIPANT_STATE.RTCPS_ALERTING:
                    break;
                case RTC_PARTICIPANT_STATE.RTCPS_ANSWERING:
                    Trace.WriteLine("answering");
                    break;
                case RTC_PARTICIPANT_STATE.RTCPS_CONNECTED:
                    Trace.WriteLine("connected");
                    break;
                case RTC_PARTICIPANT_STATE.RTCPS_DISCONNECTED:
                    break;
                case RTC_PARTICIPANT_STATE.RTCPS_DISCONNECTING:
                    break;
                case RTC_PARTICIPANT_STATE.RTCPS_IDLE:
                    break;
                case RTC_PARTICIPANT_STATE.RTCPS_INCOMING:
                    Trace.WriteLine("incoming");
                    break;
                case RTC_PARTICIPANT_STATE.RTCPS_INPROGRESS:
                    break;
                case RTC_PARTICIPANT_STATE.RTCPS_PENDING:
                    break;
                default:
                    break;
            }
        }

        private void SessionStateChangeEvent(IRTCSessionStateChangeEvent sessionEvent)
        {
            RTC_SESSION_STATE oturumDurumu = sessionEvent.State;
            IRTCCollection oturumKatilimcilari = sessionEvent.Session.Participants;

            string ad = String.Empty;
            string uri = String.Empty;

            // Uzaktan oturum açýlýnca oturumu baþlatmak için kiþinin(katýlýmcý) bilgilerini elde ediyoruz...
            foreach (IRTCParticipant p in oturumKatilimcilari)
            {
                if (p.UserURI != null)
                {
                    ad = p.Name;
                    uri = p.UserURI;
                }
            }

            switch (oturumDurumu)
            {
                case RTC_SESSION_STATE.RTCSS_IDLE: // oturum varsayýlan olarak idle olarak baþlar...
                    Trace.WriteLine("Idle");
                    break;
                case RTC_SESSION_STATE.RTCSS_HOLD: // oturum varsayýlan olarak idle olarak baþlar...
                    Trace.WriteLine("Hold");
                    break;
                case RTC_SESSION_STATE.RTCSS_REFER: // oturum varsayýlan olarak idle olarak baþlar...
                    Trace.WriteLine("Refer");
                    break;

                case RTC_SESSION_STATE.RTCSS_INCOMING: // Uzaktan media oturumu isteði geliyor...
                    Trace.WriteLine("incoming");

                    // Media oturum isteði geldi
                    if ((sessionEvent.Session.Type == RTC_SESSION_TYPE.RTCST_PC_TO_PC))
                    {
                        try
                        {
                            MediaOturumuIstegi(sessionEvent.Session, uri, ad);
                        }
                        catch (COMException hata)
                        {
                            this.anaPencere.MesajGoster(hata.ToString(), "Hata");
                        }
                    }

                    /* IM oturumu MessagingEvent de baþlatýlýyor */

                    break;

                case RTC_SESSION_STATE.RTCSS_ANSWERING:
                    Trace.WriteLine("answer");
                    break;

                case RTC_SESSION_STATE.RTCSS_INPROGRESS:
                    Trace.WriteLine("progress");
                    break;

                case RTC_SESSION_STATE.RTCSS_CONNECTED:
                    Trace.WriteLine("connected");

                    if ((sessionEvent.Session.Type == RTC_SESSION_TYPE.RTCST_MULTIPARTY_IM || sessionEvent.Session.Type == RTC_SESSION_TYPE.RTCST_PC_TO_PC))
                    {
                        try
                        {
                            Oturumlar.Add(sessionEvent.Session);
                            if ((sessionEvent.Session.Type == RTC_SESSION_TYPE.RTCST_PC_TO_PC)) // media oturumu için uyarý göster
                            {
                                ((frmGorusme)htPencereler[mediaKatilimci]).UyariGoster(Sabitler.VIDEOSES_BASLADI);
                            }
                        }
                        catch (Exception hata)
                        {
                            Trace.WriteLine(hata.ToString());
                        }
                    }

                    break;

                case RTC_SESSION_STATE.RTCSS_DISCONNECTED:
                    Trace.WriteLine("disconnected");

                    // oturum nesnesini serbest býrak ki mesaj gönderildiðinde yeniden oturum yaratýlsýn ve pencere oluþturulsun
                    if ((sessionEvent.Session.Type == RTC_SESSION_TYPE.RTCST_MULTIPARTY_IM))
                    {
                        if (Oturumlar.Contains(sessionEvent.Session)) // Ýki taraftan biri oturumu bitirdi.
                        {
                            Oturumlar.Remove(sessionEvent.Session);
                        }
                        else // offline kullancýya mesaj gönderiliyor...
                        {
                            ((frmGorusme)htPencereler[IMKatilimci]).UyariGoster(Sabitler.IM_GONDERILEMEDI);
                        }
                    }

                    if ((sessionEvent.Session.Type == RTC_SESSION_TYPE.RTCST_PC_TO_PC))
                    {
                        if (Oturumlar.Contains(sessionEvent.Session)) // Ýki taraftan biri oturumu bitirdi. 
                        {
                            Oturumlar.Remove(sessionEvent.Session);
                            ((frmGorusme)htPencereler[mediaKatilimci]).UyariGoster(Sabitler.VIDEOSES_SONLANDIRILDI);
                        }
                        else // offline kullanýcýya video görüþmesi gönderiliyor veya kullanýcý görüþmeyi reddetti...
                        {
                            ((frmGorusme)htPencereler[mediaKatilimci]).UyariGoster(Sabitler.VIDEOSES_BASLAYAMADI);
                            ((frmGorusme)htPencereler[mediaKatilimci]).MediaGorusmesiAyarla();
                        }
                    }

                    /* Media oturumu MediaEvent de sonlandýrýlýyor... */
                    break;
            }
        }

        private void MessagingEvent(IRTCMessagingEvent messagingEvent)
        {
            if (messagingEvent.EventType == RTC_MESSAGING_EVENT_TYPE.RTCMSET_MESSAGE)
            {
                Trace.WriteLine("mesaj geldi");
                IRTCSession oturum = messagingEvent.Session;
                IRTCParticipant katilimci = messagingEvent.Participant;
                string mesaj = messagingEvent.Message;

                try
                {
                    IMOturumuBaslat(oturum, katilimci.UserURI, katilimci.Name);
                    istemci.PlayRing(RTC_RING_TYPE.RTCRT_MESSAGE, true); // zil sesi
                    //FlashWindow.FlashWindowEx(((frmGorusme)htPencereler[katilimci.UserURI]).Handle, FlashWindow.FLASHW_ALL); // taskbar blinking
                    ((frmGorusme)htPencereler[katilimci.UserURI]).MesajGoster(mesaj, katilimci.Name); // gelen mesajý formatlayýp göster
                }
                catch (COMException hata)
                {
                    this.anaPencere.MesajGoster(hata.ToString(), "Hata");
                }
            }
        }

        private void MediaEvent(IRTCMediaEvent mediaEvent)
        {
            Trace.WriteLine("media");
            int mediaTuru = 0;
            frmGorusme pencere = null;

            try
            {
                pencere = ((frmGorusme)htPencereler[mediaKatilimci]);
            }
            catch (COMException e)
            {
                Trace.WriteLine("hata: " + e.ToString());
            }

            RTC_MEDIA_EVENT_TYPE olayTuru = mediaEvent.EventType;
            mediaTuru = mediaEvent.MediaType;

            if (olayTuru == RTC_MEDIA_EVENT_TYPE.RTCMET_STARTED)
            {
                Trace.WriteLine("started");
                if (mediaTuru == Sabitler.RTCMT_VIDEO_SEND)
                {
                    Trace.WriteLine("send");
                    gidenMedia.WindowStyle = Sabitler.WS_CHILD | Sabitler.WS_CLIPSIBLINGS;
                    gidenMedia.Owner = pencere.HandlePicGiden.ToInt32();
                    gidenMedia.SetWindowPosition(0, 0, pencere.WidthPicGiden, pencere.HeightPicGiden);
                    gidenMedia.Visible = 1;
                }

                if (mediaTuru == Sabitler.RTCMT_VIDEO_RECEIVE)
                {
                    Trace.WriteLine("receive");
                    try
                    {
                        gelenMedia.WindowStyle = Sabitler.WS_CHILD | Sabitler.WS_CLIPSIBLINGS;
                        gelenMedia.Owner = pencere.HandlePicGelen.ToInt32();
                        gelenMedia.SetWindowPosition(0, 0, pencere.WidthPicGelen, pencere.HeightPicGelen);
                        gelenMedia.Visible = 1;
                    }
                    catch (ArgumentException hata)
                    {
                        Trace.WriteLine("Handle: " + pencere.HandlePicGelen.ToInt32() + "\n");
                        Trace.WriteLine("Boyutlar: " + pencere.WidthPicGelen + "," + pencere.HeightPicGelen + "\n" + hata.ToString());
                    }
                }
            }
            else if (olayTuru == RTC_MEDIA_EVENT_TYPE.RTCMET_STOPPED)
            {
                Trace.WriteLine("stopped");

                if (mediaTuru == Sabitler.RTCMT_VIDEO_RECEIVE)
                {
                    try
                    {
                        Trace.WriteLine("receive");
                        gelenMedia.Visible = 0;
                        gelenMedia.Owner = 0;
                    }
                    catch (COMException ex)
                    {
                        Trace.WriteLine(ex.ToString());
                    }
                }
                else
                {
                    Trace.WriteLine("send");

                    if (pencere.MediaOturumu != null && ((frmGorusme)htPencereler[mediaKatilimci]).VideoGorusmesi)
                    {
                        this.MediaOturumuKapat(mediaKatilimci, pencere.MediaOturumu);
                    }

                    try
                    {
                        gidenMedia.Visible = 0;
                        gidenMedia.Owner = 0;
                    }
                    catch (COMException ex)
                    {
                        Trace.WriteLine(ex.ToString());
                    }
                }
            }
        }

        private void ProfileEvent(IRTCProfileEvent2 profileEvent)
        {
            if (profileEvent.EventType == RTC_PROFILE_EVENT_TYPE.RTCPFET_PROFILE_GET) // getprofile metodu çaðýrýldýðýnda. profil oluþmuþ
            {
                if (Yardim.Basarili(profileEvent.StatusCode)) // profil oluþturulmuþ mu?
                {
                    this.profil = (IRTCProfile2)profileEvent.Profile; // profil nesnesine aktarýlýyor
                    this.profil.AllowedAuth = Sabitler.RTC_DOGRULAMA_SABITLERI; // Sunucu doðrulama istesin
                    this.KayitYap();
                }
                else
                {
                    this.BulunmaDurumuPasif();
                    this.anaPencere.OturumKapandi();
                    this.anaPencere.MesajGoster("Giriþ Baþarýsýz!", "Uyarý");
                }
            }
        }

        private void BuddyEvent(IRTCBuddyEvent2 buddyEvent)
        {
            IRTCBuddy2 kisi = (IRTCBuddy2)buddyEvent.Buddy;

            switch (buddyEvent.EventType)
            {
                case RTC_BUDDY_EVENT_TYPE.RTCBET_BUDDY_ADD:     // Kiþi ekleniyor(xml dosyasýndan okundu)
                    if (Yardim.Basarili(buddyEvent.StatusCode))
                    {
                        this.anaPencere.KisiGuncelle(kisi);
                    }
                    break;

                case RTC_BUDDY_EVENT_TYPE.RTCBET_BUDDY_REMOVE:
                    //This buddy has been successfully removed from the buddy list.
                    this.anaPencere.KisiSil(kisi);
                    break;

                case RTC_BUDDY_EVENT_TYPE.RTCBET_BUDDY_UPDATE:
                    //This buddy's properties have been updated. -- ignore
                    break;

                case RTC_BUDDY_EVENT_TYPE.RTCBET_BUDDY_SUBSCRIBED:
                    //This buddy's presence information is subscribed to -- ignore
                    break;

                case RTC_BUDDY_EVENT_TYPE.RTCBET_BUDDY_STATE_CHANGE:
                    //This buddy's presence state has changed.
                    this.anaPencere.KisiGuncelle(kisi);
                    break;

                default:
                    break;
            }
        }

        private void ClientEvent(IRTCClientEvent clientEvent)
        {
            RTC_CLIENT_EVENT_TYPE olayTuru = clientEvent.EventType;

            if (olayTuru == RTC_CLIENT_EVENT_TYPE.RTCCET_ASYNC_CLEANUP_DONE) // Form kapatýldýðýnda veya PrepareForShutdown metodu tetikler...
            {
                profil = null;

                if (istemci != null)
                {
                    // Artýk olaylarý dinleme... -=
                    istemci.IRTCEventNotification_Event_Event -= new IRTCEventNotification_EventEventHandler(istemci_IRTCEventNotification_Event_Event);
                    istemci.Shutdown();
                    istemci = null;
                }
                this.anaPencere.KapatAnaPencere();
            }
        }

        private void RegistrationStateChangeEvent(IRTCRegistrationStateChangeEvent registerEvent)
        {
            switch (registerEvent.State)
            {
                case RTC_REGISTRATION_STATE.RTCRS_UNREGISTERING:
                    this.anaPencere.OturumKapatiliyor(registerEvent.Profile.UserName);
                    break;

                case RTC_REGISTRATION_STATE.RTCRS_NOT_REGISTERED: // DisablePresence() çaðýrýldý, kiþiler artýk bizi offline görür
                    this.BulunmaDurumuPasif();
                    this.anaPencere.OturumKapandi();
                    break;

                case RTC_REGISTRATION_STATE.RTCRS_REGISTERING:
                    this.anaPencere.OturumAciliyor();
                    break;

                case RTC_REGISTRATION_STATE.RTCRS_REGISTERED:
                    this.anaPencere.OturumAcildi(registerEvent.Profile.UserName);
                    break;

                case RTC_REGISTRATION_STATE.RTCRS_REJECTED:
                case RTC_REGISTRATION_STATE.RTCRS_ERROR:
                    {
                        int durumKodu = registerEvent.StatusCode;

                        // logon baþarýsýz, server yok veya authenticate gerekli
                        if ((durumKodu == Sabitler.RTC_E_STATUS_CLIENT_UNAUTHORIZED) ||
                            (durumKodu == Sabitler.RTC_E_STATUS_CLIENT_PROXY_AUTHENTICATION_REQUIRED) ||
                            (durumKodu == Sabitler.RTC_E_STATUS_CLIENT_FORBIDDEN) ||
                            (durumKodu == Sabitler.RTC_E_STATUS_CLIENT_NOT_FOUND))
                        {
                            // kullanýcýya authentication ekranýný göster...
                            Bilgiler bilgi = this.anaPencere.DogrulamaFormuGoster();

                            if (bilgi != null && bilgi.GecerliMi())
                            {
                                this.DogrulamaYap(bilgi.URI, bilgi.Kimlik, bilgi.Sifre);
                            }
                            else
                            {
                                this.Cikis();
                                this.BulunmaDurumuPasif();
                                this.anaPencere.OturumKapandi();
                                // oturum açýlamadý, kullanýcýyý uyar!
                                if (kayitDurumu == RTC_REGISTRATION_STATE.RTCRS_REGISTERING)
                                {
                                    this.anaPencere.MesajGoster("Giriþ Baþarýsýz!", "Hata");
                                }
                                return;
                            }
                        }
                        else
                        {
                            this.Cikis();
                            this.BulunmaDurumuPasif();
                            this.anaPencere.OturumKapandi();
                            // oturum açýlamadý, kullanýcýyý uyar!
                            if (kayitDurumu == RTC_REGISTRATION_STATE.RTCRS_REGISTERING)
                            {
                                this.anaPencere.MesajGoster("Giriþ Baþarýsýz!", "Hata");
                            }
                            return;
                        }
                    }
                    break;

                case RTC_REGISTRATION_STATE.RTCRS_LOGGED_OFF: // sunucu profil kaydýný sildi.
                    this.Cikis();
                    this.anaPencere.OturumKapatiliyor(registerEvent.Profile.UserName);
                    break;

                case RTC_REGISTRATION_STATE.RTCRS_LOCAL_PA_LOGGED_OFF:
                    break;

                case RTC_REGISTRATION_STATE.RTCRS_REMOTE_PA_LOGGED_OFF:
                    break;

                default:
                    break;
            }

            this.kayitDurumu = registerEvent.State; // Durumu güncelle. Önemli!!!  
        }
        #endregion

        #region IM Oturumu ve Mesaj Gönderme
        public void MesajGonder(string uri, string kisiAdi, string mesaj)
        {
            Trace.WriteLine("mesaj gönder");

            if (Oturumlar.Contains(((frmGorusme)htPencereler[uri]).IMOturumu))
            {
                try
                {
                    ((frmGorusme)htPencereler[uri]).IMOturumu.SendMessage(null, mesaj, 0);
                }
                catch (COMException hata)
                {
                    this.anaPencere.MesajGoster(hata.ToString(), "Hata");
                    ((frmGorusme)htPencereler[uri]).UyariGoster(kisiAdi + " kullanýcýsýna Mesaj gönderilemedi.");
                }
            }
            else
            {
                try
                {
                    ((frmGorusme)htPencereler[uri]).IMOturumu = IMOturumuYarat(uri, kisiAdi);
                    Trace.WriteLine("mesaj gönderiliyor");
                    ((frmGorusme)htPencereler[uri]).IMOturumu.SendMessage(null, mesaj, 0);
                }
                catch (COMException hata)
                {
                    this.anaPencere.MesajGoster(hata.ToString(), "Hata");
                }
            }
        } 
        #endregion

        #region Yardýmcý Metodlar
        public void Giris(Bilgiler bilgi) // motoru çalýþtýran metod...
        {
            if (bilgi == null || !bilgi.GecerliMi())
            {
                this.anaPencere.OturumKapandi();
                return;
            }

            if (profil != null) // Zaten giriþ yapýlmýþ
            {
                return;
            }

            int transferTipi = 0;

            try
            {
                if (bilgi.Transfer != null)
                {
                    if (bilgi.Transfer == "TCP")
                        transferTipi = Sabitler.RTCTR_TCP;
                    else if (bilgi.Transfer == "UDP")
                        transferTipi = Sabitler.RTCTR_UDP;
                    else if (bilgi.Transfer == "TLS")
                        transferTipi = Sabitler.RTCTR_TLS;
                    else
                    {
                        this.anaPencere.OturumKapandi();
                        return;
                    }
                }
            }
            catch (COMException)
            {
                this.anaPencere.OturumKapandi();
            }

            // RTC_EVENT.RTCE_PROFILE olayý tetiklendi...
            try
            {
                istemci.GetProfile(null, null, bilgi.URI, bilgi.Sunucu, transferTipi, 0);
            }
            catch (COMException ex)
            {
                Trace.WriteLine(ex.ToString());
            }
        }

        public void Cikis()
        {
            if (profil == null) // RTC_REGISTRATION_STATE.RTCRS_LOGGED_OFF olayýndan sonra da burasý çalýþýr ve oturum biter
            {
                BulunmaDurumuPasif();
                this.anaPencere.OturumKapandi();
                return;
            }
            // DisablePresence, DisableProfile den sonra çaðrýlmalýdýr...
            istemci.DisableProfile(profil); // RTCRS_UNREGISTERING tetiklenir.
            profil = null;
        }

        public void Kapat()
        {
            if (istemci != null)
            {
                istemci.PrepareForShutdown(); // RTC_EVENT.RTCE_CLIENT olayý tetiklendi
            }
        }

        private void KayitYap()
        {
            BulunmaDurumuAktif();

            istemci.EnableProfileEx(profil, Sabitler.RTCRF_REGISTER_ALL, Sabitler.RTC_ROAMING_FLAGS);
        }

        private void BulunmaDurumuAktif() // EnablePresenceEx ve xml dosyasýndan okuma
        {
            this.anaPencere.KisileriTemizle(); // Yeni kullanýcý giriþ yaptý, aðacý temizle

            if (this.bulunmaDurumu == true) // Kullanýcý aktif
            {
                return;
            }

            // xml dosyasýnýn adýný oluþturuyoruz, SUNUCUDAKÝ bütün bilgilerimiz otomatik olarak(roaming aktif olduðundan) bu dosyada tutulacak
            string uri = Regex.Replace(profil.UserURI, @"\W", "_");
            StringBuilder sb = new StringBuilder();
            sb.Append("rtcclient_").Append(uri).Append(".xml");

            // profil için bulunma durumunu onayla.
            // xml dosyasýndaki buddy ve watcher larý trivew e ekle...
            // RTC_EVENT.RTCE_BUDDY olayý tetiklenir. Profile roaming baþladý...
            this.istemci.EnablePresenceEx(profil, sb.ToString(), 0);

            // presence bilsini set et. get ile alýnýr. opsiyonel...
            string name = "http://schemas.microsoft.com/rtc/rtcpresence";
            string val = "<name> rtcclient </rtcpresence>";
            this.istemci.SetPresenceData(name, val);

            // Daha fazla özellik eklenebilir...
            string aygitAdi = System.Environment.MachineName + " (RTCClient)";
            this.istemci.set_PresenceProperty(RTC_PRESENCE_PROPERTY.RTCPP_DEVICE_NAME, aygitAdi);

            // otmataik olarak izleyicileri ekle.
            this.istemci.OfferWatcherMode = RTC_OFFER_WATCHER_MODE.RTCOWM_AUTOMATICALLY_ADD_WATCHER;
            this.bulunmaDurumu = true;
        }

        private void BulunmaDurumuPasif() // DisablePresence() 
        {
            anaPencere.KisileriTemizle();
            if (bulunmaDurumu == false)
            {
                return;
            }
            istemci.DisablePresence();
            bulunmaDurumu = false;
        }

        public void DogrulamaYap(string uri, string kimlik, string sifre) // SetCredentials(uri, kimlik, sifre)
        {
            this.profil.SetCredentials(uri, kimlik, sifre);
            KayitYap();
        }

        public void GorunumAyarla(RTC_PRESENCE_STATUS gorunumDurumu) // MenuItem lar kullanýr. SetLocalPresenceInfo(gorunumDurumu,null)
        {
            Trace.WriteLine("set local");
            istemci.SetLocalPresenceInfo(gorunumDurumu, null);
        }

        public void KisiEkle(string uri)
        {
            if (uri == null || uri.Length == 0)
                return;
            try
            {
                IRTCBuddy2 kisi = (IRTCBuddy2)istemci.get_Buddy(uri);
                try
                {
                    if (kisi.SubscriptionType == RTC_BUDDY_SUBSCRIPTION_TYPE.RTCBT_SUBSCRIBED)
                    {
                        return; // kullanýcý daha önce zaten eklenmiþ
                    }
                    istemci.RemoveBuddy(kisi); // kullanýcý daha önce eklenmiþ ama kabul etmemiþ olabilir, sil...
                }
                catch (COMException)
                {
                }
            }
            catch (COMException)
            {
            }
            try
            {
                istemci.AddBuddyEx(uri, null, null, true, RTC_BUDDY_SUBSCRIPTION_TYPE.RTCBT_SUBSCRIBED, profil, 0);
            }
            catch (COMException)
            {
            }
        }

        public void KisiSil(IRTCBuddy2 kisi)
        {
            istemci.RemoveBuddy(kisi); // RTC_BUDDY_EVENT_TYPE.RTCBET_BUDDY_REMOVE
        }

        public void AyarSihirbaziGoster(string uri)
        {
            try
            {
                istemci.InvokeTuningWizardEx(((frmGorusme)htPencereler[uri]).Handle.ToInt32(), true, true);
            }
            catch (COMException e)
            {
                MessageBox.Show(e.ToString(), "Hata");
            }
        }
        #endregion

        #region Oturum Açma/Kapatma Metodlarý
        /// <summary>
        /// Ýlk mesaj gönderildiðinde uzak kullanýcý ile IM oturumu yaratýr.
        /// </summary>
        /// <param name="uri">Uzaktaki kullanýcýnýn sip adresi</param>
        /// <param name="ad">Uzaktaki kullanýcýnýn adý</param>
        public IRTCSession IMOturumuYarat(string uri, string ad)
        {
            Trace.WriteLine("creating im session");
            IRTCSession oturum = null;

            IMKatilimci = uri; // oturum YARATILMAZSA kullanýcýnýn penceresine disconnected sinyalinden eriþebilmek için

            try
            {
                oturum = istemci.CreateSession(RTC_SESSION_TYPE.RTCST_MULTIPARTY_IM, null, null, 0);
                oturum.AddParticipant(uri, ad); // RTC_SESSION_STATE.RTCSS_CONNECTED tetiklenir
            }
            catch (COMException)
            {
            }

            return oturum;
        }


        /// <summary>
        /// Uzak kullanýcýdan mesaj geldiðinde IM oturumunu baþlatýr.
        /// </summary>
        /// <param name="oturum">Önceden yaratýlan oturum </param>
        /// <param name="uri">Uzaktaki kullanýcýnýn sip adresi</param>
        /// <param name="ad">Uzaktaki kullanýcýnýn görünen adý</param>
        public void IMOturumuBaslat(IRTCSession oturum, string uri, string ad)
        {
            Trace.WriteLine("starting IM session");

            try
            {
                IMPenceresiOlustur(uri, ad);

                if (((frmGorusme)htPencereler[uri]).IMOturumu == null)
                {
                    ((frmGorusme)htPencereler[uri]).IMOturumu = oturum;
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Uzak kullanýcý ile video/ses oturumu yaratýr.
        /// </summary>
        /// <param name="uri">Uzaktaki kullanýcýnýn sip adresi</param>
        /// <param name="ad">Uzaktaki kullanýcýnýn görünen adý</param>
        public void MediaOturumuYarat(string uri, string ad)
        {
            IRTCSession oturum = null;

            Trace.WriteLine("creating media session");

            mediaKatilimci = uri;
            ((frmGorusme)htPencereler[uri]).MediaGorusmesiAyarla();

            try
            {
                oturum = istemci.CreateSession(RTC_SESSION_TYPE.RTCST_PC_TO_PC, null, null, 0);
                ((frmGorusme)htPencereler[uri]).MediaOturumu = oturum;
                ((frmGorusme)htPencereler[uri]).UyariGoster(ad + Sabitler.VIDEOSES_DAVET_ETTI);
                oturum.AddParticipant(uri, ad);
            }
            catch (COMException exp)  // kiþi video görüþmesinde ise hata!!! Ayrýca RTC'de her istemci sadece bir video görüþmesi yapabilir...
            {
                Trace.WriteLine(exp.ToString());
                ((frmGorusme)htPencereler[uri]).UyariGoster(Sabitler.VIDEOSES_BASLAYAMADI);
                ((frmGorusme)htPencereler[uri]).MediaGorusmesiAyarla();
                ((frmGorusme)htPencereler[uri]).MediaOturumu = null;
                mediaKatilimci = String.Empty;
            }
        }

        /// <summary>
        /// Uzak kullanýcý ile oluþturulan video/ses oturumunu baþlatýr.
        /// </summary>
        /// <param name="oturum">Önceden yaratýlan oturum</param>
        /// <param name="uri">Uzaktaki kullanýcýnýn sip adresi</param>
        public void MediaOturumuIstegi(IRTCSession oturum, string uri, string ad)
        {
            Trace.WriteLine("waiting for answer...");

            MediaPenceresiOlustur(uri, ad, true);
            ((frmGorusme)htPencereler[uri]).MediaOturumu = oturum;
            ((frmGorusme)htPencereler[uri]).UyariGoster(ad + Sabitler.VIDEOSES_DAVET_EDILDI);
        }

        public void MediaOturumuBaslat(IRTCSession oturum, string uri)
        {
            Trace.WriteLine("staring media session");
            try
            {
                ((frmGorusme)htPencereler[uri]).MediaGorusmesiAyarla();
                ((frmGorusme)htPencereler[uri]).MediaOturumu.Answer();
            }
            catch (Exception hata)
            {
                Trace.WriteLine(hata.ToString());
            }
        }

        public void IMOturumuKapat(string uri, IRTCSession oturum)
        {
            Trace.WriteLine("terminating im sesssion");
            oturum.Terminate(RTC_TERMINATE_REASON.RTCTR_SHUTDOWN);
            ((frmGorusme)htPencereler[uri]).IMOturumu = null;
        }

        public void MediaOturumuKapat(string uri, IRTCSession oturum)
        {
            Trace.WriteLine("terminating media session");
            if (oturum.State == RTC_SESSION_STATE.RTCSS_INCOMING)
            {
                oturum.Terminate(RTCCORELib.RTC_TERMINATE_REASON.RTCTR_REJECT); // Gelen çaðrýlarý geri çevir
            }
            else
            {
                oturum.Terminate(RTC_TERMINATE_REASON.RTCTR_NORMAL); //Normal Session Termination
            }

            ((frmGorusme)htPencereler[uri]).MediaGorusmesiAyarla();
            ((frmGorusme)htPencereler[uri]).MediaOturumu = null;
        }
        #endregion

        #region Pencere Oluþturma/Ekleme/Silme Metodlarý
        /// <summary>
        /// IM oturumu için yeni bir görüþme penceresi oluþturur. Pencere oluþturulmuþsa Focuslanýr.
        /// </summary>
        /// <param name="oturum">Önceden yaratýlan oturum </param>
        /// <param name="uri">Uzaktaki kullanýcýnýn sip adresi</param>
        /// <param name="ad">Uzaktaki kullanýcýnýn görünen adý</param>
        public void IMPenceresiOlustur(string uri, string ad)
        {
            Trace.WriteLine("creating and showing IM window, or focusing");
            if (htPencereler.Contains(uri))
            {
                ((frmGorusme)htPencereler[uri]).Focus();
                return;
            }
            else
            {
                frmGorusme gorusmePenceresi = new frmGorusme(this, uri, ad);

                GorusmePenceresiEkle(uri, gorusmePenceresi);

                ((frmGorusme)htPencereler[uri]).Show();
            }
        }

        /// <summary>
        /// IM ve Media oturumu için yeni bir görüþme penceresi oluþturur. Pencere oluþturulmuþsa Focuslanýr.
        /// </summary>
        /// <param name="oturum">Önceden yaratýlan oturum </param>
        /// <param name="uri">Uzaktaki kullanýcýnýn sip adresi</param>
        /// <param name="ad">Uzaktaki kullanýcýnýn görünen adý</param>
        public void MediaPenceresiOlustur(string uri, string ad, bool uzaktanOturum)
        {
            Trace.WriteLine("creating and showing media window, or focusing");
            if (htPencereler.Contains(uri))
            {
                ((frmGorusme)htPencereler[uri]).Focus();
                return;
            }
            else
            {
                frmGorusme gorusmePenceresi = new frmGorusme(this, uri, ad);

                GorusmePenceresiEkle(uri, gorusmePenceresi);

                ((frmGorusme)htPencereler[uri]).Show();

                if (uzaktanOturum == false)
                {
                    try
                    {
                         MediaOturumuYarat(uri, ad);
                    }
                    catch (COMException hata)
                    {
                        this.anaPencere.MesajGoster(hata.ToString(), "Hata");
                    }
                }
            }
        }

        public void GorusmePenceresiEkle(string uri, frmGorusme gorusmePenceresi)
        {
            try
            {
                htPencereler.Add(uri, gorusmePenceresi);
            }
            catch (Exception)
            {
            }
        }

        public void GorusmePenceresiSil(string uri)
        {
            try
            {
                htPencereler.Remove(uri);
            }
            catch (Exception hata)
            {
                Trace.WriteLine(hata.ToString() + ":)");
            }
        }
        #endregion
    }
}
