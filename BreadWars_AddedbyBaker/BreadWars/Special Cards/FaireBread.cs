using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Threading;

namespace BreadWars
{
    /// <summary>
    /// Summary description for FaireBread
    /// </summary>
    public class FaireBread : Card
    {

        public FaireBread(Texture2D pTexr, Rectangle pPosit, bool active, Drawable pNumbers) : base(pTexr, pPosit, active, pNumbers)
        {
            value = 11;
            specialValue = 1;
            Name = "Faire Bread";
        }

        public override void Effect(Player opponent, Player self, Deck deck)
        {
            SetPos(self);
            if (this.is8)
            {
                base.Effect(opponent, self, deck);
                return;
            }
            EffectDescription = "Special cards are now normal (and normal are special)!";
            //switch all cards' isActive bool

            foreach (Card c in deck.Library)
            {
                if (c != null && c != self.CurrCard && c != opponent.CurrCard) c.IsActive = (c.IsActive ? false : true);
            }


        }
    }
}
