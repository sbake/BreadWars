using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace BreadWars
{
    class HUDObjects: Drawable
    {
        //constructor
        public HUDObjects(Texture2D pTexr, Rectangle pPosit)
        {
            texr = pTexr;
            posit = pPosit;
        }

        //constructor for spritesheet objects
        public HUDObjects(Texture2D pTexr, Rectangle pPosit, int pRows, int pColumns)
        {
            texr = pTexr;
            posit = pPosit;

            rows = pRows;
            columns = pColumns;
        }
    }
}
