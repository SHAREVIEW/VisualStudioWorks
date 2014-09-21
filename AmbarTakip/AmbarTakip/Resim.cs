using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace AmbarTakip
{
    class Resim
    {
        private String resimAdi = null;
        private String malzemeAdi = null;

        private ResimGoster form = null;

        private AmbarTakipDataSet1 dsMalzeme;

        public Resim(DataRow satir, AmbarTakipDataSet1 dataSet)
        {
            try
            {
                dsMalzeme = dataSet;
                resimAdi = ResimAl(satir["YTNO"].ToString());
                malzemeAdi = MalzemeAdiAl(satir["YTNO"].ToString());

                if (resimAdi != null)
                {
                    try
                    {
                        form = new ResimGoster(resimAdi, malzemeAdi);
                        form.Show();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
                Console.WriteLine(malzemeAdi + ", " + resimAdi);
            }
            catch (Exception ex2)
            {
                Console.WriteLine(ex2.ToString());
            }
        }

        private String ResimAl(String yt)
        {
            foreach (DataRow satir in dsMalzeme.CPS.Rows)
            {
                if (satir["YTNO"].ToString() == yt)
                {
                    return satir["RESIM"].ToString();
                }
            }
            return null;
        }

        private String MalzemeAdiAl(String yt)
        {
            foreach (DataRow satir in dsMalzeme.CPS.Rows)
            {
                if (satir["YTNO"].ToString() == yt)
                {
                    return satir["MALZEMEADI"].ToString();
                }
            }
            return null;
        }
    }
}
