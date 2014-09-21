using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace RTCClient
{
    class Dugum : System.Windows.Forms.TreeNode
    {
        private object kisi; // Buddy nesnesi aktarýlacak

        public object Kisi
        {
            get { return this.kisi; }
        }

        public Dugum(string yazi, object kisi, int imgIndex) : base(yazi)
        {
            this.kisi = kisi;
            this.ImageIndex = imgIndex;
            this.SelectedImageIndex = imgIndex;
        }
    }
}
