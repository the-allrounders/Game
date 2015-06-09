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
            int magmaHeight = ((int)magmaPosition.Y - bottomScreen) * -1;
            spriteBatch.Draw(magmaTexture, new Vector2(JumpScreen.Padding-13, bottomScreen + offset - magmaHeight));
        }
    }
}
