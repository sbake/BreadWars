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
        public HUDObjects(Texture2D pTexr, Rectangle pPosit) : base(pTexr, pPosit)
        {
        }

        //constructor for spritesheet objects
        public HUDObjects(Texture2D pTexr, Rectangle pPosit, int pRows, int pColumns) : base(pTexr, pPosit)
        {
            rows = pRows;
            columns = pColumns;
        }
        //methods
        //Overwrite draw methods to draw everything green if player is poisoned
        public void DrawStatic(SpriteBatch spriteBatch, bool poison)
        {
            if (poison)
            {
                //draw texture at posit
                spriteBatch.Draw(texr, posit, Color.LimeGreen);
            }
            else
            {
                //draw texture at posit
                spriteBatch.Draw(texr, posit, Color.White);
            }
        }

    }
}
