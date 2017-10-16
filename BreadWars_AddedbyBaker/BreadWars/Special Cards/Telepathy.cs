
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BreadWars
{
/// <summary>
/// Summary description for Telepathy
/// </summary>
public class Telepathy : Card
{
    public Telepathy(Texture2D pTexr, Rectangle pPosit, bool active, Player pSelf, Drawable pNumbers) : base(pTexr, pPosit, active, pSelf, pNumbers)
        {
            value = 14;
    }

        public override void Effect(Player opponent, Player self, Deck deck)
        {
            if (isActive)
            {
                for(int i=0; i<4; i++)
                {
                    deck.Library[i].DrawStatic(); //???
                }
            }
        }

    }
    }
