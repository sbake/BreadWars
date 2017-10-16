
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BreadWars
{
/// <summary>
/// Summary description for Zombie
/// </summary>
public class Zombie : Card
{
    public Zombie(Texture2D pTexr, Rectangle pPosit, bool active) : base(pTexr, pPosit, active)
    {
            value = 5;
    }
}
    }
