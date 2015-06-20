using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SeriousGame.Managers;
using SeriousGame.Screens;

namespace SeriousGame.Objects
{
    class Fly : Collectable
    {
        public Fly(Vector2 pos, int scrWrth, int width, int height, int frames, int animationSpeed)
            : base(pos, TextureManager.Fly, scrWrth, width, height, frames, animationSpeed)
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
                    flies.Add(new Fly(new Vector2(rnd.Next(JumpScreen.Padding, (int)ScreenManager.Dimensions.X - JumpScreen.Padding), i + rnd.Next(-100, 100)), 100, 48, 41, 3, 10));
                }
            }
            return flies;
        }
    }
}