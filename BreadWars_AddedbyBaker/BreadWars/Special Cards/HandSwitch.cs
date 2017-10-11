using System;

/// <summary>
/// Summary description for HandSwitch
/// </summary>
public class HandSwitch : Card
{
    private int value = 13;

    public override void effect(Player opponent, Player self, Deck deck)
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
