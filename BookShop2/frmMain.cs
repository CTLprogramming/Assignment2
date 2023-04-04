using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            btnHome.Visible = true;
            frmCustomer frmCustomer = new frmCustomer();
            frmCustomer.TopLevel = false;
            frmCustomer.FormBorderStyle = FormBorderStyle.None;
            frmCustomer.WindowState = FormWindowState.Maximized;
            pnlMain.Controls.Add(frmCustomer);
            frmCustomer.Show();
        }
    }
}
