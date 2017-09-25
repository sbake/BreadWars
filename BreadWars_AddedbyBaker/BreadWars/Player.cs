using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadWars
{
    class Player
    {
        const int PLAYER_MAX_HEALTH = 100;
        //hand (cards or slots) an array?
        private Card[] hand = new Card[5];
        //health
        private int playerCurrentHealth = PLAYER_MAX_HEALTH;
        //states (hiding cards on top of screen or showing cards on bottom of screen)
        private bool handIsShowing;
        //status (poison and block)
        private bool isPoisoned;
        private bool hasBlock;
    }
}
