﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BreadWars
{
/// <summary>
/// Summary description for Tazer
/// </summary>
public class Tazer : Card
{
    public Tazer(Texture2D pTexr, Rectangle pPosit, bool active) : base(pTexr, pPosit, active)
    {
            value = 12;
    }

        public override void Effect(Player opponent, Player self, Deck deck)
        {
            if (isActive)
            {
                opponent.IsParalyzed = true;
                opponent.ParalyzeCount = 4;
            }
        }
    }
    }
