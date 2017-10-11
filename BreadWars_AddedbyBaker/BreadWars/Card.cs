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
        protected int value;
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
        public Card(Texture2D pTexr, Rectangle pPosit, bool active)
        {
            texr = pTexr;
            posit = pPosit;
            isBurned = false;
            is8 = false;
            isActive = active;
        }

        public virtual void Effect(Player opponent, Player self, Deck deck){
            if(isActive){
                Random r = new Random();
                for(int i=r.Next(0,51); i<52; i++){
                    deck[i].Is8 = true;
                    i+= r.Next(0, 20);
                }
            }
        }

        //overwrite draw methos to only draw card if flipped up
        public void DrawStatic()
        {

        }
    }
}
