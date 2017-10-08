using System;

/// <summary>
/// Summary description for Stab
/// </summary>
public class Stab : Card
{
    private int STAB_DAMAGE = 20;
    private int value = 3;

    public override void effect(Player opponent, Player self)
    {
        if (isActive) opponent.AlterHealth(-STAB_DAMAGE);
    }
}
