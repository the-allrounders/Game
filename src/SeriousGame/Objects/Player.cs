using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System;

namespace SeriousGame
{
	public class Player
	{
		public Frog Frog {private set; get;}

		public Player ()
		{
			Frog = new Frog (new Vector2((ScreenManager.Dimensions.X / 2) - (TextureManager.Frog.Width / 2), ScreenManager.Dimensions.Y - TextureManager.Frog.Height), 5);	
		}

        /// <summary>
        /// Checks if the player is currently jumping on a platform
        /// </summary>
        /// <param name="platform">The platform the player is possibily jumping on</param>
        /// <returns>If the player is jumping on the platform</returns>
        public bool IsJumpingOn(Platform platform)
        {
            return (
                Frog.isDescending && Frog.BoundingBox.Intersects(platform.BoundingBox) && Frog.BoundingBox.Bottom <= platform.BoundingBox.Top + 30
                );
        }

		public void Update(GameTime gameTime){

            if (InputManager.IsPressing(Keys.Left, false))
            {

				Frog.Left ();

			}
            if (InputManager.IsPressing(Keys.Right, false))
            {

				Frog.Right ();
			}


		}
	}
}

