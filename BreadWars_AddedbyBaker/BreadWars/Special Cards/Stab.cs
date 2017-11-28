using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BreadWars
{
    /// <summary>
    /// Summary description for Stab
    /// </summary>
    public class Stab : Card
    {
        private int STAB_DAMAGE = 20;

        public Stab(Texture2D pTexr, Rectangle pPosit, bool active, Drawable pNumbers) : base(pTexr, pPosit, active, pNumbers)
        {
            value = 3;
            specialValue = 3;
            Name = "Stab";
        }

        public override void Effect(Player opponent, Player self, Deck deck)
        {

            SetPos(self);
            EffectDescription = "Player " + opponent.PlayerNumber + " has been Stabbed!";
            if (this.is8)
            {
                base.Effect(opponent, self, deck);
                return;
            }
            opponent.AlterHealth(-STAB_DAMAGE);
        }
    }
}
