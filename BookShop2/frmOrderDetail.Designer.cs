namespace BookShop2
{
    partial class frmOrderDetail
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
            this.pnlOrderDetail = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnCancelBook = new System.Windows.Forms.Button();
            this.txtBookTitle = new System.Windows.Forms.TextBox();
            this.cmbBookQuantity = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBookAuthor = new System.Windows.Forms.TextBox();
            this.txtBookPrice = new System.Windows.Forms.TextBox();
            this.pnlOrderDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlOrderDetail
            // 
            this.pnlOrderDetail.Controls.Add(this.label8);
            this.pnlOrderDetail.Controls.Add(this.label11);
            this.pnlOrderDetail.Controls.Add(this.btnCancelBook);
            this.pnlOrderDetail.Controls.Add(this.txtBookTitle);
            this.pnlOrderDetail.Controls.Add(this.cmbBookQuantity);
            this.pnlOrderDetail.Controls.Add(this.label12);
            this.pnlOrderDetail.Controls.Add(this.label1);
            this.pnlOrderDetail.Controls.Add(this.txtBookAuthor);
            this.pnlOrderDetail.Controls.Add(this.txtBookPrice);
            this.pnlOrderDetail.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pnlOrderDetail.Location = new System.Drawing.Point(0, 0);
            this.pnlOrderDetail.Name = "pnlOrderDetail";
            this.pnlOrderDetail.Size = new System.Drawing.Size(1160, 250);
            this.pnlOrderDetail.TabIndex = 90;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.Control;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(30, 19);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 29);
            this.label8.TabIndex = 80;
            this.label8.Text = "Title:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.SystemColors.Control;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(30, 123);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(81, 29);
            this.label11.TabIndex = 74;
            this.label11.Text = "Price:";
            // 
            // btnCancelBook
            // 
            this.btnCancelBook.AutoSize = true;
            this.btnCancelBook.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnCancelBook.Enabled = false;
            this.btnCancelBook.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLight;
            this.btnCancelBook.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(90)))), ((int)(((byte)(175)))));
            this.btnCancelBook.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.btnCancelBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelBook.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCancelBook.Location = new System.Drawing.Point(913, 173);
            this.btnCancelBook.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCancelBook.Name = "btnCancelBook";
            this.btnCancelBook.Size = new System.Drawing.Size(206, 41);
            this.btnCancelBook.TabIndex = 84;
            this.btnCancelBook.Text = "Cancel";
            this.btnCancelBook.UseVisualStyleBackColor = false;
            // 
            // txtBookTitle
            // 
            this.txtBookTitle.BackColor = System.Drawing.Color.White;
            this.txtBookTitle.Enabled = false;
            this.txtBookTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBookTitle.Location = new System.Drawing.Point(326, 23);
            this.txtBookTitle.Margin = new System.Windows.Forms.Padding(4);
            this.txtBookTitle.Name = "txtBookTitle";
            this.txtBookTitle.Size = new System.Drawing.Size(792, 35);
            this.txtBookTitle.TabIndex = 76;
            // 
            // cmbBookQuantity
            // 
            this.cmbBookQuantity.BackColor = System.Drawing.Color.White;
            this.cmbBookQuantity.Enabled = false;
            this.cmbBookQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBookQuantity.FormattingEnabled = true;
            this.cmbBookQuantity.Location = new System.Drawing.Point(327, 173);
            this.cmbBookQuantity.Margin = new System.Windows.Forms.Padding(6);
            this.cmbBookQuantity.Name = "cmbBookQuantity";
            this.cmbBookQuantity.Size = new System.Drawing.Size(272, 37);
            this.cmbBookQuantity.TabIndex = 82;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.SystemColors.Control;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(30, 71);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(95, 29);
            this.label12.TabIndex = 75;
            this.label12.Text = "Author:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 177);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 29);
            this.label1.TabIndex = 81;
            this.label1.Text = "Quantity:";
            // 
            // txtBookAuthor
            // 
            this.txtBookAuthor.BackColor = System.Drawing.Color.White;
            this.txtBookAuthor.Enabled = false;
            this.txtBookAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBookAuthor.Location = new System.Drawing.Point(326, 71);
            this.txtBookAuthor.Margin = new System.Windows.Forms.Padding(4);
            this.txtBookAuthor.Name = "txtBookAuthor";
            this.txtBookAuthor.Size = new System.Drawing.Size(792, 35);
            this.txtBookAuthor.TabIndex = 77;
            // 
            // txtBookPrice
            // 
            this.txtBookPrice.BackColor = System.Drawing.Color.White;
            this.txtBookPrice.Enabled = false;
            this.txtBookPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBookPrice.Location = new System.Drawing.Point(326, 121);
            this.txtBookPrice.Margin = new System.Windows.Forms.Padding(4);
            this.txtBookPrice.Name = "txtBookPrice";
            this.txtBookPrice.Size = new System.Drawing.Size(792, 35);
            this.txtBookPrice.TabIndex = 78;
            // 
            // frmOrderDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1160, 252);
            this.Controls.Add(this.pnlOrderDetail);
            this.Name = "frmOrderDetail";
            this.Text = "Form1";
            this.pnlOrderDetail.ResumeLayout(false);
            this.pnlOrderDetail.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Panel pnlOrderDetail;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label label11;
        public System.Windows.Forms.Button btnCancelBook;
        public System.Windows.Forms.TextBox txtBookTitle;
        public System.Windows.Forms.ComboBox cmbBookQuantity;
        public System.Windows.Forms.Label label12;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtBookAuthor;
        public System.Windows.Forms.TextBox txtBookPrice;
    }
}