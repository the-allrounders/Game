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
        private readonly List<Fly> flies = Fly.GenerateList();
        private readonly Frog frog = new Frog(new Vector2((ScreenManager.Dimensions.X / 2) - (TextureManager.FrogLeft.Width / 2), ScreenManager.Dimensions.Y - TextureManager.FrogLeft.Height), 5);
        private readonly Magma magma = new Magma(new Vector2(0, ScreenManager.Dimensions.Y));
        private bool isFrozen;
        private bool gameEnded;
        private Scoreboard scoreboard;

        private int score;

        public static int Padding = 200;

        public override void Load()
        {
            SongManager.Play(Songs.SuperMarioHipHop);
        }

        public override void Update(GameTime gameTime)
        {
            // If user is pressing ESC, return to StartScreen
            if (InputManager.IsPressing(Keys.Escape))
            {
                ScreenManager.CurrentScreen = new StartScreen();
            }

            // Check if Frog touches obstacle
            foreach (Obstacle obstacle in obstacles.Where(obstacle => obstacle.IsInViewport(offset) && frog.IsJumpingOnObstacle(obstacle) && !obstacle.IsDone()))
            {
                isFrozen = true;
                obstacle.OpenQuestion();
                if (InputManager.IsPressing(Keys.D1) || InputManager.IsPressing(Keys.D2) ||
                    InputManager.IsPressing(Keys.D3) || InputManager.IsPressing(Keys.D4) ||
                    InputManager.IsPressing(Keys.NumPad1) || InputManager.IsPressing(Keys.NumPad2) ||
                    InputManager.IsPressing(Keys.NumPad3) || InputManager.IsPressing(Keys.NumPad4))
                {
                    bool answer = false;
                    if (InputManager.IsPressing(Keys.D1) || InputManager.IsPressing(Keys.NumPad1))
                    {
                        answer = obstacle.CheckAnswer(1);
                    }
                    else if(InputManager.IsPressing(Keys.D2) || InputManager.IsPressing(Keys.NumPad2))
                    {
                        answer = obstacle.CheckAnswer(2);
                    }
                    else if (InputManager.IsPressing(Keys.D3) || InputManager.IsPressing(Keys.NumPad3))
                    {
                        answer = obstacle.CheckAnswer(3);
                    }
                    else if (InputManager.IsPressing(Keys.D4) || InputManager.IsPressing(Keys.NumPad4))
                    {
                        answer = obstacle.CheckAnswer(4);
                    }
                    obstacle.FinishedQuestion();
                    CheckAnswer(answer);
                }
            }

            // If user is pressing Left, go left. Same for Right.
            if (!isFrozen && !gameEnded && (InputManager.IsPressing(Keys.Left, false) || !gameEnded && InputManager.IsPressing(Keys.A, false)))
            {
                frog.Left();
            }
            if (!isFrozen && (!gameEnded && InputManager.IsPressing(Keys.Right, false) || !gameEnded && InputManager.IsPressing(Keys.D, false)))
            {
                frog.Right();
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

            // Check if jumping on platform
            if (platforms.Any(platform => platform.IsInViewport(offset) && frog.IsJumpingOn(platform)))
            {
                frog.Jump();
            }

            // Check if frog is catching any flies
            foreach (Fly fly in flies.Where(fly => fly.IsInViewport(offset) && fly.IsCatching(frog)))
            {
                score += fly.CollectableScoreWorth;
                fly.IsDone = true;
            }

            if (!isFrozen && !gameEnded)
            {
                // Apply gravity to Frog
                frog.ApplyGravity(gameTime);

                // Make the magma rise
                magma.Rise(offset);
            }

            if (!gameEnded)
            {
                //Check if frog is touching Magma
                if (frog.BoundingBox.Top + offset - ScreenManager.Dimensions.Y > 0 ||
                    magma.IsTouchingFrog(frog))
                {
                    frog.Die();
                    gameEnded = true;
                    scoreboard = new Scoreboard(score, frog.IsDead);
                }

                if (offset > GameHeight + 400)
                {
                    gameEnded = true;
                    scoreboard = new Scoreboard(score, frog.IsDead);
                }
            }
            else
            {
                scoreboard.Update(frog, gameTime);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            // Draw platforms
            foreach (Platform platform in platforms.Where(platform => platform.IsInViewport(offset)))
            {
                platform.Draw(spriteBatch, offset);
            }

            // Draw flies
            foreach (Fly fly in flies.Where(fly => fly.IsInViewport(offset) && !fly.IsDone))
            {
                fly.Draw(spriteBatch, offset);
            }

            // Draw frog
            frog.Draw(spriteBatch, offset);

            // Draw magma
            magma.Draw(spriteBatch, offset);

            // Draw obstacles
            foreach (
                Obstacle obstacle in obstacles.Where(obstacle => obstacle.IsInViewport(offset) && !obstacle.IsDone()))
            {
                obstacle.Draw(spriteBatch, offset);
                if (frog.IsJumpingOnObstacle(obstacle))
                {
                    obstacle.DrawQuestion(spriteBatch);
                }
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

        public void CheckAnswer(bool answer)
        {
            if (answer == false)
            {
                score -= 1000;
                isFrozen = false;
            }
            else
            {
                score += 1000;
                isFrozen = false;
            }
            frog.Jump();
        }
    }
}
