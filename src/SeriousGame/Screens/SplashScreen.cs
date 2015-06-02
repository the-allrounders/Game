using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGame
{
    class SplashScreen : GameScreen
    {
        public override void Update(GameTime gameTime)
        {
            KeyboardState keyboard = Keyboard.GetState();
            if(gameTime.TotalGameTime.Seconds >= 3 || keyboard.IsKeyDown(Keys.Escape) || keyboard.IsKeyDown(Keys.Space) || keyboard.IsKeyDown(Keys.Enter)){
                ScreenManager.Instance.CurrentScreen = new StartScreen();
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(TextureManager.Instance.Splash, new Vector2(0,0));
        }
    }
}
