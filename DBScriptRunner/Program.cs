using System;
using System.Data.SqlClient;
using System.IO;

namespace DBScriptRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the SQL file
            string scriptPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "HustleMindDB.sql");

            // Read SQL script
            string sqlScript = File.ReadAllText(scriptPath);

            // Connection string (change to your server name if needed)
            string connectionString = "Server=localhost\\SQLEXPRESS;Integrated Security=true;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(sqlScript, conn);
                    command.ExecuteNonQuery();
                    Console.WriteLine("✅ Database created successfully!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Error: " + ex.Message);
            }
        }
    }
}
