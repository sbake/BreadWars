
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
    public TableFlip(Texture2D pTexr, Rectangle pPosit, bool active, Drawable pNumbers)  : base( pTexr,  pPosit,  active,  pNumbers)
    {
        value = 2;
            specialValue = 1;
            Name = "Table Flip";
    }
        public override void Effect(Player opponent, Player self, Deck deck)
        {

            EffectDescription = "Player " + self.PlayerNumber + " has won by Table Flip!";
            if (this.is8)
            {
                base.Effect(opponent, self, deck);
                return;
            }
            if (isActive && opponent.CurrCard.Value<=2)
            {
                opponent.Health = 0;
            }
        }

    }
}