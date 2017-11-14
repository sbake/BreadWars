
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

    public Jam(Texture2D pTexr, Rectangle pPosit, bool active, Drawable pNumbers)  : base( pTexr,  pPosit,  active,  pNumbers)
        {
            value = 6;
            specialValue = 2;
            Name = "Jam";
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
            self.IsPoisoned = false;
            self.AlterHealth(RESTORE_HEALTH);
        }
    }
}
}