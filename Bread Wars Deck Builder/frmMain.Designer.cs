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
            this.btnApply = new System.Windows.Forms.Button();
            this.tbCardNum = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.clbDecks = new System.Windows.Forms.CheckedListBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.tbFilename = new System.Windows.Forms.TextBox();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
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
            this.clbCards.Location = new System.Drawing.Point(482, 22);
            this.clbCards.Name = "clbCards";
            this.clbCards.Size = new System.Drawing.Size(477, 529);
            this.clbCards.TabIndex = 0;
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(175, 457);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(76, 28);
            this.btnApply.TabIndex = 1;
            this.btnApply.Text = "apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.ApplyClick);
            // 
            // tbCardNum
            // 
            this.tbCardNum.Location = new System.Drawing.Point(97, 462);
            this.tbCardNum.Name = "tbCardNum";
            this.tbCardNum.Size = new System.Drawing.Size(72, 20);
            this.tbCardNum.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-3, 441);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(479, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Select type of cards in the list to the right. Then input desired number of each " +
    "card type and hit apply";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Pick a deck to load and edit";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 395);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Create your own deck";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(366, 529);
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
            this.label4.Location = new System.Drawing.Point(23, 534);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(231, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Write filename and hit Done to save deck to file";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(53, 502);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(181, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Current number of cards (must be 52)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(275, 502);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "0";
            // 
            // clbDecks
            // 
            this.clbDecks.FormattingEnabled = true;
            this.clbDecks.Location = new System.Drawing.Point(15, 48);
            this.clbDecks.Name = "clbDecks";
            this.clbDecks.Size = new System.Drawing.Size(445, 274);
            this.clbDecks.TabIndex = 10;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(326, 343);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 11;
            this.btnLoad.Text = "Load file";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.LoadClick);
            // 
            // tbFilename
            // 
            this.tbFilename.Location = new System.Drawing.Point(260, 531);
            this.tbFilename.Name = "tbFilename";
            this.tbFilename.Size = new System.Drawing.Size(100, 20);
            this.tbFilename.TabIndex = 12;
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(366, 502);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 23);
            this.btnHelp.TabIndex = 13;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(129, 390);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 14;
            this.btnNew.Text = "New Deck";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 571);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.tbFilename);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.clbDecks);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbCardNum);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.clbCards);
            this.Name = "frmMain";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox clbCards;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.TextBox tbCardNum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckedListBox clbDecks;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.TextBox tbFilename;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnNew;
    }
}