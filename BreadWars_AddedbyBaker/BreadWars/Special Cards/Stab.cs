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

    public Stab(Texture2D pTexr, Rectangle pPosit, bool active) : base(pTexr, pPosit, active)
        {
            value = 3;
        }

    public override void Effect(Player opponent, Player self, Deck deck)
    {
        if (isActive) opponent.AlterHealth(-STAB_DAMAGE);
    }
}
    }
