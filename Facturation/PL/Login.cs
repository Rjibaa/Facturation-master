using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace Facturation.PL
{
    public partial class Login : Form
    {
        BL.CLS_LOGIN log = new BL.CLS_LOGIN();

        int nbTentative = 0;
        
        const string connetionString = "server=localhost;user=root;database=facturation;password=";

        public Login()
        {
            InitializeComponent();
        }

        private void btnLog_Click(object sender, EventArgs e)
        {

            MySqlConnection connection = new MySqlConnection(connetionString);
            connection.Open();

            string sqlRequset = "Select Utilisateur.ID from Utilisateur where Utilisateur.USERNAME='" + txtID.Text + "' and Utilisateur.PSW='" + txtPSW.Text + "'";

            MySqlCommand command = new MySqlCommand(sqlRequset, connection);
            MySqlDataReader reader = command.ExecuteReader();


            if (reader.Read())
            {
                Console.WriteLine("while");
                this.Hide();
                frm_Facturation frm = new frm_Facturation();
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Nom d'utlisateur ou mot de passe invalide");

            }

            connection.Close();


        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtPSW.UseSystemPasswordChar = true;
                labelpwd.Text = "Cacher Password";
            }
            else
            {
                txtPSW.UseSystemPasswordChar = false;
                labelpwd.Text = "Afficher Password";
            }
        }


        private void txtPSW_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Call the btnLog_Click event handler when Enter is pressed
                btnLog_Click(sender, e);
            }
        }
    }
}
