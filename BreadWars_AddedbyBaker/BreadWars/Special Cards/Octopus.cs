
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BreadWars
{
/// <summary>
/// Summary description for Octopus
/// </summary>
public class Octopus: Card
{

    public Octopus(Texture2D pTexr, Rectangle pPosit, bool active, Player pSelf, Drawable pNumbers) : base(pTexr, pPosit, active, pSelf, pNumbers)
        {
            value = 8;
        }
}
}