using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using RTCCORELib;

namespace RTCClient
{
    public partial class AnaPencere : Form
    {
        // Bu sýnýftaki gui lerle etkileþimin ardýndan Motor sýnýfýnda gerçekleþen iþlemler sonucunda
        // yine bu sýnýftaki bazý metodlar çaðýrýlarark arayüz'de bazý deðiþiklikler yapýlýr

        // AnaPencere (Etkileþim) -> Motor (bir istemci fonksiyonu çaðýrýlýr) -> Motor (çaðrýlan fonkiyon bir olayý tetikler) ->...
        // ... -> AnaPencere (Olay sonucunda gui de deðiþiklik yapýlýr)

        private Motor motor; // API iþlemlerinin yapýldýðý sýnýf
        private Hashtable htKisiler; // Kiþilerin eklendiði koleksiyon (kisi -> dugum)

        private System.Windows.Forms.ToolStripMenuItem mnuGecerliDurumum;
        private System.Windows.Forms.ToolStripMenuItem cmnuGecerliDurumum;

        private bool programiSonlandir=false;

        public AnaPencere()
        {
            InitializeComponent();
        }

        private void AnaPencere_Load(object sender, EventArgs e)
        {
            MenuAyarla();
            TreeViewHazirla();
            htKisiler = new Hashtable();
            motor = new Motor(this); // Ýstemci nesnesi oluþturulur ve olaylarý dinlemeye alýnýr
        }

        #region Giriþ ve Doðrulama Formlarý
        private Bilgiler GirisGoster()
        {
            frmGiris giris = new frmGiris();

            if (giris.ShowDialog() == DialogResult.OK)
            {
                Bilgiler bilgi = new Bilgiler();
                bilgi.URI = giris.URI;
                bilgi.Sunucu = giris.Sunucu;
                bilgi.Transfer = giris.Transfer;
                return bilgi;
            }
            return null;
        }

        public Bilgiler DogrulamaFormuGoster()
        {
            frmDogrulama dogrulama = new frmDogrulama();

            if (dogrulama.ShowDialog() == DialogResult.OK)
            {
                Bilgiler bilgi = new Bilgiler();
                bilgi.URI = dogrulama.URI;
                bilgi.Kimlik = dogrulama.Kimlik;
                bilgi.Sifre = dogrulama.Sifre;
                return bilgi;
            }
            return null;
        }
        #endregion

        #region Oturum Bilgilendirme Metodlarý
        public void OturumKapatiliyor(string ad)
        {
            this.lblDurum.Text = ad + " için oturum kapatýlýyor";
            mnuOturumAc.Enabled = true;
            cmnuOturumAc.Enabled = true;

            mnuOturumKapat.Enabled = false;
            cmnuOturumKapat.Enabled = false;

            mnuDurumum.Enabled = false;
            cmnuDurumum.Enabled = false;

            mnuKisiEkle.Enabled = false;
        }

        public void OturumKapandi()
        {
            this.lblDurum.Text = "Çevrimdýþý";
            mnuOturumAc.Enabled = true;
            cmnuOturumAc.Enabled = true;

            mnuOturumKapat.Enabled = false;
            cmnuOturumKapat.Enabled = false;

            mnuDurumum.Enabled = false;
            cmnuDurumum.Enabled = false;

            mnuKisiEkle.Enabled = false;
        }

        public void OturumAciliyor()
        {
            this.lblDurum.Text = "Oturum açýlýyor";
            mnuOturumAc.Enabled = false;
            cmnuOturumAc.Enabled = false;

            mnuOturumKapat.Enabled = true;
            cmnuOturumKapat.Enabled = true;

            mnuDurumum.Enabled = false;
            cmnuDurumum.Enabled = false;

            mnuKisiEkle.Enabled = false;
        }

        public void OturumAcildi(string ad)
        {
            this.lblDurum.Text = ad + " için oturum açýldý";
            mnuOturumAc.Enabled = false;
            cmnuOturumAc.Enabled = false;

            mnuOturumKapat.Enabled = true;
            cmnuOturumKapat.Enabled = true;

            mnuDurumum.Enabled = true;
            cmnuDurumum.Enabled = true;

            mnuKisiEkle.Enabled = true;

            Log.istemciURI = motor.istemciURI; // Oturum açýldý. log sýnýfýný hazýrla...
        }
        #endregion

