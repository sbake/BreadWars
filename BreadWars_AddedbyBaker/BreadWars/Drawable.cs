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
    class Drawable
    {
        //attributes
        //Texture or spritesheet, or multiple textures
        //            cards will add another texture for back
        //            specials will have multiple animated things associated with them, ie. a special texture
        //            spritesheets
        //position
        Texture2D texr; //single texture or spritesheet
        Rectangle posit;
        SpriteBatch spriteBatch;


        //constructor
        //every drawable object needsa texture to be drawn, and a position to draw that texture
        Drawable(Texture2D pTexr, Rectangle pPosit, SpriteBatch pSpriteBatch)
        {
            texr = pTexr;
            posit = pPosit;
            spriteBatch = pSpriteBatch;
        }

        //methods
        //method for drawing static objects (position doesn't move, can use variable)
        public void DrawStatic()
        {
            //draw texture at posit
            spriteBatch.Draw(texr, posit, Color.White);
            
        }
        
        //methods to unpack sprites
        //method for animated objects a (takes position as a parameter)
        //method for animated objects b (moves through multiple sprites)
    }
}
