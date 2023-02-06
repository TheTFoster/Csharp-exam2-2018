using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Exam2
{
    public class DatabaseTools
    {
        public static SqlConnection GetConn()
        {
            string sqlConn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Premiere.mdf;Integrated Security=True";
            SqlConnection connect = new SqlConnection(sqlConn);
            return connect;
        }
        public static void DisplayData(DataGridView dGv, string sqlQuery)
        {
            SqlConnection con = DatabaseTools.GetConn();
            con.Open();
            SqlDataAdapter dataADAPT = new SqlDataAdapter(sqlQuery, con);
            DataTable tble = new DataTable();
            dataADAPT.Fill(tble);
            dGv.DataSource = tble;
            con.Close();

        }
        public double Total (double x, double y)
        {
            return (x * y);
        }
    }
}
