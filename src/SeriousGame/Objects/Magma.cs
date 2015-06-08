using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SeriousGame
{
    class Magma
    {
        private Vector2 _magmaPosition;
        private Texture2D _magmaTexture;
        private float _speedIncrease;

        public Magma(Vector2 pos)
        {
            _magmaPosition = pos;
            _magmaTexture = TextureManager.Magma;
            _speedIncrease = 0;
        }

        public bool IsTouchingMagma(Frog frog)
        {
            return frog.BoundingBox.Bottom > _magmaPosition.Y;
        }

        public void Update(GameTime gameTime, int offset)
        {
            _speedIncrease += 0.01f;
            if (_speedIncrease > 2)
                _speedIncrease = 2;
            _magmaPosition.Y -= 1 + _speedIncrease;
            int bottomScreen = offset * -1 + (int)ScreenManager.Dimensions.Y;
            if ((bottomScreen - _magmaPosition.Y) * -1 > 0)
            {
                _magmaPosition.Y = bottomScreen;
            }
        }

        public void Draw(SpriteBatch spriteBatch, int offset)
        {
            int bottomScreen = offset * -1 + (int)ScreenManager.Dimensions.Y;
            decimal iterations;
            int magmaHeight = ((int)_magmaPosition.Y - bottomScreen) * -1;
            if (_magmaPosition.Y < bottomScreen)
            {
                if (magmaHeight > ScreenManager.Dimensions.Y)
                    iterations = (int)ScreenManager.Dimensions.Y / _magmaTexture.Height + 6;
                else
                    iterations = magmaHeight / _magmaTexture.Height + 1;
            }
            else
            {
                iterations = 0;
            }

            for (int i = 0; i < Math.Ceiling(iterations); i++)
            {
                spriteBatch.Draw(_magmaTexture, new Vector2(JumpScreen.Padding-5, bottomScreen + offset - magmaHeight + _magmaTexture.Height * i));
            }
        }
    }
}
