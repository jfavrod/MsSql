using System;
using System.Data.SqlClient;

　
namespace SqlExpress
{
    public class Db
    {
        /** @var connectionString The connection string for the MSSQL Express DB **/
        private string connectionString = "";

　
        public Db(string connectionString)
        {
            this.connectionString = connectionString;
        }

　
        /**
         * getConnString
         * 
         * Retrieves the connectionString.
         * 
         * @return string This object's connection string.
         */

        public string getConnString()
        {
            return this.connectionString;
        }

　
        /**
         * insert
         * 
         * Executes an insert style statement on the database. Can be
         * of one of the following: CREATE TABLE, INSERT INTO, UPDATE,
         * and DELETE.
         * 
         * @param string sql The sql statement to insert into the database.
         * @return int The number of rows effected by the insert, or on
         * CREATE TABLE or rollback -1.
         */

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
