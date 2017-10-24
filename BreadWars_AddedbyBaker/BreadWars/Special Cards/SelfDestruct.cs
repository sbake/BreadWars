using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BreadWars
{
    /// <summary>
    /// Summary description for Banker
    /// </summary>
    public class SelfDestruct : Card

    {
        public SelfDestruct(Texture2D pTexr, Rectangle pPosit, bool active, Drawable pNumbers)  : base( pTexr,  pPosit,  active,  pNumbers) 
        {
            Name = "Self Destruct";
            value = 17;
            description = "You will have 3 turns left";
        }
    }
}
