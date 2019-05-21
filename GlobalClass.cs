using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Dictionary
{
    class GlobalClass
    {

        int sorusayisi;
        public DateTime Tarih = DateTime.Now.Date;
        sqlbaglantisi bagla = new sqlbaglantisi();
        
        public int id;

        public int IdOkuTr(string kelime)
        {

            SqlCommand komut = new SqlCommand("SELECT id FROM Tbl_Kelimeler WHERE tr=@p1", bagla.baglanti());
            komut.Parameters.AddWithValue("@p1",kelime);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                id = Convert.ToInt16(dr[0]);
            }
            return id;
        }// idArama değişkenindeki Türkçe kelimenin idsini verir

        public int IdOkuIng(string kelime)
        {

            SqlCommand komut = new SqlCommand("SELECT id FROM Tbl_Kelimeler WHERE eng=@p1", bagla.baglanti());
            komut.Parameters.AddWithValue("@p1", kelime);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                id = Convert.ToInt16(dr[0]);
            }
            return id;
        }// idArama değişkenindeki İngilizce kelimenin idsini verir

        public int SoruSay()
        {
           
            SqlCommand sorusay = new SqlCommand("SELECT COUNT(*) FROM Tbl_ogrenilecek WHERE GosterilecegiTarih=@p1", bagla.baglanti());
            sorusay.Parameters.AddWithValue("@p1", Tarih.ToShortDateString());
            sorusayisi = Convert.ToInt16(sorusay.ExecuteScalar());

            return sorusayisi;

        }
    }
}
