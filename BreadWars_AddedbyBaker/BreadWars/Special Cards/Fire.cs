
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BreadWars
{
/// <summary>
/// Summary description for Fire
/// </summary>
public class Fire : Card
{
    private int FIRE_DAMAGE = 5;

    public Fire(Texture2D pTexr, Rectangle pPosit, bool active, Drawable pNumbers)  : base( pTexr,  pPosit,  active,  pNumbers)
        {
            value = 18;
            Name = "Fire";
        }

    public override void Effect(Player opponent, Player self, Deck deck)
    {
        if (isActive)
        {
            opponent.AlterHealth(-FIRE_DAMAGE);
            foreach(Card c in self.Hand)
            {
                c.IsBurned = true;
            }
            foreach(Card c in opponent.Hand)
            {
                c.IsBurned = true;
            }
        }
    }
}
}
