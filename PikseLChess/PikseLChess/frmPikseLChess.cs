using System;
using System.Windows.Forms;
using System.IO;

namespace PikseLChess
{
    public partial class frmPikseLChess : Form
    {
        oyunMotoru motor;
        IntPtr handleLView;

        public frmPikseLChess()
        {
            InitializeComponent();
            // Undo ve Redo buton ve menülerinin otomatik olarak deðiþmesi için idle tanýmlýyoruz
            Application.Idle += new EventHandler(undoRedo); // undoRedo metodunu dinlemeye al...
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tbUndo.Enabled = false;
            tbRedo.Enabled = false;
            tbKaydet.Enabled = false;
            mnuKaydet.Enabled = false;

            dlgOpen.DefaultExt = "pcs";
            dlgSave.DefaultExt = "pcs";
            dlgOpen.Filter = "PikseLChess (*.pcs)|*.pcs";
            dlgSave.Filter = "PikseLChess (*.pcs)|*.pcs";

            handleLView = lvLog.Handle; // ListView'e diðer sýnýflardan eriþebilmek için handle numarsýný al.
            Tas.oyunKlasoru = Directory.GetCurrentDirectory(); // Uygulamanýn bulunuðu dizini kaydet.
        }

        private void tbYeni_Click(object sender, EventArgs e)
        {
            YeniOyunHazirla();
            motor.YeniOyun();
        }

        private void YeniOyunHazirla()
        {
            oyunAlani.TaslarGizle(picOyunAlani.CreateGraphics());

            motor = new oyunMotoru(handleLView, picOyunAlani.CreateGraphics());

            UndoRedo.undoNoktalar.Clear(); // Undo ve Redo yýðýnlarýný temizle
            UndoRedo.undoTaslar.Clear();
            UndoRedo.redoNoktalar.Clear();
            UndoRedo.redoTaslar.Clear();

            lvLog.Items.Clear(); // ListView i temizle
            tbKaydet.Enabled = true;
            mnuKaydet.Enabled = true;
        }

        private void tbUndo_Click(object sender, EventArgs e)
        {
             UndoRedo.Undo(motor);
        }

        private void tbRedo_Click(object sender, EventArgs e)
        {
             UndoRedo.Redo(motor);
        }

        private void undoRedo(object sender, EventArgs e)
        {
            // Idle'nin dinlediði metod...
            // Stack leri dinliyoruz ve butonlarýn durumlarýný belirliyoruz...
            if (UndoRedo.undoNoktalar.Count > 0)
            {
                tbUndo.Enabled = true;
                mnuUndo.Enabled = true;
            }
            else
            {
                tbUndo.Enabled = false;
                mnuUndo.Enabled = false;
            }

            if (UndoRedo.redoNoktalar.Count > 0)
            {
                tbRedo.Enabled = true;
                mnuRedo.Enabled = true;
            }
            else
            {
                tbRedo.Enabled = false;
                mnuRedo.Enabled = false;
            }
        }

        private void picOyunAlani_MouseDown(object sender, MouseEventArgs e)
        {
            int kareBoyu = 50;
            int mouseX, mouseY;

            if (motor != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    mouseX = e.X / kareBoyu;
                    mouseY = e.Y / kareBoyu;

                    motor.Play(mouseX, mouseY);
                }
            }
        }

        private void picOyunAlani_Paint(object sender, PaintEventArgs e)
        {
            // Oyun simge durumuna alýndýðýnda, önüne bir pencere geldiðinde, vb. taþlarýn tekrar çizilmesi için
            if (motor != null)
            {
                oyunAlani.TaslarGoster(motor.satrancTaslari, e.Graphics);
            }
        }

        private void tbKaydet_Click(object sender, EventArgs e)
        {
            String dosyaYolu;

            dlgSave.ShowDialog();
            dosyaYolu = dlgSave.FileName;

            if (dosyaYolu != "")
            {
                SaveLoad.Save(motor, dosyaYolu);
            }
        }

        private void tbAc_Click(object sender, EventArgs e)
        {
            String dosyaYolu;

            dlgOpen.ShowDialog();
            dosyaYolu = dlgOpen.FileName;

            if (File.Exists(dosyaYolu))
            {
                YeniOyunHazirla();
                SaveLoad.Load(motor, dosyaYolu);
            }
        }

        private void mnuCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuHakkinda_Click(object sender, EventArgs e)
        {
            Hakkinda hakkinda = new Hakkinda();
            hakkinda.ShowDialog();
        }
    }
}