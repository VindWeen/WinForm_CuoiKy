using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace SQL
{
    internal class SQL
    {
        static SqlConnection con = new SqlConnection();
        public static void KetNoi()
        {
            try
            {
                con.Close();
                con.ConnectionString = @"Data Source = LAPTOP-CM8P1CPP\SQLEXPRESS;
                           Initial Catalog = CoupleTX_SQL;
                           Integrated Security = True;
                           User ID = sa;
                           Password = 02082005";

                con.Open();
            }
            catch
            {
                con.Close();
                throw;
            }
        }
        public static void DongKetNoi()
        {
            con.Close();
        }
        public static DataTable getData(string query)
        {
            KetNoi();
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            adapter.Fill(dt);
            DongKetNoi();
            return dt;
        }
        public static DataSet GetDataSet(string query, int i)
        {
            KetNoi();
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            return ds;
        }
        // > 1 VALUE
        public static SqlDataReader Reader(string query)
        {
            KetNoi();
            SqlCommand truyvan = con.CreateCommand();
            truyvan.CommandText = query;
            return truyvan.ExecuteReader();
        }
        //INSERT, UPDATE, DELETE,
        public static void NonQuery(string query)
        {
            KetNoi();
            SqlCommand truyvan = new SqlCommand(query, con);
            truyvan.CommandType = CommandType.Text;
            truyvan.ExecuteNonQuery();
            DongKetNoi();
        }
        // 1 VALUE
        public static object Scalar(string query)
        {
            KetNoi();
            SqlCommand truyvan = con.CreateCommand();
            truyvan.CommandText = query;
            object a = truyvan.ExecuteScalar();
            DongKetNoi();
            return a;
        }
        public static bool KiemTra(string query)
        {
            KetNoi();
            bool KetQua;
            SqlCommand truyvan = con.CreateCommand();
            truyvan.CommandText = query;
            string kq = (string)truyvan.ExecuteScalar();
            if (kq == "true")
            {
                KetQua = true;
            }
            else
            {
                KetQua = false;
            }
            DongKetNoi();
            return KetQua;
        }
    }
}
