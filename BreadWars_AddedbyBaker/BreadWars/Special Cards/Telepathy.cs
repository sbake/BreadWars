﻿
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BreadWars
{
/// <summary>
/// Summary description for Telepathy
/// </summary>
public class Telepathy : Card
{
    public Telepathy(Texture2D pTexr, Rectangle pPosit, bool active, Drawable pNumbers) : base(pTexr, pPosit, active, pNumbers)
        {
            value = 14;
            specialValue = 0;
            Name = "Telepathy";
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
                self.IsTelephathic = true;
                self.TelepCount = 2;
            }
        }

    }
    }
