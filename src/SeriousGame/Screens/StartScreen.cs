using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGame
{
    class StartScreen : GameScreen
    {
        public override void Load()
        {
            // Startscherm geladen
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            if (InputManager.IsPressing(Keys.Space))
            {
                ScreenManager.Instance.CurrentScreen = new JumpScreen();
            }
            else if (InputManager.IsPressing(Keys.S))
            {
                ScreenManager.Instance.CurrentScreen = new SettingsScreen();
            }
            else if (InputManager.IsPressing(Keys.Escape))
            {
                ScreenManager.Instance.Game.Exit();
            }
        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(TextureManager.Instance.Start, new Vector2(0, 0));
        }
    }
}
