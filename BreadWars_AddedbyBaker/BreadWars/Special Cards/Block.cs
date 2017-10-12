
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

    public Block(Texture2D pTexr, Rectangle pPosit, bool active) : base(pTexr, pPosit, active)
    {
            value = 15;
        }

    public override void Effect(Player opponent, Player self, Deck deck)
    {
        if(isActive)self.HasBlock = true;
    }
}
}
