
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

    public GlueGun(Texture2D pTexr, Rectangle pPosit, bool active) : base(pTexr, pPosit, active)
    {
            value = 4;
        }

    public override void Effect(Player opponent, Player self, Deck deck)
    {
        if (isActive)
        {
            Random r = new Random();
            int index1 = r.Next(0, self.Hand.Count);
            Card c1 = self.Hand[index1];
            self.Hand.RemoveAt(index1);
            int index2 = r.Next(0, self.Hand.Count);
            Card c2 = self.Hand[index2];
            self.Hand.RemoveAt(index2);
            Card newCard = new Card(c2.texr, c1.Posit, false);
            newCard.value = c1.Value + c2.Value;
            self.Hand.Add(newCard);
            self.Hand.Add(deck.Next());
        }
    }
}
}