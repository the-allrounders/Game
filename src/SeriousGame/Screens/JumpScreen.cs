using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGame
{
    class JumpScreen : GameScreen
    {
        int offset = 0;
        const int gameHeight = 10000;
		private List<Platform> _platforms = new List<Platform>();
        private List<Obstacle> _obstacles = new List<Obstacle>();
        
        public override void Load()
        {
            // START THE JUMPING
			addPlatforms ();
            addObstacle();
        }

        public override void Unload()
        {
            // END THE JUMPING
        }

		public void addPlatforms ()
        {
            Random rnd = new Random();
            for (int i = 600; i > gameHeight * -1; i -= 200)
            {
                _platforms.Add(new Platform(new Vector2(Platform.calculateDistance(_platforms, rnd), i + rnd.Next(-30, 30)), new Vector2(150, 50)));
            }
		}

        public void addObstacle()
        {
            Random rnd = new Random();
            int question = 0;
            for (int i = 600; i > gameHeight * -1; i -= 1000)
            {
                question++;
                _obstacles.Add(new Obstacle(Color.Red, new Vector2(50, i), new Vector2(400, 50), question));
            }
        }

        public override void Update(GameTime gameTime)
        {
            offset += 1;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
			foreach (var platform in _platforms) {
                if (platform.boundingBox.Bottom + offset > 0 && platform.boundingBox.Top + offset < ScreenManager.Instance.Dimensions.Y)
                {
                    platform.Draw(spriteBatch, offset);
                }
			}
            foreach (var obstacle in _obstacles)
            {
                if (obstacle.boundingBox.Bottom + offset > 0 && obstacle.boundingBox.Top + offset < ScreenManager.Instance.Dimensions.Y)
                {
                    obstacle.Draw(spriteBatch, offset);
                }
            }
        }
    }
}
