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
        private Deck deck;
                
        public Round(int ptsPerRound, Deck d)
        {
            pointsPerRound = ptsPerRound;
            deck = d;
        }

        public byte CompareCards(Card[] cardsIn)
        {
            //compare 2 cards in and reutrn winner
            byte winner = 0;
            if (cardsIn[0].Value > cardsIn[1].Value)
                winner = 1;
            else if (cardsIn[1].Value > cardsIn[0].Value)
                winner = 2;
            else if (cardsIn[0].Value == cardsIn[1].Value)
                winner = 0;
            return winner;
        }

        public void EditHealth(byte winPlayer, Player[] players)
        {
            players[winPlayer-1].Health += pointsPerRound;
        }
        public void SpecialCards(Card cardPlayed, byte playerNum, Player[] players)
        {
            if(cardPlayed.isActive )
            {
                if (playerNum == 1)
                    cardPlayed.Effect(players[1], players[0] ,deck);
                if (playerNum == 2)
                    cardPlayed.Effect(players[0], players[1] , deck);
            }
        }
    }
}
