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
		private Texture2D   _frogTexture;
		private Vector2     _frogPosition;
		private Vector2 	_speedlr;
        public bool isDescending { get; private set; }

		public Frog (Vector2 charPos, int spd)
		{
			_frogTexture = TextureManager.Frog;
			_frogPosition = charPos;
			_speedlr = new Vector2 (10, 0);
            Jump();
		}


		public Rectangle BoundingBox {
			get {
				Rectangle rect = new Rectangle ((int)_frogPosition.X, (int)_frogPosition.Y, (int)_frogTexture.Width, (int)_frogTexture.Height);
				return rect;
			}
		}

        float jumpFrom = 0;
        public double vi { get; private set; }
        double t = 0;
        double g = 720;

        public void Jump()
        {
            vi = -820;
            t = 0;
            jumpFrom = _frogPosition.Y;
        }

        

		public void Update(GameTime gameTime)
		{
            float oldJumpHeight = (float)(vi * t + g * t * t / 2);
            t = t + gameTime.ElapsedGameTime.TotalSeconds;
            float newJumpHeight = (float)(vi * t + g * t * t / 2);
            if (newJumpHeight >= oldJumpHeight)
            {
                isDescending = true;
            }
            else
            {
                isDescending = false;
            }
            _frogPosition.Y = newJumpHeight + jumpFrom;
		}

		public void Left(){

			if (_frogPosition.X > JumpScreen.Padding) {
				_frogPosition -= _speedlr;
			}

		}

		public void Right() 
		{
            if (_frogPosition.X + _frogTexture.Width < ScreenManager.Dimensions.X - JumpScreen.Padding)
            {
				_frogPosition += _speedlr;

			}

		}

		public void Draw(SpriteBatch spriteBatch, int offset)
		{
			spriteBatch.Draw (_frogTexture, new Vector2 (_frogPosition.X, _frogPosition.Y + offset));

		}



	}
}
