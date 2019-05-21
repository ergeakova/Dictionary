using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Dictionary
{
    class KelimeEkle
    {
        sqlbaglantisi bagla = new sqlbaglantisi();
        public string[] kelime = new string[3];
        public void KelimeEK()
        {

            SqlCommand komut = new SqlCommand("INSERT INTO Tbl_Kelimeler (tr,eng,turu,ogrenilme) VALUES(@p1,@p2,@p3,@p4)", bagla.baglanti());
            komut.Parameters.AddWithValue("@p1", kelime[0]);
            komut.Parameters.AddWithValue("@p2", kelime[1]);
            komut.Parameters.AddWithValue("@p3", kelime[2]);
            komut.Parameters.AddWithValue("@p4", false);
            komut.ExecuteNonQuery();
        } //gecici Değişkenine aktarılan değerleri veri tabanına ekler.
    }
}
