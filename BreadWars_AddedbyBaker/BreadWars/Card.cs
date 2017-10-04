using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace BreadWars
{
    class Card : Drawable
    {
        
        //value
        private int value;
        public int Value { get { return value; } }

        //effect

        //special (effect active)
        public bool isActive;
        public bool IsActive
        {
            get{return isActive;}
            set { isActive = value; }
        }
        
        //isBurned
        private bool isBurned;
        public bool IsBurned{get{return isBurned;} set{isActive = value;}}

        //is8
        private bool is8;
        public bool Is8{get{return is8;} set{is8 = value;}}

        //constructor
        public Card(Texture2D pTexr, Rectangle pPosit, SpriteBatch pSpriteBatch, bool active)
        {
            texr = pTexr;
            posit = pPosit;
            spriteBatch = pSpriteBatch;
            isBurned = false;
            is8 = false;
            isActive = active;
        }

        
    }
}