        #region Kiþi Metodlarý
        public void KisileriTemizle()
        {
            htKisiler = null;
            htKisiler = new Hashtable();

            tvKisiler.CollapseAll();
            tvKisiler.Nodes[0].Nodes.Clear();
            tvKisiler.Nodes[1].Nodes.Clear();
        }

        public void KisiGuncelle(IRTCBuddy2 kisi)
        {
            if (kisi.PresentityURI == motor.istemciURI)
            {
                return;
            }

            if (htKisiler.ContainsKey(kisi)) // kiþi zaten listede var, sil...
            {
                ((TreeNode)htKisiler[kisi]).Remove();
                htKisiler.Remove(kisi);
            }

            string gorunenIsim = Yardim.KisiAdiOlustur(kisi);
            if (gorunenIsim == null || gorunenIsim.Length == 0)
            {
                return;
            }

            Dugum dugumKisi = new Dugum(gorunenIsim, kisi, Yardim.ImgIndex); // Yeni düðüm. "ugur (Çevrimiçi)" ve buddy nesnesi eklendi
            if (kisi.Status == RTC_PRESENCE_STATUS.RTCXS_PRESENCE_OFFLINE)
            {
                tvKisiler.Nodes[1].Nodes.Add(dugumKisi);
                tvKisiler.Nodes[1].Expand();
            }
            else
            {
                tvKisiler.Nodes[0].Nodes.Add(dugumKisi);
                tvKisiler.Nodes[0].Expand();
            }
            htKisiler.Add(kisi, dugumKisi); // htKisiler silme iþlemlerinde cast yoluyla kullanýlacak
            tvKisiler.Refresh();
        }

        public void KisiSil(IRTCBuddy2 kisi)
        {
            if (htKisiler.ContainsKey(kisi))
            {
                ((TreeNode)htKisiler[kisi]).Remove();
                htKisiler.Remove(kisi);
            }
        }
        #endregion

        #region Menüler
        private void MenuAyarla()
        {
            this.mnuGecerliDurumum = this.mnuCevrimici;
            this.cmnuGecerliDurumum = this.cmnuCevrimici;

            this.mnuGecerliDurumum.Checked = true;
            this.cmnuGecerliDurumum.Checked = true;

            mnuOturumKapat.Enabled = false;
            cmnuOturumKapat.Enabled = false;
            mnuDurumum.Enabled = false;
            cmnuDurumum.Enabled = false;
            mnuKisiEkle.Enabled = false;
        }

        private void mnuOturumAc_Click(object sender, EventArgs e)
        {
            Bilgiler bilgi = this.GirisGoster();
            motor.Giris(bilgi);
        }

        private void mnuOturumKapat_Click(object sender, EventArgs e)
        {
            motor.Cikis();
        }

        public void mnuCevrimici_Click(object sender, EventArgs e)
        {
            motor.GorunumAyarla(RTC_PRESENCE_STATUS.RTCXS_PRESENCE_ONLINE);
            mnuGecerliDurumum.Checked = false;
            cmnuGecerliDurumum.Checked = false;
            mnuGecerliDurumum = mnuCevrimici;
            cmnuGecerliDurumum = cmnuCevrimici;
            mnuGecerliDurumum.Checked = true;
            cmnuGecerliDurumum.Checked = true;
        }

        private void mnuMesgul_Click(object sender, EventArgs e)
        {
            motor.GorunumAyarla(RTC_PRESENCE_STATUS.RTCXS_PRESENCE_BUSY);
            mnuGecerliDurumum.Checked = false;
            cmnuGecerliDurumum.Checked = false;
            mnuGecerliDurumum = mnuMesgul;
            cmnuGecerliDurumum = cmnuMesgul;
            mnuGecerliDurumum.Checked = true;
            cmnuGecerliDurumum.Checked = true;
        }

        private void mnuDonecek_Click(object sender, EventArgs e)
        {
            motor.GorunumAyarla(RTC_PRESENCE_STATUS.RTCXS_PRESENCE_BE_RIGHT_BACK);
            mnuGecerliDurumum.Checked = false;
            cmnuGecerliDurumum.Checked = false;
            mnuGecerliDurumum = mnuDonecek;
            cmnuGecerliDurumum = cmnuDonecek;
            mnuGecerliDurumum.Checked = true;
            cmnuGecerliDurumum.Checked = true;
        }

