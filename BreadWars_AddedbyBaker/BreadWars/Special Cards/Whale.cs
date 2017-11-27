
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
    public Whale(Texture2D pTexr, Rectangle pPosit, bool active, Drawable pNumbers)  : base( pTexr,  pPosit,  active,  pNumbers)
        {
            value = 16;
            specialValue = 1;
            Name = "Whale";
    }

        public override void Effect(Player opponent, Player self, Deck deck)
        {
            SetPos(self);
            EffectDescription = "Any extra Octopi have been eaten!";
            if (this.is8)
            {
                base.Effect(opponent, self, deck);
                return;
            }
            if (isActive)
            {
                foreach(Card c in deck.Library)
                {
                    if(c!=null)c.Is8 = false;
                }
            }
        }
    }
}