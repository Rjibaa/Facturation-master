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
    public partial class Add_Client : Form
    {
        // BL.CLS_FACTURE fac = new BL.CLS_FACTURE();

        const string connetionString = "server=localhost;user=root;database=facturation;password=";

        public string CodeCl
        {
            get { return txtCodeCl.Text; }
            set { txtCodeCl.Text = value; }
        }

        public string Nom
        {
            get { return txtnom.Text; }
            set { txtnom.Text = value; }
        }

        public string Adresse
        {
            get { return txtadresse.Text; }
            set { txtadresse.Text = value; }
        }

        public string Ville
        {
            get { return txtville.Text; }
            set { txtville.Text = value; }
        }

        public string But
        {
            set { button1.Text = value; }
        }
        public Add_Client()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("add client");
           try
           {
                if (txtnom.Text == string.Empty && txtadresse.Text == string.Empty && txtville.Text == string.Empty  && txtCodeCl.Text == string.Empty)
                {
                    MessageBox.Show("Saisir Tout Les Champs de Client SVP !!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            const string connetionString = "server=localhost;user=root;database=facturation;password=";

            MySqlConnection connection = new MySqlConnection(connetionString);
                connection.Open(); 

                string sqlRequest = "INSERT INTO `Client`(`Code_cl`, `nom_cl`, `adress`, `ville`) " +
                "VALUES ('" + CodeCl + "','" + Nom + "','" + Adresse + "','" + Ville + "')" +
                "ON DUPLICATE KEY UPDATE `nom_cl` =' "+Nom +"', `adress` = '"+Adresse+"', `ville` = '"+Ville +"'";

                Console.WriteLine(sqlRequest);

                MySqlCommand command = new MySqlCommand(sqlRequest, connection);
                MySqlDataReader reader = command.ExecuteReader();


                //  fac.ADD_CLIENT(Convert.ToInt32(txtCodeCl.Text), txtnom.Text, txtadresse.Text, txtville.Text, Convert.ToDecimal(txtsolde.Text));
                DialogResult result = MessageBox.Show("Added Successfuly !!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    this.Close();
                }

            }
            catch (Exception ex) { 
//{

               MessageBox.Show(ex.Message);
           }
            
        }

        private void Add_Client_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCodeCl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtsolde_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator))
            {
                e.Handled = true;
            }
        }

        private void txtCodeCl_Validated(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
          //  dt = fac.VERIFIER_ID_CLIENT(Convert.ToInt32(txtCodeCl.Text));
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Cet identifiant existe déjà", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCodeCl.Focus();
                txtCodeCl.SelectionStart = 0;
                txtCodeCl.SelectionLength = txtCodeCl.TextLength;

            }
        }

        private void txtCodeCl_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
