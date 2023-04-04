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
        SqlCommandBuilder cmdBCustomer; //Automatically generates single-table commands that are used to reconcile changes made to a DataSet with the associated SQL Server database
        SqlCommand cmdCustomerDetails; //A SqlCommand object allows you to query and send commands to a database. 
        DataRow drCustomer; // You add data to the data table using DataRow object
        SqlConnection conn; // Equivalent to network connection to server
        String connStr, sqlNames, sqlCustomer, sqlCustomerDetails;
        int selectedTab = 0;
        bool custSelected = false;

        int custNoSelected = 0;

        public frmCustomer()
        {
            InitializeComponent();
        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            int no;

            for (int i = 0; i < 26; i++)
            {
                btns[i] = (Button)pnlButtons.Controls[i];
                btns[i].Text = "" + (char)(65 + i);
                btns[i].Enabled = false;
                btns[i].Click += new EventHandler(button1_Click);
            }

            connStr = @"Data Source = .\sqlexpress; Initial Catalog = BookShop; Integrated Security = true";
            //connStr = Properties.Resources.connectionStr;

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
            sqlCustomerDetails = @"Select CustNo, custTitle, forename, surname +', '+ Forename as name, custStreet, custTown, custCounty, custPostcode, custTel, custEmail, Marketing from customer where surname LIKE @Letter order by surname, forename ";
            conn = new SqlConnection(connStr);
            cmdCustomerDetails = new SqlCommand(sqlCustomerDetails, conn);
            cmdCustomerDetails.Parameters.Add("@Letter", SqlDbType.VarChar);
            daCustomers = new SqlDataAdapter(cmdCustomerDetails);
            daCustomers.FillSchema(dsBookShop, SchemaType.Source, "Customer");

            /*
                        //set up dataAdapter for customer details for the datagridview
                        sqlCustomer = @"Select custNo, custTitle, forename, surname +', '+ Forename as name, custStreet, custTown, custCounty, custPostcode, custTel, custEmail, Marketing from customer where surname LIKE @Letter order by surname, forename ";
                        daCustomer = new SqlDataAdapter(sqlCustomer, connStr);
                        cmdBCustomer = new SqlCommandBuilder(daCustomer);
                        daCustomer.FillSchema(dsBookShop, SchemaType.Source, "Customer");
                        daCustomer.Fill(dsBookShop, "Customer");
            */

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

            btnEditCust.Enabled = false;
            btnSaveCust.Enabled = false;
            btnClearCust.Enabled = false;
            btnDeleteCust.Enabled = false;
            btnCheckoutCust.Enabled = false;
            btnReceiptCust.Enabled = false;
            btnNewCust.Enabled = true;
            btnNewCust.BackColor = Color.FromArgb(45, 80, 150);
            btnNewCust.FlatAppearance.BorderColor = Color.FromArgb(45, 80, 150);

            //            lblDisplayEdit.Text = "Edit";





        }

        private void button1_Click(object sender, EventArgs e)
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

        private void lstCustomer_Click(object sender, EventArgs e)
        {

            dsBookShop.Tables["Customer"].Clear();

            //get all custNo details from listbox
            cmdCustomerDetails.Parameters["@CustNo"].Value = lstCustomer.SelectedValue;
            daCustomer.Fill(dsBookShop, "Customer");


            lblCustNo.Text = custNoSelected.ToString();
            drCustomer = dsBookShop.Tables["Customer"].Rows.Find(lblCustNo.Text);

            if (drCustomer["CustTitle"].ToString() == "Mr")
                cmbTitle.SelectedIndex = 0;
            if (drCustomer["CustTitle"].ToString() == "Mrs")
                cmbTitle.SelectedIndex = 1;
            if (drCustomer["CustTitle"].ToString() == "Miss")
                cmbTitle.SelectedIndex = 2;
            if (drCustomer["CustTitle"].ToString() == "Ms")
                cmbTitle.SelectedIndex = 3;
            else
                cmbTitle.SelectedIndex = 4;

            txtForename.Text = drCustomer["Forename"].ToString();
            txtSurname.Text = drCustomer["Surname"].ToString();
            txtStreet.Text = drCustomer["CustStreet"].ToString();
            txtTown.Text = drCustomer["CustTown"].ToString();
            txtCounty.Text = drCustomer["CustCounty"].ToString();
            txtPostcode.Text = drCustomer["CustPostcode"].ToString();
            txtTelNo.Text = drCustomer["CustTelNo"].ToString();
        }


        private void btnNewCust_Click(object sender, EventArgs e)
        {
            ClearCustomer();
            int noRows = dsBookShop.Tables["Customer"].Rows.Count;
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

            btnSaveCust.Enabled = true;
            btnSaveCust.BackColor = Color.FromArgb(45, 80, 150);
            btnSaveCust.FlatAppearance.BorderColor = Color.FromArgb(45, 80, 150);

            btnClearCust.Enabled = true;
            btnClearCust.BackColor = Color.FromArgb(45, 80, 150);
            btnClearCust.FlatAppearance.BorderColor = Color.FromArgb(45, 80, 150);

        }


        private void btnSaveCust_Click(object sender, EventArgs e)
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
                    drCustomer["CustTelNo"] = myCustomer.TelNo;

                    dsBookShop.Tables["Customer"].Rows.Add(drCustomer);
                    daCustomer.Update(dsBookShop, "Customer");

                    MessageBox.Show("New Customer Added");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.TargetSite + "" + ex.Message, "Error!",
                MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }

        }

        private void getNumber(int noRows)      //
        {
            drCustomer = dsBookShop.Tables["Customer"].Rows[noRows - 1];     // dr - datarow
            lblCustNo.Text = (int.Parse(drCustomer["CustNo"].ToString()) + 1).ToString();
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
            cmbMarketing.SelectedIndex = -1;
        }

    }
}
