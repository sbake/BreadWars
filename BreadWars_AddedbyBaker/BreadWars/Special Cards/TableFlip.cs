
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BreadWars
{
    /// <summary>
    /// Summary description for TableFlip
    /// </summary>
    public class TableFlip : Card
    {
        public TableFlip(Texture2D pTexr, Rectangle pPosit, bool active, Drawable pNumbers) : base(pTexr, pPosit, active, pNumbers)
        {
            value = 2;
            specialValue = 1;
            Name = "Table Flip";
        }
        public override void Effect(Player opponent, Player self, Deck deck)
        {

            SetPos(self);
            EffectDescription = "Player " + self.PlayerNumber + " has wasted this card T^T";
            if (this.is8)
            {
                base.Effect(opponent, self, deck);
                return;
            }
            if (opponent.CurrCard.Value <= 2)
            {
                opponent.Health = 0;
                EffectDescription = "Player " + self.PlayerNumber + " has won by Table Flip!";
            }
        }

    }
}