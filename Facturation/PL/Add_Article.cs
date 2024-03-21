using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using MySql.Data.MySqlClient;

namespace Facturation.PL
{
    public partial class Add_Article : Form
    {
        public string NumArt
        {
            get { return txtRef.Text; }
            set { txtRef.Text = value; }
        }

        public string Design
        {
            get { return txtDesign.Text; }
            set { txtDesign.Text = value; }
        }

        public string Prix
        {   //string.Format("{0:0.000}", double.Parse(txtPu.Text.Replace(",", ".")))
            get { return (string.Format("{0:0.000}", double.Parse(txtPu.Text))).Replace(",", "."); }
            set { txtPu.Text = value; }
        }

        public string QS
        {
            get { return txtQs.Text; }
            set { txtQs.Text = value; }
        }
        public string tva
        {
            get { return texttva.Text; }
            set { texttva.Text = value; }
        }
        public string Grat
        {
            get { return txtGrat.Text; }
            set { txtGrat.Text = value; }
        }

        public Boolean Isupdate
        {
            get { return isupdate; }
            set { isupdate = value; }
        }

        public string but
        {
            set { btnAjou.Text = value; }
        }
        public Add_Article()
        {
            InitializeComponent();
        }

        private void txtPu_KeyPress(object sender, KeyPressEventArgs e)
        {
            char DecimalSeparator = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != DecimalSeparator)
            {
                e.Handled = true;
            }
        }

        private void txtQs_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void btnAjou_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDesign.Text != string.Empty && txtPu.Text != string.Empty && txtQs.Text != string.Empty && texttva.Text != string.Empty)
                {
                    //  fac.ADD_ARTICLE(txtRef.Text, txtDesign.Text, Convert.ToDecimal(txtPu.Text), Convert.ToInt32(txtQs.Text));

                    const string connetionString = "server=localhost;user=root;database=facturation;password=";

                    MySqlConnection connection = new MySqlConnection(connetionString);
                    connection.Open();

                    /*string sqlRequest = "INSERT INTO `marchandise`(`ref`,`tva`, `designation`, `pu`, `qut_st`,`Gratuie`) " +
                    "VALUES ('" + NumArt + "','" + tva + "','" + Design + "','" + Prix + "','" + QS + "','" + Grat + "')" +
                    "ON DUPLICATE KEY UPDATE `tva` =' " + tva + "', `designation` = '" + Design + "', `pu` = '" + Prix + "', `qut_st` = '" + QS + "', `Gratuie` = '" + Grat + "'";*/
                    Console.WriteLine(Prix);
                    string sqlRequest = "INSERT INTO `marchandise`(`ref`,`tva`, `designation`, `pu`, `qut_st`,`Gratuie`) " +
                    "VALUES ('" + NumArt + "','" + tva + "','" + Design + "','" + Prix + "','" + QS + "','" + Grat + "')";

                    if (Isupdate)
                    {
                        sqlRequest = "UPDATE `marchandise` SET `ref`='" + NumArt + "',`designation`='" + Design + "',`pu`='" + Prix + "',`qut_st`='" + QS + "',`tva`='" + tva + "',`Gratuie`='" + Grat + "' WHERE " +
                            "`ref`='" + NumArt + "'" ;
                    }

                    Console.WriteLine(sqlRequest);
                    MySqlCommand command = new MySqlCommand(sqlRequest, connection);
                    MySqlDataReader reader = command.ExecuteReader();

                    DialogResult result=MessageBox.Show("Added Successfuly !!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if(result == DialogResult.OK)
                    {
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtRef_Validated(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            //dt = fac.VERIFIER_ID(txtRef.Text);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Cet identifiant existe déjà", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRef.Focus();
                txtRef.SelectionStart = 0;
                txtRef.SelectionLength = txtRef.TextLength;

            }
        }

        private void txtRef_TextChanged(object sender, EventArgs e)
        {

        }

        private void texttva_TextChanged(object sender, EventArgs e)
        {

        }

        private void Add_Article_Load(object sender, EventArgs e)
        {

        }

        private void txtQs_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPu_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDesign_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
