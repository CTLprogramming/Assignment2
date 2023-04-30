using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShop2
{
    public partial class frmReceipts : Form
    {
        SqlDataAdapter daNames, daOrder, daOrderDetails, daOrderDetail, daCustomers, daBook; //SqlDataAdapter serves as a bridge between a DataSet and SQL Server for retrieving and saving data
        DataSet dsBookShop = new DataSet(); //declare local copy of database
        SqlCommandBuilder cmdBOrder, cmdBOrderDetails, cmdBOrderDetail, cmdBBook; //d generates single-table commands that are used to reconcile changes made to a DataSet with the associated SQL Server database
        SqlCommand cmdCustomerDetails, cmdOrder, cmdOrderDetails, cmdOrderDetail, cmdBook; //A SqlCommand object allows you to query and send commands to a database. 
        DataRow drOrder, drOrderDetails, drOrderDetail, drBook; // You add data to the data table using DataRow object
        SqlConnection conn; // Equivalent to network connection to server
        String connStr, sqlNames, sqlOrder, sqlOrderDetails, sqlOrderDetail, sqlCustomerDetails, sqlBook;

        public frmReceipts()
        {
            InitializeComponent();
        }

        private void frmReceipts_Load(object sender, EventArgs e)
        {
            MyGlobals.frmReceipt = false;




        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            var picture = new PictureBox
            {
                Name = "pictureBox",
                Size = new Size(16, 16),
                Location = new Point(100, 100),
                Image = Image.FromFile("btnLogo.png"),

            };
            e.Graphics.DrawImage(picture.Image, new Point(100, 100));
            e.Graphics.DrawString("To:\t" + MyGlobals.customer.Title + " " + MyGlobals.customer.Forename + " " + MyGlobals.customer.Surname + "\n\t" + MyGlobals.customer.Street + "\n\t" + MyGlobals.customer.Town + "\n\t" + MyGlobals.customer.County + "\n\t" + MyGlobals.customer.Postcode, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(500, 100));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog(); 

        }

    }
}
