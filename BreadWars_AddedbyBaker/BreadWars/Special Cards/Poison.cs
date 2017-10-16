
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
    public Poison(Texture2D pTexr, Rectangle pPosit, bool active) : base(pTexr, pPosit, active)
    {
            value = 10;
    }

        public override void Effect(Player opponent, Player self, Deck deck)
        {
            if (isActive)
            {
                opponent.IsPoisoned = true;
            }
        }
    }
}