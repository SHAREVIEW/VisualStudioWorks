using System;
using System.Collections;
using System.Text;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Diagnostics; // Trace s�n�f�...
using RTCCORELib;

namespace RTCClient
{
    public class Motor
    {
        #region Genel De�i�kenler
        private RTCClientClass istemci;
        private IRTCProfile2 profil;

        private Hashtable htPencereler;
        private ArrayList Oturumlar;

        private RTC_REGISTRATION_STATE kayitDurumu; // Sunucudan gelen cevaplara g�re de�i�ir
        private bool bulunmaDurumu;

        private AnaPencere anaPencere;

        private IVideoWindow gelenMedia = null;
        private IVideoWindow gidenMedia = null;

        string mediaKatilimci = String.Empty; // MediaEvent fonksiyonunda pencerenin Handle'�n� elde etmek i�in SessionStateChangeEvent'ten al�yoruz
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
            this.bulunmaDurumu = false; // bulunma durumu(�evrimi�i,me�gul vs.) ayarlanmad�
            this.kayitDurumu = RTC_REGISTRATION_STATE.RTCRS_NOT_REGISTERED; // Hen�z kay�t olmad�k
            htPencereler = new Hashtable(); // uri key leri ile pencereler takip edilir
            Oturumlar = new ArrayList(); // a��lan oturumlarla(sessionEvent.Sessison) oturumlar takip edilir
            try
            {
                istemci = new RTCClientClass();
                istemci.Initialize();
                istemci.EventFilter = Sabitler.RTC_EVENTFILTERS;
                istemci.ListenForIncomingSessions = RTC_LISTEN_MODE.RTCLM_BOTH; // Gelen mesajlar� dinle, SIP portunu a�ar(5060)
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

        #region �stemci Olaylar�
        private void istemci_IRTCEventNotification_Event_Event(RTC_EVENT RTCEvent, object pEvent)
        {
            switch (RTCEvent)
            {
                case RTC_EVENT.RTCE_PROFILE: // istemci.GetProfile() metodu tetikler. profil olu�turuluyor...
                    this.ProfileEvent((IRTCProfileEvent2)pEvent); // Olay� cast et...
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

                case RTC_EVENT.RTCE_ROAMING: // server da tutulan ki�ilerimizin otomatikman al�nmas�
                    break;

                case RTC_EVENT.RTCE_MESSAGING: // arkada�dan im mesaj geldi..
                    this.MessagingEvent((IRTCMessagingEvent)pEvent);
                    break;

                case RTC_EVENT.RTCE_SESSION_STATE_CHANGE: // oturum a�ma, media ak��� ba�lad�, duraklat�ld�, bitti vb.
                    this.SessionStateChangeEvent((IRTCSessionStateChangeEvent)pEvent);
                    break;

                case RTC_EVENT.RTCE_MEDIA: // media ak��� ba�lad�, duraklat�ld�, bitti vb.
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

            // Uzaktan oturum a��l�nca oturumu ba�latmak i�in ki�inin(kat�l�mc�) bilgilerini elde ediyoruz...
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
                case RTC_SESSION_STATE.RTCSS_IDLE: // oturum varsay�lan olarak idle olarak ba�lar...
                    Trace.WriteLine("Idle");
                    break;
                case RTC_SESSION_STATE.RTCSS_HOLD: // oturum varsay�lan olarak idle olarak ba�lar...
                    Trace.WriteLine("Hold");
                    break;
                case RTC_SESSION_STATE.RTCSS_REFER: // oturum varsay�lan olarak idle olarak ba�lar...
                    Trace.WriteLine("Refer");
                    break;

                case RTC_SESSION_STATE.RTCSS_INCOMING: // Uzaktan media oturumu iste�i geliyor...
                    Trace.WriteLine("incoming");

                    // Media oturum iste�i geldi
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

                    /* IM oturumu MessagingEvent de ba�lat�l�yor */

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
                            if ((sessionEvent.Session.Type == RTC_SESSION_TYPE.RTCST_PC_TO_PC)) // media oturumu i�in uyar� g�ster
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

                    // oturum nesnesini serbest b�rak ki mesaj g�nderildi�inde yeniden oturum yarat�ls�n ve pencere olu�turulsun
                    if ((sessionEvent.Session.Type == RTC_SESSION_TYPE.RTCST_MULTIPARTY_IM))
                    {
                        if (Oturumlar.Contains(sessionEvent.Session)) // �ki taraftan biri oturumu bitirdi.
                        {
                            Oturumlar.Remove(sessionEvent.Session);
                        }
                        else // offline kullanc�ya mesaj g�nderiliyor...
                        {
                            ((frmGorusme)htPencereler[IMKatilimci]).UyariGoster(Sabitler.IM_GONDERILEMEDI);
                        }
                    }

                    if ((sessionEvent.Session.Type == RTC_SESSION_TYPE.RTCST_PC_TO_PC))
                    {
                        if (Oturumlar.Contains(sessionEvent.Session)) // �ki taraftan biri oturumu bitirdi. 
                        {
                            Oturumlar.Remove(sessionEvent.Session);
                            ((frmGorusme)htPencereler[mediaKatilimci]).UyariGoster(Sabitler.VIDEOSES_SONLANDIRILDI);
                        }
                        else // offline kullan�c�ya video g�r��mesi g�nderiliyor veya kullan�c� g�r��meyi reddetti...
                        {
                            ((frmGorusme)htPencereler[mediaKatilimci]).UyariGoster(Sabitler.VIDEOSES_BASLAYAMADI);
                            ((frmGorusme)htPencereler[mediaKatilimci]).MediaGorusmesiAyarla();
                        }
                    }

                    /* Media oturumu MediaEvent de sonland�r�l�yor... */
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
                    ((frmGorusme)htPencereler[katilimci.UserURI]).MesajGoster(mesaj, katilimci.Name); // gelen mesaj� formatlay�p g�ster
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
            if (profileEvent.EventType == RTC_PROFILE_EVENT_TYPE.RTCPFET_PROFILE_GET) // getprofile metodu �a��r�ld���nda. profil olu�mu�
            {
                if (Yardim.Basarili(profileEvent.StatusCode)) // profil olu�turulmu� mu?
                {
                    this.profil = (IRTCProfile2)profileEvent.Profile; // profil nesnesine aktar�l�yor
                    this.profil.AllowedAuth = Sabitler.RTC_DOGRULAMA_SABITLERI; // Sunucu do�rulama istesin
                    this.KayitYap();
                }
                else
                {
                    this.BulunmaDurumuPasif();
                    this.anaPencere.OturumKapandi();
                    this.anaPencere.MesajGoster("Giri� Ba�ar�s�z!", "Uyar�");
                }
            }
        }

        private void BuddyEvent(IRTCBuddyEvent2 buddyEvent)
        {
            IRTCBuddy2 kisi = (IRTCBuddy2)buddyEvent.Buddy;

            switch (buddyEvent.EventType)
            {
                case RTC_BUDDY_EVENT_TYPE.RTCBET_BUDDY_ADD:     // Ki�i ekleniyor(xml dosyas�ndan okundu)
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

            if (olayTuru == RTC_CLIENT_EVENT_TYPE.RTCCET_ASYNC_CLEANUP_DONE) // Form kapat�ld���nda veya PrepareForShutdown metodu tetikler...
            {
                profil = null;

                if (istemci != null)
                {
                    // Art�k olaylar� dinleme... -=
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

                case RTC_REGISTRATION_STATE.RTCRS_NOT_REGISTERED: // DisablePresence() �a��r�ld�, ki�iler art�k bizi offline g�r�r
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

                        // logon ba�ar�s�z, server yok veya authenticate gerekli
                        if ((durumKodu == Sabitler.RTC_E_STATUS_CLIENT_UNAUTHORIZED) ||
                            (durumKodu == Sabitler.RTC_E_STATUS_CLIENT_PROXY_AUTHENTICATION_REQUIRED) ||
                            (durumKodu == Sabitler.RTC_E_STATUS_CLIENT_FORBIDDEN) ||
                            (durumKodu == Sabitler.RTC_E_STATUS_CLIENT_NOT_FOUND))
                        {
                            // kullan�c�ya authentication ekran�n� g�ster...
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
                                // oturum a��lamad�, kullan�c�y� uyar!
                                if (kayitDurumu == RTC_REGISTRATION_STATE.RTCRS_REGISTERING)
                                {
                                    this.anaPencere.MesajGoster("Giri� Ba�ar�s�z!", "Hata");
                                }
                                return;
                            }
                        }
                        else
                        {
                            this.Cikis();
                            this.BulunmaDurumuPasif();
                            this.anaPencere.OturumKapandi();
                            // oturum a��lamad�, kullan�c�y� uyar!
                            if (kayitDurumu == RTC_REGISTRATION_STATE.RTCRS_REGISTERING)
                            {
                                this.anaPencere.MesajGoster("Giri� Ba�ar�s�z!", "Hata");
                            }
                            return;
                        }
                    }
                    break;

                case RTC_REGISTRATION_STATE.RTCRS_LOGGED_OFF: // sunucu profil kayd�n� sildi.
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

            this.kayitDurumu = registerEvent.State; // Durumu g�ncelle. �nemli!!!  
        }
        #endregion

        #region IM Oturumu ve Mesaj G�nderme
        public void MesajGonder(string uri, string kisiAdi, string mesaj)
        {
            Trace.WriteLine("mesaj g�nder");

            if (Oturumlar.Contains(((frmGorusme)htPencereler[uri]).IMOturumu))
            {
                try
                {
                    ((frmGorusme)htPencereler[uri]).IMOturumu.SendMessage(null, mesaj, 0);
                }
                catch (COMException hata)
                {
                    this.anaPencere.MesajGoster(hata.ToString(), "Hata");
                    ((frmGorusme)htPencereler[uri]).UyariGoster(kisiAdi + " kullan�c�s�na Mesaj g�nderilemedi.");
                }
            }
            else
            {
                try
                {
                    ((frmGorusme)htPencereler[uri]).IMOturumu = IMOturumuYarat(uri, kisiAdi);
                    Trace.WriteLine("mesaj g�nderiliyor");
                    ((frmGorusme)htPencereler[uri]).IMOturumu.SendMessage(null, mesaj, 0);
                }
                catch (COMException hata)
                {
                    this.anaPencere.MesajGoster(hata.ToString(), "Hata");
                }
            }
        } 
        #endregion

        #region Yard�mc� Metodlar
        public void Giris(Bilgiler bilgi) // motoru �al��t�ran metod...
        {
            if (bilgi == null || !bilgi.GecerliMi())
            {
                this.anaPencere.OturumKapandi();
                return;
            }

            if (profil != null) // Zaten giri� yap�lm��
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

            // RTC_EVENT.RTCE_PROFILE olay� tetiklendi...
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
            if (profil == null) // RTC_REGISTRATION_STATE.RTCRS_LOGGED_OFF olay�ndan sonra da buras� �al���r ve oturum biter
            {
                BulunmaDurumuPasif();
                this.anaPencere.OturumKapandi();
                return;
            }
            // DisablePresence, DisableProfile den sonra �a�r�lmal�d�r...
            istemci.DisableProfile(profil); // RTCRS_UNREGISTERING tetiklenir.
            profil = null;
        }

        public void Kapat()
        {
            if (istemci != null)
            {
                istemci.PrepareForShutdown(); // RTC_EVENT.RTCE_CLIENT olay� tetiklendi
            }
        }

        private void KayitYap()
        {
            BulunmaDurumuAktif();

            istemci.EnableProfileEx(profil, Sabitler.RTCRF_REGISTER_ALL, Sabitler.RTC_ROAMING_FLAGS);
        }

        private void BulunmaDurumuAktif() // EnablePresenceEx ve xml dosyas�ndan okuma
        {
            this.anaPencere.KisileriTemizle(); // Yeni kullan�c� giri� yapt�, a�ac� temizle

            if (this.bulunmaDurumu == true) // Kullan�c� aktif
            {
                return;
            }

            // xml dosyas�n�n ad�n� olu�turuyoruz, SUNUCUDAK� b�t�n bilgilerimiz otomatik olarak(roaming aktif oldu�undan) bu dosyada tutulacak
            string uri = Regex.Replace(profil.UserURI, @"\W", "_");
            StringBuilder sb = new StringBuilder();
            sb.Append("rtcclient_").Append(uri).Append(".xml");

            // profil i�in bulunma durumunu onayla.
            // xml dosyas�ndaki buddy ve watcher lar� trivew e ekle...
            // RTC_EVENT.RTCE_BUDDY olay� tetiklenir. Profile roaming ba�lad�...
            this.istemci.EnablePresenceEx(profil, sb.ToString(), 0);

            // presence bilsini set et. get ile al�n�r. opsiyonel...
            string name = "http://schemas.microsoft.com/rtc/rtcpresence";
            string val = "<name> rtcclient </rtcpresence>";
            this.istemci.SetPresenceData(name, val);

            // Daha fazla �zellik eklenebilir...
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

        public void GorunumAyarla(RTC_PRESENCE_STATUS gorunumDurumu) // MenuItem lar kullan�r. SetLocalPresenceInfo(gorunumDurumu,null)
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
                        return; // kullan�c� daha �nce zaten eklenmi�
                    }
                    istemci.RemoveBuddy(kisi); // kullan�c� daha �nce eklenmi� ama kabul etmemi� olabilir, sil...
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

        #region Oturum A�ma/Kapatma Metodlar�
        /// <summary>
        /// �lk mesaj g�nderildi�inde uzak kullan�c� ile IM oturumu yarat�r.
        /// </summary>
        /// <param name="uri">Uzaktaki kullan�c�n�n sip adresi</param>
        /// <param name="ad">Uzaktaki kullan�c�n�n ad�</param>
        public IRTCSession IMOturumuYarat(string uri, string ad)
        {
            Trace.WriteLine("creating im session");
            IRTCSession oturum = null;

            IMKatilimci = uri; // oturum YARATILMAZSA kullan�c�n�n penceresine disconnected sinyalinden eri�ebilmek i�in

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
        /// Uzak kullan�c�dan mesaj geldi�inde IM oturumunu ba�lat�r.
        /// </summary>
        /// <param name="oturum">�nceden yarat�lan oturum </param>
        /// <param name="uri">Uzaktaki kullan�c�n�n sip adresi</param>
        /// <param name="ad">Uzaktaki kullan�c�n�n g�r�nen ad�</param>
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
        /// Uzak kullan�c� ile video/ses oturumu yarat�r.
        /// </summary>
        /// <param name="uri">Uzaktaki kullan�c�n�n sip adresi</param>
        /// <param name="ad">Uzaktaki kullan�c�n�n g�r�nen ad�</param>
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
            catch (COMException exp)  // ki�i video g�r��mesinde ise hata!!! Ayr�ca RTC'de her istemci sadece bir video g�r��mesi yapabilir...
            {
                Trace.WriteLine(exp.ToString());
                ((frmGorusme)htPencereler[uri]).UyariGoster(Sabitler.VIDEOSES_BASLAYAMADI);
                ((frmGorusme)htPencereler[uri]).MediaGorusmesiAyarla();
                ((frmGorusme)htPencereler[uri]).MediaOturumu = null;
                mediaKatilimci = String.Empty;
            }
        }

        /// <summary>
        /// Uzak kullan�c� ile olu�turulan video/ses oturumunu ba�lat�r.
        /// </summary>
        /// <param name="oturum">�nceden yarat�lan oturum</param>
        /// <param name="uri">Uzaktaki kullan�c�n�n sip adresi</param>
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
                oturum.Terminate(RTCCORELib.RTC_TERMINATE_REASON.RTCTR_REJECT); // Gelen �a�r�lar� geri �evir
            }
            else
            {
                oturum.Terminate(RTC_TERMINATE_REASON.RTCTR_NORMAL); //Normal Session Termination
            }

            ((frmGorusme)htPencereler[uri]).MediaGorusmesiAyarla();
            ((frmGorusme)htPencereler[uri]).MediaOturumu = null;
        }
        #endregion

        #region Pencere Olu�turma/Ekleme/Silme Metodlar�
        /// <summary>
        /// IM oturumu i�in yeni bir g�r��me penceresi olu�turur. Pencere olu�turulmu�sa Focuslan�r.
        /// </summary>
        /// <param name="oturum">�nceden yarat�lan oturum </param>
        /// <param name="uri">Uzaktaki kullan�c�n�n sip adresi</param>
        /// <param name="ad">Uzaktaki kullan�c�n�n g�r�nen ad�</param>
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
        /// IM ve Media oturumu i�in yeni bir g�r��me penceresi olu�turur. Pencere olu�turulmu�sa Focuslan�r.
        /// </summary>
        /// <param name="oturum">�nceden yarat�lan oturum </param>
        /// <param name="uri">Uzaktaki kullan�c�n�n sip adresi</param>
        /// <param name="ad">Uzaktaki kullan�c�n�n g�r�nen ad�</param>
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
