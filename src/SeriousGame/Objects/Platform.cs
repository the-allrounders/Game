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
			spriteBatch.Draw(_platformTexture, new Vector2 (_platformPosition.X, _platformPosition.Y + offset));
		}
	}
}
