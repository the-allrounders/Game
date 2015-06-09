using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SeriousGame.Managers;
using SeriousGame.Screens;

namespace SeriousGame.Objects
{
    public class Wall
    {
        private Vector2 wallPosition;
        private readonly Texture2D wallTexture;

        public Wall (Vector2 pos, Texture2D tex)
        {
            wallPosition = pos;
            wallTexture = tex;
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
                Rectangle rect = new Rectangle((int)wallPosition.X, (int)wallPosition.Y, wallTexture.Width, wallTexture.Height);
                return rect;
            }
        }

        public void Update(GameTime gameTime, int offset)
        {

        }

        public void Draw(SpriteBatch spriteBatch, int offset)
        {
            spriteBatch.Draw(wallTexture, new Vector2(wallPosition.X, wallPosition.Y + offset));
        }

        public static List<Wall> GenerateList()
        {
            List<Wall> walls = new List<Wall>();
            int i;
            int iterations = 0;
            for (i = 0; i > (JumpScreen.gameHeight - (int)ScreenManager.Dimensions.Y) * -1; i -= (int)ScreenManager.Dimensions.Y)
            {
                walls.Add(new Wall(new Vector2(0, i), TextureManager.WallLeft));
                walls.Add(new Wall(new Vector2(ScreenManager.Dimensions.X-TextureManager.WallRight.Width, i), TextureManager.WallRight));
                iterations++;
            }
            Console.WriteLine(iterations);
            walls.Add(new Wall(new Vector2(0, i), TextureManager.LastWallLeft));
            walls.Add(new Wall(new Vector2(ScreenManager.Dimensions.X - TextureManager.LastWallRight.Width, i), TextureManager.WallRight));
            JumpScreen.gameHeight = iterations * TextureManager.WallRight.Height;
            Console.WriteLine(JumpScreen.gameHeight);
            return walls;
        }
    }
}
