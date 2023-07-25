using System.Data;
using System.Data.SqlClient;

namespace Company.Helpers
{
    public static class SQLHelper
    {
		private const string _connectionStr = "Server=SHALALA\\SADB;Database=Company;Trusted_Connection=true";

        public static async Task<DataTable> SelectAsync(string query)
        {
            using(SqlConnection conn = new SqlConnection(_connectionStr))
            {
                await conn.OpenAsync();
                using(SqlDataAdapter sda = new SqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    return dt;
                }
            }
        } 
        public static async Task<int> ExecuteAsync(string command)
        {
            using(SqlConnection conn = new SqlConnection(_connectionStr))
            {
                await conn.OpenAsync();
                using(SqlCommand com = new SqlCommand(command, conn))
                {
                    return await com.ExecuteNonQueryAsync();
                }
            }
        }


    }
}
