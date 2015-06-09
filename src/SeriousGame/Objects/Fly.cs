using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SeriousGame.Managers;
using SeriousGame.Screens;

namespace SeriousGame.Objects
{
    class Fly : Collectable
    {
        public Fly(Vector2 pos, int scrWrth)
            : base(pos, TextureManager.Fly, scrWrth)
        {

        }

        public static List<Fly> GenerateList()
        {
            Random rnd = new Random();
            List<Fly> flies = new List<Fly>();
            for (int i = 300; i > JumpScreen.gameHeight * -1; i -= TextureManager.Fly.Height + 200)
            {
                int fliesThisLine = rnd.Next(-1, 4);
                for (int n = 0; n < fliesThisLine; n++)
                {
                    int distance = (int)((ScreenManager.Dimensions.X - (JumpScreen.Padding * 2)) / fliesThisLine * n) + JumpScreen.Padding + rnd.Next(-30, 30);
                    if (distance < JumpScreen.Padding)
                        distance = JumpScreen.Padding;
                    else if (distance > ScreenManager.Dimensions.X - JumpScreen.Padding)
                        distance = (int)ScreenManager.Dimensions.X - JumpScreen.Padding - TextureManager.Fly.Width;
                    flies.Add(new Fly(new Vector2(distance, i + rnd.Next(-50, 50)), 100));
                }
            }
            return flies;
        }
    }
}