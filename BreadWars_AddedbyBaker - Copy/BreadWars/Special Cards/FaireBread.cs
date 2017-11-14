using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Threading;

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
            specialValue = 1;
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
            if (this.isActive)
            {
                foreach (Card c in opponent.Hand)
                {
                    if (c != null && c!=this) c.isActive = (c.IsActive ? false: true);
                }
                foreach (Card c in deck.Library)
                {
                    if (c != null) c.IsActive = (c.isActive ? false : true);
                }
                foreach (Card c in self.Hand)
                {
                    if (c != null && c!=this) c.isActive = (c.IsActive ? false : true);
                }
                this.isActive = false;
                //need to do save for laters as well
            }


        }
}
}
