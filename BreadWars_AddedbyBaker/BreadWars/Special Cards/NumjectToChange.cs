
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

    public NumjectToChange(Texture2D pTexr, Rectangle pPosit, bool active, Drawable pNumbers)  : base( pTexr,  pPosit,  active,  pNumbers)
    {
            value = 10;
            Name = "Numject to Change";
            r = new Random();
    }
    
    public void ChangeValue(Player opponent)
    {
            int min = 20;
            int max = 0;
            //get min and max card values from opponent
            foreach (Card c in opponent.Hand)
            {
                if (c.Value < min) { min = c.Value; }
                else if (c.Value > max) { max = c.Value; }
            }
            //get a random new value between opponents' highest and lowest card values
            value = r.Next(min, max);
    }

        public override void Effect(Player opponent, Player self, Deck deck)
        {
            //don't do anything!
        }
    }
    }
