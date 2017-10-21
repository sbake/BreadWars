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
        public const int PLAYER_MAX_HEALTH = 50;
        const int PLAYER_START_HEALTH = 25;

        //number
        private byte playerNumber;

        public byte PlayerNumber { get { return playerNumber; } }
        //hand (cards or slots) an array?
        private List<Card> hand = new List<Card>();

        public List<Card> Hand { get { return hand; } set => hand = value; }
        
        //health
        private int playerCurrentHealth = PLAYER_START_HEALTH;

        public int Health {get {return playerCurrentHealth;} set { playerCurrentHealth = value; } }

        //status (poison and block)
        private bool isPoisoned;
        public bool IsPoisoned {get=>isPoisoned; set => isPoisoned = value;}
        private bool hasBlock;
        public bool HasBlock {get => hasBlock; set => hasBlock = value;}
        private bool isParalyzed;
        public bool IsParalyzed { get => isParalyzed; set => isParalyzed = value; }
        private int paralyzeCount;
        public int ParalyzeCount { set => paralyzeCount = value; }

        Random r;

        public Player(byte number)
        {
            isPoisoned = false;
            hasBlock = false;
            isParalyzed = false;
            playerNumber = number;
            r = new Random();
            paralyzeCount = 0;
        }

        public void PlayTurn(Card[] cardsToPlay, int cardIndex)
        {
            if (isParalyzed)
            {
                int cIndex = r.Next(0, hand.Count);
                cardsToPlay[playerNumber] = hand[cIndex];
                hand.Remove(hand[cIndex]);
                paralyzeCount--;
                if (paralyzeCount == 0) isParalyzed = false;
                return;
            }
            cardsToPlay[playerNumber] = hand[cardIndex];
            hand.Remove(hand[cardIndex]);

        }

        public void AlterHealth(int toChange)
        {
            playerCurrentHealth += toChange;
        }

        public void ResetHealth()
        {
            playerCurrentHealth = PLAYER_START_HEALTH;
            isPoisoned = false;
            hasBlock = false;
            isParalyzed = false;
            paralyzeCount = 0;
        }
    }
}
