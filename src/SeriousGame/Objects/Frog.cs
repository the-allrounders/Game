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
        private Texture2D _frogTexture;
        private Vector2 _frogPosition;
        private Vector2 _speedlr;
        public bool isDescending { get; private set; }
        public int gameScore { get; private set; }
        public bool isDead { get; private set; }
        public String playerName { get; private set; }

        public Frog (Vector2 charPos, int spd)
		{
			_frogTexture = TextureManager.Frog;
			_frogPosition = charPos;
			_speedlr = new Vector2 (10, 0);
            playerName = "<name>";
            isDead = false;
            Jump();
		}

        public void addScore (int scrWrth)
        {
            gameScore += scrWrth;
        }

        public void makeDead ()
        {
            isDead = true;
        }

        public void addCharToName (Keys key)
        {
            if (playerName.Length < 12)
                playerName += key;
        }

        public void removeCharFromName ()
        {
            if (playerName.Length > 0)
                playerName = playerName.Remove(playerName.Length - 1);
        }

		public Rectangle BoundingBox {
			get {
				return new Rectangle ((int)_frogPosition.X, (int)_frogPosition.Y, (int)_frogTexture.Width, (int)_frogTexture.Height);
			}
		}

        public bool isJumpingOnObstacle(Obstacle obstacle)
        {
            return isDescending == false && BoundingBox.Intersects(obstacle.BoundingBox);
        }

        /// <summary>
        /// Checks if the frog is currently jumping on a platform
        /// </summary>
        /// <param name="platform">The platform the frog is possibily jumping on</param>
        /// <returns>True if the frog is jumping on the platform</returns>
        public bool IsJumpingOn(Platform platform)
        {
            return isDescending && BoundingBox.Intersects(platform.BoundingBox) && BoundingBox.Bottom <= platform.BoundingBox.Top + 30;
        }

        float jumpFrom = 0;
        double initialVelocity;
        double time = 0;
        double gravity = 3000;

        /// <summary>
        /// Resets the gravity to default values
        /// </summary>
        public void Jump()
        {
            initialVelocity = -1640;
            time = 0;
            jumpFrom = _frogPosition.Y;
        }
        
        /// <summary>
        /// Needs to be run once every update cycle
        /// </summary>
        /// <param name="gameTime">The gameTime from the Game</param>
		public void ApplyGravity(GameTime gameTime)
		{
            // Update t variable with new time
            time = time + gameTime.ElapsedGameTime.TotalSeconds;

            // Calculate new position
            float newPosition = (float)(initialVelocity * time + gravity * time * time / 2) + jumpFrom;

            // Check if is descending
            isDescending = (_frogPosition.Y < newPosition);

            // Apply new position
            _frogPosition.Y = newPosition;
		}

        /// <summary>
        /// Moves the frog to the left
        /// </summary>
		public void Left(){
			if (_frogPosition.X > JumpScreen.Padding) {
				_frogPosition -= _speedlr;
			}
		}

        /// <summary>
        /// Moves the frog to the right
        /// </summary>
		public void Right() 
		{
            if (_frogPosition.X + _frogTexture.Width < ScreenManager.Dimensions.X - JumpScreen.Padding)
            {
				_frogPosition += _speedlr;
			}
		}

		public void Draw(SpriteBatch spriteBatch, int offset)
		{
			spriteBatch.Draw(_frogTexture, new Vector2 (_frogPosition.X, _frogPosition.Y + offset));
		}
	}
}
