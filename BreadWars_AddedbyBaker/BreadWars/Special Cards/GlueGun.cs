
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BreadWars
{
/// <summary>
/// Summary description for GlueGun
/// </summary>
public class GlueGun: Card
{

    public GlueGun(Texture2D pTexr, Rectangle pPosit, bool active, Drawable pNumbers)  : base( pTexr,  pPosit,  active,  pNumbers)
        {
            value = 4;
            Name = "Glue Gun";
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
                //get two random cards from hand and add values together to form new card
            Random r = new Random();
            int index1 = r.Next(0, self.Hand.Count);
            Card c1 = self.Hand[index1];
            self.Hand.RemoveAt(index1);
            int index2 = r.Next(0, self.Hand.Count);
            Card c2 = self.Hand[index2];
            self.Hand.Remove(c2);
            self.Hand.Remove(c1);
            Card newCard = new Card(c2.Texr, c1.Posit, false, Numbers); //new card with no effect
            newCard.Value = c1.Value + c2.Value;
            self.Hand.Add(newCard);
            self.Hand.Add(deck.Next()); //draw to make up for one used card
        }
    }
}
}