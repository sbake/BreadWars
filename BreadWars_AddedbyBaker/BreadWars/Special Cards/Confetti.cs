
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BreadWars
{
/// <summary>
/// Summary description for Confetti
/// </summary>
public class Confetti : Card
{
    public Confetti(Texture2D pTexr, Rectangle pPosit, bool active, Drawable pNumbers)  : base( pTexr,  pPosit,  active,  pNumbers)
        {
            value = 20;
            Name = "Confetti";
    }
}
}