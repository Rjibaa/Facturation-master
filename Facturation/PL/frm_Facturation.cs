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
using System.Data;
using MySql.Data.MySqlClient;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
using Org.BouncyCastle.Utilities.Collections;
using CrystalDecisions.CrystalReports.Engine;
using iTextSharp.text.pdf.parser;
using Org.BouncyCastle.Asn1.Ocsp;

namespace Facturation.PL
{
    public partial class frm_Facturation : Form
    {
        const string connetionString = "server=localhost;user=root;database=facturation;password=";

        //double sold, montant;
        double montant;
        public static string myDocumentPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);


        //  BL.CLS_FACTURE fac = new BL.CLS_FACTURE();
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();

        void CreateDataTable()
        {
            dt.Columns.Add("Numéro Article");
            dt.Columns.Add("Désignation");
            dt.Columns.Add("Prix Unitaire");
            dt.Columns.Add("Quantité Vendu");
            dt.Columns.Add("TVA");
            dt.Columns.Add("Montant HT");
            dt.Columns.Add("Montant TTC");
            dgv.DataSource = dt;
        }

        

        void CalculMontant()
        {
            if (txtPrix.Text != string.Empty && txtQV.Text != string.Empty)
            {
                double montant = Convert.ToDouble(txtPrix.Text) * Convert.ToInt32(txtQV.Text);
                
            }

        }
       public void ClearData()
        {
            txtNumArt.Clear();
            txtDesign.Clear();
            txtPrix.Clear();
            txtQS.Clear();
            txtQV.Clear();
            textTVA.Clear();
            txtGrat.Clear();
        }

        void ClearTout()
        {
            txtVendu.Clear();
            dtp.ResetText();
            txtNumArt.Clear();
            txtDesign.Clear();
            txtPrix.Clear();
            txtQS.Clear();
            txtQV.Clear();
            txtNumCl.Clear();
            txtNom.Clear();
            txtSolde.Clear();
            txtTotal.Clear();
            txtMontantRest.Clear();
            dt.Clear();
            textVille.Clear();
            dgv.DataSource = null;
        }

        void ClearClient()
        {
            textVille.Clear();
            txtNom.Clear();
            txtNumCl.Clear();
            txtSolde.Clear();

        }

        public frm_Facturation()
        {
            InitializeComponent();
            CreateDataTable();


            //txtVendu.Text = fac.LAST_FACTURE().Rows[0][0].ToString();

            /*const string connetionString = "server=localhost;user=root;database=facturation;password=";

            MySqlConnection connection = new MySqlConnection(connetionString);
            connection.Open();



            // string sqlRequset = "SELECT no_facture FROM Facture";

            string sqlRequset = "";

            if (radioFacture.Checked) { 
                 sqlRequset= " SELECT no_facture FROM Facture WHERE no_facture = (SELECT max(no_facture) FROM Facture)";
            }
            else
            {
                sqlRequset = " SELECT no_BL FROM bl WHERE no_BL = (SELECT max(no_BL) FROM bl)";
            }


            MySqlCommand command = new MySqlCommand(sqlRequset, connection);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                txtVendu.Text = (reader.GetInt16(0) + 1).ToString();
            }*/

           
            radioFacture.CheckedChanged += RadioCheckedChanged;
            radioBL.CheckedChanged += RadioCheckedChanged;
            
            UpdateTxtVendu("BL");

        }



        private void RadioCheckedChanged(object sender, EventArgs e)
        {
            // Handle the radio button selection change
            if (radioFacture.Checked)
            {
                radioFacture.Focus();
                UpdateTxtVendu("Facture");
            }
            else if (radioBL.Checked)
            {
                radioBL.Focus();
                UpdateTxtVendu("BL");
            }
        }

