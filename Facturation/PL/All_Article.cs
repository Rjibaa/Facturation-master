using iTextSharp.text.pdf;
using iTextSharp.text;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text.pdf.parser;
using System.Windows.Forms;
using Org.BouncyCastle.Utilities;

namespace Facturation.PL
{
    public partial class All_Article : Form
    {
        const string connetionString = "server=localhost;user=root;database=facturation;password=";
        public static string myDocumentPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        public All_Article()
        {
            InitializeComponent();

            const string connetionString = "server=localhost;user=root;database=facturation;password=";

            MySqlConnection connection = new MySqlConnection(connetionString);
            connection.Open();

            string sqlRequset = "SELECT * FROM `marchandise`";

            MySqlCommand command = new MySqlCommand(sqlRequset, connection);
            MySqlDataReader reader = command.ExecuteReader();

            DataTable dataTable = new DataTable();
            dataTable.Load(reader);

            dgvArticle.DataSource = dataTable;

        }

        private void dgvArticle_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvArticle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnstock_Click(object sender, EventArgs e)
        {
            try
            {
                BaseFont bfTimes = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
                iTextSharp.text.Font times = new iTextSharp.text.Font(bfTimes, 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);



                DateTime currentDate = DateTime.Now;
                string dateAsString = currentDate.ToString("dd-MM-yyyy");
                String docpath = myDocumentPath + "\\Facturation\\Stock";
                String s = docpath + "\\Stock " + dateAsString + ".pdf";
                   

                Document pdfDoc = new Document(PageSize.A4, 10, 10, 10, 10);
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, new FileStream(s, FileMode.Create));
                pdfDoc.Open();


                int nbrproduit = dgvArticle.Rows.Count;
                int pagenumber = (nbrproduit / 40) + 1;
                Console.WriteLine("Page numbers : " + pagenumber);

                for (int page = 0; page < pagenumber; page++)
                {
                    if (page != 0)
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
                    tablevide.AddCell(" ");
                    tablevide.AddCell(" ");
                    tablevide.AddCell(" ");
                    tablevide.AddCell(" ");
                    tablevide.AddCell(" ");
                    tablevide.AddCell(" ");
                    tablevide.AddCell(" ");
                    tablevide.AddCell(" ");
                    tablevide.AddCell(" ");

                    pdfDoc.Add(tablevide);
                    Console.WriteLine(pdfDoc);

                    PdfPTable pdfTable = new PdfPTable(6);
                    pdfTable.WidthPercentage = 99.4f;
                    float[] widthsss = new float[] { 15f, 30f, 10f, 10f, 10f, 10f };
                    pdfTable.SetWidths(widthsss);
                    String[] headers = { "Référence", "Désignation", "Quantité", "P.U.H.T", "Gratuité", "TVA" };

                    for (int i = 0; i < headers.Length; i++)
                    {
                        //String x = headers[i];
                        pdfTable.AddCell(new Phrase(headers[i], times));
                    }


                    pdfDoc.Add(pdfTable);



                    PdfPTable pdfTable2 = new PdfPTable(6);
                    pdfTable2.WidthPercentage = 99.4f;
                    pdfTable2.DefaultCell.BorderWidth = 0;


                    float[] widthss = new float[] { 15f, 30f, 10f, 10f, 10f, 10f };
                    pdfTable2.SetWidths(widthss);


                    for (int i = 0; i < 40; i++)
                    {
                        for (int j = 0; j < 6; j++)
                        {
                            PdfPCell emptyCell = new PdfPCell(new Phrase((" ")));

                            if (i == 40 - 1)
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

                    int startindex = 40 * page;
                    int endindex = Math.Min(nbrproduit + 1, 40 * (page + 1));
                    Console.WriteLine("endindex : " + endindex);
                    Console.WriteLine("startindex : " + startindex);

                    for (int originalRowIndex = startindex; originalRowIndex < endindex; originalRowIndex++)
                    {
                        int rowIndexOnPage = originalRowIndex - startindex;

                        for (int i = 0; i < 6; i++)
                        {
                            try
                            {
                                PdfPCell celld = pdfTable2.Rows[rowIndexOnPage].GetCells()[i]; // Get the cell in the current row and column

                                if (i == 2)
                                {
                                    // Set the content of the cell from the DataGridView
                                    celld.Phrase = new Phrase(dgvArticle.Rows[originalRowIndex].Cells[i + 1].Value.ToString(), times);
                                }
                                else if (i == 3)
                                {
                                    celld.Phrase = new Phrase(dgvArticle.Rows[originalRowIndex].Cells[i - 1].Value.ToString(), times);
                                }
                                else if (i == 4)
                                {
                                    celld.Phrase = new Phrase(dgvArticle.Rows[originalRowIndex].Cells[i + 1].Value.ToString(), times);

                                }
                                else if (i == 5)
                                {
                                    celld.Phrase = new Phrase(dgvArticle.Rows[originalRowIndex].Cells[i - 1].Value.ToString(), times);
                                }
                                else
                                {
                                    celld.Phrase = new Phrase(dgvArticle.Rows[originalRowIndex].Cells[i].Value.ToString(), times);
                                }

                                // Optionally, you can set cell borders here
                                celld.BorderWidthTop = 0f;
                                if (originalRowIndex != 39)
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
                }
                pdfDoc.Close();

                MessageBox.Show("Votre Etat de stock se trouve sous " + s, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }


        }
    }
}
