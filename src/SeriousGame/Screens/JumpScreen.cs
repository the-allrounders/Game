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
        int offset = 0;
        const int gameHeight = 100000;
		private List<Platform> _platforms = new List<Platform>();
        private List<Obstacle> _obstacles = new List<Obstacle>();
		private Player _player;
        
        public override void Load()
        {
            // START THE JUMPING
			addPlatforms ();
            addObstacle();
			_player = new Player ();
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

		public void intersectPlatform()
		{
			Rectangle frogPosition = _player.getRectangle ();
			foreach (var platform in _platforms) {
				if (platform.boundingBox.Bottom + offset > 0 && platform.boundingBox.Top + offset < ScreenManager.Dimensions.Y)
				{
					Console.WriteLine (_player.getSpeed().Y);
					if(_player.getSpeed().Y < 0 && frogPosition.Intersects(platform.boundingBox) && frogPosition.Bottom >= platform.boundingBox.Top) {
						Console.WriteLine ("geraakt");
						_player.jump ();
					}
				}
			}
		}

        public override void Update(GameTime gameTime)
        {
            if (InputManager.IsPressing(Keys.Escape))
            {
                ScreenManager.CurrentScreen = new StartScreen();
            }
            Rectangle frogPosition = _player.getRectangle();
			int newOffset = (int)ScreenManager.Dimensions.Y - frogPosition.Bottom - 500;
			if (newOffset > offset)
				offset = newOffset;
			_player.Update ();
			intersectPlatform ();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
			foreach (var platform in _platforms) {
                if (platform.boundingBox.Bottom + offset > 0 && platform.boundingBox.Top + offset < ScreenManager.Dimensions.Y)
                {
                    platform.Draw(spriteBatch, offset);
                }
			}
            foreach (var obstacle in _obstacles)
            {
                if (obstacle.boundingBox.Bottom + offset > 0 && obstacle.boundingBox.Top + offset < ScreenManager.Dimensions.Y)
                {
                    obstacle.Draw(spriteBatch, offset);
                }
            }
			_player.Draw (spriteBatch, offset);
        }
    }
}
