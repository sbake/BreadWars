﻿
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BreadWars
{
/// <summary>
/// Summary description for Thief
/// </summary>
public class Thief : Card
{
    public Thief(Texture2D pTexr, Rectangle pPosit, bool active, Drawable pNumbers)  : base( pTexr,  pPosit,  active,  pNumbers)
    {
        value = 1;
        Name = "Thief";
    }

        public override void Effect(Player opponent, Player self, Deck deck)
        {
            if (this.is8)
            {
                base.Effect(opponent, self, deck);
                return;
            }
            if (isActive)
            {
                opponent.Hand[0] = null;
            }
        }
    }
}