using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShop2
{
    public partial class frmMain : Form
    {

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            lblPageTitle.Text = "Book Shop";
            btnHome.Visible = false;
            frmLogo frmLogo = new frmLogo();
            frmLogo.TopLevel = false;
            frmLogo.FormBorderStyle = FormBorderStyle.None;
            frmLogo.WindowState = FormWindowState.Maximized;
            pnlMain.Controls.Add(frmLogo);
            frmLogo.Show();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            lblPageTitle.Text = "Customer";
            btnHome.Visible = true;
            frmCustomer frmCustomer = new frmCustomer();
            frmCustomer.TopLevel = false;
            frmCustomer.FormBorderStyle = FormBorderStyle.None;
            frmCustomer.WindowState = FormWindowState.Maximized;
            pnlMain.Controls.Add(frmCustomer);
            frmCustomer.Show();
        }

        private void btnShop_Click(object sender, EventArgs e)
        {
            lblPageTitle.Text = "Shop";
            btnHome.Visible = true;
            frmShop frmShop = new frmShop();
            frmShop.TopLevel = false;
            frmShop.FormBorderStyle = FormBorderStyle.None;
            frmShop.WindowState = FormWindowState.Maximized;
            pnlMain.Controls.Add(frmShop);
            frmShop.Show();
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            lblPageTitle.Text = "Checkout";
            btnHome.Visible = true;
            frmCheckout frmCheckout = new frmCheckout();
            frmCheckout.TopLevel = false;
            frmCheckout.FormBorderStyle = FormBorderStyle.None;
            frmCheckout.WindowState = FormWindowState.Maximized;
            pnlMain.Controls.Add(frmCheckout);
            frmCheckout.Show();
        }

        private void btnReceipts_Click(object sender, EventArgs e)
        {
            lblPageTitle.Text = "Receipts";
            btnHome.Visible = true;
            frmReceipts frmReceipts = new frmReceipts();
            frmReceipts.TopLevel = false;
            frmReceipts.FormBorderStyle = FormBorderStyle.None;
            frmReceipts.WindowState = FormWindowState.Maximized;
            pnlMain.Controls.Add(frmReceipts);
            frmReceipts.Show();
        }

        private void btnRefunds_Click(object sender, EventArgs e)
        {
            lblPageTitle.Text = "Refunds";
            btnHome.Visible = true;
            frmRefunds frmRefunds = new frmRefunds();
            frmRefunds.TopLevel = false;
            frmRefunds.FormBorderStyle = FormBorderStyle.None;
            frmRefunds.WindowState = FormWindowState.Maximized;
            pnlMain.Controls.Add(frmRefunds);
            frmRefunds.Show();
        }

        private void pnlMain_ControlRemoved(object sender, ControlEventArgs e)
        {
            if (MyGlobals.frmShop)
            {
                btnShop_Click(sender, e);
            }
            if(MyGlobals.frmCustomer)
            {
                btnCustomer_Click(sender, e);
            }
            if (MyGlobals.frmCheckout)
            {
                btnCheckout_Click(sender, e);
            }
            if (MyGlobals.frmReceipt)
            {
                btnReceipts_Click(sender, e);
            }
            if (MyGlobals.frmRefunds)
            {
                btnRefunds_Click(sender, e);   
            }
        }
    }
}
