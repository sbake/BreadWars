using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;
using System.Threading;
using System.Diagnostics;
using Microsoft.Xna.Framework.Media;


namespace BreadWars
{
    public class Drawable
    {
        //attributes
        //basic
        protected Texture2D texr; //single texture or spritesheet, objects should have all associated textures on one sprite sheet, ideally
        protected SpriteFont font;
        protected Rectangle posit;
        protected Vector2 strPosit;
        protected Color tint;

        //sprite sheet + animation
        protected int rows, columns; //how many rows and columns
        protected Point imageSize; //width and height of image
        protected List<Point> spriteLocations; //stores location of sprites on spritesheet

        //drawable Numbers
        protected Drawable Numbers;


        //animation 
        protected long msPerFrame;
        protected long msSinceFrame;
        protected long oldTime;
        int frame;

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
            set { texr = value; } //for octo
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
        //animation
        public long MsPerFrame
        {
            get { return msPerFrame; }
            set { msPerFrame = value; }
        }

        //constructor- N/A
        //most things can't just be drawable objects- should be a background object or a card.
        //only two cases: numbers and Player
        public Drawable(Texture2D pTexr, Rectangle pPosit)
        {
            texr = pTexr;
            posit = pPosit;
            imageSize = new Point(pPosit.Width, pPosit.Height);

            tint = Color.White;
            strPosit = new Vector2(0,0);

            spriteLocations = new List<Point>();
        }

        //seperate constructor for player objects- for drawing effects in results
        public Drawable(SpriteFont fnt, Vector2 posit)
        {
            font = fnt;
            strPosit = posit;

            spriteLocations = new List<Point>();
        }


        //methods
        /// <summary>
        /// Draws static objects, uses rectangle position variables
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void DrawStatic(SpriteBatch spriteBatch)
        {
            //draw texture at posit
            spriteBatch.Draw(texr, posit, tint);
        }
        
        /// <summary>
        /// Draws string using default font
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void DrawString(SpriteBatch spriteBatch)
        {
            //draw texture at posit
            spriteBatch.DrawString(font, this.ToString(), strPosit, Color.SaddleBrown);
        }

        /// <summary>
        /// Draws string, and can be passed a font
        /// </summary>
        /// <param name="fnt">Font to be used</param>
        /// <param name="spriteBatch"></param>
        public void DrawString(SpriteFont fnt, SpriteBatch spriteBatch)
        {
            //draw texture at posit
            if(this.ToString()!=null)spriteBatch.DrawString(fnt, this.ToString(), strPosit, Color.SaddleBrown);
        } 
        
        /// <summary>
        /// takes size of sprites and rows/columns, divides. 
        /// saves locations for each sprite to make animation and drawing quicker quicker- only need to do this math once
        /// should only be called on an object once
        /// </summary>
        public void UnpackSprites()
        {
            spriteLocations.Clear();

            //store sprites in SpriteLocations list
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Point location = new Point((j * (imageSize.X / columns)), (i * (imageSize.Y / rows)));
                    spriteLocations.Add(location);
                }
            }
            
        }

        /// <summary>
        /// method for animated objects 
        /// a (just position changes)
        /// b (moves through multiple sprites and position)
        /// </summary>
        public void Anim(Stopwatch watch, SpriteBatch spritebatch)
        {
            msSinceFrame = watch.ElapsedMilliseconds - oldTime;
            //goes through spriteLocations timed
            if (msPerFrame <= msSinceFrame)
            {
                frame += 1;
                oldTime = watch.ElapsedMilliseconds;
            }
            if (frame > spriteLocations.Count-1)
            {
                frame = 0;
            }

            spritebatch.Draw(texr, new Rectangle(0,0, posit.Width/columns, posit.Height/rows), new Rectangle(spriteLocations[frame].X, spriteLocations[frame].Y, posit.Width / columns, posit.Height / rows), Color.White);
        }
        
    }
}
