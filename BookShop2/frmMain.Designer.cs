namespace BookShop2
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlBanner = new System.Windows.Forms.Panel();
            this.btnHome = new System.Windows.Forms.Button();
            this.pnlCart = new System.Windows.Forms.Panel();
            this.lblCartQuant = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.btnInvoice = new System.Windows.Forms.Button();
            this.btnStock = new System.Windows.Forms.Button();
            this.btnOrder = new System.Windows.Forms.Button();
            this.btnSuppliers = new System.Windows.Forms.Button();
            this.btnCheckout = new System.Windows.Forms.Button();
            this.btnRefunds = new System.Windows.Forms.Button();
            this.btnCustomer = new System.Windows.Forms.Button();
            this.btnShop = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlBanner.SuspendLayout();
            this.pnlCart.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBanner
            // 
            this.pnlBanner.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBanner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(80)))), ((int)(((byte)(150)))));
            this.pnlBanner.Controls.Add(this.btnHome);
            this.pnlBanner.Controls.Add(this.pnlCart);
            this.pnlBanner.Controls.Add(this.lblPageTitle);
            this.pnlBanner.Controls.Add(this.btnInvoice);
            this.pnlBanner.Controls.Add(this.btnStock);
            this.pnlBanner.Controls.Add(this.btnOrder);
            this.pnlBanner.Controls.Add(this.btnSuppliers);
            this.pnlBanner.Controls.Add(this.btnCheckout);
            this.pnlBanner.Controls.Add(this.btnRefunds);
            this.pnlBanner.Controls.Add(this.btnCustomer);
            this.pnlBanner.Controls.Add(this.btnShop);
            this.pnlBanner.Location = new System.Drawing.Point(3, 0);
            this.pnlBanner.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.pnlBanner.Name = "pnlBanner";
            this.pnlBanner.Size = new System.Drawing.Size(1905, 105);
            this.pnlBanner.TabIndex = 1;
            // 
            // btnHome
            // 
            this.btnHome.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnHome.BackgroundImage = global::BookShop2.Properties.Resources.btnLogo;
            this.btnHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHome.Location = new System.Drawing.Point(62, 8);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(114, 89);
            this.btnHome.TabIndex = 12;
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.frmMain_Load);
            // 
            // pnlCart
            // 
            this.pnlCart.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnlCart.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pnlCart.Controls.Add(this.lblCartQuant);
            this.pnlCart.Controls.Add(this.label1);
            this.pnlCart.Location = new System.Drawing.Point(1611, 9);
            this.pnlCart.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.pnlCart.Name = "pnlCart";
            this.pnlCart.Size = new System.Drawing.Size(170, 86);
            this.pnlCart.TabIndex = 11;
            this.pnlCart.Click += new System.EventHandler(this.btnCheckout_Click);
            // 
            // lblCartQuant
            // 
            this.lblCartQuant.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblCartQuant.AutoSize = true;
            this.lblCartQuant.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCartQuant.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(90)))), ((int)(((byte)(175)))));
            this.lblCartQuant.Location = new System.Drawing.Point(147, 26);
            this.lblCartQuant.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblCartQuant.Name = "lblCartQuant";
            this.lblCartQuant.Size = new System.Drawing.Size(26, 29);
            this.lblCartQuant.TabIndex = 2;
            this.lblCartQuant.Tag = "q";
            this.lblCartQuant.Text = "0";
            this.lblCartQuant.Click += new System.EventHandler(this.btnCheckout_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(90)))), ((int)(((byte)(175)))));
            this.label1.Location = new System.Drawing.Point(-3, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cart - items";
            this.label1.Click += new System.EventHandler(this.btnCheckout_Click);
            // 
            // lblPageTitle
            // 
            this.lblPageTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblPageTitle.AutoSize = true;
            this.lblPageTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageTitle.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblPageTitle.Location = new System.Drawing.Point(836, 14);
            this.lblPageTitle.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Size = new System.Drawing.Size(174, 37);
            this.lblPageTitle.TabIndex = 10;
            this.lblPageTitle.Text = "Book Shop";
            this.lblPageTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnInvoice
            // 
            this.btnInvoice.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnInvoice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(80)))), ((int)(((byte)(150)))));
            this.btnInvoice.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(80)))), ((int)(((byte)(150)))));
            this.btnInvoice.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(80)))), ((int)(((byte)(150)))));
            this.btnInvoice.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.btnInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInvoice.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnInvoice.Location = new System.Drawing.Point(1437, 57);
            this.btnInvoice.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.btnInvoice.Name = "btnInvoice";
            this.btnInvoice.Size = new System.Drawing.Size(132, 46);
            this.btnInvoice.TabIndex = 9;
            this.btnInvoice.Text = "Invoice";
            this.btnInvoice.UseVisualStyleBackColor = false;
            // 
            // btnStock
            // 
            this.btnStock.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(80)))), ((int)(((byte)(150)))));
            this.btnStock.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(80)))), ((int)(((byte)(150)))));
            this.btnStock.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(80)))), ((int)(((byte)(150)))));
            this.btnStock.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.btnStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStock.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnStock.Location = new System.Drawing.Point(1002, 57);
            this.btnStock.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.btnStock.Name = "btnStock";
            this.btnStock.Size = new System.Drawing.Size(132, 46);
            this.btnStock.TabIndex = 6;
            this.btnStock.Text = "Stock";
            this.btnStock.UseVisualStyleBackColor = false;
            // 
            // btnOrder
            // 
            this.btnOrder.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(80)))), ((int)(((byte)(150)))));
            this.btnOrder.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(80)))), ((int)(((byte)(150)))));
            this.btnOrder.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(80)))), ((int)(((byte)(150)))));
            this.btnOrder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.btnOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrder.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnOrder.Location = new System.Drawing.Point(1292, 57);
            this.btnOrder.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(132, 46);
            this.btnOrder.TabIndex = 8;
            this.btnOrder.Text = "Order";
            this.btnOrder.UseVisualStyleBackColor = false;
            // 
            // btnSuppliers
            // 
            this.btnSuppliers.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSuppliers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(80)))), ((int)(((byte)(150)))));
            this.btnSuppliers.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(80)))), ((int)(((byte)(150)))));
            this.btnSuppliers.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(80)))), ((int)(((byte)(150)))));
            this.btnSuppliers.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.btnSuppliers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuppliers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuppliers.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSuppliers.Location = new System.Drawing.Point(1148, 57);
            this.btnSuppliers.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.btnSuppliers.Name = "btnSuppliers";
            this.btnSuppliers.Size = new System.Drawing.Size(132, 46);
            this.btnSuppliers.TabIndex = 7;
            this.btnSuppliers.Text = "Suppliers";
            this.btnSuppliers.UseVisualStyleBackColor = false;
            // 
            // btnCheckout
            // 
            this.btnCheckout.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCheckout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(80)))), ((int)(((byte)(150)))));
            this.btnCheckout.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(80)))), ((int)(((byte)(150)))));
            this.btnCheckout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(80)))), ((int)(((byte)(150)))));
            this.btnCheckout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.btnCheckout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckout.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCheckout.Location = new System.Drawing.Point(567, 57);
            this.btnCheckout.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.Size = new System.Drawing.Size(132, 46);
            this.btnCheckout.TabIndex = 3;
            this.btnCheckout.Text = "Checkout";
            this.btnCheckout.UseVisualStyleBackColor = false;
            this.btnCheckout.Click += new System.EventHandler(this.btnCheckout_Click);
            // 
            // btnRefunds
            // 
            this.btnRefunds.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnRefunds.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(80)))), ((int)(((byte)(150)))));
            this.btnRefunds.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(80)))), ((int)(((byte)(150)))));
            this.btnRefunds.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(80)))), ((int)(((byte)(150)))));
            this.btnRefunds.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.btnRefunds.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefunds.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefunds.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRefunds.Location = new System.Drawing.Point(713, 57);
            this.btnRefunds.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.btnRefunds.Name = "btnRefunds";
            this.btnRefunds.Size = new System.Drawing.Size(350, 46);
            this.btnRefunds.TabIndex = 5;
            this.btnRefunds.Text = "  Receipts  and  Refunds";
            this.btnRefunds.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefunds.UseVisualStyleBackColor = false;
            this.btnRefunds.Click += new System.EventHandler(this.btnRefunds_Click);
            // 
            // btnCustomer
            // 
            this.btnCustomer.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCustomer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(80)))), ((int)(((byte)(150)))));
            this.btnCustomer.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(80)))), ((int)(((byte)(150)))));
            this.btnCustomer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(80)))), ((int)(((byte)(150)))));
            this.btnCustomer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.btnCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomer.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCustomer.Location = new System.Drawing.Point(422, 57);
            this.btnCustomer.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Size = new System.Drawing.Size(132, 46);
            this.btnCustomer.TabIndex = 2;
            this.btnCustomer.Text = "Customer";
            this.btnCustomer.UseVisualStyleBackColor = false;
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // btnShop
            // 
            this.btnShop.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnShop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(80)))), ((int)(((byte)(150)))));
            this.btnShop.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(80)))), ((int)(((byte)(150)))));
            this.btnShop.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(80)))), ((int)(((byte)(150)))));
            this.btnShop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.btnShop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShop.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnShop.Location = new System.Drawing.Point(278, 57);
            this.btnShop.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.btnShop.Name = "btnShop";
            this.btnShop.Size = new System.Drawing.Size(132, 46);
            this.btnShop.TabIndex = 1;
            this.btnShop.Text = "Shop";
            this.btnShop.UseVisualStyleBackColor = false;
            this.btnShop.Click += new System.EventHandler(this.btnShop_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnlMain.Location = new System.Drawing.Point(0, 108);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1905, 880);
            this.pnlMain.TabIndex = 4;
            this.pnlMain.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.pnlMain_ControlRemoved);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 988);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlBanner);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Book Shop";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.pnlBanner.ResumeLayout(false);
            this.pnlBanner.PerformLayout();
            this.pnlCart.ResumeLayout(false);
            this.pnlCart.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBanner;
        private System.Windows.Forms.Panel pnlCart;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.Button btnInvoice;
        private System.Windows.Forms.Button btnStock;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.Button btnSuppliers;
        private System.Windows.Forms.Button btnCheckout;
        private System.Windows.Forms.Button btnRefunds;
        private System.Windows.Forms.Button btnCustomer;
        private System.Windows.Forms.Button btnShop;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Button btnHome;
        public System.Windows.Forms.Label lblCartQuant;
        private System.Windows.Forms.Label label1;
    }
}

