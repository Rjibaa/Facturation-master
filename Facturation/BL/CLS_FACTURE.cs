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
    class CLS_FACTURE
    {
        public DataTable LAST_FACTURE()
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            dt = dal.SelectData("LAST_FACTURE", null);
            return dt;
        }

        public DataTable ALL_CLIENT()
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            dt = dal.SelectData("ALL_CLIENT", null);
            return dt;
        }

        public void ADD_CLIENT(int Code_cl, string nom, string adresse, string ville, decimal solde)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            MySqlParameter[] param = new MySqlParameter[5];
            dal.open();

            param[0] = new MySqlParameter("@CODE_CL", MySqlDbType.Int16);
            param[0].Value = Code_cl;
            param[1] = new MySqlParameter("@NOM_CL", MySqlDbType.VarChar, 25);
            param[1].Value = nom;
            param[2] = new MySqlParameter("@ADRESSE", MySqlDbType.VarChar, 50);
            param[2].Value = adresse;
            param[3] = new MySqlParameter("@VILLE", MySqlDbType.VarChar, 50);
            param[3].Value = ville;
            param[4] = new MySqlParameter("@SOLDE", MySqlDbType.Decimal);
            param[4].Value = solde;

            dal.ExecutCommand("ADD_CLIENT", param);
            dal.close();
        }

        public DataTable ALL_ARTICLE()
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            dt = dal.SelectData("ALL_ARTICLE", null);
            return dt;
        }

        public void ADD_ARTICLE(string REF, string DESIGNATION, decimal PU, int QS)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            MySqlParameter[] param = new MySqlParameter[4];
            dal.open();

            param[0] = new MySqlParameter("@REF", MySqlDbType.VarChar, 50);
            param[0].Value = REF;
            param[1] = new MySqlParameter("@DESIGNATION", MySqlDbType.VarChar, 50);
            param[1].Value = DESIGNATION;
            param[2] = new MySqlParameter("@PU", SqlDbType.Float);
            param[2].Value = PU;
            param[3] = new MySqlParameter("@QUT_ST", SqlDbType.Int);
            param[3].Value = QS;

            dal.ExecutCommand("ADD_ARTICLE", param);
            dal.close();
        }

        public void ADD_FACTURE(int NO_FACTURE, DateTime DATE_FACTURE, decimal MONTANT_FACTURE, decimal MONTANT_RESTE, int CODE_CL)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();

            MySqlParameter[] param = new MySqlParameter[5];

            param[0] = new MySqlParameter("@NO_FACTURE", MySqlDbType.Int16);
            param[0].Value = NO_FACTURE;
            param[1] = new MySqlParameter("@DATE_FACTURE", MySqlDbType.Date);
            param[1].Value = DATE_FACTURE;
            param[2] = new MySqlParameter("@MONTANT_FACTURE", MySqlDbType.Decimal);
            param[2].Value = MONTANT_FACTURE;
            param[3] = new MySqlParameter("@MONTANT_RESTE", MySqlDbType.Decimal);
            param[3].Value = MONTANT_RESTE;
            param[4] = new MySqlParameter("@CODE_CL", MySqlDbType.Int16);
            param[4].Value = CODE_CL;

            dal.ExecutCommand("ADD_FACTURE", param);
            dal.close();
        }

        public void ADD_CONTIENT(string REF, int NO_FACTURE, int QUT_CD)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();

            MySqlParameter[] param = new MySqlParameter[3];

            param[0] = new MySqlParameter("@REF", MySqlDbType.VarChar, 50);
            param[0].Value = REF;
            param[1] = new MySqlParameter("@NO_FACTURE", MySqlDbType.Int16);
            param[1].Value = NO_FACTURE;
            param[2] = new MySqlParameter("@QUT_CD", MySqlDbType.Int16);
            param[2].Value = QUT_CD;

            dal.ExecutCommand("ADD_CONTIENT", param);
            dal.close();
        }

        public DataTable VERIFIER_ID(string REF)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            MySqlParameter[] param = new MySqlParameter[1];
            param[0] = new MySqlParameter("@REF", MySqlDbType.VarChar, 50);
            param[0].Value = REF;
            dt = dal.SelectData("VERIFIER_ID", param);
            return dt;
        }

        public DataTable VERIFIER_ID_CLIENT(int CODE_CL)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            MySqlParameter[] param = new MySqlParameter[1];
            param[0] = new MySqlParameter("@CODE_CL", MySqlDbType.Int16);
            param[0].Value = CODE_CL;
            dt = dal.SelectData("VERIFIER_ID_CLIENT", param);
            return dt;
        }

        public DataTable VERIFY_QUTESTOCK(string REF, int QUT_ST)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            MySqlParameter[] param = new MySqlParameter[2];

            param[0] = new MySqlParameter("@REF", MySqlDbType.VarChar, 50);
            param[0].Value = REF;
            param[1] = new MySqlParameter("@QUT_ST", MySqlDbType.Int16);
            param[1].Value = QUT_ST;

            dt = dal.SelectData("VERIFY_QUTESTOCK", param);
            return dt;
        }

        public DataTable LAST_FACTURE_PRINT()
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            dt = dal.SelectData("LAST_FACTURE_PRINT", null);
            return dt;
        }

        public DataTable PRINT_DETAIL_FACTURE(int NO_FACTURE)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            MySqlParameter[] param = new MySqlParameter[1];

            param[0] = new MySqlParameter("@NO_FACTURE", MySqlDbType.Int16);
            param[0].Value = NO_FACTURE;

            dt = dal.SelectData("PRINT_DETAIL_FACTURE", param);
            return dt;
        }

    }
}
