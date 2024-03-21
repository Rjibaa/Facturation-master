using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Data;
using MySql.Data;


namespace Facturation.DAL
{
    class DataAccessLayer
    {
     //  SqlConnection ocon;
        MySqlConnection ocon;

        private static string connectionString = "server=localhost;user=root;database=Facturation;password=";
        public DataAccessLayer()
        {
           // ocon = new SqlConnection("Server = .; Database = Facturation; Integrated Security = true");

           ocon = new MySqlConnection(connectionString);

    }

    public void open()
        {
            if (ocon.State != ConnectionState.Open)
            {
                ocon.Open();
            }
        }

        public void close()
        {
            if (ocon.State == ConnectionState.Open)
            {
                ocon.Close();
            }
        }

        public DataTable SelectData(string stored_procedure, MySqlParameter[] param)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = stored_procedure;
            cmd.Connection = ocon;
            if (param != null)
            {
                for (int i = 0; i < param.Length; i++)
                {
                    cmd.Parameters.Add(param[i]);
                }
            }
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public void ExecutCommand(string stored_procedure, MySqlParameter[] param)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = stored_procedure;
            cmd.Connection = ocon;
            if (param != null)
            {
                cmd.Parameters.AddRange(param);
            }
            cmd.ExecuteNonQuery();
        }

        public int ExecuteNonQuery2(string stored_procedure, MySqlParameter paramReturn, MySqlParameter[] param)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = stored_procedure;
            cmd.Connection = ocon;
            ocon.Open();
            cmd.Parameters.AddRange(param);
            cmd.Parameters.Add(paramReturn);
            paramReturn.Direction = ParameterDirection.ReturnValue;
            cmd.ExecuteNonQuery();
            int i = Convert.ToInt32(paramReturn.Value);
            ocon.Close();
            return i;
        }

    }
}
