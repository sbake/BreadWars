using System;

/// <summary>
/// Summary description for GlueGun
/// </summary>
public class GlueGun: Card
{
    private int value = 4;

    public void effect(Player opponent, Player self)
    {
        if (isActive)
        {
            Random r = new Random();
            int index1 = r.Next(0, self.Hand.Count);
            Card c1 = self.Hand[index1];
            self.Hand.remove(index1);
            int index2 = r.Next(0, self.Hand.Count);
            Card c2 = self.Hand[index2];
            self.Hand.remove(index2);
            Card newCard;
            switch (c1.Value+c2.Value)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
                case 7:
                    break;
                case 8:
                    break;
                case 9:
                    break;
                case 10:
                    break;
                case 11:
                    break;
                case 12:
                    break;
                case 13:
                    break;
                case 14:
                    break;
                case 15:
                    break;
                case 16:
                    break;
                case 17:
                    break;
                case 18:
                    break;
                case 19:
                    break;
                case 20:
                    break;
                default:
                    newCard = new Confetti();
                    break;
            }
            self.Hand.Add(newCard);
        }
    }
}
