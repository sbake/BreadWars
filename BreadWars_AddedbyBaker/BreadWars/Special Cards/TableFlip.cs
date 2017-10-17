
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BreadWars
{
/// <summary>
/// Summary description for TableFlip
/// </summary>
public class TableFlip : Card
{
    public TableFlip(Texture2D pTexr, Rectangle pPosit, bool active, Drawable pNumbers)  : base( pTexr,  pPosit,  active,  pNumbers)
    {
        value = 2;
        Name = "Table Flip";
    }
}
}