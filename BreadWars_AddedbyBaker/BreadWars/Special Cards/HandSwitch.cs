﻿
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace BreadWars
{
    /// <summary>
    /// Summary description for HandSwitch
    /// </summary>
    public class HandSwitch : Card
    {

        public HandSwitch(Texture2D pTexr, Rectangle pPosit, bool active, Drawable pNumbers) : base(pTexr, pPosit, active, pNumbers)
        {
            value = 13;
            specialValue = 0;
            Name = "Hand Switch";
        }

        public override void Effect(Player opponent, Player self, Deck deck)
        {
            SetPos(self);
            if (this.is8)
            {
                base.Effect(opponent, self, deck);
                return;
            }
            EffectDescription = "Players have switched hands";
            //change players' hands
            List<Card> hand1 = opponent.Hand;
            List<Card> hand2 = self.Hand;
            opponent.Hand = hand2;
            self.Hand = hand1;

        }
    }
}