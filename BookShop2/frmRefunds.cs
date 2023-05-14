using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShop2
{
    public partial class frmRefunds : Form
    {
        Button[] btns = new Button[26];

        SqlDataAdapter daNames, daOrder, daOrderDetails, daOrderDetail, daCustomers, daBook; //SqlDataAdapter serves as a bridge between a DataSet and SQL Server for retrieving and saving data
        DataSet dsBookShop = new DataSet(); //declare local copy of database
        SqlCommandBuilder cmdBOrder, cmdBOrderDetails, cmdBOrderDetail, cmdBBook; //d generates single-table commands that are used to reconcile changes made to a DataSet with the associated SQL Server database
        SqlCommand cmdCustomerDetails, cmdOrder, cmdOrderDetails, cmdOrderDetail, cmdBook; //A SqlCommand object allows you to query and send commands to a database. 
        DataRow drOrder, drOrderDetails, drOrderDetail, drBook; // You add data to the data table using DataRow object
        SqlConnection conn; // Equivalent to network connection to server
        String connStr, sqlNames, sqlOrder, sqlOrderDetails, sqlOrderDetail, sqlCustomerDetails, sqlBook;


        List<MyOrderDetail> orderDetails = new List<MyOrderDetail>();  //List to store rows
        MyCustomer myCustomer = new MyCustomer();
        int custOrderNo = 0;
        int custNo = 0;

        public frmRefunds()
        {
            InitializeComponent();
        }

        private void frmRefunds_Load(object sender, EventArgs e)
        {
            MyGlobals.frmRefunds = false;
            int no;

            for (int i = 0; i < 26; i++)
            {
                btns[i] = (Button)pnlButtons.Controls[i];
                btns[i].Text = "" + (char)(65 + i);
                btns[i].Enabled = false;
                btns[i].Click += new EventHandler(button1_Click);
            }

            connStr = @"Data Source = .\sqlexpress; Initial Catalog = BookShop; Integrated Security = true";

            //get surnames for alphabet buttons
            sqlNames = @"Select surname from customer order by surname";
            daNames = new SqlDataAdapter(sqlNames, connStr);
            daNames.Fill(dsBookShop, "Names");

            //enable relevant alpha buttons
            foreach (DataRow dr in dsBookShop.Tables["Names"].Rows)
            {
                if (!Convert.IsDBNull(dr["Surname"]))
                {
                    no = dr["Surname"].ToString()[0] - 65;
                    btns[no].Enabled = true;
                    btns[no].BackColor = Color.FromArgb(45, 80, 150);
                    btns[no].FlatAppearance.BorderColor = Color.FromArgb(45, 80, 150);
                    btns[no].ForeColor = Color.White;
                }
            }

            //set up dataAdapter for customer details for the listbox
            sqlCustomerDetails = @"Select CustNo, custTitle, forename, surname, surname + ', ' + Forename + ', (' + CONVERT(VARCHAR(10), CustNo) + ')' as name, custStreet, custTown, custCounty, custPostcode, custTel, custEmail, Marketing from customer where surname LIKE @Letter order by surname, forename ";
            conn = new SqlConnection(connStr);
            cmdCustomerDetails = new SqlCommand(sqlCustomerDetails, conn);
            cmdCustomerDetails.Parameters.Add("@Letter", SqlDbType.VarChar);
            daCustomers = new SqlDataAdapter(cmdCustomerDetails);
            daCustomers.FillSchema(dsBookShop, SchemaType.Source, "Customer");

            //set up dataAdapter for order
            sqlOrder = @"Select * from CustOrder";
            cmdOrder = new SqlCommand(sqlOrder, conn);
            daOrder = new SqlDataAdapter(cmdOrder);
            cmdBOrder = new SqlCommandBuilder(daOrder);
            daOrder.FillSchema(dsBookShop, SchemaType.Source, "CustOrder");
            daOrder.Fill(dsBookShop, "CustOrder");

            //set up dataAdapter for orderDetail
            sqlOrderDetail = @"Select * from CustOrderDetails";
            cmdOrderDetail = new SqlCommand(sqlOrderDetail, conn);
            daOrderDetail = new SqlDataAdapter(cmdOrderDetail);
            cmdBOrderDetail = new SqlCommandBuilder(daOrderDetail);
            daOrderDetail.FillSchema(dsBookShop, SchemaType.Source, "CustOrderDetails");
            daOrderDetail.Fill(dsBookShop, "CustOrderDetails");

            //set up dataAdapter for book
            sqlBook = @"Select * from Book";
            cmdBook = new SqlCommand(sqlBook, conn);
            daBook = new SqlDataAdapter(cmdBook);
            cmdBBook = new SqlCommandBuilder(daBook);
            daBook.FillSchema(dsBookShop, SchemaType.Source, "Book");
            daBook.Fill(dsBookShop, "Book");

        }

        private void button1_Click(object sender, EventArgs e)  //alphabet buttons
        {
            Button b = (Button)sender;
            // get customer details for listbox - use selected button letter for parameter
            String str = b.Text;
            // empty dataset table customer
            dsBookShop.Tables["Customer"].Clear();

            fillListboxCustomers(str);
        }

        private void fillListboxCustomers(String str)
        {
            lblCustomer.Text = "";
            lblRefundTotal.Text = "";
            // get all customer details for listbox - use wildcard for parameter
            cmdCustomerDetails.Parameters["@Letter"].Value = str + "%";
            daCustomers.Fill(dsBookShop, "Customer");

            // fill listbox
            lstCustomer.DataSource = dsBookShop.Tables["Customer"];
            lstCustomer.DisplayMember = "name";
            lstCustomer.ValueMember = "CustNo";

            DataRow drCustomer = dsBookShop.Tables["Customer"].Rows.Find(lstCustomer.SelectedValue);
            myCustomer.IdNo = Convert.ToInt16(drCustomer["CustNo"].ToString());
            myCustomer.Title = drCustomer["CustTitle"].ToString();
            myCustomer.Forename = drCustomer["Forename"].ToString();
            myCustomer.Surname = drCustomer["Surname"].ToString();
            myCustomer.Street = drCustomer["CustStreet"].ToString();
            myCustomer.Town = drCustomer["CustTown"].ToString();
            myCustomer.County = drCustomer["CustCounty"].ToString();
            myCustomer.Postcode = drCustomer["CustPostcode"].ToString();
            myCustomer.TelNo = drCustomer["CustTel"].ToString();
            myCustomer.Email = drCustomer["CustEmail"].ToString();
            myCustomer.Marketing = Convert.ToBoolean(drCustomer["Marketing"].ToString());

            lblCustomer.Text = drCustomer["Forename"].ToString() + " " + drCustomer["Surname"].ToString() + " (" + lstCustomer.SelectedValue.ToString() + ")";
            custNo = Convert.ToInt32(drCustomer["CustNo"].ToString());

        }


        private void lstCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblRefundTotal.Text = "";
            lstOrders.DataSource = null;
            orderDetails.Clear();
            if (lstCustomer.SelectedItem != null)
            {
                DataRowView drv = lstCustomer.SelectedItem as DataRowView;
                if (drv != null)
                {
                    SqlDataAdapter daOrders = new SqlDataAdapter("SELECT *, CONVERT(VARCHAR(10), CustOrderNo) + '    -    (' + CONVERT(VARCHAR, CustOrderDate,23) + ') ' as OrderAndDate FROM CustOrder WHERE CustNo = @CustNo AND  Refund = 0", connStr);  //excludes refund orders
                    daOrders.SelectCommand.Parameters.AddWithValue("@CustNo", (int)drv["CustNo"]);
                    DataTable dtOrders = new DataTable();
                    daOrders.Fill(dtOrders);
                    lstOrders.DataSource = dtOrders;
                    lstOrders.DisplayMember = "OrderAndDate";
                }
            }
            if (lstOrders.Items.Count == 0)
            {
                btnIgnoreDelete.Visible = false;
                btnIgnoreDelete.BackColor = Color.Silver;
                btnEdit.Visible = false;
                btnIgnoreDelete.Text = "Ignore";
                lblSelectQuantity.Visible = false;

            }
        }

        private void lstOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnIgnoreDelete.Visible = false;
            btnIgnoreDelete.BackColor = Color.Silver;
            btnEdit.Visible = false;
            btnIgnoreDelete.Text = "Ignore";
            lblSelectQuantity.Visible = false;

            lblRefundTotal.Text = "";
            flpOrderDetails.Controls.Clear();
            btnPrintLabel.Visible = false;
            btnPrintReceipt.Visible = false;
            btnConfirmRefund.Visible = false;
            if (lstOrders.SelectedItem != null)
            {
                btnPrintLabel.Visible = true;
                btnPrintReceipt.Visible = true;

                DataRowView drv = lstOrders.SelectedItem as DataRowView;
                if (drv != null)
                {
                     custOrderNo = Convert.ToInt32(drv["CustOrderNo"]);
                    fillFlpOrderDetails(custOrderNo);
                }
            }
            if (lstOrders.Items.Count != 0)
            {
                btnIgnoreDelete.Visible = true;
                lblSelectQuantity.Visible = true;
            }
        }

        private void fillFlpOrderDetails(int orderNo)
        {
            SqlDataAdapter daOrderDetails = new SqlDataAdapter(@"Select C.CustOrderNo, C.ISBN, Quantity, BookTitle, AuthorForename, AuthorSurname, Price FROM CustOrderDetails C JOIN Book B on C.ISBN = B.ISBN WHERE CustOrderNo = @RefundDetails", connStr);
            daOrderDetails.SelectCommand.Parameters.AddWithValue("@RefundDetails", orderNo);
            DataTable dtOrderDetails = new DataTable();
            daOrderDetails.Fill(dtOrderDetails);

            orderDetails.Clear();  //List of myOrders.
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
                myOrderDetail.Stock = 0;        //Stores the number of books to be refunded and restocked

                orderDetails.Add(myOrderDetail);
            }
            for (int i = 0; i < dtOrderDetails.Rows.Count; i++)
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

                flpOrderDetails.Controls.Add(label0);
                flpOrderDetails.Controls.Add(label1);
                flpOrderDetails.Controls.Add(combo);

                label0.Text = orderDetails[i].Title + "\n" + orderDetails[i].AuthorForename + " " + orderDetails[i].AuthorSurname;
                label1.Text = String.Format("{0:0.00}", orderDetails[i].Price);

                combo.Items.Clear();
                for (int j = 0; j <= orderDetails[i].Quantity; j++)
                {
                    combo.Items.Add(j);
                }
                if (orderDetails[i].Quantity > 0)
                    combo.SelectedIndex = orderDetails[i].Stock - 1;
            }
        }

        private void combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            int tag = (int)comboBox.Tag;
            foreach (Control c in flpOrderDetails.Controls)
            {
                if (c.GetType() == typeof(ComboBox) && c.Tag.Equals(tag))
                    //                    listBox1.Items.Add(Convert.ToInt32(comboBox.Text));
                    orderDetails[tag].Stock = Convert.ToInt32(comboBox.Text);

                if (CalculateTotal() > 0)
                    lblRefundTotal.Text = "£  " + String.Format("{0:0.00}", CalculateTotal());
                else
                    lblRefundTotal.Text = "";

                if (lblCustomer.Text.Length > 0 && lblRefundTotal.Text.Length > 0)
                    btnConfirmRefund.Visible = true;
                else btnConfirmRefund.Visible = false;

            }
        }

        private decimal CalculateTotal()
        {
            decimal total = 0;
            for (int i = 0; i < orderDetails.Count; i++)
            {
                total = total + orderDetails[i].Price * orderDetails[i].Stock;

            }
            return total;
        }
        private void printLabel_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            var picture = new PictureBox
            {
                Name = "pictureBox",
                Size = new Size(16, 16),
                Location = new Point(100, 100),
                Image = Image.FromFile("btnLogo.png"),

            };
            e.Graphics.DrawImage(picture.Image, new Point(100, 100));
            e.Graphics.DrawString("To:\t" + myCustomer.Title + " " + myCustomer.Forename + " " + myCustomer.Surname + "\n\t" + myCustomer.Street + "\n\t" 
                + myCustomer.Town + "\n\t" + myCustomer.County + "\n\t" + myCustomer.Postcode, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(500, 100));

        }

        private void btnPrintLabel_Click(object sender, EventArgs e)
        {
            printPreviewDialogLabel.Document = printLabel;
            printPreviewDialogLabel.ShowDialog();
        }


        private void printReceipt_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            var picture = new PictureBox
            {
                Name = "pictureBox",
                Size = new Size(64, 40),
                Location = new Point(0, 0),
                Image = Image.FromFile("btnLogo.png"),

            };
            e.Graphics.DrawImage(picture.Image, new Point(585, 50));
            e.Graphics.DrawString("RECEIPT", new Font("Arial", 24, FontStyle.Bold), Brushes.Black, new Point(100, 100));
            e.Graphics.DrawString("" + myCustomer.Title + " " + myCustomer.Forename + " " + myCustomer.Surname, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(100, 240));
            e.Graphics.DrawString("" + DateTime.Now.ToString("dddd, dd MMMM yyyy"), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(560, 240));


            decimal total = 0;
            for (int i = 0; i < orderDetails.Count; i++)
            {
                e.Graphics.DrawString("" + orderDetails[i].Title + "\n" + orderDetails[i].AuthorForename + " " + orderDetails[i].AuthorSurname, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(100, 350+(i*60)));
                e.Graphics.DrawString(""  + orderDetails[i].Quantity, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(580, 350 + (i * 60)));
                e.Graphics.DrawString("£ ", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(630, 350 + (i * 60)));
                e.Graphics.DrawString(""  + string.Format("{0:0.00}", orderDetails[i].Price).PadLeft(10), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(650, 350 + (i * 60)));

                total += orderDetails[i].Price * orderDetails[i].Quantity;
                if (i == orderDetails.Count - 1)
                {
                    e.Graphics.DrawString(""+ string.Format("{0:0.00}", "Total:      £").PadLeft(10), new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(560, 450 + (i * 60)));
                    e.Graphics.DrawString("" + string.Format("{0:0.00}", total).PadLeft(10), new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(650, 450 + (i * 60)));
                }
            }


        }

        private void btnPrintReceipt_Click(object sender, EventArgs e)
        {
            printPreviewDialogReceipt.Document = printReceipt;
            printPreviewDialogReceipt.ShowDialog();
        }


        private void btnConfirmRefund_Click(object sender, EventArgs e)
        {
            int noRows = dsBookShop.Tables["CustOrder"].Rows.Count;
            if (noRows == 0)
                custOrderNo = 60000;
            else
            {
                getNumber(noRows);
            }

            try
            {
                drOrder = dsBookShop.Tables["CustOrder"].NewRow();          //Create new  Refund order in Database (Refund = true)

                drOrder["CustOrderNo"] = custOrderNo;
                drOrder["CustNo"] = custNo;
                drOrder["CustOrderDate"] = DateTime.Now;
                drOrder["CustDispatchDate"] = DateTime.Now;
                drOrder["Refund"] = 1;                              //true

                dsBookShop.Tables["CustOrder"].Rows.Add(drOrder);
                daOrder.Update(dsBookShop, "CustOrder");

            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.TargetSite + "" + ex.Message, "Error!",
                MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }

            for (int i = 0; i < orderDetails.Count; i++)                    //Record orderDetails for each book in database
            {
                try
                {
                    drOrderDetail = dsBookShop.Tables["CustOrderDetails"].NewRow();
                    if (orderDetails[i].Stock > 0)
                    {
                        drOrderDetail["ISBN"] = orderDetails[i].ISBN;
                        drOrderDetail["CustOrderNo"] = custOrderNo;
                        drOrderDetail["Quantity"] = orderDetails[i].Stock;

                        dsBookShop.Tables["CustOrderDetails"].Rows.Add(drOrderDetail);
                        daOrderDetail.Update(dsBookShop, "CustOrderDetails");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.TargetSite + "" + ex.Message, "Error!",
                    MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                }
            }
            for (int i = 0; i < orderDetails.Count; i++)                        //Return stock to database book table
            {
                try
                {
                    drBook = dsBookShop.Tables["Book"].Rows.Find(orderDetails[i].ISBN);

                    drBook.BeginEdit();

                    drBook["Stock"] = Convert.ToInt16(drBook["Stock"].ToString()) + orderDetails[i].Stock;

                    drBook.EndEdit();
                    daBook.Update(dsBookShop, "Book");

                    if (i == orderDetails.Count - 1)
                        MessageBox.Show("Refund has been processed for: \n" + myCustomer.Forename + " " + myCustomer.Surname, "Refund No: " + custOrderNo);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.TargetSite + "" + ex.Message, "Error!",
                    MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                }


                MyGlobals.frmRefunds = true;
                Close();

            }
        }

        private void getNumber(int noRows)      //
        {
            drOrder = dsBookShop.Tables["CustOrder"].Rows[noRows - 1];     // dr - datarow
            custOrderNo = (int.Parse(drOrder["CustOrderNo"].ToString()) + 1);
        }

        private void btnIgnoreDelete_Click(object sender, EventArgs e)
        {
            if (btnIgnoreDelete.Text == "Ignore")
            {
                btnIgnoreDelete.Text = "Delete";
                btnIgnoreDelete.BackColor = Color.FromArgb(45, 80, 150);
                btnEdit.Visible = true;
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Delete entire record of order without refund?", "Delete Order", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    deleteOrder();
                }
                else
                {
                    //Don't delete and continue
                }
            }
        }

        private void deleteOrder()
        {
            for (int i = 0; i < orderDetails.Count; i++)  //returns ordered stock to Book Table in database.
            {
                drBook = dsBookShop.Tables["Book"].Rows.Find(orderDetails[i].ISBN);

                try
                {
                    drBook = dsBookShop.Tables["Book"].Rows.Find(orderDetails[i].ISBN);

                    drBook.BeginEdit();

                    drBook["Stock"] = Convert.ToInt16(drBook["Stock"].ToString()) + orderDetails[i].Quantity;

                    drBook.EndEdit();
                    daBook.Update(dsBookShop, "Book");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.TargetSite + "" + ex.Message, "Error!",
                    MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                }
            }

            // Get the order number from the selected item in the list
            DataRowView drv = lstOrders.SelectedItem as DataRowView;
            int orderNo = Convert.ToInt32(drv["CustOrderNo"]);

            // Find all rows that match the order number and delete them
            DataRow[] rowsDetailsToDelete = dsBookShop.Tables["CustOrderDetails"].Select("CustOrderNo = " + orderNo);
            foreach (DataRow rowToDelete in rowsDetailsToDelete)
            {
                rowToDelete.Delete();
            }

            // Update the database with the changes
            daOrderDetail.Update(dsBookShop, "CustOrderDetails");


            // Find all rows that match the order number and delete them
            DataRow[] rowsToDelete = dsBookShop.Tables["CustOrder"].Select("CustOrderNo = " + orderNo);
            foreach (DataRow rowToDelete in rowsToDelete)
            {
                rowToDelete.Delete();
            }

            // Update the database with the changes
            daOrder.Update(dsBookShop, "CustOrder");

            // Display a message after all rows have been deleted and the database has been updated
            MessageBox.Show("Stock has been returned, delete has been processed", "Delete");
            lstOrders.DataSource = null;

            MyGlobals.frmCustomer = true;
            Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            MyGlobals.customer = myCustomer;
            MyGlobals.selectedOrderNo = custOrderNo;
            MyGlobals.selectedCustNo = custNo;
            MyGlobals.frmEdit = true;
            Close();
        }
    }
}
