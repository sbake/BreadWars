
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BreadWars
{
/// <summary>
/// Summary description for Punch
/// </summary>
public class Punch: Card
{
    private int PUNCH_DAMAGE = 10;
    private int value = 9;

    public Punch(Texture2D pTexr, Rectangle pPosit, bool active) : base(pTexr, pPosit, active)
    {
    }

    public override void Effect(Player opponent, Player self)
    {
        if(isActive)opponent.AlterHealth(-PUNCH_DAMAGE);
    }
    
    
}
}