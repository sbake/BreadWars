
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BreadWars
{
/// <summary>
/// Summary description for FaireBread
/// </summary>
public class FaireBread: Card
{

    public FaireBread(Texture2D pTexr, Rectangle pPosit, bool active, Drawable pNumbers)  : base( pTexr,  pPosit,  active,  pNumbers)
        {
            value = 11;
            Name = "Faire Bread";
        }

    public override void Effect(Player opponent, Player self, Deck deck)
    {
            if (this.is8)
            {
                base.Effect(opponent, self, deck);
                return;
            }
            //switch all cards' isActive bool
            foreach (Card c in opponent.Hand)
            {
                c.isActive = !c.isActive;
            }foreach(Card c in self.Hand)
            {
                c.isActive = !c.isActive;
            }
            foreach(Card c in deck.Library)
            {
                c.isActive = !c.isActive;
            }
            //need to do save for laters as well

    }
}
}
