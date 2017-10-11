using BreadWars;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

/// <summary>
/// Summary description for HandSwitch
/// </summary>
public class HandSwitch : Card
{
    private int value = 13;

    public HandSwitch(Texture2D pTexr, Rectangle pPosit, bool active) : base(pTexr, pPosit, active)
    {
    }

    public override void Effect(Player opponent, Player self, Deck deck)
    {
        if (isActive)
        {
            List<Card> hand1 = opponent.Hand;
            List<Card> hand2 = self.Hand;
            opponent.Hand = hand2;
            self.Hand = hand1;
        }
    }
}
