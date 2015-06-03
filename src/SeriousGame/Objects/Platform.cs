using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGame
{
	public class Platform
	{
		private Vector2 _platformPosition;
		private Vector2 _platformSize;
		private Texture2D _platformTexture;

		public Platform (Vector2 pos, Vector2 size) 
		{
			_platformPosition = pos;
			_platformSize = size;
			_platformTexture = TextureManager.Platform;
		}

        public bool IsInViewport(int offset)
        {
            return (
                BoundingBox.Bottom + offset > 0 && 
                BoundingBox.Top + offset < ScreenManager.Dimensions.Y
            );
        }

		public static float calculateDistance(List<Platform> _platforms, Random rnd)
		{
			float _distance;
			if (_platforms.Count > 0)
			{
				Rectangle highestPlatform = _platforms[_platforms.Count - 1].BoundingBox;

				if (highestPlatform.Left > ScreenManager.Dimensions.X / 2)
				{
					// highestPlatform is right from center
					_distance = highestPlatform.Left - highestPlatform.Width - rnd.Next(150, 300);
					if (_distance < JumpScreen.Padding)
					{
						_distance = JumpScreen.Padding;
					}
				}
				else
				{
					// highestPlatform is left from center
					_distance = highestPlatform.Left + highestPlatform.Width + rnd.Next(100, 250);
                    if (_distance + highestPlatform.Width > ScreenManager.Dimensions.X - JumpScreen.Padding)
					{
                        _distance = ScreenManager.Dimensions.X - JumpScreen.Padding - highestPlatform.Width;
					}
				}
			}
			else
			{
				_distance = 400;
			}
			return _distance;
		}


		public Rectangle BoundingBox {
			get {
				Rectangle rect = new Rectangle ((int)_platformPosition.X, (int)_platformPosition.Y, (int)_platformTexture.Width, (int)_platformTexture.Height);
				return rect;
			}
		}

		public void Update(GameTime gameTime, int offset)
		{

		}

		public void Draw(SpriteBatch spriteBatch, int offset)
		{
			spriteBatch.Draw(_platformTexture, new Vector2 (_platformPosition.X, _platformPosition.Y + offset), Color.Green);
		}
	}
}
