
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
    private int value = 15;

    public Block(Texture2D pTexr, Rectangle pPosit, bool active) : base(pTexr, pPosit, active)
    {
    }

    public override void Effect(Player opponent, Player self)
    {
        if(isActive)self.HasBlock = true;
    }
}
}
