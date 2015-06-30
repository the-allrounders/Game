using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Frogano.Managers;
using Frogano.Screens;

namespace Frogano.Objects
{
    public class Frog
    {
        private Texture2D frogTexture;
        private Vector2 frogPosition;
        private readonly Vector2 speedlr;
        public bool IsDescending { get; private set; }

        public int Lives
        {
            get { return lives; }
            set { if(value <= 4 - SettingsManager.Difficulty) lives = value; }
        }

        public bool StealthMode;
        public double TimeOfStealthMode;
        public bool IsVisible = true;
        private SpriteEffects spriteEffect = SpriteEffects.FlipHorizontally;

        public bool IsDead { get; private set; }
        public string PlayerName { get; private set; }

        public Frog(Vector2 charPos, int spd)
        {
            frogTexture = TextureManager.Frog[SettingsManager.FrogType];
            frogPosition = charPos;
            speedlr = new Vector2(10, 0);
            PlayerName = "<naam>";
            Lives = 4 - SettingsManager.Difficulty;
            Jump();
        }

        public void Die()
        {
            IsDead = true;
        }

        public void AddCharToName(Keys key)
        {
            if (PlayerName == "<naam>")
                PlayerName = "";
            if (PlayerName.Length < 11)
            {
                if (key == Keys.Space)
                    PlayerName += " ";
                else
                    PlayerName += key;
            }
        }

        public void RemoveCharFromName()
        {
            if (PlayerName == "<naam>")
                return;
            if (PlayerName.Length > 0)
                PlayerName = PlayerName.Remove(PlayerName.Length - 1);
            if (PlayerName.Length == 0)
                PlayerName = "<naam>";
        }

        public Rectangle BoundingBox
        {
            get
            {
                return new Rectangle((int)frogPosition.X, (int)frogPosition.Y, frogTexture.Width, frogTexture.Height);
            }
        }

        public bool IsJumpingOnObstacle(Obstacle obstacle)
        {
            return IsDescending == false && BoundingBox.Intersects(obstacle.BoundingBox);
        }

        /// <summary>
        /// Checks if the frog is currently jumping on a platform
        /// </summary>
        /// <param name="platform">The platform the frog is possibily jumping on</param>
        /// <returns>True if the frog is jumping on the platform</returns>

        public bool IsJumpingOn(Platform platform)
        {
            return IsDescending && BoundingBox.Intersects(platform.BoundingBox) && BoundingBox.Bottom <= platform.BoundingBox.Top + 30;
        }

        float jumpFrom;
        double initialVelocity;
        double time;
        readonly double gravity = 3000;
        private int lives;

        /// <summary>
        /// Resets the gravity to default values
        /// </summary>
        public void Jump()
        {
            initialVelocity = -1640;
            time = 0;
            jumpFrom = frogPosition.Y;
        }

        /// <summary>
        /// Needs to be run once every update cycle
        /// </summary>
        /// <param name="gameTime">The gameTime from the Game</param>
        public void ApplyGravity(GameTime gameTime)
        {
            // Update t variable with new time
            time += gameTime.ElapsedGameTime.TotalSeconds;

            // Calculate new position
            float newPosition = (float)(initialVelocity * time + gravity * time * time / 2) + jumpFrom;

            // Check if is descending
            IsDescending = (frogPosition.Y < newPosition);

            // Apply new position
            frogPosition.Y = newPosition;
        }

        /// <summary>
        /// Moves the frog to the left
        /// </summary>
        public void Left()
        {
            if (frogPosition.X > JumpScreen.Padding)
                frogPosition -= speedlr;
            spriteEffect = SpriteEffects.FlipHorizontally;
        }

        /// <summary>
        /// Moves the frog to the right
        /// </summary>
        public void Right()
        {
            if (frogPosition.X + frogTexture.Width < ScreenManager.Dimensions.X - JumpScreen.Padding)
                frogPosition += speedlr;
            spriteEffect = SpriteEffects.None;
        }

        public void Draw(SpriteBatch spriteBatch, int offset)
        {
            float frogOpacity = 1;
            if (!IsVisible)
                frogOpacity = 0.2f;
            spriteBatch.Draw(frogTexture, new Vector2(frogPosition.X, frogPosition.Y + offset), color: Color.White * frogOpacity, effects: spriteEffect);
        }
    }
}
