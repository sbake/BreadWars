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

        //can change however you want later, just for texting if other stuffs work
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
                             case 0:
                            Banker b = new Banker(null, new Rectangle(0,0,0,0), false);
                                 break;
                             case 1:
                                 break;
                             case 2:
                                 break;
                             case 3:
                                 break;
                             case 4:
                                 break;
                             case 5:
                                 break;
                             case 6:
                                 break;
                             case 7:
                                 break;
                             case 8:
                                 break;
                             case 9:
                                 break;
                             case 10:
                                 break;
                             case 11:
                                 break;
                             case 12:
                                 break;
                             case 13:
                                 break;
                             case 14:
                                 break;
                             case 15:
                                 break;
                             case 16:
                                 break;
                             case 17:
                                 break;
                             case 18:
                                 break;
                             case 19:
                                 break;
                             case 20:
                                 break;
                             default:
                                 break;
                         }
                     }        
            }
        }

    }
}
