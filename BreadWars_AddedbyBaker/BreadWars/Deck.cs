using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.IO;

namespace BreadWars
{
    public class Deck
    {
        //needs to load external deck
        const string PATH = ".";

        Card[] library = new Card[52]; //may change array size based on whether or not we choose one deck or two
        public Card[] Library { get =>library; }

        //can change however you want later, just for testing if other stuffs work
        Texture2D[] cardTexts;
        Rectangle empty = new Rectangle(0, 0, 0, 0);
        Drawable numbers;

        public Deck(Texture2D[] pCardTexts, Drawable pNumbers)
        {   
            cardTexts = pCardTexts;
            numbers = pNumbers;
            //HardcodeDeck();
            //PopulateDeck();
        }

        int count = 0;
        public Card Next()
        {
            Card toReturn = library.ElementAt(count);
            count++;
            return toReturn;
        }


        public void Shuffle()
        {
            List<Card> temp = library.ToList<Card>();
            Random rgen = new Random();
            library = new Card[52];
            for (int i = 0; i <= temp.Count; i++)
            {
                Card tempCard  = temp[rgen.Next(temp.Count)];
                library[i] = tempCard;
                temp.Remove(tempCard);
            }
        }

        //completely random deck stuff for testing
        //@kyle, if you need to discard this to make sync, please copy and paste the back up I'll put in google docs, or let me know so I can. Thanks.
        //you may want to adjust populate to read files, if you don't already have a populator
        int cardsAdded;
        // int list
        List<int> cardsToAdd = new List<int>();

        public void HardcodeDeck()
        {
            cardsToAdd[0] = 3;
            cardsToAdd[1] = 3;
            cardsToAdd[2] = 3;
            cardsToAdd[3] = 2;
            cardsToAdd[4] = 2;
            cardsToAdd[5] = 2;
            cardsToAdd[6] = 2;
            cardsToAdd[7] = 3;
            cardsToAdd[8] = 3;
            cardsToAdd[9] = 3;
            cardsToAdd[10] = 2;
            cardsToAdd[11] = 2;
            cardsToAdd[12] = 2;
            cardsToAdd[13] = 2;
            cardsToAdd[14] = 3;
            cardsToAdd[15] = 3;
            cardsToAdd[16] = 3;
            cardsToAdd[17] = 3;
            cardsToAdd[18] = 2;
            cardsToAdd[19] = 2;
            cardsToAdd[20] = 2;

            cardsAdded = 0;
            
        }

        public void LoadDeck(string filename)
        {
            int[] cards = new int[41];
            cardsToAdd.Clear();
            count = 0;
            try
            {
                // create the BinaryReader
                BinaryReader input = new BinaryReader(File.OpenRead(filename));

                // need to follow the file format to get the data
                for (int i = 0; i < 41; i++)
                {
                    input.ReadString();
                    cards[i] = input.ReadInt32();
                }
                // close when we are done
                input.Close();
            }
            catch (IOException ioe)
            {
                Console.WriteLine("error reading binary.dat: " + ioe.Message);
            }
            for (int i=0; i<cards.Length; i++)
            {
                //for(int j=0; j<cards[i]; j++)
                //{
                    cardsToAdd.Add(cards[i]);
                //}
            }
            PopulateDeck();
        }