        private void UpdateTxtVendu(string type)
        {
            const string connetionString = "server=localhost;user=root;database=facturation;password=";
            MySqlConnection connection = new MySqlConnection(connetionString);
            connection.Open();

            string sqlRequest = "";

            if (type == "Facture")
            {
                sqlRequest = "SELECT no_facture FROM Facture WHERE no_facture = (SELECT max(no_facture) FROM Facture)";
            }
            else if (type == "BL")
            {
                sqlRequest = "SELECT no_BL FROM bl WHERE no_BL = (SELECT max(no_BL) FROM bl)";
            }

            MySqlCommand command = new MySqlCommand(sqlRequest, connection);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                txtVendu.Text = (reader.GetInt16(0) + 1).ToString();
            }
        }


        private void btnAddCli_Click(object sender, EventArgs e)
        {
            Add_Client frm = new Add_Client();
            frm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                All_Client frm_c = new All_Client();
                frm_c.ShowDialog();
                Console.WriteLine(frm_c.dgvAllClient);

                if (frm_c.dgvAllClient != null && frm_c.dgvAllClient.Rows.Count > 0)
                {
                    txtNumCl.Text = frm_c.dgvAllClient.CurrentRow.Cells[0].Value.ToString();
                    txtNom.Text = frm_c.dgvAllClient.CurrentRow.Cells[1].Value.ToString();
                    txtSolde.Text = frm_c.dgvAllClient.CurrentRow.Cells[2].Value.ToString();
                    textVille.Text = frm_c.dgvAllClient.CurrentRow.Cells[3].Value.ToString();
                }
                else
                {
                    MessageBox.Show("No data available in the DataGridView.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ClearData();
            try
            {
                All_Article frm = new All_Article();
                frm.ShowDialog();
                txtNumArt.Text = frm.dgvArticle.CurrentRow.Cells[0].Value.ToString();
                txtDesign.Text = frm.dgvArticle.CurrentRow.Cells[1].Value.ToString();
                txtPrix.Text = frm.dgvArticle.CurrentRow.Cells[2].Value.ToString();
                txtQS.Text = frm.dgvArticle.CurrentRow.Cells[3].Value.ToString();
                textTVA.Text = frm.dgvArticle.CurrentRow.Cells[4].Value.ToString();
                txtGrat.Text = frm.dgvArticle.CurrentRow.Cells[5].Value.ToString();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddAtc_Click(object sender, EventArgs e)
        {
            Add_Article frm = new Add_Article();
            frm.ShowDialog();
        }

        private void txtQV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                button2_Click(sender, e);
            }
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            double sum = 0;
            double sumtva = 0;



            try
            {


                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    if (dgv.Rows[i].Cells[0].Value.ToString() == txtNumArt.Text)
                    {
                        MessageBox.Show("Cet Produit Existe Déjà", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ClearData();
                        return;
                    }
                }



                const string connetionString = "server=localhost;user=root;database=facturation;password=";

                MySqlConnection connection = new MySqlConnection(connetionString);
                connection.Open();



                Console.WriteLine("txtNumArt.Text : " + txtNumArt.Text);
                string sqlRequset = " SELECT qut_st FROM `marchandise` WHERE ref = '" + txtNumArt.Text +"'";

                MySqlCommand command = new MySqlCommand(sqlRequset, connection);
                MySqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    Console.WriteLine("qu : " + reader.GetInt16(0));

                    if (reader.GetInt16(0) < Int16.Parse(txtQV.Text))
                    {
                        MessageBox.Show("Quantité entré pour ce produit n'est pas disponibles", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                
             
                DataRow r = dt.NewRow();


                r[0] = txtNumArt.Text;
                r[1] = txtDesign.Text;
                r[2] = string.Format("{0:0.000}", double.Parse(txtPrix.Text));
                r[3] = txtQV.Text;
                r[4] = textTVA.Text;

                r[5] = (Convert.ToDouble(txtPrix.Text) * Convert.ToInt32(txtQV.Text)).ToString("0.000");
                r[6] = (Convert.ToDouble(txtPrix.Text) * Convert.ToInt32(txtQV.Text) + (Convert.ToDouble(txtPrix.Text) * Convert.ToInt32(txtQV.Text) * Convert.ToDouble(textTVA.Text) / 100)).ToString("0.000");
                dt.Rows.Add(r);


                int Grat_num = (int)Math.Floor(Convert.ToDouble(txtQV.Text) / Convert.ToDouble(txtGrat.Text));
                int restant = Convert.ToInt32(txtQS.Text) - Convert.ToInt32(txtQV.Text) - Grat_num;
                if ((!txtGrat.Text.Equals("0")) && (Grat_num > 0))
                {   if (restant > 0) { 

                    DataRow r1 = dt.NewRow();

                        Console.WriteLine(txtDesign.Text + " (Bonification)");
                    
                    r1[0] = txtNumArt.Text;
                    r1[1] = txtDesign.Text + " (Bonification)";
                    r1[2] = '0';
                    r1[3] = Grat_num;
                    //Console.WriteLine(Grat_num.ToString());
                    r1[4] = '0';
                    r1[5] = 0;
                    r1[6] = 0;
                    dt.Rows.Add(r1);
                    }
                    else
                    {
                        MessageBox.Show("Quantité Gratuite entré pour ce produit n'est pas disponibles", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        MessageBox.Show("Votre stock de ce produit devient negative", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        DataRow r1 = dt.NewRow();

                        Console.WriteLine(txtDesign.Text + " (Bonification)");

                        r1[0] = txtNumArt.Text;
                        r1[1] = txtDesign.Text + " (Bonification)";
                        r1[2] = '0';
                        r1[3] = Grat_num;
                        //Console.WriteLine(Grat_num.ToString());
                        r1[4] = '0';
                        r1[5] = 0;
                        r1[6] = 0;
                        dt.Rows.Add(r1);
                        //restant = Convert.ToInt32(txtQS.Text) - Convert.ToInt32(txtQV.Text);
                    }

                }

                dgv.DataSource = dt;

                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    sum += Convert.ToDouble(dgv.Rows[i].Cells[5].Value);
                    sumtva += Convert.ToDouble(dgv.Rows[i].Cells[6].Value);

                }


                // sold = double.Parse(txtSolde.Text);
                // montant = double.Parse(txtTotal.Text);
                txtMontantRest.Text = sumtva.ToString("0.000");
                txtTotal.Text = sum.ToString("0.000");

                MySqlConnection updateConnection = new MySqlConnection(connetionString);
                updateConnection.Open();
                int qu_vendu = Convert.ToInt32(txtQV.Text);
                string sqlRequset1 = "UPDATE `marchandise` SET `qut_st`= " + restant.ToString() + " WHERE ref = '" + txtNumArt.Text + "'";
                Console.WriteLine(sqlRequset1);
                MySqlCommand update = new MySqlCommand(sqlRequset1,updateConnection);
                MySqlDataReader reader1 = update.ExecuteReader();

                updateConnection.Close();


                connection.Close();

                ClearData();
                                                            


            }
            catch (Exception ex)
            {

               //MessageBox.Show(ex.Message);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {   
                String reference = dgv.CurrentRow.Cells[0].Value.ToString();
                String QV = dgv.CurrentRow.Cells[3].Value.ToString();
                Console.WriteLine(reference);
                Console.WriteLine(QV);

                dgv.Rows.RemoveAt(dgv.CurrentRow.Index);

                //Console.WriteLine(txtQS.Text);
                MySqlConnection updateConnection = new MySqlConnection(connetionString);
                updateConnection.Open();

                string sqlRequset1 = "UPDATE `marchandise` SET `qut_st`= qut_st + " + QV + " WHERE ref = '" + reference + "'";
                Console.WriteLine(sqlRequset1);
                

                using (MySqlCommand update = new MySqlCommand(sqlRequset1, updateConnection))
                {
                    update.ExecuteNonQuery();
                }

                updateConnection.Close();
                ClearData() ;

                /* 

                 MySqlConnection updateConnection = new MySqlConnection(connetionString);
                 updateConnection.Open();
                 /*int qu_vendu = Convert.ToInt32(txtQV.Text);
                 int restant = Convert.ToInt32(txtQS.Text) - Convert.ToInt32(txtQV.Text);
                 string sqlRequset1 = "UPDATE `marchandise` SET `qut_st`= " + txtQS.Text + " WHERE ref = " + txtNumArt.Text;
                 Console.WriteLine(sqlRequset1);
                 MySqlCommand update = new MySqlCommand(sqlRequset1, updateConnection);
                 update.ExecuteNonQuery();

                 updateConnection.Close();*/

                // sold = double.Parse(txtSolde.Text);

                // txtMontantRest.Text = montant.ToString();
                /* if (sold >= montant)
                 {
                     double calcu = sold - montant;
                     txtMontantRest.Text = calcu.ToString();
                 }
                 else
                 {
                     MessageBox.Show("Solde Insuffisant", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                     dgv.Rows.RemoveAt(dgv.Rows.Count - 1);
                 }*/

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void dgv_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            double sum = 0;
            double sumtva = 0;

            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                sum += Convert.ToDouble(dgv.Rows[i].Cells[5].Value);
                sumtva += Convert.ToDouble(dgv.Rows[i].Cells[6].Value);

            }
            txtTotal.Text = sum.ToString();
            txtMontantRest.Text = sumtva.ToString();

        }

        private void button6_Click(object sender, EventArgs e)
        {

            try
            {


                if (txtNumCl.Text == string.Empty)
                {
                    Console.WriteLine("client");
                    MessageBox.Show("Vous devez choisir un client", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                String nom_client = txtNom.Text;
                String matricule_client = txtNumCl.Text;
                String adresse_client = txtSolde.Text;
                String ville_Client = textVille.Text;
                DateTime currentDate = DateTime.Now;



                BaseFont bfTimes = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
                BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
                iTextSharp.text.Font nameCompany = new iTextSharp.text.Font(bf, 20, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
                iTextSharp.text.Font header = new iTextSharp.text.Font(bf, 18, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
                iTextSharp.text.Font footer = new iTextSharp.text.Font(bfTimes, 14, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
                iTextSharp.text.Font times = new iTextSharp.text.Font(bfTimes, 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
                iTextSharp.text.Font timesHeader = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
                iTextSharp.text.Font timesmontant = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
                iTextSharp.text.Image logo;

                string r = "";
                string docpath = "";
                string numcommande = txtVendu.Text;
                

                if (radioFacture.Checked)
                {
                    // r = "Facture " + txtNom.Text + " " + RandomString(4, true) + ".pdf";
                    r = "Facture " + txtNom.Text + " " + numcommande + ".pdf";
                    docpath = myDocumentPath+ "\\Facturation\\Facture";
                }
                else
                {
                    //r = "BL " + txtNom.Text + " " + RandomString(4, true) + ".pdf";
                    r = "BL " + txtNom.Text + " " + numcommande + ".pdf";
                    docpath = myDocumentPath+ "\\Facturation\\Bon de livraison";
                }



                iTextSharp.text.Document doc = new iTextSharp.text.Document(PageSize.A4);
                String s = docpath + "\\" + r;
                Console.WriteLine("name " + r);
                Console.WriteLine("Path" + s);

                Document pdfDoc = new Document(PageSize.A4, 10, 10, 10, 10);
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, new FileStream(s, FileMode.Create));
                pdfDoc.Open();

                double total = 0;
                int nbrproduit = dgv.Rows.Count;
                int pagenumber = (nbrproduit / 27)+1;
                Console.WriteLine("Page numbers : " + pagenumber);

                Double tva1 = 0;
                Double sanstve1 = 0;
                Double tva2 = 0;
                Double sanstve2 = 0;

                for (int page = 0; page < pagenumber; page++)
                {
                    if(page != 0)
                    {
                        pdfDoc.NewPage();
                    }
                    PdfPTable tablevide = new PdfPTable(2);
                    tablevide.WidthPercentage = 100;
                    tablevide.DefaultCell.BorderColor = new iTextSharp.text.BaseColor(255, 255, 255);
                    tablevide.DefaultCell.BorderWidth = 0;
                    tablevide.AddCell(" ");
                    tablevide.AddCell(" ");
                    tablevide.AddCell(" ");
                    tablevide.AddCell(" ");
                    tablevide.AddCell(" ");
                    tablevide.AddCell(" ");

                    pdfDoc.Add(tablevide);



                    PdfPTable bigtable1 = new PdfPTable(2);
                    bigtable1.WidthPercentage = 100;
                    bigtable1.DefaultCell.BorderColor = new iTextSharp.text.BaseColor(255, 255, 255);
                    bigtable1.DefaultCell.BorderWidth = 0;

                    PdfPTable table1 = new PdfPTable(3);

                    table1.WidthPercentage = 30;


                    table1.DefaultCell.BorderColor = new iTextSharp.text.BaseColor(255, 255, 255);
                    table1.DefaultCell.BorderWidth = 0;
                    PdfPCell cellll = new PdfPCell(new Phrase(""));
                    cellll.Colspan = 3;
                    cellll.HorizontalAlignment = Element.ALIGN_CENTER;
                    cellll.BorderColor = new iTextSharp.text.BaseColor(255, 255, 255);
                    table1.AddCell(cellll);

                    table1.AddCell("");
                    table1.AddCell("");
                    table1.AddCell("");


                    table1.AddCell("");
                    table1.AddCell("");
                    table1.AddCell("");

                    bigtable1.AddCell(table1);

                    // pdfDoc.Add(table);



                    table1 = new PdfPTable(1);
                    table1.WidthPercentage = 30;

                    PdfPCell celllll = new PdfPCell(new Phrase("Societé R.M DISTRI-PHARMA \n" +
        "SARL \n" +
        "CAPITAL SOCIAL: 20.000 DT \n" +
        "IDENTIFIANT UNIQUE: 1672716A - A - M - 000 \n" +
        "RIB: 000117100278897", timesHeader));

                    table1.AddCell(celllll);



                    bigtable1.AddCell(table1);

                    pdfDoc.Add(bigtable1);




                    PdfPTable bigtable = new PdfPTable(2);
                    bigtable.WidthPercentage = 100;
                    bigtable.DefaultCell.BorderColor = new iTextSharp.text.BaseColor(255, 255, 255);
                    bigtable.DefaultCell.BorderWidth = 0;

                    PdfPTable table = new PdfPTable(3);

                    table.WidthPercentage = 30;

                    string type = "";
                    if (radioFacture.Checked)
                    {
                        type = "Facture";
                    }
                    else
                    {
                        type = "Bon de Livraison";
                    }

                    string pagestring = (page+1).ToString()+"/"+ pagenumber.ToString();
                    PdfPCell cell = new PdfPCell(new Phrase(type, timesHeader));
                    cell.Colspan = 3;
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(cell);

                    table.AddCell(new Phrase("Numéro", timesHeader));
                    table.AddCell(new Phrase("Date", timesHeader));
                    table.AddCell(new Phrase("page", timesHeader));
                     

                    table.AddCell(new Phrase(txtVendu.Text, timesHeader));
                    table.AddCell(new Phrase(dtp.Value.ToShortDateString(), timesHeader));
                    table.AddCell(new Phrase(pagestring, timesHeader));

                    bigtable.AddCell(table);

                    // pdfDoc.Add(table);



                    table = new PdfPTable(1);
                    table.WidthPercentage = 30;


                    PdfPCell celll = new PdfPCell(new Phrase("Nom Client : " + nom_client + "\n" +

        "Adresse : " + adresse_client + " " + ville_Client + "\n" +

        "Matricule fiscal : " + matricule_client + "\n", timesHeader
        ));
                    // celll.Colspan = 3;
                    //  celll.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(celll);


                    bigtable.AddCell(table);

                    pdfDoc.Add(bigtable);



                    PdfPTable pdfTable = new PdfPTable(7);
                    pdfTable.WidthPercentage = 99.4f;
                    float[] widthsss = new float[] { 15f, 35f, 10f, 10f, 10f, 10f, 10f };
                    pdfTable.SetWidths(widthsss);
                    String[] headers = { "Référence", "Désignation", "Quantité", "P.U.H.T", "Montant HT", "TVA", "Montant TTC" };

                    for (int i = 0; i < headers.Length; i++)
                    {
                        //String x = headers[i];
                        pdfTable.AddCell(new Phrase(headers[i], times));
                    }


                    pdfDoc.Add(pdfTable);



                    PdfPTable pdfTable2 = new PdfPTable(7);
                    pdfTable2.WidthPercentage = 99.4f;
                    //pdfTable2.DefaultCell.BorderColor = new iTextSharp.text.BaseColor(255, 255, 255);
                    pdfTable2.DefaultCell.BorderWidth = 0;


                    float[] widthss = new float[] { 15f, 35f, 10f, 10f, 10f, 10f, 10f };
                    pdfTable2.SetWidths(widthss);
                    /*Double tva1 = 0;
                    Double sanstve1 = 0;
                    Double tva2 = 0;
                    Double sanstve2 = 0;*/



                    

                    for (int i = 0; i < 27; i++)
                    {
                        for (int j = 0; j < 7; j++)
                        {
                            PdfPCell emptyCell = new PdfPCell(new Phrase((" ")));

                            if (i == 27 - 1)
                            {
                                // Add a bottom border to the last row
                                emptyCell.BorderWidthTop = 0f;
                                emptyCell.BorderWidthBottom = 1f;
                            }
                            else
                            {
                                // Remove top and bottom borders for other rows
                                emptyCell.BorderWidthTop = 0f;
                                emptyCell.BorderWidthBottom = 0f;
                            }

                            //Console.WriteLine("Empty Height : " + emptyCell.Height);

                            pdfTable2.AddCell(emptyCell);
                        }
                    }

                    int startindex =27 * page;
                    int endindex = Math.Min(nbrproduit+1, 27*(page+1));
                    Console.WriteLine("endindex : " + endindex);
                    Console.WriteLine("startindex : " + startindex);

                    for (int originalRowIndex = startindex; originalRowIndex < endindex; originalRowIndex++)
                        {
                            int rowIndexOnPage = originalRowIndex - startindex;

                        for (int i=0;i<7;i++) {
                            try
                            {
                                PdfPCell celld = pdfTable2.Rows[rowIndexOnPage].GetCells()[i]; // Get the cell in the current row and column
                            
                                    if (i == 2) { 
                                    // Set the content of the cell from the DataGridView
                                    celld.Phrase = new Phrase(dgv.Rows[originalRowIndex].Cells[i+1].Value.ToString(), times);
                                    }else if (i == 3)
                                    {
                                            celld.Phrase = new Phrase(dgv.Rows[originalRowIndex].Cells[i - 1].Value.ToString(), times);
                                    }else if(i == 4)
                                    {
                                            celld.Phrase = new Phrase(dgv.Rows[originalRowIndex].Cells[i + 1].Value.ToString(), times);

                                    if (dgv.Rows[originalRowIndex].Cells[4].Value.ToString().Equals("19"))
                                    {
                                                sanstve1 = sanstve1 + double.Parse(dgv.Rows[originalRowIndex].Cells[5].Value.ToString());
                                    }
                                    if (dgv.Rows[originalRowIndex].Cells[4].Value.ToString().Equals("7"))
                                    {
                                                sanstve2 = sanstve2 + double.Parse(dgv.Rows[originalRowIndex].Cells[5].Value.ToString());
                                    }
                                    }
                                    else if(i ==5)
                                    {
                                            celld.Phrase = new Phrase(dgv.Rows[originalRowIndex].Cells[i - 1].Value.ToString(), times);
                                    }
                                    else
                                    {
                                            celld.Phrase = new Phrase(dgv.Rows[originalRowIndex].Cells[i].Value.ToString(), times);
                                    }

                                        // Optionally, you can set cell borders here
                                        celld.BorderWidthTop = 0f;
                                    if (originalRowIndex != 26)
                                    {
                                        celld.BorderWidthBottom = 0f;
                                    }
                                    else
                                    {
                                        celld.BorderWidthBottom = 1f;
                                    }

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex);
                            }
                                        // Console.WriteLine("Height : "+celld.Height);

                                }
                        
                        }

                    pdfDoc.Add(pdfTable2);

                    if (page != pagenumber-1) {
                        PdfPTable bigtablefooter = new PdfPTable(3);
                        bigtablefooter.WidthPercentage = 100;
                        bigtablefooter.DefaultCell.BorderColor = new iTextSharp.text.BaseColor(255, 255, 255);
                        bigtablefooter.DefaultCell.BorderWidth = 0;



                        PdfPTable tablebase = new PdfPTable(3);

                        //  tablebase.DefaultCell.BorderColorBottom = new iTextSharp.text.BaseColor(255, 255, 255);
                        //tablebase.DefaultCell.BorderWidthBottom = 0;

                        tablebase.WidthPercentage = 30;

                        tablebase.HorizontalAlignment = Element.ALIGN_LEFT;
                        tablebase.AddCell(new Phrase("Base", timesHeader));
                        tablebase.AddCell(new Phrase("TVA %", timesHeader));
                        tablebase.AddCell(new Phrase("TVA", timesHeader));

                        if (sanstve1 != 0)
                        {
                            tva1 = sanstve1 * 19 / 100;


                            tablebase.AddCell(new Phrase("XXXX", timesHeader)); //sanstve1.ToString());
                            tablebase.AddCell(new Phrase("XXXX", timesHeader));
                            tablebase.AddCell(new Phrase("XXXX", timesHeader));
                        }

                        if (sanstve2 != 0)
                        {
                            tva2 = sanstve2 * 7 / 100;
                            tablebase.AddCell(new Phrase("XXXX", timesHeader)); //sanstve1.ToString());
                            tablebase.AddCell(new Phrase("XXXX", timesHeader));
                            tablebase.AddCell(new Phrase("XXXX", timesHeader));
                        }




                        bigtablefooter.AddCell(tablebase);


                        /***************** table hiddennn *********************/
                        tablebase = new PdfPTable(3);
                        tablebase.DefaultCell.BorderColor = new iTextSharp.text.BaseColor(255, 255, 255);
                        tablebase.DefaultCell.BorderWidth = 0;
                        tablebase.WidthPercentage = 30;

                        tablebase.HorizontalAlignment = Element.ALIGN_LEFT;
                        tablebase.AddCell("");
                        tablebase.AddCell("");
                        tablebase.AddCell("");

                        tablebase.AddCell("");
                        tablebase.AddCell("");
                        tablebase.AddCell("");

                        tablebase.AddCell("");
                        tablebase.AddCell("");
                        tablebase.AddCell("");


                        bigtablefooter.AddCell(tablebase);




                        String totalht = txtTotal.Text;
                        String totalttc = txtMontantRest.Text;

                        //double total = double.Parse(totalttc) + 1.000;
                        total = double.Parse(totalttc) + 1.000;
                        //double tva = double.Parse(totalttc) - double.Parse(totalht);
                        double tva = double.Parse(totalttc) - double.Parse(totalht);

                        tablebase = new PdfPTable(2);

                        tablebase.WidthPercentage = 30;



                        tablebase.HorizontalAlignment = Element.ALIGN_LEFT;
                        PdfPCell celltotht = new PdfPCell(new Phrase("TOTAL HT", timesHeader));
                        celltotht.BorderColorTop = new iTextSharp.text.BaseColor(255, 255, 255);
                        tablebase.AddCell(celltotht);


                        celltotht = new PdfPCell(new Phrase("XXXX", timesHeader));
                        celltotht.BorderColorTop = new iTextSharp.text.BaseColor(255, 255, 255);
                        celltotht.HorizontalAlignment = Element.ALIGN_RIGHT;

                        tablebase.AddCell(celltotht);

                        PdfPCell celltva = new PdfPCell(new Phrase("TVA", timesHeader));
                        //  celltva.BorderColor = new iTextSharp.text.BaseColor(255, 255, 255);

                        tablebase.AddCell(celltva);

                        celltva = new PdfPCell(new Phrase("XXXX", timesHeader));
                        //celltva.BorderColor = new iTextSharp.text.BaseColor(255, 255, 255);

                        celltva.HorizontalAlignment = Element.ALIGN_RIGHT;

                        tablebase.AddCell(celltva);


                        tablebase.AddCell(new Phrase("DROIT DE TIMBRE", timesHeader));

                        PdfPCell celldroit = new PdfPCell(new Phrase("XXXX", timesHeader));
                        celldroit.HorizontalAlignment = Element.ALIGN_RIGHT;

                        tablebase.AddCell(celldroit);


                        tablebase.AddCell(new Phrase("TOTAL TTC", timesHeader));

                        PdfPCell cellttc = new PdfPCell(new Phrase("XXXX", timesmontant));
                        cellttc.HorizontalAlignment = Element.ALIGN_RIGHT;
                        tablebase.AddCell(cellttc);




                        bigtablefooter.AddCell(tablebase);
                        pdfDoc.Add(bigtablefooter);

                        String toooottt = String.Format("{0:0.000}", double.Parse(total.ToString()));
                        String[] test = toooottt.Split(',');
                        Console.WriteLine("length : " + test.Length);



                        Console.WriteLine("lettre : " + converti(int.Parse(test[0])));
                        Console.WriteLine("lettre : " + converti(int.Parse(test[1])));


                        
                        PdfPTable bigtablesignature = new PdfPTable(2);
                        bigtablesignature.WidthPercentage = 99.4f;

                        float[] widths = new float[] { 60f, 40f };
                        bigtablesignature.SetWidths(widths);

                        bigtablesignature.AddCell(new Phrase("Montant :\n XXXXXXXXXXX", timesHeader));

                        bigtablesignature.AddCell(new Phrase("signature", timesHeader));




                        pdfDoc.Add(bigtablesignature);
                    }
                    else
                    {
                        PdfPTable bigtablefooter = new PdfPTable(3);
                        bigtablefooter.WidthPercentage = 100;
                        bigtablefooter.DefaultCell.BorderColor = new iTextSharp.text.BaseColor(255, 255, 255);
                        bigtablefooter.DefaultCell.BorderWidth = 0;



                        PdfPTable tablebase = new PdfPTable(3);

                        //  tablebase.DefaultCell.BorderColorBottom = new iTextSharp.text.BaseColor(255, 255, 255);
                        //tablebase.DefaultCell.BorderWidthBottom = 0;

                        tablebase.WidthPercentage = 30;

                        tablebase.HorizontalAlignment = Element.ALIGN_LEFT;
                        tablebase.AddCell(new Phrase("Base", timesHeader));
                        tablebase.AddCell(new Phrase("TVA %", timesHeader));
                        tablebase.AddCell(new Phrase("TVA", timesHeader));

                        if (sanstve1 != 0)
                        {
                            tva1 = sanstve1 * 19 / 100;


                            tablebase.AddCell(new Phrase(String.Format("{0:0.000}", double.Parse(sanstve1.ToString())), timesHeader)); //sanstve1.ToString());
                            tablebase.AddCell(new Phrase("19.00", timesHeader));
                            tablebase.AddCell(new Phrase(String.Format("{0:0.000}", double.Parse(tva1.ToString())), timesHeader));
                        }

                        if (sanstve2 != 0)
                        {
                            tva2 = sanstve2 * 7 / 100;
                            tablebase.AddCell(new Phrase(String.Format("{0:0.000}", double.Parse(sanstve2.ToString())), timesHeader)); //sanstve2.ToString());
                            tablebase.AddCell(new Phrase("7.00", timesHeader));
                            tablebase.AddCell(new Phrase(String.Format("{0:0.000}", double.Parse(tva2.ToString())), timesHeader));
                        }




                        bigtablefooter.AddCell(tablebase);


                        /***************** table hiddennn *********************/
                        tablebase = new PdfPTable(3);
                        tablebase.DefaultCell.BorderColor = new iTextSharp.text.BaseColor(255, 255, 255);
                        tablebase.DefaultCell.BorderWidth = 0;
                        tablebase.WidthPercentage = 30;

                        tablebase.HorizontalAlignment = Element.ALIGN_LEFT;
                        tablebase.AddCell("");
                        tablebase.AddCell("");
                        tablebase.AddCell("");

                        tablebase.AddCell("");
                        tablebase.AddCell("");
                        tablebase.AddCell("");

                        tablebase.AddCell("");
                        tablebase.AddCell("");
                        tablebase.AddCell("");


                        bigtablefooter.AddCell(tablebase);




                        String totalht = txtTotal.Text;
                        String totalttc = txtMontantRest.Text;

                        //double total = double.Parse(totalttc) + 1.000;
                        total = double.Parse(totalttc) + 1.000;
                        //double tva = double.Parse(totalttc) - double.Parse(totalht);
                        double tva = double.Parse(totalttc) - double.Parse(totalht);

                        tablebase = new PdfPTable(2);

                        tablebase.WidthPercentage = 30;



                        tablebase.HorizontalAlignment = Element.ALIGN_LEFT;
                        PdfPCell celltotht = new PdfPCell(new Phrase("TOTAL HT", timesHeader));
                        celltotht.BorderColorTop = new iTextSharp.text.BaseColor(255, 255, 255);
                        tablebase.AddCell(celltotht);

                        
                        celltotht = new PdfPCell(new Phrase(String.Format("{0:0.000}", double.Parse(totalht.ToString())), timesHeader));
                        celltotht.BorderColorTop = new iTextSharp.text.BaseColor(255, 255, 255);
                        celltotht.HorizontalAlignment = Element.ALIGN_RIGHT;

                        tablebase.AddCell(celltotht);

                        PdfPCell celltva = new PdfPCell(new Phrase("TVA", timesHeader));
                        //celltva.BorderColor = new iTextSharp.text.BaseColor(255, 255, 255);
                        tablebase.AddCell(celltva);

                        celltva = new PdfPCell(new Phrase(String.Format("{0:0.000}", double.Parse(tva.ToString())), timesHeader));
                        //celltva.BorderColor = new iTextSharp.text.BaseColor(255, 255, 255);

                        celltva.HorizontalAlignment = Element.ALIGN_RIGHT;

                        tablebase.AddCell(celltva);


                        tablebase.AddCell(new Phrase("DROIT DE TIMBRE", timesHeader));

                        PdfPCell celldroit = new PdfPCell(new Phrase("1,000", timesHeader));
                        celldroit.HorizontalAlignment = Element.ALIGN_RIGHT;

                        tablebase.AddCell(celldroit);


                        tablebase.AddCell(new Phrase("TOTAL TTC", timesHeader));

                        PdfPCell cellttc = new PdfPCell(new Phrase(String.Format("{0:0.000}", double.Parse(total.ToString())), timesmontant));
                        cellttc.HorizontalAlignment = Element.ALIGN_RIGHT;
                        tablebase.AddCell(cellttc);




                        bigtablefooter.AddCell(tablebase);
                        pdfDoc.Add(bigtablefooter);

                        String toooottt = String.Format("{0:0.000}", double.Parse(total.ToString()));
                        String[] test = toooottt.Split(',');
                        Console.WriteLine("length : " + test.Length);



                        Console.WriteLine("lettre : " + converti(int.Parse(test[0])));
                        Console.WriteLine("lettre : " + converti(int.Parse(test[1])));


                        String lettre = converti(int.Parse(test[0])) + " DINARS " + converti(int.Parse(test[1])) + " MILLIMES";
                        PdfPTable bigtablesignature = new PdfPTable(2);
                        bigtablesignature.WidthPercentage = 99.4f;

                        float[] widths = new float[] { 60f, 40f };
                        bigtablesignature.SetWidths(widths);

                        bigtablesignature.AddCell(new Phrase("Montant :\n " + lettre, timesHeader));

                        bigtablesignature.AddCell(new Phrase("signature", timesHeader));




                        pdfDoc.Add(bigtablesignature);
                    }


                }
                pdfDoc.Close();


                    MessageBox.Show("Votre facture se trouve sous " + s, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    try
                    {


                        const string connetionString = "server=localhost;user=root;database=facturation;password=";

                        MySqlConnection connection = new MySqlConnection(connetionString);
                        connection.Open();

                        string sqlRequset = "";

                        if (radioFacture.Checked)
                        {
                            sqlRequset = "INSERT INTO `Facture`(`no_facture`, `moantant_facture`, `montant_reste`, `code_cl`,`date_facture`) " +
                            "VALUES ('" + txtVendu.Text + "','" + total.ToString() + "','" + txtTotal.Text.ToString() + "','" + nom_client + "','" + currentDate.ToString("yyyy-MM-dd") + "')";
                        }
                        else
                        {
                            sqlRequset = "INSERT INTO `bl`(`no_BL`, `moantant_BL`, `nom_client`,`date_BL`) " +
                             "VALUES ('" + txtVendu.Text + "','" + total.ToString() + "','" + nom_client + "','" + currentDate.ToString("yyyy-MM-dd") + "')";
                        }


                        MySqlCommand command = new MySqlCommand(sqlRequset, connection);
                        MySqlDataReader reader = command.ExecuteReader();
                        connection.Close();


                    }
                    catch (Exception ee)
                    {
                        // MessageBox.Show(ee.Message);
                    }


                    try
                    {

                        ClearTout();
                        ClearData();
                        dgv.Rows.Clear();
                        radioFacture.CheckedChanged += RadioCheckedChanged;
                        radioBL.CheckedChanged += RadioCheckedChanged;
                        UpdateTxtVendu("BL");

                    }
                    catch (Exception eeeee)
                    {
                        MessageBox.Show(eeeee.Message);

                    }


                }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }




        }
        public string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        } 
        /*private void dgv_DoubleClick(object sender, EventArgs e)
        {
            try
            {
             
            
            txtNumArt.Text = dgv.CurrentRow.Cells[0].Value.ToString();
            txtDesign.Text = dgv.CurrentRow.Cells[1].Value.ToString();
            txtPrix.Text = dgv.CurrentRow.Cells[2].Value.ToString();
            txtQV.Text = dgv.CurrentRow.Cells[3].Value.ToString();
            textTVA.Text = dgv.CurrentRow.Cells[4].Value.ToString();
            txtGrat.Text = dgv.CurrentRow.Cells[5].Value.ToString();




                dgv.Rows.RemoveAt(dgv.CurrentRow.Index);

           // sold = double.Parse(txtSolde.Text);
            montant = double.Parse(txtTotal.Text);
              //  txtMontantRest.Text = montant.ToString();

                /* if (sold >= montant)
                 {
                     double calcu = sold - montant;
                     txtMontantRest.Text = calcu.ToString();
                 }
                 else
                 {
                     MessageBox.Show("Solde Insuffisant", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                     dgv.Rows.RemoveAt(dgv.Rows.Count - 1);
                 }*/
              /*  txtVendu.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        } */

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNumArt.Text == string.Empty && txtNumCl.Text == string.Empty && dgv.Rows.Count < 1)
                {
                    MessageBox.Show("Saisir Tous les données SVP !!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

              /*  fac.ADD_FACTURE(Convert.ToInt32(txtVendu.Text), dtp.Value, Convert.ToDecimal(txtTotal.Text), Convert.ToDecimal(txtMontantRest.Text), Convert.ToInt32(txtNumCl.Text));

                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    fac.ADD_CONTIENT(dgv.Rows[i].Cells[0].Value.ToString(), Convert.ToInt32(txtVendu.Text), Convert.ToInt32(dgv.Rows[i].Cells[3].Value));
                }*/
                MessageBox.Show("Added Successfuly !!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearTout();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        

            public string converti(int chiffre)
            {
                int centaine, dizaine, unite, reste, y;
                bool dix = false;
                string lettre = "";
                //strcpy(lettre, "");
                
                reste = int.Parse(chiffre.ToString());

                for (int i = 1000000000; i >= 1; i /= 1000)
                {
                    y = reste / i;
                    if (y != 0)
                    {
                        centaine = y / 100;
                        dizaine = (y - centaine * 100) / 10;
                        unite = y - (centaine * 100) - (dizaine * 10);
                        switch (centaine)
                        {
                            case 0:
                                break;
                            case 1:
                                lettre += "cent ";
                                break;
                            case 2:
                                if ((dizaine == 0) && (unite == 0)) lettre += "deux cents ";
                                else lettre += "deux cent ";
                                break;
                            case 3:
                                if ((dizaine == 0) && (unite == 0)) lettre += "trois cents ";
                                else lettre += "trois cent ";
                                break;
                            case 4:
                                if ((dizaine == 0) && (unite == 0)) lettre += "quatre cents ";
                                else lettre += "quatre cent ";
                                break;
                            case 5:
                                if ((dizaine == 0) && (unite == 0)) lettre += "cinq cents ";
                                else lettre += "cinq cent ";
                                break;
                            case 6:
                                if ((dizaine == 0) && (unite == 0)) lettre += "six cents ";
                                else lettre += "six cent ";
                                break;
                            case 7:
                                if ((dizaine == 0) && (unite == 0)) lettre += "sept cents ";
                                else lettre += "sept cent ";
                                break;
                            case 8:
                                if ((dizaine == 0) && (unite == 0)) lettre += "huit cents ";
                                else lettre += "huit cent ";
                                break;
                            case 9:
                                if ((dizaine == 0) && (unite == 0)) lettre += "neuf cents ";
                                else lettre += "neuf cent ";
                                break;
                        }// endSwitch(centaine)

                        switch (dizaine)
                        {
                            case 0:
                                break;
                            case 1:
                                dix = true;
                                break;
                            case 2:
                                lettre += "vingt ";
                                break;
                            case 3:
                                lettre += "trente ";
                                break;
                            case 4:
                                lettre += "quarante ";
                                break;
                            case 5:
                                lettre += "cinquante ";
                                break;
                            case 6:
                                lettre += "soixante ";
                                break;
                            case 7:
                                dix = true;
                                lettre += "soixante ";
                                break;
                            case 8:
                                lettre += "quatre-vingt ";
                                break;
                            case 9:
                                dix = true;
                                lettre += "quatre-vingt ";
                                break;
                        } // endSwitch(dizaine)

                        switch (unite)
                        {
                            case 0:
                                if (dix) lettre += "dix ";
                                break;
                            case 1:
                                if (dix) lettre += "onze ";
                                else lettre += "un ";
                                break;
                            case 2:
                                if (dix) lettre += "douze ";
                                else lettre += "deux ";
                                break;
                            case 3:
                                if (dix) lettre += "treize ";
                                else lettre += "trois ";
                                break;
                            case 4:
                                if (dix) lettre += "quatorze ";
                                else lettre += "quatre ";
                                break;
                            case 5:
                                if (dix) lettre += "quinze ";
                                else lettre += "cinq ";
                                break;
                            case 6:
                                if (dix) lettre += "seize ";
                                else lettre += "six ";
                                break;
                            case 7:
                                if (dix) lettre += "dix-sept ";
                                else lettre += "sept ";
                                break;
                            case 8:
                                if (dix) lettre += "dix-huit ";
                                else lettre += "huit ";
                                break;
                            case 9:
                                if (dix) lettre += "dix-neuf ";
                                else lettre += "neuf ";
                                break;
                        } // endSwitch(unite)

                        switch (i)
                        {
                            case 1000000000:
                                if (y > 1) lettre += "milliards ";
                                else lettre += "milliard ";
                                break;
                            case 1000000:
                                if (y > 1) lettre += "millions ";
                                else lettre += "million ";
                                break;
                            case 1000:
                                lettre += "mille ";
                                break;
                        }
                    } // end if(y!=0)
                    reste -= y * i;
                    dix = false;
                } // end for
                if (lettre.Length == 0) lettre += "zero";

                return lettre;
            
        }

        private void txtNumCl_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNom_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSolde_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtQV_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtp_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void frm_Facturation_Load(object sender, EventArgs e)
        {

        }

        private void btnuppCli_Click(object sender, EventArgs e)
        {
            Add_Client frm = new Add_Client();
            frm.CodeCl = txtNumCl.Text;
            frm.Nom = txtNom.Text;
            frm.Adresse = txtSolde.Text;
            frm.Ville = textVille.Text;
            frm.But = "Update";
            ClearClient();
            frm.ShowDialog();

        }

        private void btnDelCli_Click(object sender, EventArgs e)
        {
            string clientname = txtNumCl.Text;
            string messageboxcontent = "Vous allez vraiment supprimer " + clientname + " de la liste des clients?";

            DialogResult result = MessageBox.Show(messageboxcontent, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


            if(result == DialogResult.Yes)
            {
                const string connetionString = "server=localhost;user=root;database=facturation;password=";

                MySqlConnection connection = new MySqlConnection(connetionString);
                connection.Open();

                Console.WriteLine("txtNumCl.Text : " + txtNumCl.Text);
                string sqlRequset = " DELETE FROM `client` WHERE `Code_cl`= '" + txtNumCl.Text +"'";

                MySqlCommand command = new MySqlCommand(sqlRequset, connection);
                MySqlDataReader reader = command.ExecuteReader();

                txtNumCl.Clear();
                txtNom.Clear();
                txtSolde.Clear();
                textVille.Clear();
            }
        }

        private void btnUppAtc_Click(object sender, EventArgs e)
        {
            Add_Article frm = new Add_Article();
            frm.NumArt = txtNumArt.Text;
            frm.Design = txtDesign.Text;
            frm.Prix = txtPrix.Text;
            frm.QS = txtQS.Text;
            frm.tva = textTVA.Text;
            frm.Grat = txtGrat.Text;
            frm.but = "Update";
            frm.Isupdate = true;
            ClearData();
            frm.ShowDialog();
            
        }

        private void btnDelAtc_Click(object sender, EventArgs e)
        {
            string prooductname = txtNumArt.Text;
            string messageboxcontent = "Vous allez vraiment supprimer " + prooductname + " de la liste des produits ?";

            DialogResult result = MessageBox.Show(messageboxcontent, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            { 
            const string connetionString = "server=localhost;user=root;database=facturation;password=";

            MySqlConnection connection = new MySqlConnection(connetionString);
            connection.Open();

            string sqlRequset = " DELETE FROM `marchandise` WHERE `ref`= '" + txtNumArt.Text+ "'";
            Console.WriteLine(sqlRequset);

            MySqlCommand command = new MySqlCommand(sqlRequset, connection);
            MySqlDataReader reader = command.ExecuteReader();

            ClearData();
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void checkBoxFacture_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioBL_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtVendu_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frm_Facturation_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dgv.Rows.Count > 0)
            {
                MessageBox.Show("Vous devez supprimer les lignes avant fermer le logiciel", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true; // Cancel the form closing event
            }
        }
    }
}
