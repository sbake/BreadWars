using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;


namespace BreadWars
{
    public class Deck
    {
        //needs to load external deck
        const string PATH = ".";

        Card[] library = new Card[52]; //may change array size based on whether or not we choose one deck or two
        public Card[] Library { get =>library; }

        //can change however you want later, just for testing if other stuffs work
        int count = 0;
        public Card Next()
        {
            Card toReturn = library.ElementAt(count);
            count++;
            return toReturn;
        }

        //completely random deck stuff for testing
        //@kyle, if you need to discard this to make sync, please copy and paste the back up I'll put in google docs, or let me know so I can. Thanks.
        //you may want to adjust populate to read files, if you don't already have a populator
        int cardsAdded;
        //21 int array
        int[] cardsToAdd = new int[21];
        public void HardcodeDeck()
        {
            cardsToAdd[0] = 2;
            cardsToAdd[1] = 2;
            cardsToAdd[2] = 2;
            cardsToAdd[3] = 2;
            cardsToAdd[4] = 2;
            cardsToAdd[5] = 2;
            cardsToAdd[6] = 2;
            cardsToAdd[7] = 2;
            cardsToAdd[8] = 2;
            cardsToAdd[9] = 2;
            cardsToAdd[10] = 2;
            cardsToAdd[11] = 2;
            cardsToAdd[12] = 2;
            cardsToAdd[13] = 2;
            cardsToAdd[14] = 2;
            cardsToAdd[15] = 2;
            cardsToAdd[16] = 2;
            cardsToAdd[17] = 3;
            cardsToAdd[18] = 5;
            cardsToAdd[19] = 5;
            cardsToAdd[20] = 5;

            cardsAdded = 0;
        }

        public void PopulateDeck(Random rng, Texture2D Texture)
        {
            for (int i = 0; i < cardsToAdd.Length; i ++)
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

                         switch (i)
                         {

                             case 0: //0- Thief
                            Thief th = new Thief(null, new Rectangle(0, 0, 0, 0), false);
                            library[cardsAdded] = th;
                            cardsAdded++;
                            break;
                             case 1: //1- Table flip
                            TableFlip tf = new TableFlip(null, new Rectangle(0, 0, 0, 0), false);
                            library[cardsAdded] = tf;
                            cardsAdded++;
                            break;
                             case 2: //2- Stab
                            Stab s = new Stab(null, new Rectangle(0, 0, 0, 0), false);
                            library[cardsAdded] = s;
                            cardsAdded++;
                            break;
                             case 3: //3- Glue Gun
                            GlueGun gg = new GlueGun(null, new Rectangle(0, 0, 0, 0), false);
                            library[cardsAdded] = gg;
                            cardsAdded++;
                            break;
                             case 4: //4- Zombie
                             Zombie z = new Zombie(null, new Rectangle(0, 0, 0, 0), false);
                            library[cardsAdded] = z;
                            cardsAdded++;
                            break;
                             case 5: //5- Jam
                            Jam ja = new Jam(null, new Rectangle(0, 0, 0, 0), false);
                            library[cardsAdded] = ja;
                            cardsAdded++;
                            break;
                             case 6: //6- Save For Later
                            SaveForLater sl = new SaveForLater(null, new Rectangle(0, 0, 0, 0), false);
                            library[cardsAdded] = sl;
                            cardsAdded++;
                            break;
                             case 7: //7- Octopus
                            Octopus o = new Octopus(null, new Rectangle(0, 0, 0, 0), false);
                            library[cardsAdded] = o;
                            cardsAdded++;
                            break;
                             case 8: //8 Punch
                            Punch p = new Punch(null, new Rectangle(0, 0, 0, 0), false);
                            library[cardsAdded] = p;
                            cardsAdded++;
                            break;
                             case 9: //poison
                            Poison po = new Poison(null, new Rectangle(0, 0, 0, 0), false);
                            library[cardsAdded] = po;
                            cardsAdded++;
                            break;
                             case 10: //faire bread
                            FaireBread fb = new FaireBread(null, new Rectangle(0, 0, 0, 0), false);
                            library[cardsAdded] = fb;
                            cardsAdded++;
                            break;
                             case 11: //tazer
                            Tazer ta = new Tazer(null, new Rectangle(0, 0, 0, 0), false);
                            library[cardsAdded] = ta;
                            cardsAdded++;
                            break;
                             case 12: //hand switch
                            HandSwitch hs = new HandSwitch(null, new Rectangle(0, 0, 0, 0), false);
                            library[cardsAdded] = hs;
                            cardsAdded++;
                            break;
                             case 13: //telepathy
                            Telepathy te = new Telepathy(null, new Rectangle(0, 0, 0, 0), false);
                            library[cardsAdded] = te;
                            cardsAdded++;
                            break;
                             case 14: //block
                            Block bl = new Block(null, new Rectangle(0, 0, 0, 0), false);
                            library[cardsAdded] = bl;
                            cardsAdded++;
                            break;
                             case 15: //whale
                            Whale wh = new Whale(null, new Rectangle(0, 0, 0, 0), false);
                            library[cardsAdded] = wh;
                            cardsAdded++;
                            break;
                             case 16: //banker
                            Banker b = new Banker(null, new Rectangle(0, 0, 0, 0), false);
                            library[cardsAdded] = b;
                            cardsAdded++;
                            break;
                             case 17: //fire
                            Fire fi = new Fire(null, new Rectangle(0, 0, 0, 0), false);
                            library[cardsAdded] = fi;
                            cardsAdded++;
                            break;
                             case 18: //unicorn
                            Unicorn u = new Unicorn(null, new Rectangle(0, 0, 0, 0), false);
                            library[cardsAdded] = u;
                            cardsAdded++;
                            break;
                             case 19: //confetti
                            Confetti c = new Confetti(null, new Rectangle(0, 0, 0, 0), false);
                            library[cardsAdded] = c;
                            cardsAdded++;
                            break;
                             case 20: //numbject to change
                            NumjectToChange nj = new NumjectToChange(null, new Rectangle(0, 0, 0, 0), false);
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
