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
    //half these comments will be deleted as methods are actually written- Sophia
    class Drawable
    {
        //attributes
        //basic
        protected Texture2D texr; //single texture or spritesheet, objects should have all associated textures on one sprite sheet, ideally
        protected Rectangle posit;
        protected SpriteBatch spriteBatch;

        //sprite sheet + animation
        protected int rows, columns; //how many rows and columns
        protected Point imageSize; //width and height of image
        protected List<Point> spriteLocations; //stores location of sprites on spritesheet

        //animation 
        protected int msPerFrame;



        //constructor- N/A
        //things can't just be drawable- should be a background object or a card.
        //every drawable object needsa texture to be drawn, and a position to draw that texture
        //BUT this will be passed an existing spritebatch in both children
        

        //methods
        //method for drawing static objects (position doesn't move, can use variable)
        public void DrawStatic()
        {
            //draw texture at posit
            spriteBatch.Draw(texr, posit, Color.White);
            //please don't add spritebatch bits to this- spritebatch starting and ending should be handled in Game1, so we aren't restarting spritebatch 20x an update
            //unless there is a compelling reason to restart spritebatch every time this method is called,
            //in which case, please let me know
        }
        
        //methods to unpack sprites
        ///takes size of sprites and rows/columns, divides. 
        //saves locations for each to make animation quicker- only need to do this math once
        void UnpackSprites()
        {
            //store sprites in SpriteLocations list

        }
        
        //method for animated objects a (just position changes)
        //+ b (moves through multiple sprites and position)
        public void Anim()
        {
            //goes through spriteLocations timed

        }
        
    }
}
