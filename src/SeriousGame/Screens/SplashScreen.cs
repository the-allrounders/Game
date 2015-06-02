﻿using Microsoft.Xna.Framework;
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
            if (gameTime.TotalGameTime.Seconds >= 3 || InputManager.IsPressing(Keys.Escape) || InputManager.IsPressing(Keys.Space) || InputManager.IsPressing(Keys.Enter))
            {
                ScreenManager.CurrentScreen = new StartScreen();
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(TextureManager.Splash, new Vector2(0,0));
        }
    }
}
