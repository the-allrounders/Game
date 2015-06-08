using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Linq;
using System.Text;

namespace SeriousGame
{
    class LeaderboardScreen : GameScreen
    {
        private string[] values;

        public override void Load()
        {
            String pathOfFile = "../../../leaderboard.txt";
            values = File.ReadAllLines(pathOfFile);
            List<string> scores = values.ToList<string>();
            //Sort<string>(values, 2);
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            
        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            for (int i = 0; i < values.Length && i < 11; i++)
            {
                string[] score = values[i].Split(',');
                String text = (i + 1) + ". " + score[0] + ": " + score[1];
                spriteBatch.DrawString(FontManager.Verdana, text, new Vector2(ScreenManager.Dimensions.X / 2 - 150, 100 + (i * 40)), Color.Black);
            }
        }
    }
}
