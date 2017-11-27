
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BreadWars
{
/// <summary>
/// Summary description for Confetti
/// </summary>
public class Confetti : Card
{
    public Confetti(Texture2D pTexr, Rectangle pPosit, bool active, Drawable pNumbers)  : base( pTexr,  pPosit,  active,  pNumbers)
        {
            value = 20;
            specialValue = 0;
            Name = "Confetti";
    }
        public override void Effect(Player opponent, Player self, Deck deck)
        {
            SetPos(self);
            EffectDescription = "You have been confettied!";
            if (is8)base.Effect(opponent, self, deck);
        }
    }
}