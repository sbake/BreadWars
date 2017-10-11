using BreadWars;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

/// <summary>
/// Summary description for FaireBread
/// </summary>
public class FaireBread: Card
{
    private int value = 11;

    public FaireBread(Texture2D pTexr, Rectangle pPosit, bool active) : base(pTexr, pPosit, active)
    {
    }

    public override void Effect()
    {

    }
}
