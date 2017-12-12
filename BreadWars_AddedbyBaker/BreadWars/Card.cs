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
            get { return isActive; }
            set { isActive = value; }
        }

        //isBurned
        protected bool isBurned;
        public bool IsBurned { get { return isBurned; } set { isBurned = value; } }

        //is8
        protected bool is8;
        public bool Is8 { get { return is8; } set { is8 = value; } }

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

        public virtual void Effect(Player opponent, Player self, Deck deck)
        {
            SetPos(self);
            EffectDescription = "Random cards have become octopuses!";
            if (isActive || is8)
            {
                Random r = new Random();
                for (int i = r.Next(0, 51); i < 52; i++)
                {
                    if (deck.Library[i] != null)
                    {
                        deck.Library[i].Is8 = true;
                    }
                    i += r.Next(0, 20);
                }
            }
        }

        public void SetPos(Player self)
        {
            ChangeTintNoTint();
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
            if (isBurned) return r.Next(0, 20);
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

        public void ChangeTintNoTint()
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

            base.UnpackSprites();
            //draw base
            spriteBatch.Draw(texr, posit, new Rectangle(spriteLocations[0], new Point(posit.Width / 2, posit.Height)), isBurned ? (tint == Color.White ? Color.Black : tint) : tint);
            //draw special if special
            if (!isBurned && isActive)
            {
                spriteBatch.Draw(texr, posit, new Rectangle(new Point(SpriteLocations[1].X, SpriteLocations[1].Y), new Point(posit.Width, posit.Height)), Color.White);
            }

            if (!isBurned)
            {
                spriteBatch.DrawString(font, SplitName(), new Vector2(posit.X + 5, posit.Y + 190), Color.Black);
            }

            //say if card is not a natural octopus
            spriteBatch.DrawString(font, is8 ? "Octopied!" : "", new Vector2(posit.X, posit.Y), Color.Black);

        }

        //turns the name of the card into a drawable string to fit card graphic
        private string SplitName()
        {
            string toReturn = value + " ";
            if (!isActive) return toReturn;
            int count = toReturn.Length;
            if (Name.Length > 10)
            {
                string[] words = Name.Split();
                for (int i = 0; i < words.Length; i++)
                {
                    if ((count + words[i].Length) > 11)
                    {
                        toReturn += "\n " + words[i] + " ";
                        count = words[i].Length + 2;
                    }
                    else
                    {
                        toReturn += words[i] + " ";
                        count += words[i].Length + 1;
                    }

                }
            }
            else
            {
                toReturn += Name;
            }
            return toReturn;
        }
    }
}
