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
        public int collectableScoreWorth { get; protected set; }

        public Collectable(Vector2 pos, Texture2D txtur, int scrWrth)
        {
            _collectablePosition = pos;
            _collectableTexture = txtur;
            collectableScoreWorth = scrWrth;
        }

        public Rectangle BoundingBox
        {
            get
            {
                Rectangle rect = new Rectangle((int)_collectablePosition.X, (int)_collectablePosition.Y, (int)_collectableTexture.Width, (int)_collectableTexture.Height);
                return rect;
            }
        }

        public bool IsCatching(Frog frog)
        {
            return frog.BoundingBox.Intersects(BoundingBox);
        }

        public bool IsInViewport(int offset)
        {
            return (
                BoundingBox.Bottom + offset > 0 &&
                BoundingBox.Top + offset < ScreenManager.Dimensions.Y
            );
        }

        public void Update(GameTime gameTime, int offset)
        {

        }

        public void Draw(SpriteBatch spriteBatch, int offset)
        {
            spriteBatch.Draw(_collectableTexture, new Vector2(_collectablePosition.X, _collectablePosition.Y + offset));
        }
    }
}
