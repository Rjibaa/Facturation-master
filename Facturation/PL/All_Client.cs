using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Facturation.PL
{
    public partial class All_Client : Form
    {

        public All_Client()
        {
            InitializeComponent();

            const string connetionString = "server=localhost;user=root;database=facturation;password=";

            MySqlConnection connection = new MySqlConnection(connetionString);
            connection.Open();

            string sqlRequset = "SELECT * FROM `client`";

            MySqlCommand command = new MySqlCommand(sqlRequset, connection);
            MySqlDataReader reader = command.ExecuteReader();
           
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            
            dgvAllClient.DataSource = dataTable;

            Console.WriteLine(dgvAllClient);

        }

        private void dgvAllClient_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvAllClient_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