        private void mnuDisarida_Click(object sender, EventArgs e)
        {
            motor.GorunumAyarla(RTC_PRESENCE_STATUS.RTCXS_PRESENCE_AWAY);
            mnuGecerliDurumum.Checked = false;
            cmnuGecerliDurumum.Checked = false;
            mnuGecerliDurumum = mnuDisarida;
            cmnuGecerliDurumum = cmnuDisarida;
            mnuGecerliDurumum.Checked = true;
            cmnuGecerliDurumum.Checked = true;
        }

        private void mnuTelefonda_Click(object sender, EventArgs e)
        {
            motor.GorunumAyarla(RTC_PRESENCE_STATUS.RTCXS_PRESENCE_ON_THE_PHONE);
            mnuGecerliDurumum.Checked = false;
            cmnuGecerliDurumum.Checked = false;
            mnuGecerliDurumum = mnuTelefonda;
            cmnuGecerliDurumum = cmnuTelefonda;
            mnuGecerliDurumum.Checked = true;
            cmnuGecerliDurumum.Checked = true;
        }

        private void mnuYemekte_Click(object sender, EventArgs e)
        {
            motor.GorunumAyarla(RTC_PRESENCE_STATUS.RTCXS_PRESENCE_OUT_TO_LUNCH);
            mnuGecerliDurumum.Checked = false;
            cmnuGecerliDurumum.Checked = false;
            mnuGecerliDurumum = mnuYemekte;
            cmnuGecerliDurumum = cmnuYemekte;
            mnuGecerliDurumum.Checked = true;
            cmnuGecerliDurumum.Checked = true;
        }

        private void mnuCevrimdisi_Click(object sender, EventArgs e)
        {
            motor.GorunumAyarla(RTC_PRESENCE_STATUS.RTCXS_PRESENCE_OFFLINE);
            mnuGecerliDurumum.Checked = false;
            cmnuGecerliDurumum.Checked = false;
            mnuGecerliDurumum = mnuCevrimdisi;
            cmnuGecerliDurumum = cmnuCevrimdisi;
            mnuGecerliDurumum.Checked = true;
            cmnuGecerliDurumum.Checked = true;
        }

        private void mnuKapat_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void mnuKisiEkle_Click(object sender, EventArgs e)
        {
            string kisiURI = null;

            frmKisiEkle dlgEkle = new frmKisiEkle();
            if (dlgEkle.ShowDialog() == DialogResult.OK)
            {
                kisiURI = dlgEkle.URI;
                motor.KisiEkle(kisiURI);
            }
        }
        #endregion

        #region TreeView ContextMenu Metodlarý
        private void cmnuMesajGonder_Click(object sender, EventArgs e)
        {
            Dugum kisiBilgi = (Dugum)(tvKisiler.SelectedNode);
            IRTCBuddy2 kisi = (IRTCBuddy2)kisiBilgi.Kisi;

            if (kisi!=null && htKisiler.Contains(kisi))
            {
                motor.IMPenceresiOlustur(kisi.PresentityURI,Yardim.KisiAdiAl(kisi));
            }
        }

        private void cmnuKisiSil_Click(object sender, EventArgs e)
        {
            Dugum kisiBilgi = (Dugum)(tvKisiler.SelectedNode);
            IRTCBuddy2 kisi = (IRTCBuddy2)kisiBilgi.Kisi;

            if (kisi!=null && htKisiler.ContainsKey(kisi))
            {
                motor.KisiSil(kisi);
            }
        }

        private void mnuOzellikler_Click(object sender, EventArgs e)
        {
            Dugum kisiBilgi = (Dugum)(tvKisiler.SelectedNode);
            IRTCBuddy2 kisi = (IRTCBuddy2)kisiBilgi.Kisi;

            if (kisi != null && htKisiler.ContainsKey(kisi))
            {
                this.MesajGoster(Yardim.KisiOzellikeri(kisi), Yardim.KisiAdiAl(kisi) + " Özellikleri");
            }
        }

