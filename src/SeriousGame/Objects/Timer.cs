using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SeriousGame.Managers;

namespace SeriousGame.Objects
{
    class Timer
    {
        private int totalTime;
        private int startGameTime;
        public bool waiting = true;
        private int timeWaiting;

        public Timer(int ttltm, int gameTime)
        {
            totalTime = ttltm;
            startGameTime = gameTime;
            waiting = true;
            timeWaiting = ttltm;
        }

        public void Update(GameTime currentGameTime)
        {
            if ((int)startGameTime + totalTime > (int)currentGameTime.TotalGameTime.Seconds)
            {
                timeWaiting = (totalTime + startGameTime) - (int)currentGameTime.TotalGameTime.Seconds;
            } 
            else
            {
                waiting = false;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(FontManager.MarkerFelt100, timeWaiting.ToString(), new Vector2(ScreenManager.Dimensions.X / 2 - FontManager.MarkerFelt100.MeasureString(timeWaiting.ToString()).X / 2, (ScreenManager.Dimensions.Y / 2 - TextureManager.ControlInfoArrows.Height / 2) - 150), Color.Green);
        }
    }
}
