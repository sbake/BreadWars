﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace BreadWars
{
    public class Player
    {
        public const int PLAYER_MAX_HEALTH = 100;
        const int PLAYER_START_HEALTH = 25;
        const int POISON_DAMAGE = 5;

        //number
        private byte playerNumber;

        public byte PlayerNumber { get { return playerNumber; } }
        //hand 
        private List<Card> hand = new List<Card>();
        //last card played
        private Card prevCard;
        public Card PrevCard { get => prevCard; }
        private Card currCard;
        public Card CurrCard { get => currCard; }

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
        private bool isAI;
        public bool IsAI{get=>isAI; set=>isAI=value;}
        private int untilDestruct;
        public int UntilDestruct { set => untilDestruct = value; }
        private bool isDestruct;
        public bool IsDestruct { set => isDestruct = value; }


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
            if (isAI || isParalyzed)
            {
                int cIndex = r.Next(0, hand.Count);
                cardsToPlay[playerNumber-1] = hand[cIndex];
                prevCard = currCard;
                currCard = hand[cIndex];
                hand.Remove(hand[cIndex]);
                if(!isAI)paralyzeCount--;
                if (paralyzeCount == 0) isParalyzed = false;
                return;
            }
            cardsToPlay[playerNumber-1] = hand[cardIndex];
            prevCard = currCard;
            currCard = hand[cardIndex];
            hand.Remove(hand[cardIndex]);

        }

        public void AlterHealth(int toChange)
        {
            playerCurrentHealth += toChange;
        }

        /// <summary>
        /// Updates all status of this player. Must be called once each round
        /// </summary>
        /// <param name="opponent"></param>
        public void Update(Player opponent)
        {
            if (isPoisoned)
            {
                AlterHealth(-POISON_DAMAGE);
            }
            if (isDestruct)
            {
                untilDestruct--;
                if (untilDestruct == 0) playerCurrentHealth = 0;
            }
            foreach(Card c in hand)
            {
                if(c.Name=="Numject to Change")
                {
                    ((NumjectToChange)c).ChangeValue(opponent);
                }
            }
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
