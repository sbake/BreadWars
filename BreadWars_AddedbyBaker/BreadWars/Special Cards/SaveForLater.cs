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
    public SaveForLater(Texture2D pTexr, Rectangle pPosit, bool active, Player pSelf, Drawable pNumbers) : base(pTexr, pPosit, active, pSelf, pNumbers)
        {
    }
}
}