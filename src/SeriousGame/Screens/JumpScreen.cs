using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SeriousGame
{
    class JumpScreen : GameScreen
    {
        private int offset = 0;
        private int gameHeight = 100000;
        private List<Platform> platforms = new List<Platform>();
        private List<Obstacle> obstacles = new List<Obstacle>();
        private List<Fly> flies = new List<Fly>();
        private Frog frog;
        private Magma magma;
        private Boolean isFrozen;
        private bool gameEnded;
        private bool buttonIsSaveButton;

        public static int Padding = 200;

        public override void Load()
        {
            addPlatforms();
            addObstacles();
            addFlies();
            frog = new Frog(new Vector2((ScreenManager.Dimensions.X / 2) - (TextureManager.Frog.Width / 2), ScreenManager.Dimensions.Y - TextureManager.Frog.Height), 5);
            magma = new Magma(new Vector2(0, ScreenManager.Dimensions.Y));
            gameEnded = false;
            buttonIsSaveButton = true;
        }

        private void addPlatforms()
        {
            Random rnd = new Random();
            for (int i = 600; i > gameHeight * -1; i -= 200)
            {
                platforms.Add(new Platform(new Vector2(rnd.Next(JumpScreen.Padding, (int)ScreenManager.Dimensions.X - JumpScreen.Padding - TextureManager.Platform.Width), i + rnd.Next(-30, 30)), new Vector2(150, 50)));
            }
        }

        private void addObstacles()
        {
            int question = -2;
            for (int i = 1000; i > gameHeight * -1; i -= 2000)
            {
                question++;
                obstacles.Add(new Obstacle(Color.Red, new Vector2(50, i), question));
            }
        }

        private void addFlies()
        {
            Random rnd = new Random();
            for (int i = 300; i > gameHeight * -1; i -= TextureManager.Fly.Height + 200)
            {
                int fliesThisLine = rnd.Next(-1, 4);
                for (int n = 0; n < fliesThisLine; n++)
                {
                    int distance = (int)((ScreenManager.Dimensions.X - (Padding * 2)) / fliesThisLine * n) + Padding + rnd.Next(-30, 30);
                    if (distance < Padding)
                        distance = Padding;
                    else if (distance > ScreenManager.Dimensions.X - Padding)
                        distance = (int)ScreenManager.Dimensions.X - Padding - TextureManager.Fly.Width;
                    flies.Add(new Fly(new Vector2(distance, i + rnd.Next(-50, 50)), 100));
                }
            }
        }

        public void endGame(SpriteBatch spriteBatch)
        {
            if (frog.isDead)
            {
                drawScoreScreen(spriteBatch, offset, true);
            }
            else
            {
                String text = "Score: " + frog.gameScore;
                spriteBatch.DrawString(FontManager.Verdana, text, new Vector2(ScreenManager.Dimensions.X - 200, 20), Color.White);
            }
            if (gameEnded)
            {
                if (InputManager.IsPressing(Keys.Enter) || InputManager.IsClicking(new Rectangle((int)ScreenManager.Dimensions.X / 2 - 40, (int)ScreenManager.Dimensions.Y / 2, 100, 20)))
                {
                    if (buttonIsSaveButton)
                    {
                        String pathOfFile = "../../../leaderboard.txt";

                        string[] values = File.ReadAllLines(pathOfFile);
                        List<string> scores = new List<string>();
                        bool added = false;
                        for (int i = 0; i < values.Length; i++)
                        {
                            string[] score = values[i].Split(',');
                            if (!added && frog.gameScore > Convert.ToInt32(score[1]))
                            {
                                scores.Add(frog.playerName + ", " + frog.gameScore);
                                added = true;
                            }
                            scores.Add(values[i]);
                        }
                        if (!added)
                            scores.Add(frog.playerName + ", " + frog.gameScore);
                        File.WriteAllLines(pathOfFile, scores);
                        buttonIsSaveButton = false;
                    }
                    else
                    {
                        ScreenManager.CurrentScreen = new LeaderboardScreen();
                    }
                }
                else if (InputManager.IsPressing(Keys.Space) || InputManager.IsClicking(new Rectangle((int)ScreenManager.Dimensions.X / 2 - 45, (int)ScreenManager.Dimensions.Y / 2 + 35, 100, 20)))
                {
                    ScreenManager.CurrentScreen = new JumpScreen();
                }
            }
        }

        public override void Update(GameTime gameTime)
        {
            // If user is pressing ESC, return to StartScreen
            if (InputManager.IsPressing(Keys.Escape))
            {
                ScreenManager.CurrentScreen = new StartScreen();
            }

            // Check if Frog touches obstacle
            foreach (Obstacle obstacle in obstacles)
            {
                if (obstacle.IsInViewport(offset) && frog.isJumpingOnObstacle(obstacle))
                {
                    if (!obstacle.isDone())
                    {
                        isFrozen = true;
                        obstacle.openQuestion();
                        Boolean answer;
                        if (InputManager.IsPressing(Keys.A))
                        {
                            answer = obstacle.checkAnswer(1);
                            Console.WriteLine(answer);
                            obstacle.finishedQuestion();
                            checkAnswer(answer);
                        }
                        else if (InputManager.IsPressing(Keys.B))
                        {
                            answer = obstacle.checkAnswer(2);
                            Console.WriteLine(answer);
                            obstacle.finishedQuestion();
                            checkAnswer(answer);
                        }
                        else if (InputManager.IsPressing(Keys.C))
                        {
                            answer = obstacle.checkAnswer(3);
                            Console.WriteLine(answer);
                            obstacle.finishedQuestion();
                            checkAnswer(answer);
                        }
                        else if (InputManager.IsPressing(Keys.D))
                        {
                            answer = obstacle.checkAnswer(4);
                            Console.WriteLine(answer);
                            obstacle.finishedQuestion();
                            checkAnswer(answer);
                        }
                    }
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
                frog.addScore((int)Math.Ceiling(addPoints));
                offset = newOffset;
            }

            // Check if jumping on platform
            foreach (Platform platform in platforms)
            {
                if (platform.IsInViewport(offset) && frog.IsJumpingOn(platform))
                {
                    frog.Jump();
                }
            }

            // Check if frog is catching any flies
            List<Fly> copyFlies = new List<Fly>();
            copyFlies = flies;
            for (int i = 0; i < copyFlies.Count; i++)
            {
                if (flies[i].IsInViewport(offset) && flies[i].IsCatching(frog))
                {
                    frog.addScore(flies[i].collectableScoreWorth);
                    flies.RemoveAt(i);
                }
            }

            if (frog.BoundingBox.Top + offset - ScreenManager.Dimensions.Y > 0 || magma.IsTouchingMagma(frog))
            {
                frog.makeDead();
                gameEnded = true;
            }
            else if (!isFrozen)
            {
                // Apply gravity to Frog
                frog.ApplyGravity(gameTime);

                // Make the magma rise
                magma.Update(gameTime, offset);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {

            // Draw platforms
            foreach (Platform platform in platforms) {
                if (platform.IsInViewport(offset))
                {
                    platform.Draw(spriteBatch, offset);
                }
            }

            // Draw obstacles
            foreach (Obstacle obstacle in obstacles)
            {
                if (obstacle.IsInViewport(offset) && !obstacle.isDone())
                {
                    obstacle.Draw(spriteBatch, offset);
                    if (frog.isJumpingOnObstacle(obstacle))
                    {
                        obstacle.DrawQuestion(spriteBatch);
                    }
                }
            }

			// Draw flies
            foreach (Fly fly in flies)
            {
                if (fly.IsInViewport(offset))
                {
                    fly.Draw(spriteBatch, offset);
                }
            }

            // Draw frog
            frog.Draw(spriteBatch, offset);

            // Draw magma
            magma.Draw(spriteBatch, offset);

            // Draw walls
            spriteBatch.Draw(TextureManager.WallLeft, new Vector2(0, offset * -1 + offset));
            spriteBatch.Draw(TextureManager.WallRight, new Vector2(ScreenManager.Dimensions.X - Padding, offset * -1 + offset));

            if (frog.isDead)
            {
                endGame(spriteBatch);
                gameEnded = true;
            }
            else
            {
                String text = "Score: " + frog.gameScore;
                spriteBatch.DrawString(FontManager.Verdana, text, new Vector2(ScreenManager.Dimensions.X - 200, 20), Color.White);
            }
        }

        public void drawScoreScreen(SpriteBatch spriteBatch, int offset, bool isDead)
        {
            String winText = "Hoera, gewonnen! Je scoorde " + frog.gameScore + " punten";
            String loseText = "Helaas, GameOver! Je scoorde " + frog.gameScore + " punten";
            String text = isDead ? loseText : winText;
            spriteBatch.DrawString(FontManager.Verdana, text, new Vector2(ScreenManager.Dimensions.X / 2 - 230, ScreenManager.Dimensions.Y / 2 - 100), Color.White);
            spriteBatch.Draw(TextureManager.InputMedium, new Vector2(ScreenManager.Dimensions.X / 2 - 100, ScreenManager.Dimensions.Y / 2 - 50));
            String playerName = buildPlayerName();
            //spriteBatch.Draw(TextureManager.Caret, new Vector2(ScreenManager.Dimensions.X / 2 - 90 + spriteFont.MeasureString(playerName).X, ScreenManager.Dimensions.Y / 2 - 40));
            spriteBatch.DrawString(FontManager.Verdana, playerName, new Vector2(ScreenManager.Dimensions.X / 2 - 90, ScreenManager.Dimensions.Y / 2 - 40), Color.Black);
            if (buttonIsSaveButton)
                spriteBatch.DrawString(FontManager.Verdana, "Opslaan", new Vector2(ScreenManager.Dimensions.X / 2 - 40, ScreenManager.Dimensions.Y / 2), Color.White);
            else
                spriteBatch.DrawString(FontManager.Verdana, "Leaderboard", new Vector2(ScreenManager.Dimensions.X / 2 - 60, ScreenManager.Dimensions.Y / 2), Color.White);
            spriteBatch.DrawString(FontManager.Verdana, "Opnieuw", new Vector2(ScreenManager.Dimensions.X / 2 - 45, ScreenManager.Dimensions.Y / 2 + 30), Color.White);
        }

        public String buildPlayerName()
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
            String playerName = frog.playerName;
            return playerName;
        }

        public void checkAnswer (Boolean answer)
        {
            if (answer == false)
            {
                frog.addScore(-1000);
                isFrozen = false;
            }
            else
            {
                frog.addScore(1000);
                isFrozen = false;
            }
            frog.Jump();
        }
    }
}
