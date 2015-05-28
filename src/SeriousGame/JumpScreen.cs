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
		private List<Platform> _platforms = new List<Platform>();
        
        public override void Load()
        {
            // START THE JUMPING
			addPlatform (new Vector2 (0, 0), new Vector2 (10, 100));
        }

        public override void Unload()
        {
            // END THE JUMPING
        }

		public void addPlatform (Vector2 pos, Vector2 size) {
			_platforms.Add (new Platform (pos, size));
			Console.WriteLine ("add platform!");
		}

        public override void Update(GameTime gameTime)
        {
            offset += 1;
			foreach (var platform in _platforms) {
				if (platform.boundingBox.Top > ScreenManager.Instance.Dimensions.Y) {
					_platforms.RemoveAt(_platforms.IndexOf (platform));
					addPlatform (new Vector2 (offset, 0), new Vector2 (200, 50));
				} 
				else {
					platform.Update (gameTime, offset);
				}
			}
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(TextureManager.Instance.Fly, new Vector2(0, 0 + offset));
            spriteBatch.Draw(TextureManager.Instance.Fly, new Vector2(1050, 650 + offset));
			foreach (var platform in _platforms) {
				platform.Draw (spriteBatch, offset);
			}
        }
    }
}
