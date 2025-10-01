using ConnectionDA.Interface;
using Microsoft.Data.SqlClient;
using System.Data;




namespace ConnectionDA
{
    public class SQLHelper :ISQLHelper
    {
       public int ExcuteQuery(String query, Dictionary<string, string> parameters)
        {
            int result =-1;
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(InMemory.Connection))
                {
                    sqlConn.Open();
                    using (SqlCommand cmd =new SqlCommand(query, sqlConn))
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value);

                        }
                        result = cmd.ExecuteNonQuery();

                    }
                    sqlConn.Close();
                }
            }
            catch(SqlException ex)
            {
                throw new Exception("SQL Error:" + ex.Message);

            }
            finally
            { }
            return result;
        }

        public List<Dictionary<string, object>> RetriveMultipleData(string query, Dictionary<string, string> parameters)
        {
            throw new NotImplementedException();
        }

        public object RetriveSingleData(string query, Dictionary<string, string> parameters)
        {
            throw new NotImplementedException();
        }

        public DataSet GetData(string query, Dictionary<string, string> parameters)
        {
            try
            {
                SqlConnection sql = new SqlConnection(InMemory.Connection);

                sql.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sql;
                cmd.CommandText = query;

                foreach (var param in parameters)
                {
                    cmd.Parameters.AddWithValue(param.Key, param.Value);

                }
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                return ds;
                sql.Open();
            }
            catch(SqlException ex)
            {
                return null;
            }
        }
    }
}
