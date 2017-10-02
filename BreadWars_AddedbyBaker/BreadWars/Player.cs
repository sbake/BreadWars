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

        public List<Card> playerHand { get {return hand;} }

        //health
        private int playerCurrentHealth = PLAYER_MAX_HEALTH;

        public int playerHealth {get {return playerCurrentHealth;}}
        

        //states (hiding cards on top of screen or showing cards on bottom of screen)
        private bool handIsShowing;

        //status (poison and block)
        private bool isPoisoned;
        private bool hasBlock;

        public Player(byte number){
            playerCurrentHealth = 20;
            isPoisoned = false;
            hasBlock = false;
            handIsShowing = false;
            playerNumber = number;
        }

        public void playTurn(Card[] cardsToPlay, int cardIndex){
            cardsToPlay[playerNumber] = hand[cardIndex];
            hand.Remove(cardIndex);

        }

        public void alterHealth(int toChange){
            playerCurrentHealth += toChange;
        }

    }
}
