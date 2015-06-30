using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Frogano.Managers;

namespace Frogano.Screens
{
    class CreditsScreen : GameScreen
    {
        public override void Update(GameTime gameTime)
        {
            // If user is pressing ESC, return to StartScreen
            if (InputManager.IsPressing(Keys.Escape) || InputManager.IsClicking(new Rectangle(24, 14, TextureManager.SettingsArrow[0].Width, TextureManager.SettingsArrow[0].Height)))
            {
                ScreenManager.CurrentScreen = new StartScreen();
            }
        }


        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(TextureManager.CreditsScreen, new Vector2(0, 0));
            spriteBatch.DrawString(FontManager.MarkerFelt12, "Mogelijk gemaakt door:", new Vector2(400, 300), Color.White);
            spriteBatch.DrawString(FontManager.MarkerFelt12, "Bart Langelaan, Ian Wensink, Niels Otten & Lisa Uijtewaal", new Vector2(400, 340), Color.White);

            // Draw back button
            spriteBatch.Draw(
                InputManager.IsHovering(new Rectangle(24, 14, TextureManager.SettingsArrow[0].Width, TextureManager.SettingsArrow[0].Height))
                ? TextureManager.SettingsArrow[1]
                : TextureManager.SettingsArrow[0],
                new Vector2(24, 14)
                );
        }
    }
}
