
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BreadWars
{
/// <summary>
/// Summary description for Unicorn
/// </summary>
public class Unicorn : Card
{
    public Unicorn(Texture2D pTexr, Rectangle pPosit, bool active, Drawable pNumbers)  : base( pTexr,  pPosit,  active,  pNumbers)
        {
            value = 19;
            specialValue = -1;
            Name = "Unicorn";
    }

        public override void Effect(Player opponent, Player self, Deck deck)
        {
            EffectDescription = "Any special cards in play have been UNICORNED!";
            if (this.is8)
            {
                base.Effect(opponent, self, deck);
                return;
            }
            if (isActive)
            {
                foreach (Card c in opponent.Hand)
                {
                    if (c!=null && c.IsActive) {
                        c.IsActive = false;
                        c.IsUnicorn = true;
                    }
                    
                }
                foreach (Card c in self.Hand)
                {
                    if (c!=null && c.IsActive)
                    {
                        c.IsActive = false;
                        c.IsUnicorn = true;
                    }
                }
            }
        }
    }
}