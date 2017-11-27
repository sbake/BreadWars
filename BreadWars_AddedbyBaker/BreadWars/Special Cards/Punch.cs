
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BreadWars
{
/// <summary>
/// Summary description for Punch
/// </summary>
public class Punch: Card
{
    private int PUNCH_DAMAGE = 10;

    public Punch(Texture2D pTexr, Rectangle pPosit, bool active, Drawable pNumbers) : base(pTexr, pPosit, active, pNumbers)
        {
            value = 9;
            specialValue = 3;
            Name = "Punch";
        }

    public override void Effect(Player opponent, Player self, Deck deck)
        {
            SetPos(self);
            EffectDescription = "Player " + opponent.PlayerNumber + " has been punched!";
        if (this.is8) {
                base.Effect(opponent,self,deck);
                return;
        }

        if(isActive)opponent.AlterHealth(-PUNCH_DAMAGE);
    }
    
    
}
}