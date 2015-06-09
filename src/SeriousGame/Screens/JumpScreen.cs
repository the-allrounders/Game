using System;
using System.Collections.Generic;
using System.Linq;
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
        private const int gameHeight = 10000;
        private readonly List<Platform> platforms = Platform.GenerateList(gameHeight);
        private readonly List<Obstacle> obstacles = Obstacle.GenerateList(gameHeight);
        private readonly List<Fly> flies = Fly.GenerateList(gameHeight);
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
                if (InputManager.IsPressing(Keys.A) || InputManager.IsPressing(Keys.B) ||
                    InputManager.IsPressing(Keys.C) || InputManager.IsPressing(Keys.D))
                {
                    bool answer = false;
                    if (InputManager.IsPressing(Keys.A))
                    {
                        answer = obstacle.CheckAnswer(1);
                    }
                    else if (InputManager.IsPressing(Keys.B))
                    {
                        answer = obstacle.CheckAnswer(2);
                    }
                    else if (InputManager.IsPressing(Keys.C))
                    {
                        answer = obstacle.CheckAnswer(3);
                    }
                    else if (InputManager.IsPressing(Keys.D))
                    {
                        answer = obstacle.CheckAnswer(4);
                    }
                    obstacle.FinishedQuestion();
                    CheckAnswer(answer);
                }
            }

            // If user is pressing Left, go left. Same for Right.
            if (!isFrozen && !gameEnded && InputManager.IsPressing(Keys.Left, false))
            {
                frog.Left();
            }
            if (!isFrozen && !gameEnded && InputManager.IsPressing(Keys.Right, false))
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
            List<Fly> copyFlies = new List<Fly>();
            copyFlies = flies;
            for (int i = 0; i < copyFlies.Count; i++)
            {
                if (!flies[i].IsInViewport(offset) || !flies[i].IsCatching(frog)) continue;
                score += flies[i].CollectableScoreWorth;
                flies.RemoveAt(i);
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

                if (offset > gameHeight)
                {
                    gameEnded = true;
                    scoreboard = new Scoreboard(score, frog.IsDead);
                }
            }
            else
            {
                scoreboard.Update(frog);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            // Draw platforms
            foreach (Platform platform in platforms.Where(platform => platform.IsInViewport(offset)))
            {
                platform.Draw(spriteBatch, offset);
            }

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

            // Draw flies
            foreach (Fly fly in flies.Where(fly => fly.IsInViewport(offset)))
            {
                fly.Draw(spriteBatch, offset);
            }

            // Draw frog
            frog.Draw(spriteBatch, offset);

            // Draw magma
            magma.Draw(spriteBatch, offset);

            // Draw walls
            spriteBatch.Draw(TextureManager.WallLeft, new Vector2(0, offset*-1 + offset));
            spriteBatch.Draw(TextureManager.WallRight,
                new Vector2(ScreenManager.Dimensions.X - Padding, offset*-1 + offset));

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
