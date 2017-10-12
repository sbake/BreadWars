
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BreadWars
{
/// <summary>
/// Summary description for FaireBread
/// </summary>
public class FaireBread: Card
{

    public FaireBread(Texture2D pTexr, Rectangle pPosit, bool active) : base(pTexr, pPosit, active)
    {
            value = 11;
        }

    public override void Effect(Player opponent, Player self, Deck deck)
    {

    }
}
}
