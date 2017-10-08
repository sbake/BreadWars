using System;

/// <summary>
/// Summary description for Block
/// </summary>
public class Block : Card
{
    private int value = 15;

    public override void effect(Player opponent, Player self)
    {
        if(isActive)self.HasBlock = true;
    }
}
