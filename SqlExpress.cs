using System;
using System.Data.SqlClient;

　
namespace SqlExpress
{
    public class Db
    {
        private string connectionString = "";

　
        public Db(string connectionString)
        {
            this.connectionString = connectionString;
        }

　
        public string getConnString()
        {
            return this.connectionString;
        }

　
        public int insert(string sql)
        {
            int result = 0;
            SqlConnection conn = new SqlConnection(this.connectionString);

            conn.Open();

            result = (new SqlCommand(sql, conn)).ExecuteNonQuery();

            conn.Close();
            return result;
        }
    }
}
