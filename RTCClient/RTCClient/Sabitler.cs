using System;
using System.Collections.Generic;
using System.Text;

namespace RTCClient
{
    class Sabitler
    {
        // Flags for CreateSession/AddBuddy
        public const int RTCCS_FORCE_PROFILE = 0x00000001;
        public const int RTCCS_FAIL_ON_REDIRECT = 0x00000002;

        // Transports
        public const int RTCTR_UDP = 0x00000001;
        public const int RTCTR_TCP = 0x00000002;
        public const int RTCTR_TLS = 0x00000004;

        // Media Types
        public const int RTCMT_AUDIO_SEND = 0x1;
        public const int RTCMT_AUDIO_RECEIVE = 0x2;
        public const int RTCMT_VIDEO_SEND = 0x4;
        public const int RTCMT_VIDEO_RECEIVE = 0x8;
        public const int RTCMT_T120_SENDRECV = 0x10;
        public const int RTCMT_ALL_RTP = 0xF;
        public const int RTCMT_ALL = 0x1F;

        // The authentication constants 
        public const int RTCAU_ALL = 0x0001009F;
        public const int RTCAU_BASIC = 0x00000001;
        public const int RTCAU_DIGEST = 0x00000002;
        public const int RTCAU_NTLM = 0x00000004;
        public const int RTCAU_KERBEROS = 0x00000008;
        public const int RTCAU_USE_LOGON_CRED = 0x00010000;

        // Registration Flags
        public const int RTCRF_REGISTER_PRESENCE = 0x00000004;
        public const int RTCRF_REGISTER_NOTIFY = 0x00000008;
        public const int RTCRF_REGISTER_ALL = 0x0000000F;

        // The roaming constants 
        public const int RTCRMF_BUDDY_ROAMING = 0x00000001;
        public const int RTCRMF_WATCHER_ROAMING = 0x00000002;
        public const int RTCRMF_PRESENCE_ROAMING = 0x00000004;
        public const int RTCRMF_PROFILE_ROAMING = 0x00000008;
        public const int RTCRMF_ALL_ROAMING = 0x0000000F;

        // Event filters
        public const int RTCEF_CLIENT = 0x00000001;
        public const int RTCEF_REGISTRATION_STATE_CHANGE = 0x00000002;
        public const int RTCEF_SESSION_STATE_CHANGE = 0x00000004;
        public const int RTCEF_SESSION_OPERATION_COMPLETE = 0x00000008;
        public const int RTCEF_PARTICIPANT_STATE_CHANGE = 0x00000010;
        public const int RTCEF_MESSAGING = 0x00000080;
        public const int RTCEF_BUDDY = 0x00000100;
        public const int RTCEF_WATCHER = 0x00000200;
        public const int RTCEF_PROFILE = 0x00000400;
        public const int RTCEF_INFO = 0x00001000;
        public const int RTCEF_GROUP = 0x00002000;
        public const int RTCEF_MEDIA_REQUEST = 0x00004000;
        public const int RTCEF_ROAMING = 0x00010000;
        public const int RTCEF_PRESENCE_PROPERTY = 0x00020000;
        public const int RTCEF_BUDDY2 = 0x00040000;
        public const int RTCEF_WATCHER2 = 0x00080000;
        public const int RTCEF_PRESENCE_DATA = 0x00800000;
        public const int RTCEF_PRESENCE_STATUS = 0x01000000;
        public const int RTCEF_ALL = 0x01FFFFFF;
        public const int RTCEF_MEDIA = 0x20;

        // Constants related to the IVideoInterface. These are used
        public const int WS_CHILD = 0x40000000;
        public const int WS_CLIPSIBLINGS = 0x4000000;

        // initialization flags 
        public const int RTCIF_ENABLE_SERVER_CLASS = 0x00000010;
        public const int RTCIF_DISABLE_STRICT_DNS = 0x00000020;  //someone@example.com için

        public const int RTC_E_STATUS_CLIENT_UNAUTHORIZED = -2131820143; //0x80EF0191;
        public const int RTC_E_STATUS_CLIENT_PROXY_AUTHENTICATION_REQUIRED = -2131820137; //0x80EF0197;
        public const int RTC_E_STATUS_CLIENT_FORBIDDEN = -2131820141; //0x80EF0193
        public const int RTC_E_STATUS_CLIENT_NOT_FOUND = -2131820140; //0x80EF0194

        public const int RTC_EVENTFILTERS = RTCEF_REGISTRATION_STATE_CHANGE |
                                            RTCEF_CLIENT |
                                            RTCEF_BUDDY |
                                            RTCEF_BUDDY2 | // arakadaþlardaki deðiþiklikleri dinlemeye al...
                                            RTCEF_WATCHER |
                                            RTCEF_WATCHER2 |
                                            RTCEF_ROAMING | // server da kiþilerin tutulmasý, baþka istemci ile de listeye eriþebilme imkaný
                                            RTCEF_PROFILE |
                                            RTCEF_PRESENCE_PROPERTY |
                                            RTCEF_PRESENCE_DATA |
                                            RTCEF_SESSION_STATE_CHANGE |
                                            RTCEF_MESSAGING |
                                            RTCEF_MEDIA;

        public const int RTC_ROAMING_FLAGS = RTCRMF_BUDDY_ROAMING |
                                             RTCRMF_WATCHER_ROAMING |
                                             RTCRMF_PRESENCE_ROAMING |
                                             RTCRMF_PROFILE_ROAMING;

        public const int RTC_MEDIA_SABITLERI =  RTCMT_AUDIO_SEND |
                                                RTCMT_AUDIO_RECEIVE |
                                                RTCMT_VIDEO_SEND |
                                                RTCMT_VIDEO_RECEIVE;

        public const int RTC_DOGRULAMA_SABITLERI =  RTCAU_NTLM |
                                                    RTCAU_KERBEROS |
                                                    RTCAU_USE_LOGON_CRED;

        public const string VIDEOSES_BASLADI = "Video/Ses görüþmesi baþladý.";
        public const string VIDEOSES_BASLAYAMADI = "Video/Ses görüþmesi baþlatýlamadý. Kullanýcý isteði reddetti, çevrimdýþý veya bir baþka video görüþmesinde.";
        public const string VIDEOSES_SONLANDIRILDI = "Video/Ses görüþmesi sonlandýlýrdý.";
        public const string IM_GONDERILEMEDI = "Mesaj gönderilemedi. Kullanýcý çevrimdýþý.";
        public const string VIDEOSES_DAVET_ETTI = " kullanýcýsýný Video/Ses görüþmesine davet ettiniz. Lütfen cevap için bekleyiniz.";
        public const string VIDEOSES_DAVET_EDILDI = " kullanýcýsý sizi Video/Ses görüþmesine davet ediyor. Daveti #" + VIDEOSES_KABULET + "# veya #" + VIDEOSES_REDDET + "# istiyor musunuz?";
        public const string VIDEOSES_KABULET = "kabul et";
        public const string VIDEOSES_REDDET = "reddet";
    }
}
