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
			_frog = new Frog (new Vector2((ScreenManager.Instance.Dimensions.X / 2) - (TextureManager.Instance.Frog.Width / 2), ScreenManager.Instance.Dimensions.Y - TextureManager.Instance.Frog.Height), 5);	
		}

		public Rectangle getRectangle () {
			return _frog.boundingBox;
		}

		public Vector2 getSpeed(){
			return _frog.getSpeed;
		}

		public void jump () {
			_frog.jump ();
		}

		public void Update(){

			KeyboardState keyboardState = Keyboard.GetState ();

			_frog.Update ();

			if (keyboardState.IsKeyDown (Keys.Left)) {

				_frog.left ();

			}
			if (keyboardState.IsKeyDown (Keys.Right)) {

				_frog.right ();
			}


		}

		public void Draw (SpriteBatch spriteBatch, int offset) {
			_frog.Draw (spriteBatch, offset);
		}
	}
}

