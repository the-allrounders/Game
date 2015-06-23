using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SeriousGame.Managers;

namespace SeriousGame.Screens
{
    class CreditsScreen : GameScreen
    {
        public override void Update(GameTime gameTime)
        {
            #region Shortcuts

            // If user is pressing ESC, return to StartScreen
            if (InputManager.IsPressing(Keys.Escape))
            {
                ScreenManager.CurrentScreen = new StartScreen();
            }

            #endregion
        }


        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(FontManager.MarkerFelt12, "Mogelijk gemaakt door:", new Vector2(300,300), Color.White);
            spriteBatch.DrawString(FontManager.MarkerFelt12, "Bart Langelaan, Ian Wensink, Niels Otten & Lisa Uijtewaal", new Vector2(300, 340), Color.White);
        }
    }
}
