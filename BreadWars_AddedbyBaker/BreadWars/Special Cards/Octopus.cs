using BreadWars;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

/// <summary>
/// Summary description for Octopus
/// </summary>
public class Octopus: Card
{
    private int value = 8;

    public Octopus(Texture2D pTexr, Rectangle pPosit, bool active) : base(pTexr, pPosit, active)
    {
    }
}
