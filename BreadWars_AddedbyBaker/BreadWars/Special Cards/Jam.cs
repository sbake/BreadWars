using System;

/// <summary>
/// Summary description for Jam
/// </summary>
public class Jam: Card
{
    private int RESTORE_HEALTH = 5;
    private int value = 6;

    public override void effect(Player opponent, Player self)
    {
        if (isActive)
        {
            self.IsPoisoned = false;
            self.AlterHealth(RESTORE_HEALTH);
        }
    }
}
