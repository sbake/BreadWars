using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bread_Wars_Deck_Builder
{
    public partial class frmMain : Form
    {
        //array possible cards (names, both normal and special)
        private string[] cards = new string[] {
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
            "Numject to Change"};

        private List<string> files = new List<string>(); //for all deck files in existance
        private int[] numberCards; //number desired cards per type
        private int sumCards; //total number cards in deck, should be 52


        public frmMain()
        {
            InitializeComponent();

            
            //set options on form correctly
            this.clbCards.Items.Clear();
            this.clbDecks.Items.Clear();
            Reload();
            this.clbCards.Items.AddRange(cards);
            //initialize attributes
            numberCards = new int[cards.Length];
            sumCards = 0;
        }

        /// <summary>
        /// will write deck information to binary file with name given by param f. 
        /// </summary>
        /// <param name="f">File name. Any file type will be removed (ex. WriteFile("1.txt") will write to "1.dat")</param>
        public void WriteFile(string f)
        {
            string filename = f + ".dat";
            if (f.Contains("."))
            {
                filename = f.Split('.')[0] + ".dat";
            }

            // handles exceptions
            try
            {
                // create a stream
                Stream str = File.OpenWrite(filename);

                // create the binary writer object
                BinaryWriter output = new BinaryWriter(str);

                //write information (name and number) for each card type
                for(int i=0; i<cards.Length; i++)
                {
                    output.Write(cards[i]);
                    output.Write(numberCards[i]);
                }
               
                // close the file since we are done
                output.Close();
            }
            catch (IOException ioe)
            {
                MessageBox.Show(ioe.Message, "Error creating file", MessageBoxButtons.OK);
            }
            
        }

        //for editing files
        public void ReadFile(string filename)
        {
            // read in filename.dat first
            try
            {
                // create the BinaryReader
                BinaryReader input = new BinaryReader(File.OpenRead(filename));

                // need to follow the file format to get the data
               for(int i=0; i<41; i++)
                {
                    input.ReadString(); //read name of card
                    numberCards[i] = input.ReadInt32(); //save number of the card
                    clbCards.Items[i] = cards[i] + " " + numberCards[i]; //update display on form
                    sumCards += numberCards[i]; //edit overal number of cards in deck
                }
                lblCardNum.Text = sumCards.ToString(); //display to form number of cards in deck
                // close when we are done
                input.Close();
            }
            catch (IOException ioe)
            {
                MessageBox.Show(ioe.Message, "Error reading file", MessageBoxButtons.OK);
            }

        }

        private void DoneClick(object sender, EventArgs e)
        {
            try
            {
                if (sumCards == 52 && tbFilename.Text != "") //if the deck is full then save to file
                {
                    WriteFile(tbFilename.Text);
                }
                else
                {
                    
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error Saving File", "Error", MessageBoxButtons.OK);
            }

            Reload();

        }
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frmMain f2 = new frmMain();
            Application.Run(f2);
        }

        private void LoadClick(object sender, EventArgs e)
        {
            //if there is one specified file to read from , read from that file
            //otherwise read from default file
            if (clbDecks.SelectedItems.Count == 1)
            {
                ReadFile((string)clbDecks.SelectedItem + ".dat");
                Uncheck(clbDecks);
            }
            else
            {
                
            }
            
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            frmHelp fhelp = new frmHelp();

            fhelp.Show();
        }

        private void Reload()
        {
            this.clbDecks.Items.Clear();
            files.Clear();
            string[] allFiles = Directory.GetFiles("."); //get all files in directory;
            foreach (string f in allFiles) //only keep deck files
            { 
                if (f.Contains(".dat")) files.Add(f.Substring(2, f.Length - 6));
            }

            this.clbDecks.Items.AddRange(files.ToArray());
        }

        private void btnMinus5_Click(object sender, EventArgs e)
        {
            int value = -5;

            foreach (int indexChecked in clbCards.SelectedIndices)
            {
                if ((numberCards[indexChecked] + value) < 0) continue; //cards cannot have negative amount
                numberCards[indexChecked] += value;
                sumCards += value;
                clbCards.Items[indexChecked] = cards[indexChecked] + " " + numberCards[indexChecked];//write on form number of card 
                
            }

            lblCardNum.Text = sumCards.ToString(); //write to form total number cards on deck]
            //Uncheck(clbCards);
        }

        private void btnMinus1_Click(object sender, EventArgs e)
        {
            int value = -1;

            foreach (int indexChecked in clbCards.SelectedIndices)
            {
                if ((numberCards[indexChecked] + value) < 0) continue; //cards cannot have negative amount
                numberCards[indexChecked] += value;
                sumCards += value;
                clbCards.Items[indexChecked] = cards[indexChecked] + " " + numberCards[indexChecked];//write on form number of card 
            }

            lblCardNum.Text = sumCards.ToString(); //write to form total number cards on deck]
        }

        private void btnPlus1_Click(object sender, EventArgs e)
        {
            int value = 1;

            foreach (int indexChecked in clbCards.SelectedIndices)
            {
                if ((numberCards[indexChecked] + value) < 0) continue; //cards cannot have negative amount
                numberCards[indexChecked] += value;
                sumCards += value;
                clbCards.Items[indexChecked] = cards[indexChecked] + " " + numberCards[indexChecked];//write on form number of card 
            }

            lblCardNum.Text = sumCards.ToString(); //write to form total number cards on deck]
        }

        private void btnPlus5_Click(object sender, EventArgs e)
        {
            int value = 5;


            foreach (int indexChecked in clbCards.SelectedIndices)
            {
                if ((numberCards[indexChecked] + value) < 0) continue; //cards cannot have negative amount
                numberCards[indexChecked] += value;
                sumCards += value;
                clbCards.Items[indexChecked] = cards[indexChecked] + " " + numberCards[indexChecked];//write on form number of card 
            }

            lblCardNum.Text = sumCards.ToString(); //write to form total number cards on deck]
            //Uncheck(clbCards);
        }

        private void btnClearCard_Click(object sender, EventArgs e)
        {
            int value = -999;

           /* foreach (string item in clbCards.Items)
            {
                if ((numberCards[indexChecked] + value) < 0) continue; //cards cannot have negative amount
                numberCards[indexChecked] += value;
                sumCards += value;
                clbCards.Items[indexChecked] = cards[indexChecked] + " " + numberCards[indexChecked];//write on form number of card 
            } */

            Uncheck(clbCards);
            lblCardNum.Text = sumCards.ToString(); //write to form total number cards on deck]
        }

        private void Uncheck(CheckedListBox clb)
        {
            for (int i = 0; i < clb.Items.Count; i++)
            {
                clb.SetItemChecked(i, false);
            }
        }
        private void Uncheck(ListBox lb)
        {
            for (int i = 0; i < lb.Items.Count; i++)
            {
                lb.ClearSelected();
            }
        }
    }
}
