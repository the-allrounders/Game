using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SeriousGame.Managers;
using SeriousGame.Objects;

namespace SeriousGame.Screens
{
    class JumpScreen : GameScreen
    {
        private int offset;
        public static int GameHeight;
        private readonly List<Wall> walls = Wall.GenerateList();
        private readonly List<Platform> platforms = Platform.GenerateList();
        private readonly List<Obstacle> obstacles = Obstacle.GenerateList();
        private readonly List<Collectable> collectables = Fly.GenerateList();
        private readonly Frog frog = new Frog(new Vector2((ScreenManager.Dimensions.X / 2) - (TextureManager.FrogLeft.Width / 2), ScreenManager.Dimensions.Y - TextureManager.FrogLeft.Height), 5);
        private readonly Magma magma = new Magma(new Vector2(0, ScreenManager.Dimensions.Y));
        private Obstacle touchingObstacle = null;
        private bool gameEnded;
        private Scoreboard scoreboard;

        private bool wrong = false;
        private bool good = false;
        private int waitTime;

        private int score;

        public static int Padding = 200;

        public override void Load()
        {
            SongManager.Play(Songs.SuperMarioHipHop);
        }

        public override void Update(GameTime gameTime)
        {
            #region Shortcuts

            // If user is pressing ESC, return to StartScreen
            if (InputManager.IsPressing(Keys.Escape))
            {
                ScreenManager.CurrentScreen = new StartScreen();
            }

            #endregion

            #region Question screen

            // Show questionscreen if touching obstacle
            if (touchingObstacle != null)
            {
                touchingObstacle.OpenQuestion();
                int answer = 0;
                if (InputManager.IsPressing(Keys.D1) || InputManager.IsPressing(Keys.NumPad1))
                {
                    answer = 1;
                }
                else if (InputManager.IsPressing(Keys.D2) || InputManager.IsPressing(Keys.NumPad2))
                {
                    answer = 2;
                }
                else if (InputManager.IsPressing(Keys.D3) || InputManager.IsPressing(Keys.NumPad3))
                {
                    answer = 3;
                }
                else if (InputManager.IsPressing(Keys.D4) || InputManager.IsPressing(Keys.NumPad4))
                {
                    answer = 4;
                }

                if (answer != 0)
                {
                    bool right = touchingObstacle.CheckAnswer(answer);
                    touchingObstacle.FinishedQuestion();
                    if (right)
                    {
                        score += 1000;
                        good = true;
                    }
                    else
                    {
                        score -= 1000;
                        wrong = true;
                    }
                    touchingObstacle = null;
                    waitTime = gameTime.TotalGameTime.Seconds;
                    frog.Jump();
                }
            }

            // Set wrong and good to false after 3 seconds
            if ((wrong || good) && gameTime.TotalGameTime.Seconds >= waitTime + 3)
            {
                wrong = false;
                good = false;
            }

            #endregion


            if (!gameEnded && touchingObstacle == null)
            {
                #region Game actively running

                // Check if Frog touches obstacle
                foreach (
                    Obstacle obstacle in
                        obstacles.Where(
                            obstacle =>
                                obstacle.IsInViewport(offset) && frog.IsJumpingOnObstacle(obstacle) && !obstacle.IsDone()))
                {
                    touchingObstacle = obstacle;
                }

                // If user is pressing Left, go left. Same for Right.
                if (InputManager.IsPressing(Keys.Left, false) || InputManager.IsPressing(Keys.A, false))
                    frog.Left();
                else if (InputManager.IsPressing(Keys.Right, false) || InputManager.IsPressing(Keys.D, false))
                    frog.Right();


                // Check if jumping on platform
                if (platforms.Any(platform => platform.IsInViewport(offset) && frog.IsJumpingOn(platform)))
                {
                    frog.Jump();
                    SoundManager.Play(Sounds.Jump);
                }

                // Check if frog is catching any collectables
                foreach (Collectable collectable in collectables.Where(collectable => !collectable.IsDone && collectable.IsInViewport(offset)))
                {
                    collectable.Update(gameTime, offset);
                    if (collectable.IsCatching(frog))
                    {
                        score += collectable.CollectableScoreWorth;
                        SoundManager.Play(Sounds.Coin);
                        collectable.IsDone = true;
                    }
                }

                // Apply gravity to Frog
                frog.ApplyGravity(gameTime);

                // Make the magma rise
                magma.Rise(offset);

                //Check if frog is touching Magma
                if (frog.BoundingBox.Top + offset - ScreenManager.Dimensions.Y > 0 ||
                    magma.IsTouchingFrog(frog))
                {
                    frog.Die();
                    gameEnded = true;
                    SoundManager.Play(Sounds.Death);
                    SongManager.Stop();
                    scoreboard = new Scoreboard(score, frog.IsDead);
                }

                // Calculate new offset
                int newOffset = (int)ScreenManager.Dimensions.Y - frog.BoundingBox.Bottom - 500;

                // If new offset is bigger, apply
                if (newOffset > offset)
                {
                    decimal addPoints = (newOffset - offset) / 10;
                    score += (int)Math.Ceiling(addPoints);
                    offset = newOffset;
                }

                // Check if game is won
                if (offset > GameHeight + 400)
                {
                    gameEnded = true;
                    scoreboard = new Scoreboard(score, frog.IsDead);
                }

                #endregion
            }

            #region Scoreboard
            if (gameEnded)
            {
                scoreboard.Update(frog, gameTime);
            }
            #endregion

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            // Draw platforms
            foreach (Platform platform in platforms.Where(platform => platform.IsInViewport(offset)))
            {
                platform.Draw(spriteBatch, offset);
            }

            // Draw collectables
            foreach (Collectable collectable in collectables.Where(collectable => collectable.IsInViewport(offset) && !collectable.IsDone))
            {
                collectable.Draw(spriteBatch, offset);
            }

            // Draw frog
            frog.Draw(spriteBatch, offset);

            // Draw magma
            magma.Draw(spriteBatch, offset);

            // Show feedback
            if (wrong)
                spriteBatch.Draw(TextureManager.Wrong, new Vector2(400, 300));
            else if (good)
                spriteBatch.Draw(TextureManager.Good, new Vector2(400, 300));

            // Draw obstacles
            foreach (
                Obstacle obstacle in obstacles.Where(obstacle => obstacle.IsInViewport(offset) && !obstacle.IsDone()))
            {
                obstacle.Draw(spriteBatch, offset);
                if (frog.IsJumpingOnObstacle(obstacle))
                    obstacle.DrawQuestion(spriteBatch);
            }

            // Draw walls
            foreach (Wall wall in walls.Where(wall => wall.IsInViewport(offset)))
            {
                wall.Draw(spriteBatch, offset);
            }

            // Draw scorescreen of frog is dead
            if (gameEnded)
            {
                scoreboard.Draw(spriteBatch, offset, frog.PlayerName);
            }

            // If the frog is alive, draw the score
            else
            {
                string text = "Score: " + score;
                spriteBatch.DrawString(FontManager.Verdana, text, new Vector2(ScreenManager.Dimensions.X - 200, 20),
                    Color.White);
            }
        }
    }
}
