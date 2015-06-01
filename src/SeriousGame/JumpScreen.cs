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
        
        public override void Load()
        {
            // START THE JUMPING
			addPlatforms ();
        }

        public override void Unload()
        {
            // END THE JUMPING
        }

        public float calculateDistance ()
        {
            float _distance;
            Console.WriteLine(_platforms.Count);
            if (_platforms.Count > 0)
            {
                Rectangle highestPlatform = _platforms[_platforms.Count - 1].boundingBox;
                if (highestPlatform.Left > ScreenManager.Instance.Dimensions.X / 2)
                {
                    // highestPlatform is right from center
                    _distance = highestPlatform.Left - highestPlatform.Width - 200;
                }
                else
                {
                    // highestPlatform is left from center
                    _distance = highestPlatform.Left + highestPlatform.Width + 200;
                }
            }
            else
            {
                _distance = ScreenManager.Instance.Dimensions.X / 2;
            }
            Console.WriteLine(_distance);
            return _distance;
        }

		public void addPlatforms ()
        {
            for (int i = 100; i < gameHeight; i++)
            {
                _platforms.Add(new Platform(new Vector2(calculateDistance(), -50), new Vector2(150, 50));
            }
		}

        public override void Update(GameTime gameTime)
        {
            offset += 1;
			foreach (var platform in _platforms) {
                Console.WriteLine(platform.boundingBox.Top);
				if (platform.boundingBox.Top > ScreenManager.Instance.Dimensions.Y) {
					_platforms.RemoveAt(_platforms.IndexOf (platform));
                    addPlatform(new Vector2(calculateDistance(), offset + -50), new Vector2(50, 100));
                } 
				else {
					platform.Update (gameTime, offset);
				}
			}
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
			foreach (var platform in _platforms) {
				platform.Draw (spriteBatch, offset);
			}
        }
    }
}
