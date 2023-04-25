using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShop2
{
    public partial class frmCheckout : Form
    {
        SqlDataAdapter daOrder, daOrderDetails, daBook; //SqlDataAdapter serves as a bridge between a DataSet and SQL Server for retrieving and saving data
        DataSet dsBookShop = new DataSet(); //declare local copy of database
        SqlCommandBuilder cmdBOrder, cmdBOrderDetails, cmdBBook; //Automatically generates single-table commands that are used to reconcile changes made to a DataSet with the associated SQL Server database
        SqlCommand cmdOrder, cmdOrderDetails, cmdBook; //A SqlCommand object allows you to query and send commands to a database. 
        DataRow drOrder, drOrderDetails, drBook; // You add data to the data table using DataRow object
        SqlConnection conn; // Equivalent to network connection to server
        String connStr, sqlOrder, sqlOrderDetails, sqlBook;

        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Delete entire order?", "Cancel Order", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                MyGlobals.orderDetails.Clear();
                MyGlobals.cart = 0;
                frmMain.instance.lblCartQuant.Text = MyGlobals.cart.ToString();
                MyGlobals.frmShop = true;
                Close();
            }

        }

        int custOrderNo = 0;

        public frmCheckout()
        {
            InitializeComponent();
        }

        private void frmCheckout_Load(object sender, EventArgs e)
        {
            MyGlobals.frmCheckout = false;

            connStr = @"Data Source = .\sqlexpress; Initial Catalog = BookShop; Integrated Security = true";
            conn = new SqlConnection(connStr);

            //set up dataAdapter for order
            sqlOrder = @"Select * from CustOrder order by CustOrderNo ASC";
            cmdOrder = new SqlCommand(sqlOrder, conn);
            daOrder = new SqlDataAdapter(cmdOrder);
            cmdBOrder = new SqlCommandBuilder(daOrder);
            daOrder.FillSchema(dsBookShop, SchemaType.Source, "CustOrder");
            daOrder.Fill(dsBookShop, "CustOrder");


            //set up dataAdapter for orderDetails
            sqlOrderDetails = @"Select * from CustOrderDetails";
            cmdOrderDetails = new SqlCommand(sqlOrderDetails, conn);
            daOrderDetails = new SqlDataAdapter(cmdOrderDetails);
            cmdBOrderDetails = new SqlCommandBuilder(daOrderDetails);
            daOrderDetails.FillSchema(dsBookShop, SchemaType.Source, "CustOrderDetails");

            //set up dataAdapter for book
            sqlBook = @"Select * from Book";
            cmdBook = new SqlCommand(sqlBook, conn);
            daBook = new SqlDataAdapter(cmdBook);
            cmdBBook = new SqlCommandBuilder(daBook);
            daBook.FillSchema(dsBookShop, SchemaType.Source, "Book");
            daBook.Fill(dsBookShop, "Book");


            if (MyGlobals.customer == null || MyGlobals.customer.IdNo == 0)
            {
                lblCustomer.Text = "(none selected)";
            }
            else
                lblCustomer.Text = MyGlobals.customer.Forename + " " + MyGlobals.customer.Surname;

            if (lblCustomer.Text == "(none selected)")
            {
                btnChangeCust.Text = "Select";
                btnConfirmCustomer.Visible = false;
            }

            for (int i = 0; i < MyGlobals.orderDetails.Count; i++)
            {
                System.Windows.Forms.Label label0 = new System.Windows.Forms.Label();
                label0.Size = new Size(300, 75);
                label0.Font = new Font("Serif", 12);
                label0.Tag = i;

                System.Windows.Forms.Label label1 = new System.Windows.Forms.Label();
                label1.TextAlign = ContentAlignment.MiddleRight;
                label1.Font = new Font("Serif", 12);
                label1.Tag = i;

                System.Windows.Forms.ComboBox combo = new System.Windows.Forms.ComboBox();
                combo.Size = new Size(50, 20);
                combo.Font = new Font("Serif", 12);
                combo.Tag = i;
                combo.SelectedIndexChanged += combo_SelectedIndexChanged;

                flpCart.Controls.Add(label0);
                flpCart.Controls.Add(label1);
                flpCart.Controls.Add(combo);

                label0.Text = MyGlobals.orderDetails[i].Title + "\n" + MyGlobals.orderDetails[i].AuthorForename +" "+ MyGlobals.orderDetails[i].AuthorSurname;
                label1.Text = MyGlobals.orderDetails[i].Price.ToString();

                combo.Items.Clear();
                for (int j = 0; j < MyGlobals.orderDetails[i].Stock; j++)
                {
                    combo.Items.Add(j + 1);
                    if (j == 8) break;
                }
                combo.SelectedIndex = MyGlobals.orderDetails[i].Quantity - 1;
                lblTotal.Text = "£  " + CalculateTotal().ToString();
            }
        }

        private void combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            int tag = (int)comboBox.Tag;
            foreach (Control c in flpCart.Controls)
            {
                if (c.GetType() == typeof(ComboBox) && c.Tag.Equals(tag))
                    MyGlobals.orderDetails[tag].Quantity = Convert.ToInt32(comboBox.Text);
                lblTotal.Text = "£  " + CalculateTotal().ToString();
            }
        }

        private decimal CalculateTotal()
        {
            MyGlobals.cart = 0;
            decimal total = 0;
            for (int i = 0; i < MyGlobals.orderDetails.Count; i++)
            {
                total = total + MyGlobals.orderDetails[i].Price * MyGlobals.orderDetails[i].Quantity;
                MyGlobals.cart += MyGlobals.orderDetails[i].Quantity;
            }
            frmMain.instance.lblCartQuant.Text = MyGlobals.cart.ToString();
            return total;
        }

        private void btnConfirmCustomer_Click(object sender, EventArgs e)
        {
            btnConfirmCustomer.Visible = false;
            btnConfirmOrder.Visible = true;
        }

        private void btnChangeCust_Click(object sender, EventArgs e)
        {
            MyGlobals.frmCustomer = true;
            Close();
        }

        private void btnContinueShop_Click(object sender, EventArgs e)
        {
            MyGlobals.frmShop = true;
            Close();
        }

        private void btnConfirmOrder_Click(object sender, EventArgs e)
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
                drOrder["CustNo"] = MyGlobals.customer.IdNo;
                drOrder["CustOrderDate"] = DateTime.Now;
                drOrder["CustDispatchDate"] = DateTime.Now;
                drOrder["Refund"] = 0;                              //false

                dsBookShop.Tables["CustOrder"].Rows.Add(drOrder);
                daOrder.Update(dsBookShop, "CustOrder");

            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.TargetSite + "" + ex.Message, "Error!",
                MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }

            for (int i = 0; i < MyGlobals.orderDetails.Count; i++)
            {
                try
                {
                    drOrderDetails = dsBookShop.Tables["CustOrderDetails"].NewRow();

                    drOrderDetails["ISBN"] = MyGlobals.orderDetails[i].ISBN;
                    drOrderDetails["CustOrderNo"] = custOrderNo;
                    drOrderDetails["Quantity"] = MyGlobals.orderDetails[i].Quantity;

                    dsBookShop.Tables["CustOrderDetails"].Rows.Add(drOrderDetails);
                    daOrderDetails.Update(dsBookShop, "CustOrderDetails");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.TargetSite + "" + ex.Message, "Error!",
                    MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                }
            }
            for (int i = 0; i < MyGlobals.orderDetails.Count; i++)
            {
                drBook = dsBookShop.Tables["Book"].Rows.Find(MyGlobals.orderDetails[i].ISBN);

                try
                {
                    drBook = dsBookShop.Tables["Book"].Rows.Find(MyGlobals.orderDetails[i].ISBN);

                    drBook.BeginEdit();

                    drBook["Stock"] = Convert.ToInt16(drBook["Stock"].ToString()) - MyGlobals.orderDetails[i].Quantity;

                    drBook.EndEdit();
                    daBook.Update(dsBookShop, "Book");

                    if (i == MyGlobals.orderDetails.Count - 1)

                        MessageBox.Show("New Order Added", "Order");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.TargetSite + "" + ex.Message, "Error!",
                    MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                }

                MyGlobals.justOrdered[0] = MyGlobals.customer.IdNo;  //Save order details to load on receipts page
                MyGlobals.justOrdered[1] = custOrderNo;
                MyGlobals.orderDetails.Clear();
                MyGlobals.customer = null;
                MyGlobals.cart = 0;
                frmMain.instance.lblCartQuant.Text = MyGlobals.cart.ToString();
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
