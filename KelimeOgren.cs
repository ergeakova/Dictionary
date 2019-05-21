using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Dictionary
{
    class KelimeOgren
    {
        sqlbaglantisi bagla = new sqlbaglantisi();
        GlobalClass GbClass = new GlobalClass();
        Istatistik istatistik = new Istatistik();
        public Random rand = new Random();
        int ogrenilecekid;
        int seviye;
        public string[] soru = new string[5];
        string dogru;
        string yanlis;
        public string DogruSik;
    


        private void ogrenilecekKelId() {
            SqlCommand komut = new SqlCommand("SELECT TOP 1 Ogrenilecekid FROM Tbl_Ogrenilecek WHERE GosterilecegiTarih=@p1", bagla.baglanti());
            komut.Parameters.AddWithValue("@p1", GbClass.Tarih.ToShortDateString());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read()) {
                ogrenilecekid =Convert.ToInt16(dr[0].ToString());
            }
            

        } //sıradaki sorunun Kelimeler tablosundaki idsini çeker

        public void SoruDizi()
        {

            ogrenilecekKelId();
            

            SqlCommand sorucek = new SqlCommand("SELECT tr,eng FROM Tbl_kelimeler WHERE id=@p1", bagla.baglanti());
            sorucek.Parameters.AddWithValue("@p1",ogrenilecekid.ToString());
            SqlDataReader soruc = sorucek.ExecuteReader();
            while (soruc.Read())
            {
                soru[1] = soruc[0].ToString();
                soru[0] = soruc[1].ToString();

            }
            
            int j = 2;
            SqlCommand cvp2 = new SqlCommand("SELECT top 3 tr FROM Tbl_Kelimeler  WHERE Tbl_Kelimeler.tr!=@p2 ORDER BY NEWID()", bagla.baglanti());
            cvp2.Parameters.AddWithValue("@p2", soru[1].ToString());
            SqlDataReader soruc2 = cvp2.ExecuteReader();
            while (soruc2.Read())
            {
                soru[j] = soruc2[0].ToString();
                j++;
            }

            
        } //sıradaki soruyu ve cevapları soru dizisine atar


        public string DogruCevap()
        {
            SqlCommand komut1 = new SqlCommand("SELECT OgrenmeSeviyesi FROM Tbl_Ogrenilecek WHERE ogrenilecekid=@p1", bagla.baglanti());
            komut1.Parameters.AddWithValue("@p1", ogrenilecekid.ToString());
            SqlDataReader dr = komut1.ExecuteReader();
            while (dr.Read())
            {
                seviye = Convert.ToInt16(dr[0].ToString());
            }

            //seviyeye gore kelimenin  daha sonra ne zaman gosterilecegine bakar

            if (seviye == 0)
            {//7gün

                SqlCommand komut2 = new SqlCommand("UPDATE Tbl_Ogrenilecek SET GosterilecegiTarih=@p1, OgrenmeSeviyesi=@p2 WHERE ogrenilecekid=@p3", bagla.baglanti());
                komut2.Parameters.AddWithValue("@p1", GbClass.Tarih.AddDays(7).ToShortDateString());
                komut2.Parameters.AddWithValue("@p2", '1');
                komut2.Parameters.AddWithValue("@p3", ogrenilecekid.ToString());
                komut2.ExecuteNonQuery();

                dogru = "Doğru Cevap " + soru[0] + " Kelimesinde " + (seviye + 2) + ". seviyeye ulaştınız ";

            }
            if (seviye == 1)
            {//30 gün

                SqlCommand komut2 = new SqlCommand("UPDATE Tbl_Ogrenilecek SET GosterilecegiTarih=@p1, OgrenmeSeviyesi=@p2 WHERE ogrenilecekid=@p3", bagla.baglanti());
                komut2.Parameters.AddWithValue("@p1", GbClass.Tarih.AddDays(30).ToShortDateString());
                komut2.Parameters.AddWithValue("@p2", '2');
                komut2.Parameters.AddWithValue("@p3", ogrenilecekid.ToString());
                komut2.ExecuteNonQuery();
                dogru = "Doğru Cevap " + soru[0] + " Kelimesinde " + (seviye + 2) + ". seviyeye ulaştınız ";

            }
            if (seviye == 2)
            {//6 ay
                SqlCommand komut2 = new SqlCommand("UPDATE Tbl_Ogrenilecek SET GosterilecegiTarih=@p1, OgrenmeSeviyesi=@p2 WHERE ogrenilecekid=@p3", bagla.baglanti());
                komut2.Parameters.AddWithValue("@p1", GbClass.Tarih.AddDays(180).ToShortDateString());
                komut2.Parameters.AddWithValue("@p2", '3');
                komut2.Parameters.AddWithValue("@p3", ogrenilecekid.ToString());
                komut2.ExecuteNonQuery();
                dogru = "Doğru Cevap " + soru[0] + " Kelimesinde " + (seviye + 2) + ". seviyeye ulaştınız ";

            }
            if (seviye == 3)
            {//ogrenildi                
                SqlCommand komut = new SqlCommand("INSERT INTO Tbl_Ogrenilen(Ogrenilenid,Ay,Yil) VALUES(@p1,@p2,@p3)", bagla.baglanti());
                komut.Parameters.AddWithValue("@p1", ogrenilecekid.ToString());
                komut.Parameters.AddWithValue("@p2", GbClass.Tarih.Month.ToString());
                komut.Parameters.AddWithValue("@p3", GbClass.Tarih.Year.ToString());
                komut.ExecuteNonQuery();

                SqlCommand komut2 = new SqlCommand("DELETE FROM Tbl_Ogrenilecek WHERE ogrenilecekid=@p1", bagla.baglanti());
                komut2.Parameters.AddWithValue("@p1", ogrenilecekid.ToString());
                komut2.ExecuteNonQuery();
                bagla.baglanti().Close();
                dogru = "Tebrikler " + soru[0] + " Kelimesi Öğrendiğiniz Kelimeler arasına Eklendi. ";
            }

            istatistik.DogruArttir();

            return dogru;

        } //dogru cevap verildiğinde yapılacak işlemler


        public string YanlisCevap()
        {

             ogrenilecekKelId();

            //kelimenin id ile seviyesini ogrenir

            SqlCommand komut2 = new SqlCommand("UPDATE Tbl_Ogrenilecek SET GosterilecegiTarih=@p1, OgrenmeSeviyesi=@p2 WHERE ogrenilecekid=@p3", bagla.baglanti());
            komut2.Parameters.AddWithValue("@p1", GbClass.Tarih.AddDays(1).ToShortDateString());
            komut2.Parameters.AddWithValue("@p2", '0');
            komut2.Parameters.AddWithValue("@p3", ogrenilecekid.ToString());
            komut2.ExecuteNonQuery();

            istatistik.YanlisArttir();

            yanlis = "yanlıs cevap verdiniz. " + soru[0] + " Kelimesinde 0. seviyeye Döndünüz";

            return yanlis;
        } //Yanlış cevap verildiğinde yapılacak işlemler



    }
}
