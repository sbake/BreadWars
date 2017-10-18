using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BreadWars
{
    /// <summary>
    /// Summary description for Banker
    /// </summary>
    public class Banker : Card

    {
        public Banker(Texture2D pTexr, Rectangle pPosit, bool active, Drawable pNumbers)  : base( pTexr,  pPosit,  active,  pNumbers) 
        {
            Name = "Banker";
            value = 17;
        }
    }
}