        public void PopulateDeck()
        {
            cardsAdded = 0;
            library = new Card[52];
            for (int i = 0; i < cardsToAdd.Count; i ++)
            {
                     for (int j = 0; j < cardsToAdd[i]; j++)
                     {
                         /*
                          0- Thief
                          1- Table flip
                          2- Stab
                          3- Glue Gun
                          4- Zombie
                          5- Jam
                          6- Save for later
                          7- Octopus
                          8- Punch
                          9- Poison
                          10- Faire Bread
                          11- Tazer
                          12- Hand Switch
                          13- Telepathy
                          14- Block
                          15- Whale
                          16-  Banker
                          17- Fire
                          18- Unicorn
                          19- Confetti
                          20-     ??? Numject to Change
                          
                          */

                         switch (i/2)
                         {

                            case 0: //0- Thief
                            Thief th = new Thief(cardTexts[0], empty, i!=0, numbers);
                            library[cardsAdded] = th;
                            cardsAdded++;
                            break;
                             case 1: //1- Table flip
                            TableFlip tf = new TableFlip(cardTexts[1], empty, i!=1, numbers);
                            library[cardsAdded] = tf;
                            cardsAdded++;
                            break;
                             case 2: //2- Stab
                            Stab s = new Stab(cardTexts[2], empty, i!=2, numbers);
                            library[cardsAdded] = s;
                            cardsAdded++;
                            break;
                             case 3: //3- Glue Gun
                            GlueGun gg = new GlueGun(cardTexts[3], empty, i!=3, numbers);
                            library[cardsAdded] = gg;
                            cardsAdded++;
                            break;
                             case 4: //4- Zombie
                             Zombie z = new Zombie(cardTexts[4], empty, i!=4, numbers);
                            library[cardsAdded] = z;
                            cardsAdded++;
                            break;
                             case 5: //5- Jam
                            Jam ja = new Jam(cardTexts[5], empty, i!=5, numbers);
                            library[cardsAdded] = ja;
                            cardsAdded++;
                            break;
                             case 6: //6- Save For Later
                            SaveForLater sl = new SaveForLater(cardTexts[6], empty, i!=6, numbers);
                            library[cardsAdded] = sl;
                            cardsAdded++;
                            break;
                             case 7: //7- Octopus
                            Octopus o = new Octopus(cardTexts[7], empty, i!=7, numbers);
                            library[cardsAdded] = o;
                            cardsAdded++;
                            break;
                             case 8: //8 Punch
                            Punch p = new Punch(cardTexts[8], empty, i!=8, numbers);
                            library[cardsAdded] = p;
                            cardsAdded++;
                            break;
                             case 9: //poison
                            Poison po = new Poison(cardTexts[9], empty, i!=9, numbers);
                            library[cardsAdded] = po;
                            cardsAdded++;
                            break;
                             case 10: //faire bread
                            FaireBread fb = new FaireBread(cardTexts[10], empty, i!=10, numbers);
                            library[cardsAdded] = fb;
                            cardsAdded++;
                            break;
                             case 11: //tazer
                            Tazer ta = new Tazer(cardTexts[11], empty, i!=11, numbers);
                            library[cardsAdded] = ta;
                            cardsAdded++;
                            break;
                             case 12: //hand switch
                            HandSwitch hs = new HandSwitch(cardTexts[12], empty, i!=12, numbers);
                            library[cardsAdded] = hs;
                            cardsAdded++;
                            break;
                             case 13: //telepathy
                            Telepathy te = new Telepathy(cardTexts[13], empty, i!=13, numbers);
                            library[cardsAdded] = te;
                            cardsAdded++;
                            break;
                             case 14: //block
                            Block bl = new Block(cardTexts[14], empty, i!=14, numbers);
                            library[cardsAdded] = bl;
                            cardsAdded++;
                            break;
                             case 15: //whale
                            Whale wh = new Whale(cardTexts[15], empty, i!=15, numbers);
                            library[cardsAdded] = wh;
                            cardsAdded++;
                            break;
                             case 16: //banker
                            SelfDestruct b = new SelfDestruct(cardTexts[16], empty, i!=16, numbers);
                            library[cardsAdded] = b;
                            cardsAdded++;
                            break;
                             case 17: //fire
                            Fire fi = new Fire(cardTexts[17], empty, i!=17, numbers);
                            library[cardsAdded] = fi;
                            cardsAdded++;
                            break;
                             case 18: //unicorn
                            Unicorn u = new Unicorn(cardTexts[18], empty, i!=18, numbers);
                            library[cardsAdded] = u;
                            cardsAdded++;
                            break;
                             case 19: //confetti
                            Confetti c = new Confetti(cardTexts[19], empty, i!=19, numbers);
                            library[cardsAdded] = c;
                            cardsAdded++;
                            break;
                             case 20: //numbject to change
                            NumjectToChange nj = new NumjectToChange(cardTexts[20], empty, false, numbers);
                            library[cardsAdded] = nj;
                            cardsAdded++;
                            break;
                            default:
                                 break;
                         }
                     }        
            }
        }

    }
}
