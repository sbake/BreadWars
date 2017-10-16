
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BreadWars
{
/// <summary>
/// Summary description for Jam
/// </summary>
public class Jam: Card
{
    private int RESTORE_HEALTH = 5;

    public Jam(Texture2D pTexr, Rectangle pPosit, bool active, Player pSelf, Drawable pNumbers) : base(pTexr, pPosit, active, pSelf, pNumbers)
        {
            value = 6;
        }

    public override void Effect(Player opponent, Player self, Deck deck)
    {
        if (isActive)
        {
            self.IsPoisoned = false;
            self.AlterHealth(RESTORE_HEALTH);
        }
    }
}
}