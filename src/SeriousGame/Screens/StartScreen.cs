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
            KeyboardState keyboard = Keyboard.GetState();
            if(keyboard.IsKeyDown(Keys.Space)){
                ScreenManager.Instance.CurrentScreen = new JumpScreen();
            }
            else if (keyboard.IsKeyDown(Keys.S))
            {
                ScreenManager.Instance.CurrentScreen = new SettingsScreen();
            }
            else if (keyboard.IsKeyDown(Keys.Escape))
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
