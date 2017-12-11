
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BreadWars
{
    /// <summary>
    /// Summary description for Octopus
    /// </summary>
    public class Octopus : Card
    {

        public Octopus(Texture2D pTexr, Rectangle pPosit, bool active, Drawable pNumbers) : base(pTexr, pPosit, active, pNumbers)
        {

            EffectDescription = "Random cards have become octopuses!";
            value = 8;
            specialValue = 2;
            Name = "Octopus";
        }
    }
}