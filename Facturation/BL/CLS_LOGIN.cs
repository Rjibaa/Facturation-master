using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using MySql.Data.MySqlClient;

namespace Facturation.BL
{
    class CLS_LOGIN
    {
        public int SP_LOGING(string ID, string PSW)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();

            MySqlParameter paramReturn = new MySqlParameter("@returnedvalue", MySqlDbType.Int16);

            MySqlParameter[] param = new MySqlParameter[2];

            param[0] = new MySqlParameter("@ID", MySqlDbType.VarChar, 50);
            param[0].Value = ID;

            param[1] = new MySqlParameter("@PSW", MySqlDbType.VarChar, 50);
            param[1].Value = PSW;

            int i = dal.ExecuteNonQuery2("SP_LOGIN", paramReturn, param);

            return i;
            
        }
    }
}
