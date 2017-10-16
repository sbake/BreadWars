
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace BreadWars
{
/// <summary>
/// Summary description for HandSwitch
/// </summary>
public class HandSwitch : Card
{

    public HandSwitch(Texture2D pTexr, Rectangle pPosit, bool active, Player pSelf, Drawable pNumbers) : base(pTexr, pPosit, active, pSelf, pNumbers)
        {
            value = 13;
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
}