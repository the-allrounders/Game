using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Frogano.Managers;
using Frogano.Screens;

namespace Frogano.Objects
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
            float maxSpeed = 2f;
            int magmaMargin = 0;
            switch (SettingsManager.Difficulty)
            {
                case 1:
                    maxSpeed = 1f;
                    magmaMargin = 50;
                    break;
                case 2:
                    maxSpeed = 2f;
                    magmaMargin = 20;
                    break;
                case 3:
                    maxSpeed = 3f;
                    break;
            }
            speedIncrease += 0.01f;
            if (speedIncrease > maxSpeed)
                speedIncrease = maxSpeed;
            magmaPosition.Y -= 1 + speedIncrease;
            int bottomScreen = offset * -1 + (int)ScreenManager.Dimensions.Y;
            if ((bottomScreen + magmaMargin - magmaPosition.Y) * -1 > 0)
                magmaPosition.Y = bottomScreen + magmaMargin;
            else if (magmaPosition.Y < (offset + 72) * -1)
                magmaPosition.Y = (offset + 72) * -1;
        }

        public void Draw(SpriteBatch spriteBatch, int offset)
        {
            int bottomScreen = offset * -1 + (int)ScreenManager.Dimensions.Y;
            int magmaHeight = ((int)magmaPosition.Y - bottomScreen) * -1;
            spriteBatch.Draw(magmaTexture, new Vector2(JumpScreen.Padding-13, bottomScreen + offset - magmaHeight));
        }
    }
}
