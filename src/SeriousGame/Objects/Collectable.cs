using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SeriousGame.Managers;

namespace SeriousGame.Objects
{
    class Collectable
    {
        private Vector2 collectablePosition;
        protected Texture2D CollectableTexture;
        public int CollectableScoreWorth { get; protected set; }

        public Collectable(Vector2 pos, Texture2D txtur, int scrWrth)
        {
            collectablePosition = pos;
            CollectableTexture = txtur;
            CollectableScoreWorth = scrWrth;
        }

        public Rectangle BoundingBox
        {
            get
            {
                Rectangle rect = new Rectangle((int)collectablePosition.X, (int)collectablePosition.Y, CollectableTexture.Width, CollectableTexture.Height);
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
            spriteBatch.Draw(CollectableTexture, new Vector2(collectablePosition.X, collectablePosition.Y + offset));
        }
    }
}
