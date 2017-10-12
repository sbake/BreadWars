﻿
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BreadWars
{
/// <summary>
/// Summary description for Octopus
/// </summary>
public class Octopus: Card
{

    public Octopus(Texture2D pTexr, Rectangle pPosit, bool active) : base(pTexr, pPosit, active)
    {
            value = 8;
        }
}
}