        private void cmnuVideoSes_Click(object sender, EventArgs e)
        {
            Dugum kisiBilgi = (Dugum)(tvKisiler.SelectedNode);
            IRTCBuddy2 kisi = (IRTCBuddy2)kisiBilgi.Kisi;

            if (kisi != null && htKisiler.Contains(kisi))
            {
                motor.MediaPenceresiOlustur(kisi.PresentityURI, Yardim.KisiAdiAl(kisi),false);
            }
        }
        #endregion

        #region Form Metodlarý
        private void AnaPencere_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Açýk olan görüþme pencerelerini kapat...

            if (programiSonlandir) // sadece cmnuCikis'a týklandýðýnda...
            {
                motor.Kapat();
            }
            else
            {
                this.WindowState = FormWindowState.Minimized;
                e.Cancel = true;
            }
        }

        public void MesajGoster(string yazi, string baslik)
        {
            MessageBox.Show(yazi, baslik,MessageBoxButtons.OK,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1,MessageBoxOptions.DefaultDesktopOnly);
        }

        public void KapatAnaPencere()
        {
            Application.Exit();
        }

        private void AnaPencere_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
                this.Hide();
        }

        #endregion

        #region NotifyIcon Metodlarý
        // Diðer menülerin olaylarý design kýsmýnda MainMenu'ye baðlandý...
        private void cmnuCikis_Click(object sender, EventArgs e)
        {
            programiSonlandir = true;
            this.Close();
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            WindowState = FormWindowState.Normal;
        }
        #endregion

        #region TreeView Metodlarý
        private void TreeViewHazirla()
        {
            Dugum dugumCevrimici = new Dugum("Çevrimiçi", null, 0);
            Dugum dugumCevrimdisi = new Dugum("Çevrimdýþý", null, 0);
            tvKisiler.Nodes.Add(dugumCevrimici);
            tvKisiler.Nodes.Add(dugumCevrimdisi);

            tvKisiler.DrawMode = TreeViewDrawMode.OwnerDrawAll;
            tvKisiler.DrawNode += new DrawTreeNodeEventHandler(tvKisiler_DrawNode);
        }

        private void tvKisiler_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                RootDugumResimAyarla(e.Node);
            }
        }

        private void RootDugumResimAyarla(TreeNode dugum)
        {
            if (dugum == tvKisiler.Nodes[0])
            {
                if (dugum.IsExpanded)
                {
                    dugum.Collapse();
                    dugum.ImageIndex = 0;
                }
                else
                {
                    dugum.Expand();
                    dugum.ImageIndex = 8;
                }
            }
            else if (dugum == tvKisiler.Nodes[1])
            {
                if (dugum.IsExpanded)
                {
                    dugum.Collapse();
                    dugum.ImageIndex = 0;
                }
                else
                {
                    dugum.Expand();
                    dugum.ImageIndex = 8;
                }
            }
        }

        void tvKisiler_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            Dugum dugum = (Dugum)e.Node;
            Graphics g = e.Graphics;

            if (e.Node.IsSelected)
            {
                g.FillRectangle(Brushes.DeepSkyBlue, e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
            }

            try
            {
                g.DrawImage(imgResimler.Images[dugum.ImageIndex], e.Bounds.X, e.Bounds.Y);
                g.DrawString(dugum.Text, tvKisiler.Font, new SolidBrush(Color.Black), e.Bounds.X + imgResimler.ImageSize.Width, e.Bounds.Y + 3);
            }
            catch (Exception hata)
            {
                Trace.WriteLine(hata.Message.ToString());
            }
        }

        private void tvKisiler_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            Dugum kisiBilgi = (Dugum)(e.Node);
            IRTCBuddy2 kisi = (IRTCBuddy2)kisiBilgi.Kisi;

            if (kisi != null && htKisiler.Contains(kisi))
            {
                motor.IMPenceresiOlustur(kisi.PresentityURI, Yardim.KisiAdiAl(kisi));
            }
        }

        private void tvKisiler_AfterExpand(object sender, TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.Expand)
            {
                e.Node.ImageIndex = 8;
            }
        }

        private void tvKisiler_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Action == TreeViewAction.Collapse)
            {
                e.Node.ImageIndex = 0;
            }
        }
        #endregion 
    }
}