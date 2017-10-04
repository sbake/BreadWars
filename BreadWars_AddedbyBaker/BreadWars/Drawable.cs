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
        //basic
        //Texture or spritesheet, or multiple textures
        //cards will add another texture for back
        //specials will have multiple animated things associated with them
        //position
        Texture2D texr; //single texture or spritesheet
        Rectangle posit;
        SpriteBatch spriteBatch;

        //sprite sheet + animation
        int rows, columns; //how many rows and columns
        Point imageSize; //width and height of image

        //animation 
        int msPerFrame;



        //constructor- N/A
        //things can't just be drawable- should be a background object or a card.
        //every drawable object needsa texture to be drawn, and a position to draw that texture
        

        //methods
        //method for drawing static objects (position doesn't move, can use variable)
        public void DrawStatic()
        {
            //draw texture at posit
            spriteBatch.Draw(texr, posit, Color.White);
            
        }
        
        //methods to unpack sprites
        ///takes size of sprites and rows/columns, divides. 
        //saves locations for each to make animation quicker- only need to do this math once
        void UnpackSprites()
        {
            

        }
        
        //method for animated objects a (just position changes)
        //+ b (moves through multiple sprites and position)
        public void Anim()
        {


        }
        
    }
}
