using System;
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
        public bool IsDone;
        private int height;
        private int width;
        private int frames;
        private int currentFrame = 1;
        private int animationSpeed;
        private int animationCounter;
        private bool revert = false;

        public Collectable(Vector2 pos, Texture2D txtur, int scrWrth, int wdth, int hght, int frms, int nmtnSpd)
        {
            collectablePosition = pos;
            CollectableTexture = txtur;
            CollectableScoreWorth = scrWrth;
            IsDone = false;
            height = hght;
            width = wdth;
            frames = frms;
            animationSpeed = nmtnSpd;
        }

        public Rectangle BoundingBox
        {
            get
            {
                Rectangle rect = new Rectangle((int)collectablePosition.X, (int)collectablePosition.Y, width, height);
                return rect;
            }
        }

        private Rectangle currentRectangle
        {
            get
            {
                return new Rectangle(
                    ((width+2) * currentFrame) - width,
                    0,
                    width,
                    height
                    );
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
            animationCounter++;
            Random rnd = new Random();
            if (animationCounter % animationSpeed == 0)
            {
                // Ga telkens een frame verder
                if (revert)
                {
                    currentFrame--;
                    //collectablePosition.X -= 3;
                    //collectablePosition.Y -= 3;
                }
                else
                {
                    currentFrame++;
                    //collectablePosition.X += 3;
                    //collectablePosition.Y += 3;
                }
                collectablePosition.X += rnd.Next(-4, 4);
                collectablePosition.Y += rnd.Next(-4, 4);
            }

            // Als laatste frame in de animatie bereikt is
            if (currentFrame == frames)
            {
                revert = true;
            }
            else if (currentFrame == 1)
            {
                revert = false;
            }
        }

        public void Draw(SpriteBatch spriteBatch, int offset)
        {
            spriteBatch.Draw(
                CollectableTexture,
                new Vector2(collectablePosition.X, collectablePosition.Y + offset),
                currentRectangle,
                Color.White,
                0,
                new Vector2(0, 0),
                1,
                SpriteEffects.None,
                0);
        }
    }
}
