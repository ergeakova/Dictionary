using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Dictionary
{
    class Sozluk
    {
        sqlbaglantisi bagla = new sqlbaglantisi();
        GlobalClass GbClass = new GlobalClass();
        public string[] sozlukVeri = new string[3];
        string ogrenilmeDurumu;

        public void Cevir(string kelime)
        {
            SqlCommand komut = new SqlCommand("SELECT tr,eng,turu FROM Tbl_Kelimeler WHERE eng=@p1", bagla.baglanti());
            komut.Parameters.AddWithValue("@p1", kelime.ToString());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                sozlukVeri[0] = dr[0].ToString();
                sozlukVeri[1] = dr[1].ToString();
                sozlukVeri[2] = dr[2].ToString();
            }
        }// TxtAranan'a yazılan kelimenin turkce ingilizce ve turunu ceviri dizisine atar.

        
        public Boolean OgrenimSorgu()
        {

            

            SqlCommand komut = new SqlCommand("SELECT ogrenilme FROM Tbl_kelimeler WHERE id=@p1", bagla.baglanti());
            komut.Parameters.AddWithValue("@p1", GbClass.IdOkuTr(sozlukVeri[0]));
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {

                ogrenilmeDurumu = dr[0].ToString();
            }

            if (ogrenilmeDurumu =="False")
            {
                return false;
            }
            else {

                return true;
            }

            ;
        }


        public void OgrenileceklereEkle()
        {

            //ogrenilecekler Tablosuna Ekler
            SqlCommand komut = new SqlCommand("INSERT INTO Tbl_Ogrenilecek(ogrenilecekid,GosterilecegiTarih,OgrenmeSeviyesi) VALUES(@p1,@p2,@p3)", bagla.baglanti());
            komut.Parameters.AddWithValue("@p1", GbClass.IdOkuTr(sozlukVeri[0]).ToString());
            komut.Parameters.AddWithValue("@p2", GbClass.Tarih.AddDays(1).ToShortDateString());
            komut.Parameters.AddWithValue("@p3", "0");
            komut.ExecuteNonQuery();

            //Eklenen Kelimenin Kelimeler Tablosundaki Ogrenilme Değerini Günceller
            SqlCommand komut2 = new SqlCommand("UPDATE Tbl_kelimeler SET ogrenilme=@p2 WHERE Tr=@p1", bagla.baglanti());
            komut2.Parameters.AddWithValue("@p1", sozlukVeri[0]);
            komut2.Parameters.AddWithValue("@p2", true);
            komut2.ExecuteNonQuery();


        }///cevirilen Kelimeyi ogrenilecekler tablosuna ekler ve kelimeler tablosundan ogrenilme sütununu günceller

    }
}
