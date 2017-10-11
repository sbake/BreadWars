using BreadWars;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

/// <summary>
/// Summary description for Fire
/// </summary>
public class Fire : Card
{
    private int FIRE_DAMAGE = 5;
    private int value = 18;

    public Fire(Texture2D pTexr, Rectangle pPosit, bool active) : base(pTexr, pPosit, active)
    {
    }

    public override void Effect(Player opponent, Player self)
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
