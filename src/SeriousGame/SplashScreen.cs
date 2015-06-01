using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
            if(gameTime.TotalGameTime.Seconds >= 1){
                ScreenManager.Instance.CurrentScreen = new StartScreen();
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            // TODO: Een super coole splash screen tekenen
        }
    }
}
