using BreadWars;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

/// <summary>
/// Summary description for Jam
/// </summary>
public class Jam: Card
{
    private int RESTORE_HEALTH = 5;
    private int value = 6;

    public Jam(Texture2D pTexr, Rectangle pPosit, bool active) : base(pTexr, pPosit, active)
    {
    }

    public override void Effect(Player opponent, Player self, Deck deck)
    {
        if (isActive)
        {
            self.IsPoisoned = false;
            self.AlterHealth(RESTORE_HEALTH);
        }
    }
}
