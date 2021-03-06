﻿
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BreadWars
{
    /// <summary>
    /// Summary description for Zombie
    /// </summary>
    public class Zombie : Card
    {
        public Zombie(Texture2D pTexr, Rectangle pPosit, bool active, Drawable pNumbers) : base(pTexr, pPosit, active, pNumbers)
        {
            value = 5;
            specialValue = 1;
            Name = "Zombie";
        }

        public override void Effect(Player opponent, Player self, Deck deck)
        {
            SetPos(self);
            if (this.is8)
            {
                base.Effect(opponent, self, deck);
                return;
            }
            if (self.PrevCard != null && !Type.ReferenceEquals(self.PrevCard, this) && self.PrevCard.IsActive)
            {
                self.PrevCard.Effect(opponent, self, deck);
                EffectDescription = self.PrevCard.EffectDescription;
            }
        }

    }
}
