using System;

/// <summary>
/// Summary description for Punch
/// </summary>
public class Punch: Card
{
    private int PUNCH_DAMAGE = 10;
    private int value = 9;

    public override void Effect(Player opponent, Player self)
    {
        if(isActive)opponent.AlterHealth(-PUNCH_DAMAGE);
    }
    
    
}
