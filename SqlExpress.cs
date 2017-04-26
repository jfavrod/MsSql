using System;
using System.Data.SqlClient;
using System.Collections;

　
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

　
        /**
         * select
         * 
         * Executes SQL select statements on the database.
         * 
         * @param string sql The SQL select statement to be executed.
         * @param int colCount The number of columns in the resulting tuples.
         * @return ArrayList A collection of string ArrayLists representing
         * the result set.
         */

        public ArrayList select(string sql, int colCount)
        {
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlDataReader reader = null;
            ArrayList result = new ArrayList();
            ArrayList tuple = new ArrayList();

            conn.Open();
            reader = (new SqlCommand(sql, conn)).ExecuteReader();

            while (reader.Read())
            {
                for (int j = 0; j < colCount; j++) {
                    if (j+1 == colCount) {
                        tuple.Add(reader.GetString(j));
                    }
                    else {
                        tuple.Add(reader.GetString(j));
                    }
                }

                result.Add(tuple.Clone());
                tuple.Clear();
            }

            conn.Close();

            return result;
        }
    }
}
