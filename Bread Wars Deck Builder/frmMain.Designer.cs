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
            this.clbCards = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCardNum = new System.Windows.Forms.Label();
            this.clbDecks = new System.Windows.Forms.CheckedListBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.tbFilename = new System.Windows.Forms.TextBox();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnPlus1 = new System.Windows.Forms.Button();
            this.btnClearCard = new System.Windows.Forms.Button();
            this.btnPlus5 = new System.Windows.Forms.Button();
            this.btnMinus5 = new System.Windows.Forms.Button();
            this.btnMinus1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // clbCards
            // 
            this.clbCards.FormattingEnabled = true;
            this.clbCards.Items.AddRange(new object[] {
            "1",
            "Thief",
            "2",
            "Table Flip",
            "3",
            "Stab",
            "4",
            "Glue Gun",
            "5",
            "Zombie",
            "6",
            "Jam",
            "7",
            "Save",
            "8",
            "Octopus",
            "9",
            "Punch",
            "10",
            "Poison",
            "11",
            "Faerie Bread",
            "12",
            "Taser",
            "13",
            "Switch Hands",
            "14",
            "Telepathy",
            "15",
            "Block",
            "16",
            "Whale",
            "17",
            "Self-Destruct",
            "18",
            "Fire",
            "19",
            "Unicorn",
            "20",
            "Confetti",
            "Numject to Change"});
            this.clbCards.Location = new System.Drawing.Point(243, 32);
            this.clbCards.Name = "clbCards";
            this.clbCards.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.clbCards.Size = new System.Drawing.Size(124, 277);
            this.clbCards.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Pick a deck to load or edit";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(305, 451);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.DoneClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 456);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(178, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Write filename before clicking save: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(222, 407);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Current number of cards: ";
            // 
            // lblCardNum
            // 
            this.lblCardNum.AutoSize = true;
            this.lblCardNum.Location = new System.Drawing.Point(354, 407);
            this.lblCardNum.Name = "lblCardNum";
            this.lblCardNum.Size = new System.Drawing.Size(13, 13);
            this.lblCardNum.TabIndex = 9;
            this.lblCardNum.Text = "0";
            // 
            // clbDecks
            // 
            this.clbDecks.FormattingEnabled = true;
            this.clbDecks.Location = new System.Drawing.Point(12, 35);
            this.clbDecks.Name = "clbDecks";
            this.clbDecks.Size = new System.Drawing.Size(137, 274);
            this.clbDecks.TabIndex = 10;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(11, 344);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 11;
            this.btnLoad.Text = "Load File";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.LoadClick);
            // 
            // tbFilename
            // 
            this.tbFilename.Location = new System.Drawing.Point(192, 453);
            this.tbFilename.Name = "tbFilename";
            this.tbFilename.Size = new System.Drawing.Size(100, 20);
            this.tbFilename.TabIndex = 12;
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(305, 480);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 23);
            this.btnHelp.TabIndex = 13;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(11, 315);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 14;
            this.btnNew.Text = "New Deck";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnPlus1
            // 
            this.btnPlus1.Location = new System.Drawing.Point(305, 315);
            this.btnPlus1.Name = "btnPlus1";
            this.btnPlus1.Size = new System.Drawing.Size(34, 31);
            this.btnPlus1.TabIndex = 15;
            this.btnPlus1.Text = "+1";
            this.btnPlus1.UseVisualStyleBackColor = true;
            this.btnPlus1.Click += new System.EventHandler(this.btnPlus1_Click);
            // 
            // btnClearCard
            // 
            this.btnClearCard.Location = new System.Drawing.Point(265, 352);
            this.btnClearCard.Name = "btnClearCard";
            this.btnClearCard.Size = new System.Drawing.Size(74, 31);
            this.btnClearCard.TabIndex = 16;
            this.btnClearCard.Text = "Clear Card";
            this.btnClearCard.UseVisualStyleBackColor = true;
            this.btnClearCard.Click += new System.EventHandler(this.btnClearCard_Click);
            // 
            // btnPlus5
            // 
            this.btnPlus5.Location = new System.Drawing.Point(346, 315);
            this.btnPlus5.Name = "btnPlus5";
            this.btnPlus5.Size = new System.Drawing.Size(34, 31);
            this.btnPlus5.TabIndex = 17;
            this.btnPlus5.Text = "+5";
            this.btnPlus5.UseVisualStyleBackColor = true;
            this.btnPlus5.Click += new System.EventHandler(this.btnPlus5_Click);
            // 
            // btnMinus5
            // 
            this.btnMinus5.Location = new System.Drawing.Point(225, 315);
            this.btnMinus5.Name = "btnMinus5";
            this.btnMinus5.Size = new System.Drawing.Size(34, 31);
            this.btnMinus5.TabIndex = 18;
            this.btnMinus5.Text = "-5";
            this.btnMinus5.UseVisualStyleBackColor = true;
            this.btnMinus5.Click += new System.EventHandler(this.btnMinus5_Click);
            // 
            // btnMinus1
            // 
            this.btnMinus1.Location = new System.Drawing.Point(265, 315);
            this.btnMinus1.Name = "btnMinus1";
            this.btnMinus1.Size = new System.Drawing.Size(34, 31);
            this.btnMinus1.TabIndex = 19;
            this.btnMinus1.Text = "-1";
            this.btnMinus1.UseVisualStyleBackColor = true;
            this.btnMinus1.Click += new System.EventHandler(this.btnMinus1_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 511);
            this.Controls.Add(this.btnMinus1);
            this.Controls.Add(this.btnMinus5);
            this.Controls.Add(this.btnPlus5);
            this.Controls.Add(this.btnClearCard);
            this.Controls.Add(this.btnPlus1);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.tbFilename);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.clbDecks);
            this.Controls.Add(this.lblCardNum);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.clbCards);
            this.Name = "frmMain";
            this.Text = "Bread Wars Deck Editor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox clbCards;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblCardNum;
        private System.Windows.Forms.CheckedListBox clbDecks;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.TextBox tbFilename;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnPlus1;
        private System.Windows.Forms.Button btnClearCard;
        private System.Windows.Forms.Button btnPlus5;
        private System.Windows.Forms.Button btnMinus5;
        private System.Windows.Forms.Button btnMinus1;
    }
}