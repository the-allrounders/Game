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
		private Frog _frog;

		public Player ()
		{
			_frog = new Frog (new Vector2((ScreenManager.Dimensions.X / 2) - (TextureManager.Frog.Width / 2), ScreenManager.Dimensions.Y - TextureManager.Frog.Height), 5);	
		}

		public Rectangle getFrogBoundingBox() {
			return _frog.boundingBox;
		}

		public Vector2 getSpeed(){
			return _frog.getSpeed;
		}

		public void jump () {
			_frog.jump ();
		}

		public void Update(){

			_frog.Update ();

            if (InputManager.IsPressing(Keys.Left, false))
            {

				_frog.left ();

			}
            if (InputManager.IsPressing(Keys.Right, false))
            {

				_frog.right ();
			}


		}

		public void Draw (SpriteBatch spriteBatch, int offset) {
			_frog.Draw (spriteBatch, offset);
		}
	}
}

