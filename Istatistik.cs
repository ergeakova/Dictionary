using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Dictionary
{
    class Istatistik
    {
        sqlbaglantisi bagla = new sqlbaglantisi();
        int istatistik;
        int i = 0;
        public int OgrenilenYillık;
        public int ogrenilenAylik;
        public string secilenAy;
        public string SecilenYil;
        public string[] Genelis = new string[5];
        public string[] yillaris = new string[5];


        public void genelistatistik()
        {

            //kelime sayisi
            SqlCommand komut = new SqlCommand("SELECT count(*) FROM Tbl_Kelimeler", bagla.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                istatistik = Convert.ToInt16(dr[0].ToString());
            }

            SqlCommand komut2 = new SqlCommand("UPDATE Tbl_Genelis SET KelimeSayisi=@p1 WHERE id=@p2", bagla.baglanti());
            komut2.Parameters.AddWithValue("@p1", istatistik.ToString());
            komut2.Parameters.AddWithValue("@p2", '1');
            komut2.ExecuteNonQuery();

           

            //ogrenilmis Kelime sayisi

            SqlCommand komut3 = new SqlCommand("SELECT COUNT(*) FROM Tbl_ogrenilen", bagla.baglanti());
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                istatistik = Convert.ToInt16(dr3[0].ToString());
            }

            SqlCommand komut4 = new SqlCommand("UPDATE Tbl_Genelis SET ogrenilmisKelime=@p1 WHERE id=@p2", bagla.baglanti());
            komut4.Parameters.AddWithValue("@p1", istatistik.ToString());
            komut4.Parameters.AddWithValue("@p2", '1');
            komut4.ExecuteNonQuery();

            istatistik = 0;

            ///ogrenimekte olan Kelime sayisi

            SqlCommand komut5 = new SqlCommand("SELECT COUNT(*) FROM Tbl_ogrenilecek", bagla.baglanti());
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                istatistik = Convert.ToInt16(dr5[0].ToString());
            }

            SqlCommand komut6 = new SqlCommand("UPDATE Tbl_Genelis SET ogrenilenKelime=@p1 WHERE id=@p2", bagla.baglanti());
            komut6.Parameters.AddWithValue("@p1", istatistik.ToString());
            komut6.Parameters.AddWithValue("@p2", '1');
            komut6.ExecuteNonQuery();

            istatistik = 0;

            SqlCommand komut7 = new SqlCommand("SELECT KelimeSayisi,ogrenilmisKelime,ogrenilenKelime,Dogru,Yanlis FROM Tbl_Genelis", bagla.baglanti());
            SqlDataReader dr7 = komut7.ExecuteReader();
            while (dr7.Read())
            {

                Genelis[0] = dr7[0].ToString();
                Genelis[1] = dr7[1].ToString();
                Genelis[2] = dr7[2].ToString();
                Genelis[3] = dr7[3].ToString();
                Genelis[4] = dr7[4].ToString();

            }
        }

        public void DogruArttir() {
            

            SqlCommand komut3 = new SqlCommand("SELECT Dogru FROM Tbl_Genelis WHERE id=@p1", bagla.baglanti());
            komut3.Parameters.AddWithValue("@p1", '1');
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                istatistik = Convert.ToInt16(dr3[0].ToString());
            }

            SqlCommand komut4 = new SqlCommand("UPDATE Tbl_Genelis SET dogru=@p1 WHERE id=@p2", bagla.baglanti());
            komut4.Parameters.AddWithValue("@p1", (istatistik + 1).ToString());
            komut4.Parameters.AddWithValue("@p2", '1');
            komut4.ExecuteNonQuery();
           



        } //genel istatistiklerin tutulduğu tablodaki dogru sayısını arttırır

        public void YanlisArttir()
        {

            //genel istatistik Yanlıs sayısını arttırır

            SqlCommand komut3 = new SqlCommand("SELECT Yanlis FROM Tbl_Genelis WHERE id=@p1", bagla.baglanti());
            komut3.Parameters.AddWithValue("@p1", '1');
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                istatistik = Convert.ToInt16(dr3[0].ToString());
            }

            SqlCommand komut4 = new SqlCommand("UPDATE Tbl_Genelis SET Yanlis=@p1 WHERE id=@p2", bagla.baglanti());
            komut4.Parameters.AddWithValue("@p1", (istatistik + 1).ToString());
            komut4.Parameters.AddWithValue("@p2", '1');
            komut4.ExecuteNonQuery();

        } //genel istatistiklerin tutulduğu tablodaki Yanlış sayısını arttırır

        public void Yillar() {

            SqlCommand komut = new SqlCommand("SELECT DISTINCT yil FROM Tbl_Ogrenilen", bagla.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read()) {
                
                yillaris[i] = dr[0].ToString();
                i++;
            }
        }//cmb yıl İçin Tbl_Ogrenilendeki mevcut yılları bulur ve yillaris Değişkenine Atar 

        public void YillikIstatistik() {


            SqlCommand komut = new SqlCommand("SELECT COUNT(*) FROM Tbl_ogrenilen WHERE yil=@p1", bagla.baglanti());
            komut.Parameters.AddWithValue("@p1", SecilenYil);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                OgrenilenYillık = Convert.ToInt16(dr[0].ToString());
            }



        }

        public void AylikIstatistik() {

            SqlCommand komut = new SqlCommand("SELECT COUNT(*) FROM Tbl_Ogrenilen WHERE Ay=@p1 AND Yil=@p2", bagla.baglanti());
            komut.Parameters.AddWithValue("@p1", secilenAy.ToString());
            komut.Parameters.AddWithValue("@p2", SecilenYil.ToString());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read()) {
                ogrenilenAylik = Convert.ToInt16(dr[0].ToString());
            }

        }

       



    }
}
