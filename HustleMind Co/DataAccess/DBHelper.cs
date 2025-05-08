using Microsoft.Data.SqlClient;
using System.Data;

namespace HustleMind_Co.DB
{
    public class DBHelper
    {
        private static string connectionString = "Server=DESKTOP-2VPR9IB\\SQLEXPRESS;Database=HustleMindDB;TrustServerCertificate=True;Integrated Security=True;";

        public static DataTable ExecuteQuery(string query)
        {
            return ExecuteQuery(query, null);
        }

        public static DataTable ExecuteQuery(string query, SqlParameter[] parameters)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        public static int ExecuteNonQuery(string query, SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddRange(parameters);
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
