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
            "thief",
            "thief special",
            "table flip",
            "table flip special",
            "stab",
            "stab special",
            "glue gun",
            "glue gun special",
            "zombie",
            "zombie special",
            "jam",
            "jam special",
            "save for later",
            "save for later spcial",
            "octopus",
            "octopus special",
            "punch",
            "punch special",
            "poison",
            "poison special",
            "Faire Bread",
            "faire bread special",
            "Tazer",
            "tazer special",
            "Hand Switch",
            "hand switch special",
            "Telepathy",
            "telepathy special",
            "Block",
            "block special",
            "Whale",
            "whale special",
            " Banker",
            "banker special",
            "Fire",
            "fire special",
            "Unicorn",
            "unicorn special",
            "Confetti",
            "confetti special",
            "Numject to Change"};
        private List<string> files = new List<string>(); //for all deck files in existance
        private int[] numberCards; //number desired cards per type
        private int sumCards; //total number cards in deck, should be 52


        public frmMain()
        {
            InitializeComponent();
            string[] allFiles = Directory.GetFiles("."); //get all files in directory;
            foreach(string f in allFiles) //only keep deck files
            {
                if (f.Contains(".dat")) files.Add(f.Substring(2, f.Length-6));
            }
            //set options on form correctly
            this.checkedListBox1.Items.Clear();
            this.checkedListBox2.Items.Clear();
            this.checkedListBox1.Items.AddRange(cards);
            this.checkedListBox2.Items.AddRange(files.ToArray());
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
                Console.WriteLine("Error creating " + filename +": " + ioe.Message);
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
                    checkedListBox1.Items[i] = cards[i] + " " + numberCards[i]; //update display on form
                    sumCards += numberCards[i]; //edit overal number of cards in deck
                }
                label6.Text = sumCards.ToString(); //display to form number of cards in deck
                // close when we are done
                input.Close();
            }
            catch (IOException ioe)
            {
                Console.WriteLine("error reading binary.dat: " + ioe.Message);
            }

        }

        private void ApplyClick(object sender, EventArgs e)
        {
            int value = 0;
            try { value = int.Parse(textBox1.Text); } catch { } //only function if user input an int value
            
            //update number of cards as specified by user
            foreach (int indexChecked in checkedListBox1.CheckedIndices)
            {
                if ((numberCards[indexChecked] + value) < 0) continue; //cards cannot have negative amount
                numberCards[indexChecked] += value;
                sumCards += value;
                checkedListBox1.Items[indexChecked] = cards[indexChecked] + " " + numberCards[indexChecked];//write on form number of card 
            }

            label6.Text = sumCards.ToString(); //write to form total number cards on deck

        }

        private void DoneClick(object sender, EventArgs e)
        {
                if (sumCards == 52 && textBox2.Text!= "") //if the deck is full then save to file
                {
                    WriteFile(textBox2.Text);
                }
            
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
            if (checkedListBox2.SelectedItems.Count == 1) ReadFile((string)checkedListBox2.SelectedItem);
            else ReadFile("1.dat");
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            frmHelp fhelp = new frmHelp();

            fhelp.Show();
        }
    }
}
