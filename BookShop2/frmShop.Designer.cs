namespace BookShop2
{
    partial class frmShop
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblLowStock = new System.Windows.Forms.Label();
            this.lblBookOrderMessage = new System.Windows.Forms.Label();
            this.btnChangeCust = new System.Windows.Forms.Button();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddBook = new System.Windows.Forms.Button();
            this.btnCheckout = new System.Windows.Forms.Button();
            this.btnCancelBook = new System.Windows.Forms.Button();
            this.cmbBookQuantity = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBookPrice = new System.Windows.Forms.TextBox();
            this.txtBookAuthor = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtBookTitle = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lstBook = new System.Windows.Forms.ListBox();
            this.btnAuthorTitle = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblLowStock);
            this.panel1.Controls.Add(this.lblBookOrderMessage);
            this.panel1.Controls.Add(this.btnChangeCust);
            this.panel1.Controls.Add(this.lblCustomer);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnAddBook);
            this.panel1.Controls.Add(this.btnCheckout);
            this.panel1.Controls.Add(this.btnCancelBook);
            this.panel1.Controls.Add(this.cmbBookQuantity);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtBookPrice);
            this.panel1.Controls.Add(this.txtBookAuthor);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.txtBookTitle);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Location = new System.Drawing.Point(942, 130);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(872, 684);
            this.panel1.TabIndex = 0;
            // 
            // lblLowStock
            // 
            this.lblLowStock.AutoSize = true;
            this.lblLowStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLowStock.Location = new System.Drawing.Point(510, 410);
            this.lblLowStock.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLowStock.Name = "lblLowStock";
            this.lblLowStock.Size = new System.Drawing.Size(129, 29);
            this.lblLowStock.TabIndex = 89;
            this.lblLowStock.Text = "(low stock)";
            this.lblLowStock.Visible = false;
            // 
            // lblBookOrderMessage
            // 
            this.lblBookOrderMessage.AutoSize = true;
            this.lblBookOrderMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBookOrderMessage.Location = new System.Drawing.Point(286, 619);
            this.lblBookOrderMessage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBookOrderMessage.Name = "lblBookOrderMessage";
            this.lblBookOrderMessage.Size = new System.Drawing.Size(327, 29);
            this.lblBookOrderMessage.TabIndex = 88;
            this.lblBookOrderMessage.Text = "Order has been added to cart";
            this.lblBookOrderMessage.Visible = false;
            // 
            // btnChangeCust
            // 
            this.btnChangeCust.AutoSize = true;
            this.btnChangeCust.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(80)))), ((int)(((byte)(150)))));
            this.btnChangeCust.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(80)))), ((int)(((byte)(150)))));
            this.btnChangeCust.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(80)))), ((int)(((byte)(150)))));
            this.btnChangeCust.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.btnChangeCust.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangeCust.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnChangeCust.Location = new System.Drawing.Point(690, 30);
            this.btnChangeCust.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnChangeCust.Name = "btnChangeCust";
            this.btnChangeCust.Size = new System.Drawing.Size(154, 39);
            this.btnChangeCust.TabIndex = 85;
            this.btnChangeCust.Text = "Change";
            this.btnChangeCust.UseVisualStyleBackColor = false;
            this.btnChangeCust.Click += new System.EventHandler(this.btnChangeCust_Click);
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.BackColor = System.Drawing.SystemColors.Control;
            this.lblCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomer.Location = new System.Drawing.Point(247, 46);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(0, 29);
            this.lblCustomer.TabIndex = 87;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 29);
            this.label2.TabIndex = 86;
            this.label2.Text = "Customer:";
            // 
            // btnAddBook
            // 
            this.btnAddBook.AutoSize = true;
            this.btnAddBook.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnAddBook.Enabled = false;
            this.btnAddBook.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLight;
            this.btnAddBook.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(90)))), ((int)(((byte)(175)))));
            this.btnAddBook.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.btnAddBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddBook.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAddBook.Location = new System.Drawing.Point(510, 511);
            this.btnAddBook.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnAddBook.Name = "btnAddBook";
            this.btnAddBook.Size = new System.Drawing.Size(154, 39);
            this.btnAddBook.TabIndex = 85;
            this.btnAddBook.Text = "Add to cart";
            this.btnAddBook.UseVisualStyleBackColor = false;
            this.btnAddBook.Click += new System.EventHandler(this.btnAddBook_Click);
            // 
            // btnCheckout
            // 
            this.btnCheckout.AutoSize = true;
            this.btnCheckout.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnCheckout.Enabled = false;
            this.btnCheckout.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLight;
            this.btnCheckout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(90)))), ((int)(((byte)(175)))));
            this.btnCheckout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.btnCheckout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckout.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCheckout.Location = new System.Drawing.Point(690, 610);
            this.btnCheckout.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.Size = new System.Drawing.Size(154, 39);
            this.btnCheckout.TabIndex = 83;
            this.btnCheckout.Text = "Checkout";
            this.btnCheckout.UseVisualStyleBackColor = false;
            this.btnCheckout.Click += new System.EventHandler(this.btnCheckout_Click);
            // 
            // btnCancelBook
            // 
            this.btnCancelBook.AutoSize = true;
            this.btnCancelBook.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnCancelBook.Enabled = false;
            this.btnCancelBook.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLight;
            this.btnCancelBook.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(90)))), ((int)(((byte)(175)))));
            this.btnCancelBook.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.btnCancelBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelBook.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCancelBook.Location = new System.Drawing.Point(690, 511);
            this.btnCancelBook.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnCancelBook.Name = "btnCancelBook";
            this.btnCancelBook.Size = new System.Drawing.Size(154, 39);
            this.btnCancelBook.TabIndex = 84;
            this.btnCancelBook.Text = "Cancel";
            this.btnCancelBook.UseVisualStyleBackColor = false;
            this.btnCancelBook.Click += new System.EventHandler(this.btnCancelBook_Click);
            // 
            // cmbBookQuantity
            // 
            this.cmbBookQuantity.BackColor = System.Drawing.Color.White;
            this.cmbBookQuantity.Enabled = false;
            this.cmbBookQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBookQuantity.FormattingEnabled = true;
            this.cmbBookQuantity.Location = new System.Drawing.Point(250, 404);
            this.cmbBookQuantity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbBookQuantity.Name = "cmbBookQuantity";
            this.cmbBookQuantity.Size = new System.Drawing.Size(205, 37);
            this.cmbBookQuantity.TabIndex = 82;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 407);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 29);
            this.label1.TabIndex = 81;
            this.label1.Text = "Quantity:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.Control;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(28, 231);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 29);
            this.label8.TabIndex = 80;
            this.label8.Text = "Title:";
            // 
            // txtBookPrice
            // 
            this.txtBookPrice.BackColor = System.Drawing.Color.White;
            this.txtBookPrice.Enabled = false;
            this.txtBookPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBookPrice.Location = new System.Drawing.Point(250, 333);
            this.txtBookPrice.Name = "txtBookPrice";
            this.txtBookPrice.Size = new System.Drawing.Size(595, 35);
            this.txtBookPrice.TabIndex = 78;
            // 
            // txtBookAuthor
            // 
            this.txtBookAuthor.BackColor = System.Drawing.Color.White;
            this.txtBookAuthor.Enabled = false;
            this.txtBookAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBookAuthor.Location = new System.Drawing.Point(250, 285);
            this.txtBookAuthor.Name = "txtBookAuthor";
            this.txtBookAuthor.Size = new System.Drawing.Size(595, 35);
            this.txtBookAuthor.TabIndex = 77;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.SystemColors.Control;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(28, 285);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(95, 29);
            this.label12.TabIndex = 75;
            this.label12.Text = "Author:";
            // 
            // txtBookTitle
            // 
            this.txtBookTitle.BackColor = System.Drawing.Color.White;
            this.txtBookTitle.Enabled = false;
            this.txtBookTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBookTitle.Location = new System.Drawing.Point(250, 234);
            this.txtBookTitle.Name = "txtBookTitle";
            this.txtBookTitle.Size = new System.Drawing.Size(595, 35);
            this.txtBookTitle.TabIndex = 76;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.SystemColors.Control;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(28, 334);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(81, 29);
            this.label11.TabIndex = 74;
            this.label11.Text = "Price:";
            // 
            // txtSearch
            // 
            this.txtSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtSearch.BackColor = System.Drawing.Color.White;
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(90, 57);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(598, 35);
            this.txtSearch.TabIndex = 83;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lstBook
            // 
            this.lstBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstBook.FormattingEnabled = true;
            this.lstBook.ItemHeight = 29;
            this.lstBook.Location = new System.Drawing.Point(89, 130);
            this.lstBook.Margin = new System.Windows.Forms.Padding(2);
            this.lstBook.Name = "lstBook";
            this.lstBook.Size = new System.Drawing.Size(824, 613);
            this.lstBook.TabIndex = 85;
            this.lstBook.Click += new System.EventHandler(this.lstBook_Click);
            // 
            // btnAuthorTitle
            // 
            this.btnAuthorTitle.AutoSize = true;
            this.btnAuthorTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(80)))), ((int)(((byte)(150)))));
            this.btnAuthorTitle.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(80)))), ((int)(((byte)(150)))));
            this.btnAuthorTitle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(80)))), ((int)(((byte)(150)))));
            this.btnAuthorTitle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.btnAuthorTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAuthorTitle.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAuthorTitle.Location = new System.Drawing.Point(758, 782);
            this.btnAuthorTitle.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnAuthorTitle.Name = "btnAuthorTitle";
            this.btnAuthorTitle.Size = new System.Drawing.Size(154, 39);
            this.btnAuthorTitle.TabIndex = 86;
            this.btnAuthorTitle.Text = "Author";
            this.btnAuthorTitle.UseVisualStyleBackColor = false;
            this.btnAuthorTitle.Click += new System.EventHandler(this.btnAuthorTitle_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(280, 791);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(424, 29);
            this.label3.TabIndex = 88;
            this.label3.Text = "Click for whole  alphabetical list by:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(694, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(219, 29);
            this.label4.TabIndex = 89;
            this.label4.Text = "Search Title/Author";
            // 
            // frmShop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1881, 878);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAuthorTitle);
            this.Controls.Add(this.lstBook);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmShop";
            this.Text = "Shop";
            this.Load += new System.EventHandler(this.frmShop_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtBookPrice;
        private System.Windows.Forms.TextBox txtBookAuthor;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtBookTitle;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbBookQuantity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnAddBook;
        private System.Windows.Forms.Button btnCheckout;
        private System.Windows.Forms.Button btnCancelBook;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnChangeCust;
        private System.Windows.Forms.ListBox lstBook;
        private System.Windows.Forms.Button btnAuthorTitle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblBookOrderMessage;
        private System.Windows.Forms.Label lblLowStock;
        private System.Windows.Forms.Label label4;
    }
}