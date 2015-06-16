using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SeriousGame.Managers;

namespace SeriousGame.Screens
{
    class Creditsscreen : GameScreen
    {

       

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(FontManager.Verdana, "Mogelijk gemaakt door:", new Vector2(300,300), Color.White);
            spriteBatch.DrawString(FontManager.Verdana, "Bart Langelaan, Ian Wensink, Niels Otten & Lisa Uijtewaal", new Vector2(300, 340), Color.White);


        }
    }
}
