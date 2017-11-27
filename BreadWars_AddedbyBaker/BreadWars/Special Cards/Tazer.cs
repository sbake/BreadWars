using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BreadWars
{
/// <summary>
/// Summary description for Tazer
/// </summary>
public class Tazer : Card
{
    public Tazer(Texture2D pTexr, Rectangle pPosit, bool active, Drawable pNumbers) : base(pTexr, pPosit, active, pNumbers)
    {
            value = 12;
            specialValue = 2;
            Name = "Tazer";
    }

        public override void Effect(Player opponent, Player self, Deck deck)
        {
            SetPos(self);
            EffectDescription = "Player " + opponent.PlayerNumber + " is Paralyzed!";
            if (this.is8)
            {
                base.Effect(opponent, self, deck);
                return;
            }
            if (isActive)
            {
                opponent.IsParalyzed = true;
                opponent.ParalyzeCount = 4;
            }
        }
    }
    }
