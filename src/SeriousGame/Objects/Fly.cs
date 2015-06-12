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

        public static List<Collectable> GenerateList()
        {
            Random rnd = new Random();
            List<Collectable> flies = new List<Collectable>();
            for (int i = 300; i > JumpScreen.GameHeight * -1; i -= TextureManager.Fly.Height + 200)
            {
                int fliesThisLine = rnd.Next(-1, 3);
                for (int n = 0; n < fliesThisLine; n++)
                {
                    int distance = (int)((ScreenManager.Dimensions.X - (JumpScreen.Padding * 2)) / fliesThisLine * n) + JumpScreen.Padding + 100 + rnd.Next(-100, 100);
                    if (distance < JumpScreen.Padding)
                        distance = JumpScreen.Padding;
                    else if (distance > ScreenManager.Dimensions.X - JumpScreen.Padding)
                        distance = (int)ScreenManager.Dimensions.X - JumpScreen.Padding - TextureManager.Fly.Width;
                    flies.Add(new Fly(new Vector2(distance, i + rnd.Next(-100, 100)), 100));
                }
            }
            return flies;
        }
    }
}