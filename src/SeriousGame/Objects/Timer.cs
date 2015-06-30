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
        private int duration;
        private double startGameTime;
        public bool waiting = true;
        private double timeWaiting;

        public Timer(int dur, GameTime gameTime)
        {
            duration = dur;
            startGameTime = gameTime.TotalGameTime.TotalSeconds;
            waiting = true;
            timeWaiting = dur;
        }

        public void Update(GameTime currentGameTime)
        {
            if (startGameTime + duration > currentGameTime.TotalGameTime.TotalSeconds)
                timeWaiting = duration + startGameTime - currentGameTime.TotalGameTime.TotalSeconds;
            else
                waiting = false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            double time = timeWaiting;
            string text = "";
            if (time >= duration / 2 && time < duration)
                text = "Klaar?";
            else if (time > 0 && time < duration/2)
                text = "Start!";
            spriteBatch.DrawString(FontManager.MarkerFelt100, text, new Vector2(ScreenManager.Dimensions.X / 2 - FontManager.MarkerFelt100.MeasureString(text).X / 2, (ScreenManager.Dimensions.Y / 2 - TextureManager.ControlInfoArrows.Height / 2)), Color.Green);
        }
    }
}
