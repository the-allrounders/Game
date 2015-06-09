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
        private Vector2 _platformPosition;
        private Vector2 _platformSize;
        private Texture2D _platformTexture;

        public Platform(Vector2 pos, Vector2 size)
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

        public Rectangle BoundingBox
        {
            get
            {
                Rectangle rect = new Rectangle((int)_platformPosition.X, (int)_platformPosition.Y, _platformTexture.Width, _platformTexture.Height);
                return rect;
            }
        }

        public void Update(GameTime gameTime, int offset)
        {

        }

        public void Draw(SpriteBatch spriteBatch, int offset)
        {
            spriteBatch.Draw(_platformTexture, new Vector2(_platformPosition.X, _platformPosition.Y + offset));
        }

        public static List<Platform> generateList(int gameHeight)
        {
            Random rnd = new Random();
            List<Platform> platforms = new List<Platform>();
            for (int i = 600; i > gameHeight * -1; i -= 200)
            {
                platforms.Add(new Platform(new Vector2(rnd.Next(JumpScreen.Padding, (int)ScreenManager.Dimensions.X - JumpScreen.Padding - TextureManager.Platform.Width), i + rnd.Next(-30, 30)), new Vector2(150, 50)));
            }
            return platforms;
        }
    }
}
