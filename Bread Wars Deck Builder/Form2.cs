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
    public partial class Form2 : Form
    {

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
        private string[] files= new string[] { "" };
        private int[] numberCards;
        private int sumCards;


        public Form2()
        {
            InitializeComponent();
            this.checkedListBox1.Items.AddRange(cards);
            this.checkedListBox2.Items.AddRange(files);
            numberCards = new int[cards.Length];
            sumCards = 0;
        }

        public void WriteFile()
        {
            string filename = "1.dat";

            // handles exceptions
            try
            {
                // create a stream
                Stream str = File.OpenWrite(filename);

                // create the binary writer object
                BinaryWriter output = new BinaryWriter(str);

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
            // read in binary.dat first
            try
            {
                // create the BinaryReader
                BinaryReader input = new BinaryReader(File.OpenRead(filename));

                // need to follow the file format to get the data
               for(int i=0; i<41; i++)
                {
                    Console.WriteLine(input.ReadString());
                    Console.WriteLine(input.ReadInt32());
                }

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
            Console.WriteLine("apply");
            int value = 0;
            try { value = int.Parse(textBox1.Text); } catch { }
            
            foreach (int indexChecked in checkedListBox1.CheckedIndices)
            {
                numberCards[indexChecked] += value;
                sumCards += value;
                checkedListBox1.Items[indexChecked] = checkedListBox1.Items[indexChecked] + " " + value;
            }

            label6.Text = sumCards.ToString();

        }

        private void DoneClick(object sender, EventArgs e)
        {
                if (sumCards == 52)
                {
                    WriteFile();
                }
            
        }
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form2 f2 = new Form2();
            Application.Run(f2);
        }
    }
}
