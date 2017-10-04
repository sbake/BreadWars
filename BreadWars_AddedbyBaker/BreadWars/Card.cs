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

        //name
        private String name;
        //value
        private int value;

        public int Value { get { return value; } }
        //effect

        //special (effect active)
        public bool isActive;
        public bool IsActive
        {
            get
            {
                return isActive;
            }
            set
            {
                isActive = value;
            }
        }
        
        //isBurned
        private bool isBurned;
        //is8
        private bool is8;


        //constructor
        public Card(Texture2D pTexr, Rectangle pPosit, SpriteBatch pSpriteBatch)
        {

        }
    }
}
