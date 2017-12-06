
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BreadWars
{
    /// <summary>
    /// Summary description for Fire
    /// </summary>
    public class Fire : Card
    {
        private int FIRE_DAMAGE = 5;

        public Fire(Texture2D pTexr, Rectangle pPosit, bool active, Drawable pNumbers) : base(pTexr, pPosit, active, pNumbers)
        {
            value = 18;
            specialValue = 2;
            Name = "Fire";
        }

        public override void Effect(Player opponent, Player self, Deck deck)
        {
            SetPos(self);
            if (this.is8)
            {
                base.Effect(opponent, self, deck);
                return;
            }
            EffectDescription = "All cards in play have been burned!";
            opponent.AlterHealth(-FIRE_DAMAGE); //damage opponent
            //burn all cards on field 
            foreach (Card c in self.Hand)
            {
                if (c != null) c.IsBurned = true;
            }
            foreach (Card c in opponent.Hand)
            {
                if (c != null) c.IsBurned = true;
            }

        }
    }
}
