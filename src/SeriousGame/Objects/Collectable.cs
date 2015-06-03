using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGame
{
    class Collectable
    {
        private Vector2 _collectablePosition;
        protected Texture2D _collectableTexture;

        public Collectable (Vector2 pos)
        {
            _collectablePosition = pos;
        }

        public Rectangle boundingBox
        {
            get
            {
                Rectangle rect = new Rectangle((int)_collectablePosition.X, (int)_collectablePosition.Y, (int)_collectableTexture.Width, (int)_collectableTexture.Height);
                return rect;
            }
        }

        public void Update(GameTime gameTime, int offset)
        {

        }

        public void Draw(SpriteBatch spriteBatch, int offset)
        {
            spriteBatch.Draw(_collectableTexture, new Vector2(_collectablePosition.X, _collectablePosition.Y + offset), Color.Green);
        }
    }
}
