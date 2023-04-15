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
    public partial class frmReceipts : Form
    {
        public frmReceipts()
        {
            InitializeComponent();
        }

        private void frmReceipts_Load(object sender, EventArgs e)
        {
            MyGlobals.frmReceipt = false;




        }
    }
}
