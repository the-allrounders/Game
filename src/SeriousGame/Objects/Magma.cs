using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SeriousGame.Managers;
using SeriousGame.Screens;

namespace SeriousGame.Objects
{
    class Magma
    {
        private Vector2 magmaPosition;
        private readonly Texture2D magmaTexture;
        private float speedIncrease;

        public Magma(Vector2 pos)
        {
            magmaPosition = pos;
            magmaTexture = TextureManager.Magma;
            speedIncrease = 0;
        }

        public bool IsTouchingFrog(Frog frog)
        {
            return frog.BoundingBox.Bottom > magmaPosition.Y;
        }

        public void Rise(int offset)
        {
            speedIncrease += 0.01f;
            if (speedIncrease > 2)
                speedIncrease = 2;
            magmaPosition.Y -= 1 + speedIncrease;
            int bottomScreen = offset * -1 + (int)ScreenManager.Dimensions.Y;
            if ((bottomScreen - magmaPosition.Y) * -1 > 0)
                magmaPosition.Y = bottomScreen;
        }

        public void Draw(SpriteBatch spriteBatch, int offset)
        {
            int bottomScreen = offset * -1 + (int)ScreenManager.Dimensions.Y;
            decimal iterations;
            int magmaHeight = ((int)magmaPosition.Y - bottomScreen) * -1;
            if (magmaPosition.Y < bottomScreen)
            {
                if (magmaHeight > ScreenManager.Dimensions.Y)
                    iterations = (int)ScreenManager.Dimensions.Y / magmaTexture.Height + 6;
                else
                    iterations = magmaHeight / magmaTexture.Height + 1;
            }
            else
            {
                iterations = 0;
            }

            for (int i = 0; i < Math.Ceiling(iterations); i++)
            {
                spriteBatch.Draw(magmaTexture, new Vector2(JumpScreen.Padding-5, bottomScreen + offset - magmaHeight + magmaTexture.Height * i));
            }
        }
    }
}
