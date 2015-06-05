using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System;

namespace SeriousGame
{
    class Magma
    {
        private Vector2 _magmaPosition;
        private Texture2D _magmaTexture;
        private float _speedIncrease;

        public Magma (Vector2 pos)
        {
            _magmaPosition = pos;
            _magmaTexture = TextureManager.Magma;
            _speedIncrease = 0;
        }

        public bool IsTouchingMagma (Frog frog)
        {
            return frog.BoundingBox.Bottom > _magmaPosition.Y;
        }

        public void Update (GameTime gameTime, int offset)
        {
            _speedIncrease += 0.01f;
            if (_speedIncrease > 2)
                _speedIncrease = 2;
            _magmaPosition.Y -= 1 + _speedIncrease;
            int bottomScreen = offset * -1 + (int)ScreenManager.Dimensions.Y;
            if ((bottomScreen - _magmaPosition.Y) * -1 > (int)ScreenManager.Dimensions.Y / 2)
            {
                _magmaPosition.Y = bottomScreen + (int)ScreenManager.Dimensions.Y / 2;
            }
        }

        public void Draw (SpriteBatch spriteBatch, int offset)
        {
            int bottomScreen = offset * -1 + (int)ScreenManager.Dimensions.Y;
            decimal iterations;
            if (_magmaPosition.Y < bottomScreen)
            {
                int magmaHeight = ((int)_magmaPosition.Y - bottomScreen) * -1;
                if (magmaHeight > ScreenManager.Dimensions.Y)
                    iterations = (int)ScreenManager.Dimensions.Y / _magmaTexture.Height + 5;
                else
                    iterations = magmaHeight / _magmaTexture.Height;
            }
            else
            {
                iterations = 0;
            }

            for (int i = 0; i < Math.Ceiling(iterations); i++)
            {
                spriteBatch.Draw(_magmaTexture, new Vector2(0, bottomScreen + offset - (int)_magmaTexture.Height * i));
            }
        }
    }
}
