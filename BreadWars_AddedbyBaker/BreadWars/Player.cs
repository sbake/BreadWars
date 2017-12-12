using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace BreadWars
{
    public class Player:Drawable
    {
        public const int PLAYER_MAX_HEALTH = 100;
        const int PLAYER_START_HEALTH = 25;
        const int POISON_DAMAGE = 5;

        //number
        private byte playerNumber;

        public byte PlayerNumber { get { return playerNumber; } }
        //hand 
        private List<Card> hand = new List<Card>();
        private Card prevCard;
        /// <summary>
        /// Last card played by this player.
        /// </summary>
        public Card PrevCard { get => prevCard; }
        private Card currCard;
        /// <summary>
        /// Card being played by this player in this current turn.
        /// </summary>
        public Card CurrCard { get => currCard; }
        private Card saveLater;
        public Card SaveLater { get => saveLater; set => saveLater = value; }
        public List<Card> Hand { get { return hand; } set => hand = value; }
        
        //health
        private int playerCurrentHealth = PLAYER_START_HEALTH;

        public int Health {get {return playerCurrentHealth;} set { playerCurrentHealth = value; } }

        //status (poison and block)
        private bool isPoisoned;
        /// <summary>
        /// Player status. Poison causes the player to take a certain amount of damage each round.
        /// </summary>
        public bool IsPoisoned {get=>isPoisoned; set => isPoisoned = value;}
        private bool hasBlock;
        /// <summary>
        /// Player status. Player will block the next special effect by the opponent.
        /// </summary>
        public bool HasBlock {get => hasBlock; set => hasBlock = value;}
        private bool isParalyzed;
        /// <summary>
        /// Player status. Player will play a random card for the next turn.
        /// </summary>
        public bool IsParalyzed { get => isParalyzed; set => isParalyzed = value; }
        private int paralyzeCount;
        /// <summary>
        /// Related to IsParalyzed. The number of rounds until player stops being paralyzed.
        /// </summary>
        public int ParalyzeCount { set => paralyzeCount = value; }
        private bool isAI;
        /// <summary>
        /// True if the player is an AI. Used for single-player mode.
        /// </summary>
        public bool IsAI{get=>isAI; set=>isAI=value;}
        private int untilDestruct;
        /// <summary>
        /// Related to IsDestruct. The number of rounds until player loses by Self Destruct.
        /// </summary>
        public int UntilDestruct { set => untilDestruct = value; }
        private bool isDestruct;
        /// <summary>
        /// True if the player has played Self Destruct card. Allows for count down until player loses (see UntilDestruct).
        /// </summary>
        public bool IsDestruct { set => isDestruct = value; }
        private bool isTelepathic;
        /// <summary>
        /// Player status. Player can see opponent's hand.
        /// </summary>
        public bool IsTelephathic { set => isTelepathic = value; get =>  isTelepathic; }
        private int telepCount;
        /// <summary>
        /// Related to IsTelephathic. Count down until player stops being Telepathic.
        /// </summary>
        public int TelepCount { set => telepCount = value; }
        
        Random r;

        /// <summary>
        /// Create player and set all statuses to begining status.
        /// </summary>
        /// <param name="number">Player number (can be 1 or 2)</param>
        /// <param name="font">Font for writing Player Status</param>
        /// <param name="posit">Position to write Player Status</param>
        public Player(byte number, SpriteFont font, Vector2 posit):base(font, posit)
        {
            isPoisoned = false;
            hasBlock = false;
            isParalyzed = false;
            playerNumber = number;
            r = new Random();
            paralyzeCount = 0;
        }

        /// <summary>
        /// Adjusts hand based on card being played.
        /// </summary>
        /// <param name="cardsToPlay">Container to put card being played</param>
        /// <param name="cardIndex">Index of card selected by user to be played.</param>
        public void PlayTurn(Card[] cardsToPlay, int cardIndex)
        {
            if (isAI) //if isAI, ignore cardIndex and play based on AI heuristic
            {
                AiTurn(cardsToPlay);
                return;
            }
            if (isParalyzed) //if player is paralyzed, play a random card
            {
                RandomTurn(cardsToPlay);
                return;
            }
            cardsToPlay[playerNumber-1] = hand[cardIndex]; //put card to play in container
            currCard = hand[cardIndex]; //store card as curr card played
            hand.Remove(hand[cardIndex]); //remove card from hand

        }

        /// <summary>
        /// Play a random card, used if player is Paralyzed.
        /// </summary>
        /// <param name="cardsToPlay">Container to place card being played.</param>
        public void RandomTurn(Card[] cardsToPlay)
        {
            int cIndex = r.Next(0, hand.Count);
            cardsToPlay[playerNumber - 1] = hand[cIndex];
            currCard = hand[cIndex];
            hand.Remove(hand[cIndex]);
            if (isParalyzed) paralyzeCount--;
            if (paralyzeCount == 0) isParalyzed = false;
        }

        /// <summary>
        /// Play a card based on values given to each card. Used for AI.
        /// </summary>
        /// <param name="cardsToPlay">Container to place card being played.</param>
        public void AiTurn(Card[] cardsToPlay)
        {
            if (isParalyzed)
            {
                RandomTurn(cardsToPlay);
                return;
            }
            int cIndex = 0;
            int maxHur = 0;
            for(int i=0; i<Hand.Count; i++)
            {   if (Hand[i] == null) continue;
                if(Hand[i].GetTotalValue() > maxHur)
                {
                    maxHur = Hand[i].GetTotalValue();
                    cIndex = i;
                }
            }
            cardsToPlay[playerNumber - 1] = hand[cIndex];
            currCard = hand[cIndex];
            hand.Remove(hand[cIndex]);
            return;
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
            prevCard = currCard;
            if (isPoisoned)
            {
                AlterHealth(-POISON_DAMAGE);
            }
            if (isDestruct)
            {
                untilDestruct--;
                if (untilDestruct == 0) playerCurrentHealth = 0;
            }
            bool isEmpty = true;
            foreach(Card c in hand)
            {
                if (c != null)
                {
                    isEmpty = false;
                    if (c.Name == "Numject to Change")
                    {
                        ((NumjectToChange)c).ChangeValue(opponent);
                    }
                }
            }
            if (isEmpty) playerCurrentHealth = 0;
            if (isTelepathic)
            {
                telepCount--;
                if(telepCount ==0)
                isTelepathic = false;
            }
        }

        /// <summary>
        /// Resets all status and health of player. Called for each new game.
        /// </summary>
        public void ResetHealth()
        {
            playerCurrentHealth = PLAYER_START_HEALTH;
            isPoisoned = false;
            hasBlock = false;
            isParalyzed = false;
            isDestruct = false;
            paralyzeCount = 0;
            prevCard = null;
            currCard = null;
        }

        public override string ToString()
        {   string toReturn = "HP: " + Health;
            if (isPoisoned) toReturn += "\nYou are Poisoned!";
            if (HasBlock) toReturn += "\nYou have Block!";
            if (isParalyzed) toReturn += "\nYou are Paralyzed!";
            if (isDestruct) toReturn += "\nYou will destruct in " + untilDestruct + " turns!";
            if (isTelepathic) toReturn += "\nYou are Telepathic!";
            return toReturn;
        }
    }
}
