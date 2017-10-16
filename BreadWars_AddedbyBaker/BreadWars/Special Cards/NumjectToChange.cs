
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace BreadWars
{
/// <summary>
/// Summary description for Class1
/// </summary>
public class NumjectToChange : Card
{
        Random r;

    public NumjectToChange(Texture2D pTexr, Rectangle pPosit, bool active) : base(pTexr, pPosit, active)
    {
            value = 10;
            r = new Random();
    }
    
    public void ChangeValue(Player opponent)
    {
            int min = 20;
            int max = 0;
            foreach (Card c in opponent.Hand)
            {
                if (c.Value < min) { min = c.Value; }
                else if (c.Value > max) { max = c.Value; }
            }
            value = r.Next(min, max);
    }

        public override void Effect(Player opponent, Player self, Deck deck)
        {
            //don't do anything!
        }
    }
    }
