using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadWars
{
        class Round
        {
            //TODO add methods for comparing cards, calling specials, awarding points 

            public byte CompareCards(Card[] cardsIn)
            {
                //compare 2 cards in and reutrn winner
                byte winner = 0;
                if (cardsIn[0].Value > cardsIn[1].Value)
                    winner = 1;
                else if (cardsIn[1].Value > cardsIn[0].Value)
                    winner = 2;

                return winner;
            }
        }
}
