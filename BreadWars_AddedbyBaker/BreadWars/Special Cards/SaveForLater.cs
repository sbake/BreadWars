using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace BreadWars
{
/// <summary>
/// Summary description for SaveForLater
/// </summary>
public class SaveForLater : Card
{
    public SaveForLater(Texture2D pTexr, Rectangle pPosit, bool active, Drawable pNumbers)  : base( pTexr,  pPosit,  active,  pNumbers)
    {
        value = 7;
            specialValue = 1;
            Name = "Save for Later";
    }

        public override void Effect(Player opponent, Player self, Deck deck)
        {
            if (is8)
            {
                base.Effect(opponent, self, deck);
                return;
            }
            if (isActive)
            {
                Random r = new Random();
                int index = r.Next(0, self.Hand.Count);
                Card toSave = self.Hand[index];
                while (toSave == null || toSave.Name == "Save for Later")
                {
                    index = r.Next(0, self.Hand.Count);
                    toSave = self.Hand[index];
                }
                self.SaveLater = toSave;
                self.Hand[index] = deck.Next();
            }

        }
    }
}