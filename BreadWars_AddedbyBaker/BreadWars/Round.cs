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
        //attributes
        private int pointsPerRound;
                
        public Round(int ptsPerRound)
        {
            pointsPerRound = ptsPerRound;
        }

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

        public void EditHealth(byte winPlayer, Player[] players)
        {
            players[winPlayer - 1].Health += pointsPerRound;
        }
        public void SpecialCards(Card cardPlayed, byte playerNum, Player[] players)
        {
            if(cardPlayed.isActive )
            {
                if (playerNum == 1)
                    cardPlayed.effect(players[1], players[2]);
                if (playerNum == 2)
                    cardPlayed.effect(players[2], players[1]);
            }
        }
    }
}
