using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace BreadWars
{
    class Player
    {
        const int PLAYER_MAX_HEALTH = 50;

        //number
        private byte playerNumber;

        //hand (cards or slots) an array?
        private List<Card> hand = new List<Card>();

        public List<Card> Hand
        {
            get
            {
                return hand;
            }
        }

        //health
        private int playerCurrentHealth = PLAYER_MAX_HEALTH;

        public int Health {get {return playerCurrentHealth;}}

        //status (poison and block)
        private bool isPoisoned;
        private bool hasBlock;

        public Player(byte number)
        {
            playerCurrentHealth = 20;
            isPoisoned = false;
            hasBlock = false;
            playerNumber = number;
        }

        public void PlayTurn(Card[] cardsToPlay, int cardIndex)
        {
            cardsToPlay[playerNumber] = hand[cardIndex];
            hand.Remove(hand[cardIndex]);

        }

        public void AlterHealth(int toChange)
        {
            playerCurrentHealth += toChange;
        }

    }
}
