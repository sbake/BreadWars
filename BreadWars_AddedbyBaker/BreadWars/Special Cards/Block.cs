
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace BreadWars
{
/// <summary>
/// Summary description for Block
/// </summary>
public class Block : Card
{

    public Block(Texture2D pTexr, Rectangle pPosit, bool active, Drawable pNumbers)  : base( pTexr,  pPosit,  active,  pNumbers)
        {
            value = 15;
            Name = "Block";
        }

    public override void Effect(Player opponent, Player self, Deck deck)
    {
            if (this.is8)
            {
                base.Effect(opponent, self, deck);
                return;
            }
            if (isActive)self.HasBlock = true;
    }
}
}
