using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SeriousGame
{
    class JumpScreen : GameScreen
    {
        private int offset;
        private const int gameHeight = 100000;
        private readonly List<Platform> platforms = Platform.generateList(gameHeight);
        private readonly List<Obstacle> obstacles = Obstacle.GenerateList(gameHeight);
        private readonly List<Fly> flies = Fly.GenerateList(gameHeight);
        private readonly Frog frog = new Frog(new Vector2((ScreenManager.Dimensions.X / 2) - (TextureManager.Frog.Width / 2), ScreenManager.Dimensions.Y - TextureManager.Frog.Height), 5);
        private readonly Magma magma = new Magma(new Vector2(0, ScreenManager.Dimensions.Y));
        private bool isFrozen;
        private bool gameEnded;
        private bool buttonIsSaveButton = true;

        private int score;

        public static int Padding = 200;

        public override void Update(GameTime gameTime)
        {
            // If user is pressing ESC, return to StartScreen
            if (InputManager.IsPressing(Keys.Escape))
            {
                ScreenManager.CurrentScreen = new StartScreen();
            }

            // Check if Frog touches obstacle
            foreach (Obstacle obstacle in obstacles.Where(obstacle => obstacle.IsInViewport(offset) && frog.isJumpingOnObstacle(obstacle) && !obstacle.isDone()))
            {
                isFrozen = true;
                obstacle.openQuestion();
                if (InputManager.IsPressing(Keys.A) || InputManager.IsPressing(Keys.B) ||
                    InputManager.IsPressing(Keys.C) || InputManager.IsPressing(Keys.D))
                {
                    bool answer = false;
                    if (InputManager.IsPressing(Keys.A))
                    {
                        answer = obstacle.checkAnswer(1);
                    }
                    else if (InputManager.IsPressing(Keys.B))
                    {
                        answer = obstacle.checkAnswer(2);
                    }
                    else if (InputManager.IsPressing(Keys.C))
                    {
                        answer = obstacle.checkAnswer(3);
                    }
                    else if (InputManager.IsPressing(Keys.D))
                    {
                        answer = obstacle.checkAnswer(4);
                    }
                    obstacle.finishedQuestion();
                    checkAnswer(answer);
                }
            }

            // If user is pressing Left, go left. Same for Right.
            if (!isFrozen && !frog.isDead && InputManager.IsPressing(Keys.Left, false))
            {
                frog.Left();
            }
            if (!isFrozen && !frog.isDead && InputManager.IsPressing(Keys.Right, false))
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
                score += flies[i].collectableScoreWorth;
                flies.RemoveAt(i);
            }

            if (!isFrozen && !gameEnded)
            {
                // Apply gravity to Frog
                frog.ApplyGravity(gameTime);

                // Make the magma rise
                magma.Rise(offset);
            }

            //Check if frog is touching Magma
            if (frog.BoundingBox.Top + offset - ScreenManager.Dimensions.Y > 0 || magma.IsTouchingFrog(frog))
            {
                frog.Die();
                gameEnded = true;

                if (InputManager.IsPressing(Keys.Enter) || InputManager.IsClicking(new Rectangle((int)ScreenManager.Dimensions.X / 2 - 40, (int)ScreenManager.Dimensions.Y / 2, 100, 20)))
                {
                    if (buttonIsSaveButton)
                    {
                        const string pathOfFile = "../../../leaderboard.txt";

                        string[] values = File.ReadAllLines(pathOfFile);
                        List<string> scores = new List<string>();
                        bool added = false;
                        foreach (string t in values)
                        {
                            string[] sc = t.Split(',');
                            if (!added && score > Convert.ToInt32(sc[1]))
                            {
                                scores.Add(frog.playerName + ", " + score);
                                added = true;
                            }
                            scores.Add(t);
                        }
                        if (!added)
                            scores.Add(frog.playerName + ", " + score);
                        File.WriteAllLines(pathOfFile, scores);
                        buttonIsSaveButton = false;
                    }
                    else
                    {
                        ScreenManager.CurrentScreen = new LeaderboardScreen();
                    }
                }
                else if (InputManager.IsPressing(Keys.Space) ||
                         InputManager.IsClicking(new Rectangle((int)ScreenManager.Dimensions.X / 2 - 45,
                             (int)ScreenManager.Dimensions.Y / 2 + 35, 100, 20)))
                {
                    ScreenManager.CurrentScreen = new JumpScreen();
                }
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
                Obstacle obstacle in obstacles.Where(obstacle => obstacle.IsInViewport(offset) && !obstacle.isDone()))
            {
                obstacle.Draw(spriteBatch, offset);
                if (frog.isJumpingOnObstacle(obstacle))
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
            if (frog.isDead)
            {
                DrawScoreScreen(spriteBatch, offset, true);
            }

            // If the frog is alive, draw the score
            else
            {
                string text = "Score: " + score;
                spriteBatch.DrawString(FontManager.Verdana, text, new Vector2(ScreenManager.Dimensions.X - 200, 20),
                    Color.White);
            }
        }

        public void DrawScoreScreen(SpriteBatch spriteBatch, int offset, bool isDead)
        {
            string winText = "Hoera, gewonnen! Je scoorde " + score + " punten";
            string loseText = "Helaas, GameOver! Je scoorde " + score + " punten";
            string text = isDead ? loseText : winText;
            spriteBatch.DrawString(FontManager.Verdana, text, new Vector2(ScreenManager.Dimensions.X / 2 - 230, ScreenManager.Dimensions.Y / 2 - 100), Color.White);
            spriteBatch.Draw(TextureManager.InputMedium, new Vector2(ScreenManager.Dimensions.X / 2 - 100, ScreenManager.Dimensions.Y / 2 - 50));
            string playerName = BuildPlayerName();
            //spriteBatch.Draw(TextureManager.Caret, new Vector2(ScreenManager.Dimensions.X / 2 - 90 + spriteFont.MeasureString(playerName).X, ScreenManager.Dimensions.Y / 2 - 40));
            spriteBatch.DrawString(FontManager.Verdana, playerName, new Vector2(ScreenManager.Dimensions.X / 2 - 90, ScreenManager.Dimensions.Y / 2 - 40), Color.Black);
            if (buttonIsSaveButton)
                spriteBatch.DrawString(FontManager.Verdana, "Opslaan", new Vector2(ScreenManager.Dimensions.X / 2 - 40, ScreenManager.Dimensions.Y / 2), Color.White);
            else
                spriteBatch.DrawString(FontManager.Verdana, "Leaderboard", new Vector2(ScreenManager.Dimensions.X / 2 - 60, ScreenManager.Dimensions.Y / 2), Color.White);
            spriteBatch.DrawString(FontManager.Verdana, "Opnieuw", new Vector2(ScreenManager.Dimensions.X / 2 - 45, ScreenManager.Dimensions.Y / 2 + 30), Color.White);
        }

        public string BuildPlayerName()
        {
            if (InputManager.IsPressing(Keys.Back))
            {
                frog.removeCharFromName();
            }
            else
            {
                for (Keys key = Keys.A; key <= Keys.Z; key++)
                {
                    if (InputManager.IsPressing(key))
                    {
                        frog.addCharToName(key);
                    }
                }
            }
            string playerName = frog.playerName;
            return playerName;
        }

        public void checkAnswer(bool answer)
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
