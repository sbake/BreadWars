﻿using System;
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
        protected int value;
        protected int specialValue;
        protected string description;
        public int Value
        {
            get { return value; }
            set { this.value = value; } //too late to change value name? value is already the name of a thing in C#
        }
        private Random r;

        public string Name { get; set; }
        public string EffectDescription { get; set; }

        //dimensions
        const int WIDTH = 20;
        public int Width { get => WIDTH; }
        const int HEIGHT = 20;
        public int Height { get => HEIGHT; }

        //special (effect active)
        protected bool isActive;
        public bool IsActive
        {
            get{return isActive;}
            set { isActive = value; }
        }
        
        //isBurned
        protected bool isBurned;
        public bool IsBurned{get{return isBurned;} set{isBurned = value;}}

        //is8
        protected bool is8;
        public bool Is8{get{return is8;} set{is8 = value;}}

        //is unicorn
        protected bool isUnicorn;
        public bool IsUnicorn { get { return isUnicorn; } set { isUnicorn = value; } }

        //constructor
        public Card(Texture2D pTexr, Rectangle pPosit, bool active, Drawable pNumbers) : base(pTexr, pPosit)
        {
            isBurned = false;
            is8 = false;
            isActive = active;
            Numbers = pNumbers;

            r = new Random();

            //rows and columns
            rows = 1;
            columns = 2;
        }

        public virtual void Effect(Player opponent, Player self, Deck deck){
            SetPos(self);
            if(isActive || is8){
                Random r = new Random();
                for(int i=r.Next(0,51); i<52; i++){
                    if (deck.Library[i] != null)
                    {
                        deck.Library[i].Is8 = true;
                    }
                    i+= r.Next(0, 20);
                }
            }
        }

        public void SetPos(Player self)
        {
            ChangeTintNotHover();
            if (self.PlayerNumber == 1)
            {
                strPosit = new Vector2(10, 10);
            }
            else
            {
                strPosit = new Vector2(10, 50);
            }
        }

        public int GetTotalValue()
        {
            if (isBurned) return r.Next(0,20);
            if (isActive) return value + specialValue;
            else return value;
        }
        public override string ToString()
        {
            return EffectDescription; 
        }

        public void ChangeTintHover()
        {
            tint = Color.Gray;
        }

        public void ChangeTintNotHover()
        {
            tint = Color.White;
        }

        public void ChangeTintPressed()
        {
            tint = Color.HotPink;
        }

        //overwrite draw method to only draw card if flipped up
        public void DrawStatic(SpriteBatch spriteBatch, SpriteFont font)
        {
            if (1 == 1)//if player has turn, how to check?
            {
                base.UnpackSprites();
                //draw base
                spriteBatch.Draw(texr, posit, new Rectangle(spriteLocations[0], new Point(posit.Width/2, posit.Height)), isBurned? Color.Black: tint);
                //draw special if special
                if (isActive)
                {
                    spriteBatch.Draw(texr, new Rectangle(posit.X, Posit.Y, Posit.Width, posit.Height*2), new Rectangle(new Point(SpriteLocations[1].X +2, SpriteLocations[1].Y), new Point(posit.Width/2, posit.Height)), Color.Red);
                }
                //draw numbr
                //int offsetFromCorners = 30; //add to posit
                
                if (!isBurned && value / 10 != 0)
                {
                    spriteBatch.Draw(Numbers.Texr, new Rectangle(posit.X + 5, posit.Y+125, 14, 20), new Rectangle(Numbers.SpriteLocations[value / 10], new Point(Numbers.Posit.Width / 10, Numbers.Posit.Height)), Color.White);
                    spriteBatch.Draw(Numbers.Texr, new Rectangle(posit.X +14 + 5, posit.Y + 125, 14, 20), new Rectangle(Numbers.SpriteLocations[value % 10], new Point(Numbers.Posit.Width / 10, Numbers.Posit.Height)), Color.White);
                }
                else if(!isBurned)
                {
                    //texture, destination, source, color
                    spriteBatch.Draw(Numbers.Texr, new Rectangle(posit.X+ 5, posit.Y + 125, 14, 20), new Rectangle(Numbers.SpriteLocations[value % 10], new Point(Numbers.Posit.Width / 10, Numbers.Posit.Height)), Color.White);
                }
                
                //draw numbers with spritefont instead
                spriteBatch.DrawString(font, is8? "octo": "" + (isBurned? "burn" : ""), new Vector2(posit.X, posit.Y), Color.Black);
            }
        }
    }
}
