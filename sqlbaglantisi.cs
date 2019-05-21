using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Dictionary
{
    class sqlbaglantisi
    {
        public SqlConnection baglanti() {
            SqlConnection baglan= new SqlConnection("Data Source=DESKTOP-ERGE\\SQLEXPRESS;Initial Catalog=Dictionary;Integrated Security=True");
            baglan.Open();
            return baglan;
        }

      
    }
}
