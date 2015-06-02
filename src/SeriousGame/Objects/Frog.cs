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
	public class Frog
	{
		private float 		_startY;
		private Vector2 	_speed;
		private Texture2D   _frogTexture;
		private Vector2     _frogPosition;
		private Vector2 	_speedlr;

		public Frog (Vector2 charPos, int spd)
		{
			_frogTexture = TextureManager.Frog;
			_frogPosition = charPos;
			_startY = _frogPosition.Y;
			_speed = new Vector2(0, spd);
			_speedlr = new Vector2 (10, 0);
		}

		public void jump(){
			_startY = _frogPosition.Y;
			_speed.Y *= -1;
		}


		public Rectangle boundingBox {
			get {
				Rectangle rect = new Rectangle ((int)_frogPosition.X, (int)_frogPosition.Y, (int)_frogTexture.Width, (int)_frogTexture.Height);
				return rect;
			}
		}

		public Vector2 getSpeed {
			get {
				return _speed;
			}
		}

		public void Update()
		{
			_frogPosition.Y -= _speed.Y;
			if (_frogPosition.Y < _startY - 300) {
				_speed.Y *= -1;
			}
		}

		public void left(){

			if (_frogPosition.X > ScreenManager.leftBound) {
				_frogPosition -= _speedlr;
			}

		}

		public void right() 
		{
			if (_frogPosition.X + _frogTexture.Width < ScreenManager.rightBound) {
				_frogPosition += _speedlr;

			}

		}

		public void Draw(SpriteBatch spriteBatch, int offset)
		{
			spriteBatch.Draw (_frogTexture, new Vector2 (_frogPosition.X, _frogPosition.Y + offset));

		}



	}
}
