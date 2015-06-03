using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGame
{
    class JumpScreen : GameScreen
    {
        private int offset = 0;
        private int gameHeight = 100000;
		private List<Platform> platforms = new List<Platform>();
        private List<Obstacle> obstacles = new List<Obstacle>();
		private Player player;

        public static int Padding = 200;
        
        public override void Load()
        {
			addPlatforms ();
            addObstacles();
			player = new Player ();
        }

		private void addPlatforms ()
        {
            Random rnd = new Random();
            for (int i = 600; i > gameHeight * -1; i -= 200)
            {
                platforms.Add(new Platform(new Vector2(Platform.calculateDistance(platforms, rnd), i + rnd.Next(-30, 30)), new Vector2(150, 50)));
            }
		}

        private void addObstacles()
        {
            int question = 0;
            for (int i = 600; i > gameHeight * -1; i -= 1000)
            {
                question++;
                obstacles.Add(new Obstacle(Color.Red, new Vector2(50, i), new Vector2(400, 50), question));
            }
        }

        public override void Update(GameTime gameTime)
        {
            // If user is pressing ESC, return to StartScreen
            if (InputManager.IsPressing(Keys.Escape))
            {
                ScreenManager.CurrentScreen = new StartScreen();
            }

            // Update the player
            player.Update();

            // Calculate new offset
            int newOffset = (int)ScreenManager.Dimensions.Y - player.Frog.BoundingBox.Bottom - 500;

            // If new offset is bigger, apply
			if (newOffset > offset) offset = newOffset;

            // Check if jumping on platform
            foreach (Platform platform in platforms)
            {
                if (platform.IsInViewport(offset) && player.IsJumpingOn(platform))
                {
                    player.Frog.jump();
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
			// Draw platforms
            foreach (Platform platform in platforms) {
                if (platform.IsInViewport(offset))
                {
                    platform.Draw(spriteBatch, offset);
                }
			}

            // Draw obstacles
            foreach (Obstacle obstacle in obstacles)
            {
                if (obstacle.IsInViewport(offset))
                {
                    obstacle.Draw(spriteBatch, offset);
                }
            }

            // Draw frog
			player.Frog.Draw(spriteBatch, offset);
        }
    }
}
