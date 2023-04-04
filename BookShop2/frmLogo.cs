using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShop2
{
    public partial class frmLogo : Form
    {
        public frmLogo()
        {
            InitializeComponent();
        }

        private void frmLogo_Load(object sender, EventArgs e)
        {            
            picLogo.Location = new Point(1400, 120);
            tmrLogo.Enabled = true;
        }

        private void tmrLogo_Tick(object sender, EventArgs e)
        {
            if (picLogo.Left > 350)
            {
                picLogo.Left -= 15;
                if (picLogo.Left <400)
                    this.picLogo.Load("ACB_logo2.png");
            }

            else
            {
                this.picLogo.Load("ACB_logo3.png");
                tmrLogo.Enabled = false;

            }

        }
    }
}
