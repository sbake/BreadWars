
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BreadWars
{
/// <summary>
/// Summary description for Whale
/// </summary>
public class Whale : Card
{
    public Whale(Texture2D pTexr, Rectangle pPosit, bool active, Player pSelf, Drawable pNumbers) : base(pTexr, pPosit, active, pSelf, pNumbers)
        {
            value = 16;
    }

        public override void Effect(Player opponent, Player self, Deck deck)
        {
            if (isActive)
            {
                foreach(Card c in deck.Library)
                {
                    c.Is8 = false;
                }
            }
        }
    }
}