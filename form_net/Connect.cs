using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace form_net.Connection
{
    public class Connect
    {
        public static SqlConnection con = new SqlConnection($"Data Source=NQUANG;Initial Catalog=english_quiz_app;Integrated Security=True;MultipleActiveResultSets=True");
        public static SqlConnection getSqlConnection()
        {
            return con;
        }
        public static void OpenConnection()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
        }

        public static void CloseConnection()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }

    }
}
