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
    public class Card : Drawable
    {
        
        //value
        protected int value;
        public int Value
        {
            get { return value; }
            set { value = this.value; } //too late to change value name? value is already the name of a thing in C#
        }

        protected string Name { get; set; }

        //dimensions
        const int WIDTH = 20;
        public int Width { get => WIDTH; }
        const int HEIGHT = 20;
        public int Height { get => HEIGHT; }

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

        //is unicorn
        private bool isUnicorn;
        public bool IsUnicorn { get { return isUnicorn; } set { isUnicorn = value; } }

        //constructor
        public Card(Texture2D pTexr, Rectangle pPosit, bool active, Drawable pNumbers) : base(pTexr, pPosit)
        {
            isBurned = false;
            is8 = false;
            isActive = active;
            Numbers = pNumbers;

            //rows and columns
            rows = 1;
            columns = 2;
        }

        public virtual void Effect(Player opponent, Player self, Deck deck){
            if(isActive){
                Random r = new Random();
                for(int i=r.Next(0,51); i<52; i++){
                    deck.Library[i].Is8 = true;
                    i+= r.Next(0, 20);
                }
            }
        }

        //overwrite draw methos to only draw card if flipped up
        public void DrawStatic(SpriteBatch spriteBatch)
        {
            if (1 == 1)//if player has turn, how to check?
            {
                base.UnpackSprites();
                //draw base
                spriteBatch.Draw(texr, posit, new Rectangle(spriteLocations[0], new Point(posit.Width/2, posit.Height)), Color.White);
                //draw special if special
                if (isActive)
                {
                    spriteBatch.Draw(texr, posit, new Rectangle(spriteLocations[1], new Point(posit.Width/2, posit.Height)), Color.White);
                }
                //draw numbr
                //int offsetFromCorners = 30; //add to posit
                spriteBatch.Draw(Numbers.Texr, new Rectangle(posit.X, posit.Y, 20, 20), new Rectangle(Numbers.SpriteLocations[value/10], new Point(Numbers.Posit.Width/10, Numbers.Posit.Height)), Color.White);
                spriteBatch.Draw(Numbers.Texr, new Rectangle(posit.X+20, posit.Y, 20, 20), new Rectangle(Numbers.SpriteLocations[value%10], new Point(Numbers.Posit.Width / 10, Numbers.Posit.Height)), Color.White);
            }
        }
    }
}
// Point location = new Point((i * (posit.Height/rows)),(j * (posit.Width/columns)));
//spriteLocations.Add(location);
