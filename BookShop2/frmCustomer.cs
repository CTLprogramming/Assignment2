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
    public partial class frmCustomer : Form
    {
        Button[] btns = new Button[26];

        SqlDataAdapter daNames, daCustomer, daCustomers; //SqlDataAdapter serves as a bridge between a DataSet and SQL Server for retrieving and saving data
        DataSet dsBookShop = new DataSet(); //declare local copy of database
        SqlCommandBuilder cmdBCustomer; //d generates single-table commands that are used to reconcile changes made to a DataSet with the associated SQL Server database
        SqlCommand cmdCustomerDetails; //A SqlCommand object allows you to query and send commands to a database. 
        DataRow drCustomer; // You add data to the data table using DataRow object
        SqlConnection conn; // Equivalent to network connection to server
        String connStr, sqlNames, sqlCustomer, sqlCustomerDetails;


        public frmCustomer()
        {
            InitializeComponent();
        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            MyGlobals.frmCustomer = false;
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



            //set up dataAdapter for customer details for the pnlCustDetails
            sqlCustomer = @"select * from Customer order by CustNo ASC";
            daCustomer = new SqlDataAdapter(sqlCustomer, connStr);
            cmdBCustomer = new SqlCommandBuilder(daCustomer);
            daCustomer.FillSchema(dsBookShop, SchemaType.Source, "Customers");
            daCustomer.Fill(dsBookShop, "Customers");


            //Loads customer details if one is already stored in MyGlobals.  None selected is displayed if record shows zero or is null .
            if (MyGlobals.customer != null)
            {
                lblCustNo.Text = MyGlobals.customer.IdNo.ToString();

                if (MyGlobals.customer.Title.ToString() == "Mr")
                    cmbTitle.SelectedIndex = 0;
                if (MyGlobals.customer.Title.ToString() == "Mrs")
                    cmbTitle.SelectedIndex = 1;
                if (MyGlobals.customer.Title.ToString() == "Miss")
                    cmbTitle.SelectedIndex = 2;
                if (MyGlobals.customer.Title.ToString() == "Ms")
                    cmbTitle.SelectedIndex = 3;


                txtForename.Text = MyGlobals.customer.Forename.ToString();
                txtSurname.Text = MyGlobals.customer.Surname.ToString();
                txtStreet.Text = MyGlobals.customer.Street.ToString();
                txtTown.Text = MyGlobals.customer.Town.ToString();
                txtCounty.Text = MyGlobals.customer.County.ToString();
                txtPostcode.Text = MyGlobals.customer.Postcode.ToString();
                txtTelNo.Text = MyGlobals.customer.TelNo.ToString();
                txtEmail.Text = MyGlobals.customer.Email.ToString();

                cmbMarketing.Enabled = true;
                if (Convert.ToBoolean(MyGlobals.customer.Marketing.ToString()))
                    cmbMarketing.SelectedIndex = 1;
                else
                    cmbMarketing.SelectedIndex = 0;
                cmbMarketing.Enabled = false;

                btnClearCust.Visible = true;
                btnEditCust.Visible = true;
                btnDeleteCust.Visible = true;


                if (lblCustNo.Text == "0")
                {
                    lblCustNo.Text = "(none selected)";
                    btnClearCust.Visible = false;
                    btnEditCust.Visible = false;
                    btnDeleteCust.Visible = false;
                }
            }
            else
                lblCustNo.Text = "(none selected)";

            btnSaveCust.Visible = false;

            cmbTitle.Enabled = false;
            txtSurname.Enabled = false;
            txtForename.Enabled = false;
            txtStreet.Enabled = false;
            txtTown.Enabled = false;
            txtCounty.Enabled = false;
            txtPostcode.Enabled = false;
            txtTelNo.Enabled = false;
            txtEmail.Enabled = false;
            cmbMarketing.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)  //alphabet buttons
        {
            Button b = (Button)sender;
            // get customer details for listbox - use selected button letter for parameter
            String str = b.Text;
            // empty dataset table customer
            dsBookShop.Tables["Customer"].Clear();

            fillListboxCustomers(str);

            ClearCustomer();
        }



        private void fillListboxCustomers(String str)
        {
            // get all customer details for listbox - use wildcard for parameter
            cmdCustomerDetails.Parameters["@Letter"].Value = str + "%";
            daCustomers.Fill(dsBookShop, "Customer");

            // fill listbox
            lstCustomer.DataSource = dsBookShop.Tables["Customer"];
            lstCustomer.DisplayMember = "name";
            lstCustomer.ValueMember = "CustNo";
        }

        private void btnShopCust_Click(object sender, EventArgs e)
        {
            MyGlobals.frmShop = true;
            Close();
        }

        private void btnCheckoutCust_Click(object sender, EventArgs e)
        {
            MyGlobals.frmCheckout = true;
            Close();
        }

        private void btnReceiptCust_Click(object sender, EventArgs e)
        {
            MyGlobals.frmReceipt = true;
            Close();
        }

        private void btnRefunds_Click(object sender, EventArgs e)
        {
            MyGlobals.frmRefunds = true;
            Close();
        }

        private void btnClearCust_Click(object sender, EventArgs e)
        {
            ClearCustomer();
        }

        private void lstCustomer_Click(object sender, EventArgs e)  //Click on customer to load full details into pnlCustDetails
        {
            MyCustomer myCustomer = new MyCustomer();

            drCustomer = dsBookShop.Tables["Customer"].Rows.Find(lstCustomer.SelectedValue);

            lblCustNo.Text = drCustomer["CustNo"].ToString();

            drCustomer = dsBookShop.Tables["Customer"].Rows.Find(lblCustNo.Text);
            if (drCustomer["CustTitle"].ToString() == "Mr")
                cmbTitle.SelectedIndex = 0;
            if (drCustomer["CustTitle"].ToString() == "Mrs")
                cmbTitle.SelectedIndex = 1;
            if (drCustomer["CustTitle"].ToString() == "Miss")
                cmbTitle.SelectedIndex = 2;
            if (drCustomer["CustTitle"].ToString() == "Ms")
                cmbTitle.SelectedIndex = 3;


            txtForename.Text = drCustomer["Forename"].ToString();
            txtSurname.Text = drCustomer["Surname"].ToString();
            txtStreet.Text = drCustomer["CustStreet"].ToString();
            txtTown.Text = drCustomer["CustTown"].ToString();
            txtCounty.Text = drCustomer["CustCounty"].ToString();
            txtPostcode.Text = drCustomer["CustPostcode"].ToString();
            txtTelNo.Text = drCustomer["CustTel"].ToString();
            txtEmail.Text = drCustomer["CustEmail"].ToString();

            cmbMarketing.Enabled = true;
            if (Convert.ToBoolean(drCustomer["Marketing"].ToString()))
                cmbMarketing.SelectedIndex = 1;
            else
                cmbMarketing.SelectedIndex = 0;
            cmbMarketing.Enabled = false;

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

            MyGlobals.customer = myCustomer;


            btnSaveCust.Visible = false;
            btnClearCust.Visible = true;
            btnEditCust.Visible = true;
            btnDeleteCust.Visible = true;
        }

        private void btnNewCust_Click(object sender, EventArgs e)
        {
            ClearCustomer();
            btnSaveCust.Tag = "Add";
            daCustomer.Fill(dsBookShop, "Customers");
            int noRows = dsBookShop.Tables["Customers"].Rows.Count;
            if (noRows == 0)
                lblCustNo.Text = "10000";
            else
            {
                getNumber(noRows);
            }
            errP.Clear();

            cmbTitle.Enabled = true;
            txtSurname.Enabled = true;
            txtForename.Enabled = true;
            txtStreet.Enabled = true;
            txtTown.Enabled = true;
            txtCounty.Enabled = true;
            txtPostcode.Enabled = true;
            txtTelNo.Enabled = true;
            txtEmail.Enabled = true;
            cmbMarketing.Enabled = true;

            btnSaveCust.Visible = true;
            btnClearCust.Visible = true;

            MyGlobals.customer = null;
        }

        private void getNumber(int noRows)      //
        {
            drCustomer = dsBookShop.Tables["Customers"].Rows[noRows - 1];     
            lblCustNo.Text = (int.Parse(drCustomer["CustNo"].ToString()) + 1).ToString();
        }

        private void btnEditCust_Click(object sender, EventArgs e)
        {
            cmbTitle.Enabled = true;
            txtSurname.Enabled = true;
            txtForename.Enabled = true;
            txtStreet.Enabled = true;
            txtTown.Enabled = true;
            txtCounty.Enabled = true;
            txtPostcode.Enabled = true;
            txtTelNo.Enabled = true;
            txtEmail.Enabled = true;
            cmbMarketing.Enabled = true;

            btnSaveCust.Tag = "Edit";
            btnSaveCust.Visible = true;
            btnEditCust.Visible = false;
        }

        private void btnSaveCust_Click(object sender, EventArgs e)
        {
            if (btnSaveCust.Tag == "Add")
            {
                AddCustomer();
            }
            else            //(btnSaveCust.Tag == "Edit")
            {
                EditCustomer();
            }
        }


        private void AddCustomer()
        {
            MyCustomer myCustomer = new MyCustomer();
            bool ok = true;
            errP.Clear();

            try
            {
                myCustomer.IdNo = Convert.ToInt32(lblCustNo.Text.Trim()); //passes to Customer class to check  Converts string to 32-bit integer.   Trim() removes white space characters
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(lblCustNo, MyEx.toString());     // ***ASK errP
            }
            try
            {
                myCustomer.Title = cmbTitle.Text.Trim(); //passed to Customer class to check 
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(cmbTitle, MyEx.toString());
            }
            try
            {
                myCustomer.Surname = txtSurname.Text.Trim(); //passed to Customer class to check 
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtSurname, MyEx.toString());
            }
            try
            {
                myCustomer.Forename = txtForename.Text.Trim();   //passed to Customer class to check
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtForename, MyEx.toString());
            }
            try
            {
                myCustomer.Street = txtStreet.Text.Trim();   //passed to Customer class to check
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtStreet, MyEx.toString());
            }
            try
            {
                myCustomer.Town = txtTown.Text.Trim();   //passed to Customer class to check
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtTown, MyEx.toString());
            }
            try
            {
                myCustomer.County = txtCounty.Text.Trim();   //passed to Customer class to check
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtCounty, MyEx.toString());
            }
            try
            {
                myCustomer.Postcode = txtPostcode.Text.Trim();   //passed to Customer class to check
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtPostcode, MyEx.toString());
            }
            try
            {
                myCustomer.TelNo = txtTelNo.Text.Trim();   //passed to Customer class to check  
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtTelNo, MyEx.toString());
            }

            try
            {
                myCustomer.Email = txtEmail.Text.Trim();   //passed to Customer class to check  
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtEmail, MyEx.toString());
            }
            try
            {
                int selectedIndex = cmbMarketing.SelectedIndex;

                if (selectedIndex == 0)
                    myCustomer.Marketing = false;
                if (selectedIndex == 1)
                    myCustomer.Marketing = true;
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(cmbMarketing, MyEx.toString());
            }

            try
            {
                if (ok)
                {
                    drCustomer = dsBookShop.Tables["Customer"].NewRow();

                    drCustomer["CustNo"] = myCustomer.IdNo;
                    drCustomer["CustTitle"] = myCustomer.Title;
                    drCustomer["Forename"] = myCustomer.Forename;
                    drCustomer["Surname"] = myCustomer.Surname;
                    drCustomer["CustStreet"] = myCustomer.Street;
                    drCustomer["CustTown"] = myCustomer.Town;
                    drCustomer["CustCounty"] = myCustomer.County;
                    drCustomer["CustPostcode"] = myCustomer.Postcode;
                    drCustomer["CustTel"] = myCustomer.TelNo;
                    drCustomer["CustEmail"] = myCustomer.Email;
                    drCustomer["Marketing"] = myCustomer.Marketing;


                    dsBookShop.Tables["Customer"].Rows.Add(drCustomer);
                    daCustomer.Update(dsBookShop, "Customer");

                    MessageBox.Show("New Customer Added");

                    btnSaveCust.Visible = false;
                    btnClearCust.Visible = true;
                    btnEditCust.Visible = true;
                    btnDeleteCust.Visible = true;

                    cmbTitle.Enabled = false;
                    txtSurname.Enabled = false;
                    txtForename.Enabled = false;
                    txtStreet.Enabled = false;
                    txtTown.Enabled = false;
                    txtCounty.Enabled = false;
                    txtPostcode.Enabled = false;
                    txtTelNo.Enabled = false;
                    txtEmail.Enabled = false;
                    cmbMarketing.Enabled = false;

                    MyGlobals.customer = myCustomer;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.TargetSite + "" + ex.Message, "Error!",
                MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }
        }

        private void EditCustomer()
        {
            MyCustomer myCustomer = new MyCustomer();
            bool ok = true;
            errP.Clear();

            try
            {
                myCustomer.IdNo = Convert.ToInt32(lblCustNo.Text.Trim()); //passes to Customer class to check  Converts string to 32-bit integer.   Trim() removes white space characters
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(lblCustNo, MyEx.toString());     // ***ASK errP
            }
            try
            {
                myCustomer.Title = cmbTitle.Text.Trim(); //passed to Customer class to check 
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(cmbTitle, MyEx.toString());
            }
            try
            {
                myCustomer.Surname = txtSurname.Text.Trim(); //passed to Customer class to check 
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtSurname, MyEx.toString());
            }
            try
            {
                myCustomer.Forename = txtForename.Text.Trim();   //passed to Customer class to check
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtForename, MyEx.toString());
            }
            try
            {
                myCustomer.Street = txtStreet.Text.Trim();   //passed to Customer class to check
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtStreet, MyEx.toString());
            }
            try
            {
                myCustomer.Town = txtTown.Text.Trim();   //passed to Customer class to check
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtTown, MyEx.toString());
            }
            try
            {
                myCustomer.County = txtCounty.Text.Trim();   //passed to Customer class to check
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtCounty, MyEx.toString());
            }
            try
            {
                myCustomer.Postcode = txtPostcode.Text.Trim();   //passed to Customer class to check
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtPostcode, MyEx.toString());
            }
            try
            {
                myCustomer.TelNo = txtTelNo.Text.Trim();   //passed to Customer class to check  
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtTelNo, MyEx.toString());
            }

            try
            {
                myCustomer.Email = txtEmail.Text.Trim();   //passed to Customer class to check  
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtEmail, MyEx.toString());
            }
            try
            {
                int selectedIndex = cmbMarketing.SelectedIndex;

                if (selectedIndex == 0)
                    myCustomer.Marketing = false;
                if (selectedIndex == 1)
                    myCustomer.Marketing = true;
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(cmbMarketing, MyEx.toString());
            }

            try
            {
                if (ok)
                {
                    drCustomer.BeginEdit();

                    drCustomer["CustNo"] = myCustomer.IdNo;
                    drCustomer["CustTitle"] = myCustomer.Title;
                    drCustomer["Forename"] = myCustomer.Forename;
                    drCustomer["Surname"] = myCustomer.Surname;
                    drCustomer["CustStreet"] = myCustomer.Street;
                    drCustomer["CustTown"] = myCustomer.Town;
                    drCustomer["CustCounty"] = myCustomer.County;
                    drCustomer["CustPostcode"] = myCustomer.Postcode;
                    drCustomer["CustTel"] = myCustomer.TelNo;
                    drCustomer["CustEmail"] = myCustomer.Email;
                    drCustomer["Marketing"] = myCustomer.Marketing;

                    drCustomer.EndEdit();
                    daCustomer.Update(dsBookShop, "Customer");

                    MessageBox.Show("Customer Details Updated", "Customer");

                    btnSaveCust.Visible = false;
                    btnClearCust.Visible = true;
                    btnEditCust.Visible = true;
                    btnDeleteCust.Visible = true;

                    cmbTitle.Enabled = false;
                    txtSurname.Enabled = false;
                    txtForename.Enabled = false;
                    txtStreet.Enabled = false;
                    txtTown.Enabled = false;
                    txtCounty.Enabled = false;
                    txtPostcode.Enabled = false;
                    txtTelNo.Enabled = false;
                    txtEmail.Enabled = false;
                    cmbMarketing.Enabled = false;

                    MyGlobals.customer = myCustomer;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.TargetSite + "" + ex.Message, "Error!",
                MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }
        }

        private void ClearCustomer()
        {
            lstCustomer.SelectedIndex = -1;
            lblCustNo.Text = "";
            cmbTitle.SelectedIndex = -1;
            txtForename.Text = "";
            txtSurname.Text = "";
            txtStreet.Text = "";
            txtTown.Text = "";
            txtCounty.Text = "";
            txtPostcode.Text = "";
            txtTelNo.Text = "";
            txtEmail.Text = "";
            cmbMarketing.SelectedIndex = -1;

            cmbTitle.Enabled = false;
            txtSurname.Enabled = false;
            txtForename.Enabled = false;
            txtStreet.Enabled = false;
            txtTown.Enabled = false;
            txtCounty.Enabled = false;
            txtPostcode.Enabled = false;
            txtTelNo.Enabled = false;
            txtEmail.Enabled = false;
            cmbMarketing.Enabled = false;

            btnSaveCust.Visible = false;
            btnClearCust.Visible = false;
            btnEditCust.Visible = false;
            btnDeleteCust.Visible = false;

            MyGlobals.customer = null;

        }
    }
}
