using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace BreadWars
{
/// <summary>
/// Summary description for SaveForLater
/// </summary>
public class SaveForLater : Card
{
    public SaveForLater(Texture2D pTexr, Rectangle pPosit, bool active, Drawable pNumbers)  : base( pTexr,  pPosit,  active,  pNumbers)
    {
        value = 7;
        Name = "Save for Later";
    }
}
}