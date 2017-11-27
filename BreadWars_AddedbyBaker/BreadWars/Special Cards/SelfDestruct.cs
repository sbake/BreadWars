using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BreadWars
{
    /// <summary>
    /// Summary description for Banker
    /// </summary>
    public class SelfDestruct : Card

    {

        const int UNTIL_DESTRUCT = 3;


        public SelfDestruct(Texture2D pTexr, Rectangle pPosit, bool active, Drawable pNumbers)  : base( pTexr,  pPosit,  active,  pNumbers) 
        {
            Name = "Self Destruct";
            value = 17;
            specialValue = -3;
            description = "You will have 3 turns left";
        }

        public override void Effect(Player opponent, Player self, Deck deck)
        {
            EffectDescription = "Player " + self.PlayerNumber + " has 3 turns left";
            if (this.is8)
            {
                base.Effect(opponent, self, deck);
                return;
            }
            if (isActive)
            {
                self.IsDestruct = true;
                self.UntilDestruct = UNTIL_DESTRUCT;
            }
        }
    }
}
