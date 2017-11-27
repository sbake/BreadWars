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
    public class Drawable
    {
        //attributes
        //basic
        protected Texture2D texr; //single texture or spritesheet, objects should have all associated textures on one sprite sheet, ideally
        protected SpriteFont font;
        protected Rectangle posit;
        protected Vector2 strPosit;

        //sprite sheet + animation
        protected int rows, columns; //how many rows and columns
        protected Point imageSize; //width and height of image
        protected List<Point> spriteLocations; //stores location of sprites on spritesheet

        //drawable Numbers
        protected Drawable Numbers;


        //animation 
        protected int msPerFrame;
        protected int msSinceFrame;

        //Properties
        public Rectangle Posit
        {
            get { return posit; }
            set { posit = value; }
        }

        public List<Point> SpriteLocations
        {
            get { return spriteLocations; }
        }
        public Texture2D Texr
        {
            get { return texr; }
        }
        public int Rows
        {
            get { return rows; }
            set { rows = value; }
        }
        public int Columns
        {
            get { return columns; }
            set { columns = value; }
        }

        //constructor- N/A
        //most things can't just be drawable objects- should be a background object or a card.
        //only one case: numbers
        public Drawable(Texture2D pTexr, Rectangle pPosit)
        {
            texr = pTexr;
            posit = pPosit;
            imageSize = new Point(pPosit.Width, pPosit.Height);

            spriteLocations = new List<Point>();
        }

        public Drawable(SpriteFont fnt, Vector2 posit)
        {
            font = fnt;
            strPosit = posit;

            spriteLocations = new List<Point>();
        }


        //methods
        //method for drawing static objects (position doesn't move, can use variable)
        public void DrawStatic(SpriteBatch spriteBatch)
        {
            //draw texture at posit
            spriteBatch.Draw(texr, posit, Color.White);
        }

        //method for drawing static objects (position doesn't move, can use variable)
        public void DrawString(SpriteBatch spriteBatch)
        {
            //draw texture at posit
            spriteBatch.DrawString(font, this.ToString(), strPosit, Color.Brown);
        }

        public void DrawString(SpriteFont fnt, SpriteBatch spriteBatch)
        {
            //draw texture at posit
            spriteBatch.DrawString(fnt, this.ToString(), strPosit, Color.Brown);
        } 
        //methods to unpack sprites
        ///takes size of sprites and rows/columns, divides. 
        //saves locations for each to make animation quicker- only need to do this math once
        public void UnpackSprites()
        {
            spriteLocations.Clear();

            //store sprites in SpriteLocations list
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Point location = new Point((j * (posit.Width/columns)), (i * (posit.Height / rows)));
                    spriteLocations.Add(location);
                }
            }
        }
        
        //method for animated objects a (just position changes)
        //+ b (moves through multiple sprites and position)
        public void Anim()
        {
            //goes through spriteLocations timed
            if (msPerFrame >= msSinceFrame)
            {
                
            }
        }
        
    }
}
