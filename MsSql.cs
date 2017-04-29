using System;using System.Data.SqlClient;using System.Collections;
namespace MsSql{    public class Db    {        /** @var connectionString The connection string for the MSSQL Express DB **/        private string connectionString = "";
        public Db(string connectionString)        {            this.connectionString = connectionString;        }
        /**         * tableExists         *          * Tells wheather or not the given table exists.         *          * @param string table A given table name.         * @return Boolean True if table exists, false otherwise.         */
        public Boolean tableExists(string table)        {            SqlConnection conn = new SqlConnection(this.connectionString);            Boolean result = false;            ArrayList tmp = null;
            string sql = "select count(*) from information_schema.tables ";            sql += "where table_name = '" + table + "'";
            conn.Open();            tmp = select(sql, 1);
            // Make sure the query has only one resulting row.            if (tmp.Count == 1) {                foreach (ArrayList item in tmp) {                    if (item[0].ToString() == "1") {                        result = true;                    }                }            }
            conn.Close();            return result;        }
        /**         * insert         *          * Executes an insert style statement on the database. Can be         * of one of the following: CREATE TABLE, INSERT INTO, UPDATE,         * and DELETE.         *          * @param string sql The sql statement to insert into the database.         * @return int The number of rows effected by the insert, or on         * CREATE TABLE or rollback -1.         */
        public int insert(string sql)        {            int result = 0;            SqlConnection conn = new SqlConnection(this.connectionString);
            conn.Open();
            result = (new SqlCommand(sql, conn)).ExecuteNonQuery();
            conn.Close();            return result;        }
        /**         * select         *          * Executes SQL select statements on the database.         *          * @param string sql The SQL select statement to be executed.         * @param int colCount The number of columns in the resulting tuples.         * @return ArrayList A collection of string ArrayLists representing         * the result set.         */
        public ArrayList select(string sql, int colCount)        {            SqlConnection conn = new SqlConnection(this.connectionString);            SqlDataReader reader = null;            ArrayList result = new ArrayList();            ArrayList tuple = new ArrayList();
            conn.Open();            reader = (new SqlCommand(sql, conn)).ExecuteReader();
            while (reader.Read())            {                for (int j = 0; j < colCount; j++) {                    try {                        tuple.Add(reader.GetString(j));                    }                    // When the reader returns an int.                    catch (InvalidCastException) {                        tuple.Add((reader.GetInt32(j)).ToString());                    }                }
                result.Add(tuple.Clone());                tuple.Clear();            }
            conn.Close();            return result;        }
        /**         * getConnString         *          * Retrieves the connectionString.         *          * @return string This object's connection string.         */
        public string getConnString()        {            return this.connectionString;        }    }}
