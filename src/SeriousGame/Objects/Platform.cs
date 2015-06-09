using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SeriousGame.Managers;
using SeriousGame.Screens;

namespace SeriousGame.Objects
{
    public class Platform
    {
        private Vector2 platformPosition;
        private Vector2 platformSize;
        private readonly Texture2D platformTexture;

        public Platform(Vector2 pos, Vector2 size)
        {
            platformPosition = pos;
            platformSize = size;
            platformTexture = TextureManager.Platform;
        }

        public bool IsInViewport(int offset)
        {
            return (
                BoundingBox.Bottom + offset > 0 &&
                BoundingBox.Top + offset < ScreenManager.Dimensions.Y
            );
        }

        public Rectangle BoundingBox
        {
            get
            {
                Rectangle rect = new Rectangle((int)platformPosition.X, (int)platformPosition.Y, platformTexture.Width, platformTexture.Height);
                return rect;
            }
        }

        public void Update(GameTime gameTime, int offset)
        {

        }

        public void Draw(SpriteBatch spriteBatch, int offset)
        {
            spriteBatch.Draw(platformTexture, new Vector2(platformPosition.X, platformPosition.Y + offset));
        }

        public static List<Platform> GenerateList()
        {
            Random rnd = new Random();
            List<Platform> platforms = new List<Platform>();
            for (int i = 600; i > JumpScreen.gameHeight * -1; i -= 200)
            {
                platforms.Add(new Platform(new Vector2(rnd.Next(JumpScreen.Padding, (int)ScreenManager.Dimensions.X - JumpScreen.Padding - TextureManager.Platform.Width), i + rnd.Next(-30, 30)), new Vector2(150, 50)));
            }
            return platforms;
        }
    }
}
