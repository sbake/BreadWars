namespace Bread_Wars_Deck_Builder
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lbl1 = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl5 = new System.Windows.Forms.Label();
            this.lblSize = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.cbbDeck = new System.Windows.Forms.ComboBox();
            this.cbbCards = new System.Windows.Forms.ComboBox();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lstSummary = new System.Windows.Forms.ListBox();
            this.lbl4 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(386, 297);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(467, 297);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(34, 31);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(101, 13);
            this.lbl1.TabIndex = 3;
            this.lbl1.Text = "Choose your Deck: ";
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(305, 297);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 5;
            this.btnNew.Text = "New Deck";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Location = new System.Drawing.Point(44, 232);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(89, 13);
            this.lbl2.TabIndex = 6;
            this.lbl2.Text = "Amount of Each: ";
            // 
            // lbl5
            // 
            this.lbl5.AutoSize = true;
            this.lbl5.Location = new System.Drawing.Point(44, 278);
            this.lbl5.Name = "lbl5";
            this.lbl5.Size = new System.Drawing.Size(99, 13);
            this.lbl5.TabIndex = 7;
            this.lbl5.Text = "Current Deck Size: ";
            // 
            // lblSize
            // 
            this.lblSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSize.Location = new System.Drawing.Point(140, 267);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(49, 34);
            this.lblSize.TabIndex = 9;
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(139, 229);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(50, 20);
            this.txtAmount.TabIndex = 10;
            // 
            // cbbDeck
            // 
            this.cbbDeck.FormattingEnabled = true;
            this.cbbDeck.Location = new System.Drawing.Point(37, 47);
            this.cbbDeck.Name = "cbbDeck";
            this.cbbDeck.Size = new System.Drawing.Size(129, 21);
            this.cbbDeck.TabIndex = 11;
            // 
            // cbbCards
            // 
            this.cbbCards.FormattingEnabled = true;
            this.cbbCards.Location = new System.Drawing.Point(37, 97);
            this.cbbCards.Name = "cbbCards";
            this.cbbCards.Size = new System.Drawing.Size(129, 21);
            this.cbbCards.TabIndex = 12;
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Location = new System.Drawing.Point(34, 81);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(80, 13);
            this.lbl3.TabIndex = 13;
            this.lbl3.Text = "Choose a Card:";
            // 
            // lstSummary
            // 
            this.lstSummary.FormattingEnabled = true;
            this.lstSummary.Location = new System.Drawing.Point(305, 29);
            this.lstSummary.Name = "lstSummary";
            this.lstSummary.Size = new System.Drawing.Size(236, 238);
            this.lstSummary.TabIndex = 14;
            // 
            // lbl4
            // 
            this.lbl4.AutoSize = true;
            this.lbl4.Location = new System.Drawing.Point(302, 13);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(85, 13);
            this.lbl4.TabIndex = 15;
            this.lbl4.Text = "Deck Summary: ";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(37, 124);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 16;
            this.btnAdd.Text = "Add Card";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 342);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lbl4);
            this.Controls.Add(this.lstSummary);
            this.Controls.Add(this.lbl3);
            this.Controls.Add(this.cbbCards);
            this.Controls.Add(this.cbbDeck);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.lblSize);
            this.Controls.Add(this.lbl5);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Name = "frmMain";
            this.Text = "Bread Wars Deck Builder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lbl5;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.ComboBox cbbDeck;
        private System.Windows.Forms.ComboBox cbbCards;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.ListBox lstSummary;
        private System.Windows.Forms.Label lbl4;
        private System.Windows.Forms.Button btnAdd;
    }
}

