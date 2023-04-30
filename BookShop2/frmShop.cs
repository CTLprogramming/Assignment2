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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BookShop2
{
    public partial class frmShop : Form
    {

        SqlDataAdapter daBook; //SqlDataAdapter serves as a bridge between a DataSet and SQL Server for retrieving and saving data
        DataSet dsBookShop = new DataSet(); //declare local copy of database
        SqlCommand cmdBook; //A SqlCommand object allows you to query and send commands to a database. 
        DataRow drBook; // You add data to the data table using DataRow object
        SqlConnection conn; // Equivalent to network connection to server
        String connStr, sqlBook;
        long iSBN = 0;
        int stock = 0;

        public frmShop()
        {
            InitializeComponent();
        }

        private void frmShop_Load(object sender, EventArgs e)
        {
            MyGlobals.frmShop = false;

            if (MyGlobals.customer == null || MyGlobals.customer.IdNo == 0)
            {
                lblCustomer.Text = "(none selected)";
            }
            else
                lblCustomer.Text = MyGlobals.customer.Forename + " " + MyGlobals.customer.Surname;

            if (lblCustomer.Text == "(none selected)")
                btnChangeCust.Text = "Search";

            connStr = @"Data Source = .\sqlexpress; Initial Catalog = BookShop; Integrated Security = true";

            //set up dataAdapter for book details for the book listbox
            sqlBook = @"Select ISBN, BookTitle, AuthorForename, AuthorSurname, Stock, Price, SupplNo, BookTitle + '   -   ' + AuthorForename + '  ' +  AuthorSurname as details from BOOK order by BookTitle";
            conn = new SqlConnection(connStr);
            cmdBook = new SqlCommand(sqlBook, conn);
            daBook = new SqlDataAdapter(cmdBook);
            daBook.FillSchema(dsBookShop, SchemaType.Source, "Book");
            daBook.Fill(dsBookShop, "Book");


            fillListboxBooks();



        }

        private void fillListboxBooks()
        {
            // fill listbox
            lstBook.DataSource = dsBookShop.Tables["Book"];
            lstBook.DisplayMember = "details";
            lstBook.ValueMember = "ISBN";
        }

        private void btnChangeCust_Click(object sender, EventArgs e)
        {
            MyGlobals.frmCustomer = true;
            Close();
        }


        private void btnAuthorTitle_Click(object sender, EventArgs e)
        {
            if (btnAuthorTitle.Text == "Author")
            {
                sqlBook = @"Select ISBN, BookTitle, AuthorForename, AuthorSurname, Stock, Price, SupplNo, AuthorForename +' '+ AuthorSurname + '   -   ' +  BookTitle as details from BOOK order by AuthorSurname";
                btnAuthorTitle.Text = "Title";
            }
            else
            {
                sqlBook = @"Select ISBN, BookTitle, AuthorForename, AuthorSurname, Stock, Price, SupplNo, BookTitle + '   -   ' +  AuthorForename +', '+ AuthorSurname as details from BOOK order by BookTitle";
                btnAuthorTitle.Text = "Author";
            }
            cmdBook = new SqlCommand(sqlBook, conn);
            daBook = new SqlDataAdapter(cmdBook);
            daBook.FillSchema(dsBookShop, SchemaType.Source, "Book");
            dsBookShop.Clear();
            daBook.Fill(dsBookShop, "Book");
            fillListboxBooks();
        }

        private void lstBook_Click(object sender, EventArgs e)
        {
            drBook = dsBookShop.Tables["Book"].Rows.Find(lstBook.SelectedValue);
            lblLowStock.Visible = false;
            lblBookOrderMessage.Visible = false;

            txtBookTitle.Text = drBook["BookTitle"].ToString();
            txtBookAuthor.Text = drBook["AuthorForename"].ToString() +" "+ drBook["AuthorSurname"].ToString();
            txtBookPrice.Text = String.Format("{0:0.00}", drBook["Price"]);
            iSBN = Convert.ToInt64(drBook["ISBN"].ToString());
            stock = Convert.ToInt32(drBook["Stock"].ToString());

            //CHECK STOCK   
            int cartStock = 0;      //FIND WHAT'S ALREADY IN THE CART (= cartStock)
            for (int i = 0; i < MyGlobals.orderDetails.Count; i++)
            {
                if (MyGlobals.orderDetails[i].ISBN == iSBN)
                {
                    cartStock = MyGlobals.orderDetails[i].Quantity;
                }
            }
            if (Convert.ToInt16(drBook["Stock"].ToString()) - cartStock > 0)
            {
                cmbBookQuantity.Enabled = true;
                cmbBookQuantity.Items.Clear();
                for (int i = 0; i < Convert.ToInt16(drBook["Stock"].ToString()) - cartStock; i++)
                {
                    this.cmbBookQuantity.Items.Add(i + 1);
                    if (i == 8) break;
                }
                if (Convert.ToInt16(drBook["Stock"].ToString()) < 6)
                    lblLowStock.Visible = true;


            }
            else
            {
                cmbBookQuantity.Items.Clear();
                this.cmbBookQuantity.Items.Add("Out of stock");
                cmbBookQuantity.Enabled = false;
                lblLowStock.Visible = false;

            }

            cmbBookQuantity.SelectedIndex = 0;
            if (Convert.ToInt16(drBook["Stock"].ToString()) > 0)
            {
                btnAddBook.Enabled = true;
                btnAddBook.BackColor = Color.FromArgb(45, 80, 150);
                btnAddBook.FlatAppearance.BorderColor = Color.FromArgb(45, 80, 150);
                btnCancelBook.Enabled = true;
                btnCancelBook.BackColor = Color.FromArgb(45, 80, 150);
                btnCancelBook.FlatAppearance.BorderColor = Color.FromArgb(45, 80, 150);
            }
            else
            {
                btnAddBook.Enabled = false;
                btnAddBook.BackColor = Color.FromKnownColor(KnownColor.ControlLight);
                btnAddBook.FlatAppearance.BorderColor = Color.FromKnownColor(KnownColor.ControlLight);
            }

        }

        private void btnCancelBook_Click(object sender, EventArgs e)
        {
            clearForm();
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            drBook = dsBookShop.Tables["Book"].Rows.Find(iSBN);

            MyOrderDetail myOrderDetail = new MyOrderDetail();
            myOrderDetail.ISBN = iSBN;
            myOrderDetail.Title = txtBookTitle.Text;
            myOrderDetail.AuthorForename = drBook["AuthorForename"].ToString();
            myOrderDetail.AuthorSurname = drBook["AuthorSurname"].ToString();

            myOrderDetail.Quantity = Convert.ToInt32(cmbBookQuantity.Text);
            myOrderDetail.Price = Convert.ToDecimal(txtBookPrice.Text);
            myOrderDetail.Stock = stock;

            //Check if this is a duplicate order and update quantity to existing order if true or add another myOrderDetail to list.
            bool duplicate = false;
            for (int i = 0; i < MyGlobals.orderDetails.Count; i++)
            {
                if (MyGlobals.orderDetails[i].ISBN == iSBN)
                {
                    duplicate = true;
                    MyGlobals.orderDetails[i].Quantity = MyGlobals.orderDetails[i].Quantity + myOrderDetail.Quantity;
                    break;
                }
            }
            if (duplicate == false)
            {
                MyGlobals.orderDetails.Add(myOrderDetail);
            }

            MyGlobals.cart += myOrderDetail.Quantity;
            lblBookOrderMessage.Visible = true;

            //UPDATE CART IN TOP RIGHT CORNER
            updateCart(MyGlobals.cart);

            clearForm();

            btnCheckout.Enabled = true;
            btnCheckout.BackColor = Color.FromArgb(45, 80, 150);
            btnCheckout.FlatAppearance.BorderColor = Color.FromArgb(45, 80, 150);


        }
        public void updateCart(int quantity)
        {
            frmMain.instance.lblCartQuant.Text = quantity.ToString();
        }

        private void clearForm()
        {
            btnAddBook.Enabled = false;
            btnCancelBook.Enabled = false;

            txtBookTitle.Text = "";
            txtBookAuthor.Text = "";
            txtBookPrice.Text = "";
            cmbBookQuantity.SelectedIndex = -1;
            cmbBookQuantity.Enabled = false;

            btnAddBook.BackColor = Color.FromKnownColor(KnownColor.ControlLight);
            btnAddBook.FlatAppearance.BorderColor = Color.FromKnownColor(KnownColor.ControlLight);
            btnCancelBook.BackColor = Color.FromKnownColor(KnownColor.ControlLight);
            btnCancelBook.FlatAppearance.BorderColor = Color.FromKnownColor(KnownColor.ControlLight);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {   
            SqlDataAdapter daBooks = new SqlDataAdapter("Select *, BookTitle + '   -   ' + AuthorForename + '  ' +  AuthorSurname as details from BOOK WHERE BookTitle LIKE '%' +@parm1 +'%' OR AuthorForename LIKE '%' +@parm1 +'%' OR AuthorSurname LIKE '%' +@parm1 +'%'", connStr);
            daBooks.SelectCommand.Parameters.AddWithValue("@parm1", txtSearch.Text);
            DataTable dtBooks = new DataTable();
            daBooks.Fill(dtBooks);
            lstBook.DataSource = dtBooks;
            lstBook.DisplayMember = "details";
            lstBook.ValueMember = "ISBN";

        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            MyGlobals.frmCheckout = true;
            Close();
        }
    }
}
