using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace BreadWars
{
    public class Player
    {
        const int PLAYER_MAX_HEALTH = 50;

        //number
        private byte playerNumber;

        public byte PlayerNumber { get { return playerNumber; } }
        //hand (cards or slots) an array?
        private List<Card> hand = new List<Card>();

        public List<Card> Hand { get {return hand;}}
        
        //health
        private int playerCurrentHealth = PLAYER_MAX_HEALTH;

        public int Health {get {return playerCurrentHealth;} set { playerCurrentHealth = value; } }

        //status (poison and block)
        private bool isPoisoned;
        public bool IsPoisoned {get=>isPoisoned; set => isPoisoned = value;}
        private bool hasBlock;
        public bool HasBlock {get => hasBlock; set => hasBlock = value;}

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
