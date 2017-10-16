
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
    public Unicorn(Texture2D pTexr, Rectangle pPosit, bool active) : base(pTexr, pPosit, active)
    {
            value = 19;
    }

        public override void Effect(Player opponent, Player self, Deck deck)
        {
            if (isActive)
            {
                foreach (Card c in opponent.Hand)
                {
                    if (c.IsActive) {
                        c.IsActive = false;
                        c.IsUnicorn = true;
                    }
                    
                }
                foreach (Card c in self.Hand)
                {
                    if (c.IsActive)
                    {
                        c.IsActive = false;
                        c.IsUnicorn = true;
                    }
                }
            }
        }
    }
}