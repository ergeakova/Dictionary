using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.XtraCharts;
using Microsoft.Win32;

namespace Dictionary
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
        }
        GlobalClass GbClass = new GlobalClass();
        Sozluk Sozluk = new Sozluk();
        KelimeEkle KelimeEkle = new KelimeEkle();
        KelimeOgren KelimeOgren = new KelimeOgren();
        Istatistik istatistik = new Istatistik();
        int i;

        void Temizle() {
            TxtAranan.Text = "";
            Txtingilizce.Text = "";
            TxtTurkce.Text = "";
            CmbTuru.Text = "";
        }///sözlük sayfasını temizleyen method.

        public void SiklariAc()
        {

            BtnA.Visible = true;
            BtnB.Visible = true;
            BtnC.Visible = true;
            BtnD.Visible = true;

        } //şıkları visible özelliğini true yapar

        public void SiklariKapat()
        {

            BtnA.Visible = false;
            BtnB.Visible = false;
            BtnC.Visible = false;
            BtnD.Visible = false;

        } //şıkların visible özelliğini false yapar

        public void SikEnableOn() {
            BtnA.Enabled = true;
            BtnB.Enabled = true;
            BtnC.Enabled = true;
            BtnD.Enabled = true;
            Btn_Basla.Enabled = false;
        } //şıkların enamle özelliğini true yapar

        public void SikEnableOff()
        {
            BtnA.Enabled = false;
            BtnB.Enabled = false;
            BtnC.Enabled = false;
            BtnD.Enabled = false;
            Btn_Basla.Enabled = true;
        } //şıkların enamle özelliğini False yapar

        public void GenelisGoster()
        {
            istatistik.genelistatistik();
            
            for (int i = 0; i < 12; i++)
            {
                chartControl2.Series["Yanlış"].Points.AddPoint("Yanlış Sayısı", Convert.ToInt16(istatistik.Genelis[4]));
                chartControl2.Series["Doğru"].Points.AddPoint("Doğru Sayısı", Convert.ToInt16(istatistik.Genelis[3]));
                chartControl2.Series["Öğrenilen Kelime Sayısı"].Points.AddPoint("Öğrenilen Kelime Sayısı", Convert.ToInt16(istatistik.Genelis[2]));
                chartControl2.Series["Öğrenilmis Kelime Sayısı"].Points.AddPoint("Öğrenilmiş Kelime Sayısı", Convert.ToInt16(istatistik.Genelis[1]));
                chartControl2.Series["Kelime Sayısı"].Points.AddPoint("kelimesayısı",Convert.ToInt16( istatistik.Genelis[0]));

                LblOgrenilenKelimeSayisi.Text = istatistik.Genelis[1].ToString();
              
                LblDogruYanlisOran.Text ="% "+( (Convert.ToInt16(istatistik.Genelis[3])*100)    / (Convert.ToInt16(istatistik.Genelis[3]) + Convert.ToInt16(istatistik.Genelis[4])   )).ToString();
                
            }
        }//genel istatistikleri gosterir

        public void CmbYilItem() {
            i = 0;
            istatistik.Yillar();
            while (istatistik.yillaris[i] != null) {
                CmbYil_Aylik.Items.Add(istatistik.yillaris[i].ToString());
                CmbYil_Yillik.Items.Add(istatistik.yillaris[i].ToString());
                i++;
            }
        } //CmbYil İtemlerini Doldurur

        public void aylikis() {

            if (CmbAy_Aylik.Text != "" && CmbYil_Aylik.Text != "")
            {
                ChartAylik.Visible = true;
                istatistik.secilenAy = CmbAy_Aylik.Text;
                istatistik.SecilenYil = CmbYil_Aylik.Text;
                istatistik.AylikIstatistik();

                ChartAylik.Series["Aylik"].Points.AddPoint(CmbAy_Aylik.Text+"-"+CmbYil_Aylik.Text, istatistik.ogrenilenAylik);

                LblAylikis.Text = CmbYil_Aylik.Text+"Yılının " + CmbAy_Aylik.Text + ". Ayında Öğrendiğiniz Kelime Sayısı:";
                LblAylikisSay.Text = Convert.ToString(istatistik.ogrenilenAylik);

            }
        }//aylik  istatistik sayfasına veri gönderir

        public void soruyu_goster()
        {
            SiklariAc();
            LblSoru.Text = KelimeOgren.soru[0];

                int j = KelimeOgren.rand.Next(1, 4);
                if (j == 1)
                {
                    BtnA.Text = KelimeOgren.soru[1];
                    BtnB.Text = KelimeOgren.soru[2];
                    BtnC.Text = KelimeOgren.soru[3];
                    BtnD.Text = KelimeOgren.soru[4];
                    KelimeOgren.DogruSik = "a";

                }
                if (j == 2)
                {
                    BtnA.Text = KelimeOgren.soru[2];
                    BtnB.Text = KelimeOgren.soru[1];
                    BtnC.Text = KelimeOgren.soru[3];
                    BtnD.Text = KelimeOgren.soru[4];
                    KelimeOgren.DogruSik = "b";

            }
                if (j == 3)
                {
                    BtnA.Text = KelimeOgren.soru[3];
                    BtnB.Text = KelimeOgren.soru[2];
                    BtnC.Text = KelimeOgren.soru[1];
                    BtnD.Text = KelimeOgren.soru[4];
                    KelimeOgren.DogruSik = "c";

            }
                if (j == 4)
                {
                    BtnA.Text = KelimeOgren.soru[4];
                    BtnB.Text = KelimeOgren.soru[2];
                    BtnC.Text = KelimeOgren.soru[3];
                    BtnD.Text = KelimeOgren.soru[1];
                    KelimeOgren.DogruSik = "d";


                }

            if (GbClass.SoruSay() == 1)
            {
                Btn_Basla.Text = "Testi Bitir";
            }
            else
            {
                Btn_Basla.Text = "Sonraki Soru";
            }

            SikEnableOn();
        }  //soruyu gosteren method

        ///--------------------------------------------------------------------------------------------------------------------------------------
        private void Form1_Load(object sender, EventArgs e)
        {

            string ProgramAdi = "Dictionary";
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
            key.SetValue(ProgramAdi, "\"" + Application.ExecutablePath + "\"");

            CmbYilItem();
            
            if (GbClass.SoruSay() != 0)
            {
                LblSoru.Text = "Bugün ki Sorularınıza Başlamak için Başla Butonuna Basınız.";
            }
            else
            {
                Btn_Basla.Visible = false;
                LblSoru.Text = "bugün sorunuz Yok";
            }

        }

        private void BtnCevir_Click(object sender, EventArgs e)
        {
            Sozluk.Cevir(TxtAranan.Text);
            LblTurkce.Text = Sozluk.sozlukVeri[0];
            Lblingilizce.Text = Sozluk.sozlukVeri[1];
            LblTur.Text = Sozluk.sozlukVeri[2];
        }//Kelime Çeviren Buton

        private void OgrenileceklereEkle_Click(object sender, EventArgs e)
        {
            
            if (Sozluk.OgrenimSorgu().ToString() == "False")
            {
                Sozluk.OgrenileceklereEkle();
                MessageBox.Show("Kelime Başarılı Bir Şekilde Eklendi.");
            }
            else {
                MessageBox.Show("Kelime Eklenemedi! Zaten Ögrenilmekte Veya Öğrenilmiş");
            }
        }//cevirisi yapılan kelimeyi oğrenileceklere aktarır ve ogrenme srecini başlatır.

        private void BtnEkle_Click (object sender, EventArgs e)
        {
            KelimeEkle.kelime[0] = TxtTurkce.Text;
            KelimeEkle.kelime[1] = Txtingilizce.Text;
            KelimeEkle.kelime[2] = CmbTuru.Text;
            KelimeEkle.KelimeEK();
            Temizle();
            MessageBox.Show(KelimeEkle.kelime[1] + " Kelimesi Başarılı Bir Şekilde Sözlüğünüze Eklendi.");
        }//Sözlüğe Kelime Ekleyen Buton

        private void Btn_Basla_Click(object sender, EventArgs e)
        {
            if (GbClass.SoruSay() != 0)
            {
                KelimeOgren.SoruDizi();
                soruyu_goster();
               
            }
            else {
                SiklariKapat();
                LblSoru.Text = "Bugün sorunuz Kalmadı";
                Btn_Basla.Visible = false;
            }
        }

        private void BtnA_Click(object sender, EventArgs e)
        {
            SikEnableOff();

            if (KelimeOgren.DogruSik == "a")
            {
                MessageBox.Show(KelimeOgren.DogruCevap());            
            }
            else
            {         
                MessageBox.Show(KelimeOgren.YanlisCevap());
            }
        }

        private void BtnB_Click(object sender, EventArgs e)
        {
            SikEnableOff();

            if (KelimeOgren.DogruSik == "b")
            {
                MessageBox.Show(KelimeOgren.DogruCevap());             
            }
            else
            {
                MessageBox.Show(KelimeOgren.YanlisCevap());
            }
        }

        private void BtnC_Click(object sender, EventArgs e)
        {
            SikEnableOff();

            if (KelimeOgren.DogruSik == "c")
            {
                MessageBox.Show(KelimeOgren.DogruCevap());
            }
            else
            {
                MessageBox.Show(KelimeOgren.YanlisCevap());
            }
        }
        private void BtnD_Click(object sender, EventArgs e)
        {
            SikEnableOff();

            if (KelimeOgren.DogruSik == "d")
            {
                MessageBox.Show(KelimeOgren.DogruCevap());   
            }
            else
            {
                MessageBox.Show(KelimeOgren.YanlisCevap());
            }
        }

        private void BtnTab_Click(object sender, EventArgs e)
        {
         GenelisGoster();
        }

        private void CmbYil_Yillik_SelectedIndexChanged(object sender, EventArgs e)
        {
            chartYillik.Visible = true;
            istatistik.SecilenYil = CmbYil_Yillik.Text;
            istatistik.YillikIstatistik();
            LblYillikis.Text =CmbYil_Yillik.Text+"Yılın'da Öğrendiğiniz Kelime Sayısı:";
            LblYillikisSay.Text = istatistik.OgrenilenYillık.ToString();
            chartYillik.Series["YILI"].Points.AddPoint(CmbYil_Yillik.Text, istatistik.OgrenilenYillık);

        }

        private void CmbAy_SelectedIndexChanged(object sender, EventArgs e)
        {
            aylikis();
        }

        private void CmbYil_Aylik_SelectedIndexChanged(object sender, EventArgs e)
        {
            aylikis();
        }
    }
}

