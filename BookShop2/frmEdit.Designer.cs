namespace BookShop2
{
    partial class frmEdit
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
            this.lstBook = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAuthorTitle = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.flpCart = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddBook = new System.Windows.Forms.Button();
            this.lblCustomerNo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblOrderNo = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnConfirmEdit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstBook
            // 
            this.lstBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstBook.FormattingEnabled = true;
            this.lstBook.ItemHeight = 29;
            this.lstBook.Location = new System.Drawing.Point(36, 127);
            this.lstBook.Name = "lstBook";
            this.lstBook.Size = new System.Drawing.Size(645, 584);
            this.lstBook.TabIndex = 96;
            this.lstBook.Click += new System.EventHandler(this.lstBook_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(42, 791);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(424, 29);
            this.label3.TabIndex = 94;
            this.label3.Text = "Click for whole  alphabetical list by:";
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
            this.btnAuthorTitle.Location = new System.Drawing.Point(520, 782);
            this.btnAuthorTitle.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnAuthorTitle.Name = "btnAuthorTitle";
            this.btnAuthorTitle.Size = new System.Drawing.Size(154, 39);
            this.btnAuthorTitle.TabIndex = 93;
            this.btnAuthorTitle.Text = "Author";
            this.btnAuthorTitle.UseVisualStyleBackColor = false;
            this.btnAuthorTitle.Click += new System.EventHandler(this.btnAuthorTitle_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtSearch.BackColor = System.Drawing.Color.White;
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(36, 17);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(645, 35);
            this.txtSearch.TabIndex = 92;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(455, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(219, 29);
            this.label4.TabIndex = 95;
            this.label4.Text = "Search Title/Author";
            // 
            // flpCart
            // 
            this.flpCart.AutoScroll = true;
            this.flpCart.Location = new System.Drawing.Point(969, 127);
            this.flpCart.Margin = new System.Windows.Forms.Padding(2);
            this.flpCart.Name = "flpCart";
            this.flpCart.Size = new System.Drawing.Size(807, 584);
            this.flpCart.TabIndex = 97;
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
            this.btnAddBook.Location = new System.Drawing.Point(705, 397);
            this.btnAddBook.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnAddBook.Name = "btnAddBook";
            this.btnAddBook.Size = new System.Drawing.Size(156, 39);
            this.btnAddBook.TabIndex = 86;
            this.btnAddBook.Text = "Add to order";
            this.btnAddBook.UseVisualStyleBackColor = false;
            this.btnAddBook.Click += new System.EventHandler(this.btnAddBook_Click);
            // 
            // lblCustomerNo
            // 
            this.lblCustomerNo.AutoSize = true;
            this.lblCustomerNo.BackColor = System.Drawing.SystemColors.Control;
            this.lblCustomerNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerNo.Location = new System.Drawing.Point(1279, 23);
            this.lblCustomerNo.Name = "lblCustomerNo";
            this.lblCustomerNo.Size = new System.Drawing.Size(0, 29);
            this.lblCustomerNo.TabIndex = 99;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(998, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 29);
            this.label1.TabIndex = 98;
            this.label1.Text = "Customer:";
            // 
            // lblOrderNo
            // 
            this.lblOrderNo.AutoSize = true;
            this.lblOrderNo.BackColor = System.Drawing.SystemColors.Control;
            this.lblOrderNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderNo.Location = new System.Drawing.Point(1769, 23);
            this.lblOrderNo.Name = "lblOrderNo";
            this.lblOrderNo.Size = new System.Drawing.Size(0, 29);
            this.lblOrderNo.TabIndex = 101;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1488, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 29);
            this.label5.TabIndex = 100;
            this.label5.Text = "OrderNo:";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.BackColor = System.Drawing.SystemColors.Control;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Red;
            this.lblTotal.Location = new System.Drawing.Point(1160, 750);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(0, 29);
            this.lblTotal.TabIndex = 103;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(974, 750);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 29);
            this.label2.TabIndex = 102;
            this.label2.Text = "Total:";
            // 
            // btnConfirmEdit
            // 
            this.btnConfirmEdit.AutoSize = true;
            this.btnConfirmEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(80)))), ((int)(((byte)(150)))));
            this.btnConfirmEdit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(80)))), ((int)(((byte)(150)))));
            this.btnConfirmEdit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(80)))), ((int)(((byte)(150)))));
            this.btnConfirmEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.btnConfirmEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmEdit.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnConfirmEdit.Location = new System.Drawing.Point(1622, 781);
            this.btnConfirmEdit.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnConfirmEdit.Name = "btnConfirmEdit";
            this.btnConfirmEdit.Size = new System.Drawing.Size(155, 39);
            this.btnConfirmEdit.TabIndex = 104;
            this.btnConfirmEdit.Text = "Confirm Edit";
            this.btnConfirmEdit.UseVisualStyleBackColor = false;
            this.btnConfirmEdit.Visible = false;
            this.btnConfirmEdit.Click += new System.EventHandler(this.btnConfirmEdit_Click);
            // 
            // frmEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1881, 878);
            this.Controls.Add(this.btnConfirmEdit);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblOrderNo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblCustomerNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddBook);
            this.Controls.Add(this.flpCart);
            this.Controls.Add(this.lstBook);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAuthorTitle);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label4);
            this.Name = "frmEdit";
            this.Text = "Adjustment";
            this.Load += new System.EventHandler(this.Edit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstBook;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAuthorTitle;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FlowLayoutPanel flpCart;
        private System.Windows.Forms.Button btnAddBook;
        private System.Windows.Forms.Label lblCustomerNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblOrderNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnConfirmEdit;
    }
}