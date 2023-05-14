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
    public partial class frmEdit : Form
    {
        SqlDataAdapter daBook, daOrder, daOrderDetail, daBooks; //SqlDataAdapter serves as a bridge between a DataSet and SQL Server for retrieving and saving data
        DataSet dsBookShop = new DataSet(); //declare local copy of database
        SqlCommandBuilder cmdBOrder, cmdBOrderDetail, cmdBBook, cmdBBooks;
        SqlCommand cmdBook, cmdOrder, cmdOrderDetail, cmdBooks; //A SqlCommand object allows you to query and send commands to a database. 
        DataRow drBook, drOrder, drOrderDetail, drBooks; // You add data to the data table using DataRow object
        SqlConnection conn; // Equivalent to network connection to server
        String connStr, sqlBook, sqlOrder, sqlOrderDetail, sqlBooks;
        long iSBN = 0;
        int stock = 0;
        List<MyOrderDetail> originalOrderDetails = new List<MyOrderDetail>();  //List to store rows
        List<MyOrderDetail> editOrderDetails = new List<MyOrderDetail>();  //List to store rows

        int orderNo = MyGlobals.selectedOrderNo;


        public frmEdit()
        {
            InitializeComponent();
        }

        private void Edit_Load(object sender, EventArgs e)
        {
            MyGlobals.frmEdit = false;

            lblCustomerNo.Text = MyGlobals.customer.Forename + " " + MyGlobals.customer.Surname;
            lblOrderNo.Text = MyGlobals.selectedOrderNo.ToString();

            connStr = @"Data Source = .\sqlexpress; Initial Catalog = BookShop; Integrated Security = true";

            conn = new SqlConnection(connStr);

            sqlBook = @"Select ISBN, BookTitle, AuthorForename, AuthorSurname, Stock, Price, SupplNo, BookTitle + '   -   ' + AuthorForename + '  ' +  AuthorSurname as details from BOOK order by BookTitle";
            cmdBook = new SqlCommand(sqlBook, conn);
            daBook = new SqlDataAdapter(cmdBook);
            daBook.FillSchema(dsBookShop, SchemaType.Source, "Book");
            daBook.Fill(dsBookShop, "Book");

            //set up dataAdapter for order
            sqlOrder = @"Select * from CustOrder order by CustOrderNo ASC";
            cmdOrder = new SqlCommand(sqlOrder, conn);
            daOrder = new SqlDataAdapter(cmdOrder);
            cmdBOrder = new SqlCommandBuilder(daOrder);
            daOrder.FillSchema(dsBookShop, SchemaType.Source, "CustOrder");
            daOrder.Fill(dsBookShop, "CustOrder");

            //set up dataAdapter to find orderDetails
            SqlDataAdapter daOrderDetails = new SqlDataAdapter(@"Select C.CustOrderNo, C.ISBN, Quantity, BookTitle, AuthorForename, AuthorSurname, Price, Stock FROM CustOrderDetails C JOIN Book B on C.ISBN = B.ISBN WHERE CustOrderNo = @RefundDetails", connStr);
            daOrderDetails.SelectCommand.Parameters.AddWithValue("@RefundDetails", orderNo);
            DataTable dtOrderDetails = new DataTable();
            daOrderDetails.Fill(dtOrderDetails);

            //Loop to store list of books in order and identical list to be adjusted.
            for (int i = 0; i < dtOrderDetails.Rows.Count; i++)
            {
                MyOrderDetail myOrderDetail = new MyOrderDetail(); //Object to store each row

                DataRow dr = dtOrderDetails.Rows[i];
                myOrderDetail.ISBN = Convert.ToInt64(dr["ISBN"]);
                myOrderDetail.Title = dr["BookTitle"].ToString();
                myOrderDetail.AuthorForename = dr["AuthorForename"].ToString();
                myOrderDetail.AuthorSurname = dr["AuthorSurname"].ToString();

                myOrderDetail.Price = Convert.ToDecimal(dr["Price"]);
                myOrderDetail.Quantity = Convert.ToInt32(dr["Quantity"]);
                myOrderDetail.Stock = Convert.ToInt32(dr["Stock"]);

                originalOrderDetails.Add(myOrderDetail);    //Stores order details saved on database
                editOrderDetails.Add(myOrderDetail);    //Stores the adjusted order to replace the saved order
            }

            fillListboxBooks();
            fillFlpCart();

        }

        private void fillListboxBooks()
        {
            // fill listbox
            lstBook.DataSource = dsBookShop.Tables["Book"];
            lstBook.DisplayMember = "details";
            lstBook.ValueMember = "ISBN";
        }
        private void fillFlpCart()
        {
            flpCart.Controls.Clear();
            for (int i = 0; i < editOrderDetails.Count; i++)
            {
                System.Windows.Forms.Label label0 = new System.Windows.Forms.Label();
                label0.Size = new Size(300, 75);
                label0.Font = new Font("Serif", 12);
                label0.Tag = i;

                System.Windows.Forms.Label label1 = new System.Windows.Forms.Label();
                label1.TextAlign = ContentAlignment.MiddleRight;
                label1.Font = new Font("Serif", 12);
                label1.Tag = i + "a";

                System.Windows.Forms.ComboBox combo = new System.Windows.Forms.ComboBox();
                combo.Size = new Size(50, 20);
                combo.Font = new Font("Serif", 12);
                combo.Tag = i;
                combo.SelectedIndexChanged += combo_SelectedIndexChanged;
                combo.DropDownStyle = ComboBoxStyle.DropDownList;


                flpCart.Controls.Add(label0);
                flpCart.Controls.Add(label1);
                flpCart.Controls.Add(combo);

                label0.Text = editOrderDetails[i].Title + "\n" + editOrderDetails[i].AuthorForename + " " + editOrderDetails[i].AuthorSurname;
                label1.Text = String.Format("{0:0.00}", editOrderDetails[i].Price);

                combo.Items.Clear();
                for (int j = 0; j <= (editOrderDetails[i].Stock + editOrderDetails[i].Quantity); j++)
                {
                    combo.Items.Add(j);
                    if (j == 9) break;
                }
                combo.SelectedIndex = editOrderDetails[i].Quantity;
                lblTotal.Text = "£  " + String.Format("{0:0.00}", CalculateTotal());
            }
        }


        private void combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            int tag = (int)comboBox.Tag;
            foreach (Control c in flpCart.Controls)
            {
                if (c.GetType() == typeof(ComboBox) && c.Tag.Equals(tag))
                    editOrderDetails[tag].Quantity = Convert.ToInt32(comboBox.Text);
                lblTotal.Text = "£  " + String.Format("{0:0.00}", CalculateTotal());
            }
            if (CalculateTotal() > 0)
            {
                btnConfirmEdit.Visible = true;
            }
            else { btnConfirmEdit.Visible = false; }
        }

        private decimal CalculateTotal()
        {
            MyGlobals.cart = 0;
            decimal total = 0;
            for (int i = 0; i < editOrderDetails.Count; i++)
            {
                total = total + editOrderDetails[i].Price * editOrderDetails[i].Quantity;
                MyGlobals.cart += editOrderDetails[i].Quantity;
            }
            frmMain.instance.lblCartQuant.Text = MyGlobals.cart.ToString();
            return total;
        }


        private void lstBook_Click(object sender, EventArgs e)
        {
            drBook = dsBookShop.Tables["Book"].Rows.Find(lstBook.SelectedValue);

            iSBN = Convert.ToInt64(drBook["ISBN"].ToString());
            stock = Convert.ToInt32(drBook["Stock"].ToString());

            //CHECK STOCK   
            int cartStock = 0;      //FIND WHAT'S ALREADY IN THE CART (= cartStock)
            for (int i = 0; i < editOrderDetails.Count; i++)
            {
                if (editOrderDetails[i].ISBN == iSBN)
                {
                    cartStock = editOrderDetails[i].Quantity;
                }
            }
            if (stock > 0)
            {
                btnAddBook.Enabled = true;
                btnAddBook.BackColor = Color.FromArgb(45, 80, 150);
                btnAddBook.FlatAppearance.BorderColor = Color.FromArgb(45, 80, 150);
            }
            else
            {
                btnAddBook.Enabled = false;
                btnAddBook.BackColor = Color.FromKnownColor(KnownColor.ControlLight);
                btnAddBook.FlatAppearance.BorderColor = Color.FromKnownColor(KnownColor.ControlLight);
            }
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            drBook = dsBookShop.Tables["Book"].Rows.Find(iSBN);

            MyOrderDetail myOrderDetail = new MyOrderDetail();
            myOrderDetail.ISBN = iSBN;
            myOrderDetail.Title = drBook["BookTitle"].ToString();
            myOrderDetail.AuthorForename = drBook["AuthorForename"].ToString();
            myOrderDetail.AuthorSurname = drBook["AuthorSurname"].ToString();

            myOrderDetail.Quantity = 1;
            myOrderDetail.Price = Convert.ToDecimal(drBook["Price"].ToString());
            myOrderDetail.Stock = stock;

            //Check if this is a duplicate order and update quantity to existing order if true or add another myOrderDetail to list.
            bool duplicate = false;
            for (int i = 0; i < editOrderDetails.Count; i++)
            {
                if (editOrderDetails[i].ISBN == iSBN)
                {
                    duplicate = true;
                    if (editOrderDetails[i].Quantity < 9)
                    {
                        editOrderDetails[i].Quantity += 1;   //Restrict to 9 books max
                        MyGlobals.cart += 1;
                    }
                    else
                    {
                        editOrderDetails[i].Quantity = 9;

                        btnAddBook.Enabled = false;
                        btnAddBook.BackColor = Color.FromKnownColor(KnownColor.ControlLight);
                        btnAddBook.FlatAppearance.BorderColor = Color.FromKnownColor(KnownColor.ControlLight);
                    }
                }
            }
            if (duplicate == false)
            {
                editOrderDetails.Add(myOrderDetail);
                MyGlobals.cart += 1;

            }
            fillFlpCart();
            //UPDATE CART IN TOP RIGHT CORNER
            updateCart(MyGlobals.cart);

        }

        public void updateCart(int quantity)
        {
            frmMain.instance.lblCartQuant.Text = quantity.ToString();
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

        private void btnConfirmEdit_Click(object sender, EventArgs e)
        {
            //set up dataAdapter to find orderDetails
            SqlDataAdapter daOrderDetails = new SqlDataAdapter(@"Select C.CustOrderNo, C.ISBN, Quantity, BookTitle, AuthorForename, AuthorSurname, Price, Stock FROM CustOrderDetails C JOIN Book B on C.ISBN = B.ISBN WHERE CustOrderNo = @RefundDetails", connStr);
            daOrderDetails.SelectCommand.Parameters.AddWithValue("@RefundDetails", orderNo);
            DataTable dtOrderDetails = new DataTable();
            daOrderDetails.Fill(dtOrderDetails);

            //set up dataAdapter for book
            sqlBooks = @"Select * from Book";
            cmdBooks = new SqlCommand(sqlBooks, conn);
            daBooks = new SqlDataAdapter(cmdBooks);
            cmdBBooks = new SqlCommandBuilder(daBooks);
            daBooks.FillSchema(dsBookShop, SchemaType.Source, "Book");
            daBooks.Fill(dsBookShop, "Book");

            //Loop to store list of books in order
            for (int i = 0; i < dtOrderDetails.Rows.Count; i++)
            {
                DataRow dr = dtOrderDetails.Rows[i];

                try         //Put original order books back in database
                {
                    drBooks = dsBookShop.Tables["Book"].Rows.Find(Convert.ToInt64(dr["ISBN"]));

                    drBooks.BeginEdit();

                    drBooks["Stock"] = Convert.ToInt16(drBooks["Stock"].ToString()) + Convert.ToInt32(dr["Quantity"]);

                    drBooks.EndEdit();
                    daBooks.Update(dsBookShop, "Book");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.TargetSite + "" + ex.Message, "Error!",
                    MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                }
            }

            //set up dataAdapter for orderDetail
            sqlOrderDetail = @"Select * from CustOrderDetails";
            cmdOrderDetail = new SqlCommand(sqlOrderDetail, conn);
            daOrderDetail = new SqlDataAdapter(cmdOrderDetail);
            cmdBOrderDetail = new SqlCommandBuilder(daOrderDetail);
            daOrderDetail.FillSchema(dsBookShop, SchemaType.Source, "CustOrderDetails");
            daOrderDetail.Fill(dsBookShop, "CustOrderDetails");

            // find all rows that match the order number and delete them
            DataRow[] rowsToDelete = dsBookShop.Tables["CustOrderDetails"].Select("CustOrderNo = " + orderNo);
            foreach (DataRow rowToDelete in rowsToDelete)
            {
                rowToDelete.Delete();
            }

            // update the database with the changes
            daOrderDetail.Update(dsBookShop, "CustOrderDetails");

            editOrder();
            addOrderDetails();
        }

        private void editOrder()
        {
            for (int i = 0; i < dsBookShop.Tables["CustOrder"].Rows.Count; i++)  //Updates order in the database
            {
                try
                {
                    drOrder = dsBookShop.Tables["CustOrder"].Rows[i];
                    if (int.Parse(drOrder["CustOrderNo"].ToString()) == orderNo)
                    {
                        drOrder.BeginEdit();
                        drOrder["CustOrderDate"] = DateTime.Now;
                        drOrder["CustDispatchDate"] = DateTime.Now;
                        drOrder.EndEdit();
                        daOrder.Update(dsBookShop, "CustOrder");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.TargetSite + "" + ex.Message, "Error!",
                    MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                }
            }
        }
        private void addOrderDetails()
        {
            for (int i = 0; i < editOrderDetails.Count; i++)
            {
                if(editOrderDetails[i].Quantity>0)
                try
                {
                    drOrderDetail = dsBookShop.Tables["CustOrderDetails"].NewRow();

                    drOrderDetail["ISBN"] = editOrderDetails[i].ISBN;
                    drOrderDetail["CustOrderNo"] = orderNo;
                    drOrderDetail["Quantity"] = editOrderDetails[i].Quantity;

                    dsBookShop.Tables["CustOrderDetails"].Rows.Add(drOrderDetail);
                    daOrderDetail.Update(dsBookShop, "CustOrderDetails");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.TargetSite + "" + ex.Message, "Error!",
                    MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                }
            }
            for (int i = 0; i < editOrderDetails.Count; i++)
            {
                drBooks = dsBookShop.Tables["Book"].Rows.Find(editOrderDetails[i].ISBN);

                if (editOrderDetails[i].Quantity > 0)
                    try
                    {
                    drBooks = dsBookShop.Tables["Book"].Rows.Find(editOrderDetails[i].ISBN);

                    drBooks.BeginEdit();

                    drBooks["Stock"] = Convert.ToInt16(drBooks["Stock"].ToString()) - editOrderDetails[i].Quantity;

                    drBooks.EndEdit();
                    daBooks.Update(dsBookShop, "Book");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.TargetSite + "" + ex.Message, "Error!",
                    MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                }
                if (i == editOrderDetails.Count - 1)
                    MessageBox.Show("New order details saved for: \n" + MyGlobals.customer.Forename + " " + MyGlobals.customer.Surname, "Order No: "+orderNo);
            }
            MyGlobals.orderDetails.Clear();
            MyGlobals.customer = null;
            MyGlobals.cart = 0;
            frmMain.instance.lblCartQuant.Text = MyGlobals.cart.ToString();
            MyGlobals.frmCustomer = true;
            Close();
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



    }
}
