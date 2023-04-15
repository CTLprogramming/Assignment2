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
                no = (int)dr["Surname"].ToString()[0] - 65;
                btns[no].Enabled = true;
                btns[no].BackColor = Color.FromArgb(45, 80, 150);
                btns[no].FlatAppearance.BorderColor = Color.FromArgb(45, 80, 150);
                btns[no].ForeColor = Color.White;
            }

            //set up dataAdapter for customer details for the listbox
            sqlCustomerDetails = @"Select CustNo, custTitle, forename, surname, surname + ', ' + Forename + ', (' + CONVERT(VARCHAR(10), CustNo) + ')' as name, custStreet, custTown, custCounty, custPostcode, custTel, custEmail, Marketing from customer where surname LIKE @Letter order by surname, forename ";
            conn = new SqlConnection(connStr);
            cmdCustomerDetails = new SqlCommand(sqlCustomerDetails, conn);
            cmdCustomerDetails.Parameters.Add("@Letter", SqlDbType.VarChar);
            daCustomers = new SqlDataAdapter(cmdCustomerDetails);
            daCustomers.FillSchema(dsBookShop, SchemaType.Source, "Customer");

/*            //set up dataAdapter for orders listbox

            sqlOrder = @"select * from CustOrder ";
            cmdOrder = new SqlCommand(sqlOrder, conn);
            cmdOrder.Parameters.Add("@CustNo", SqlDbType.VarChar);
            cmdOrder.Parameters["@CustNo"].Value = "";
            daOrder = new SqlDataAdapter(cmdOrder);
            daOrder.FillSchema(dsBookShop, SchemaType.Source, "CustOrder");
*/
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
            lblCustomer.Text = drCustomer["Forename"].ToString() + " " + drCustomer["Surname"].ToString() + " (" + lstCustomer.SelectedValue.ToString() + ")";
            custNo = Convert.ToInt32(drCustomer["CustNo"].ToString());
            orderDetails.Clear();
            flpOrderDetails.Controls.Clear();

        }


        private void lstCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstOrders.DataSource = null;
            orderDetails.Clear();
            if (lstCustomer.SelectedItem != null)
            {
                DataRowView drv = lstCustomer.SelectedItem as DataRowView;
                if (drv != null)
                {
                    //                    int custNo = (int)drv["CustNo"];
                    SqlDataAdapter daOrders = new SqlDataAdapter("SELECT *, CONVERT(VARCHAR(10), CustOrderNo) + '    -    (' + CONVERT(VARCHAR, CustOrderDate,23) + ') ' as OrderAndDate FROM CustOrder WHERE CustNo = @CustNo", connStr);
                    daOrders.SelectCommand.Parameters.AddWithValue("@CustNo", (int)drv["CustNo"]);
                    DataTable dtOrders = new DataTable();
                    daOrders.Fill(dtOrders);
                    lstOrders.DataSource = dtOrders;
                    lstOrders.DisplayMember = "OrderAndDate";
                }
            }
        }

        private void lstCustomer_Click(object sender, EventArgs e)
        {
            DataRow drCustomer = dsBookShop.Tables["Customer"].Rows.Find(lstCustomer.SelectedValue);
            lblCustomer.Text = drCustomer["Forename"].ToString() + " " + drCustomer["Surname"].ToString() + " (" + lstCustomer.SelectedValue.ToString() + ")";
            custNo = Convert.ToInt32(drCustomer["CustNo"].ToString());
            orderDetails.Clear();
            flpOrderDetails.Controls.Clear();
        }


        private void lstOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            flpOrderDetails.Controls.Clear();
            if (lstOrders.SelectedItem != null)
            {
                DataRowView drv = lstOrders.SelectedItem as DataRowView;
                if (drv != null)
                {
                    int orderNo = Convert.ToInt32(drv["CustOrderNo"]);

                    SqlDataAdapter daOrderDetails = new SqlDataAdapter(@"Select C.CustOrderNo, C.ISBN, Quantity, BookTitle, Author, Price FROM CustOrderDetails C JOIN Book B on C.ISBN = B.ISBN WHERE CustOrderNo = @RefundDetails", connStr);
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
                        myOrderDetail.Author = dr["Author"].ToString();
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

                        flpOrderDetails.Controls.Add(label0);
                        flpOrderDetails.Controls.Add(label1);
                        flpOrderDetails.Controls.Add(combo);

                        label0.Text = orderDetails[i].Title + "\n" + orderDetails[i].Author;
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

                if (lblCustomer.Text.Length > 0 && lblRefundTotal.Text.Length > 0);
                    btnConfirmCustomer.Visible = true;
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
        private void btnConfirmCustomer_Click(object sender, EventArgs e)
        {
            if (lblRefundTotal.Text.Length > 0)
            {
                btnConfirmCustomer.Visible = false;
                btnConfirmRefund.Visible = true;
            }
            else
            {
                MessageBox.Show("Select at least one book to return", "Quantity error");
            }

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
                drOrder = dsBookShop.Tables["CustOrder"].NewRow();

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

            for (int i = 0; i < orderDetails.Count; i++)
            {
                try
                {
                    drOrderDetail = dsBookShop.Tables["CustOrderDetails"].NewRow();
                    if(orderDetails[i].Stock>0)
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
            for (int i = 0; i < orderDetails.Count; i++)
            {
                drBook = dsBookShop.Tables["Book"].Rows.Find(orderDetails[i].ISBN);

                try
                {
                    drBook = dsBookShop.Tables["Book"].Rows.Find(orderDetails[i].ISBN);

                    drBook.BeginEdit();

                    drBook["Stock"] = Convert.ToInt16(drBook["Stock"].ToString()) + orderDetails[i].Stock;

                    drBook.EndEdit();
                    daBook.Update(dsBookShop, "Book");

                    if (i == orderDetails.Count - 1)

                        MessageBox.Show("Return has been processed", "Return");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.TargetSite + "" + ex.Message, "Error!",
                    MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                }

                MyGlobals.justOrdered[0] = custNo;  //Save order details to load on receipts page
                MyGlobals.justOrdered[1] = custOrderNo;
                MyGlobals.orderDetails.Clear();
                MyGlobals.customer = null;
                MyGlobals.frmReceipt = true;
                Close();

            }
        }

        private void getNumber(int noRows)      //
        {
            drOrder = dsBookShop.Tables["CustOrder"].Rows[noRows - 1];     // dr - datarow
            custOrderNo = (int.Parse(drOrder["CustOrderNo"].ToString()) + 1);
        }

    }
}
