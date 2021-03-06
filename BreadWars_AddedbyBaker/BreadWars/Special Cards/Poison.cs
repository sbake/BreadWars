﻿
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BreadWars
{
    /// <summary>
    /// Summary description for Poison
    /// </summary>
    public class Poison : Card
    {
        public Poison(Texture2D pTexr, Rectangle pPosit, bool active, Drawable pNumbers) : base(pTexr, pPosit, active, pNumbers)
        {
            value = 10;
            specialValue = 3;
            Name = "Poison";
        }

        public override void Effect(Player opponent, Player self, Deck deck)
        {
            SetPos(self);
            if (this.is8)
            {
                base.Effect(opponent, self, deck);
                return;
            }
            EffectDescription = "Player " + opponent.PlayerNumber + " has been poisoned!";
            opponent.IsPoisoned = true;

        }
    }
}