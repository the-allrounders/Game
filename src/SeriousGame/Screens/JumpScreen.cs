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
        private readonly Frog frog = new Frog(new Vector2((ScreenManager.Dimensions.X / 2) - (TextureManager.Frog[SettingsManager.FrogType].Width / 2), ScreenManager.Dimensions.Y - TextureManager.Frog[SettingsManager.FrogType].Height), 5);
        private readonly Magma magma = new Magma(new Vector2(0, ScreenManager.Dimensions.Y));
        private Obstacle touchingObstacle = null;
        private bool gameEnded;
        private Scoreboard scoreboard;
        private bool controlInfoVisible = SettingsManager.ShowControlInfo;
        private bool dontShowControlInfoAgain;

        private bool wrong = false;
        private bool good = false;
        private string answer;
        private double waitTime;

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
                ScreenManager.IsMouseVisible = true;
                ScreenManager.CurrentScreen = new StartScreen();
                return;
            }

            #endregion

            #region Info screen

            if (controlInfoVisible)
            {
                if (InputManager.IsPressing(Keys.Enter))
                {
                    dontShowControlInfoAgain = !dontShowControlInfoAgain;
                    SettingsManager.ShowControlInfo = !SettingsManager.ShowControlInfo;
                }
                if (InputManager.IsPressing(Keys.Space))
                    controlInfoVisible = false;
                return;
            }

            #endregion

            #region Question screen

            // Show questionscreen if touching obstacle
            if (!wrong && touchingObstacle != null)
            {
                answer = "";
                if (InputManager.IsPressing(Keys.D1) || InputManager.IsPressing(Keys.NumPad1))
                    answer = touchingObstacle.popUp.questions[touchingObstacle.question].Answers[0];
                else if (InputManager.IsPressing(Keys.D2) || InputManager.IsPressing(Keys.NumPad2))
                    answer = touchingObstacle.popUp.questions[touchingObstacle.question].Answers[1];
                else if (InputManager.IsPressing(Keys.D3) || InputManager.IsPressing(Keys.NumPad3))
                    answer = touchingObstacle.popUp.questions[touchingObstacle.question].Answers[2];
                else if (InputManager.IsPressing(Keys.D4) || InputManager.IsPressing(Keys.NumPad4))
                    answer = touchingObstacle.popUp.questions[touchingObstacle.question].Answers[3];

                if (answer != string.Empty)
                {
                    bool right = touchingObstacle.CheckAnswer(answer);
                    touchingObstacle.FinishedQuestion();
                    if (right)
                    {
                        score += 1000;
                        good = true;
                        touchingObstacle = null;
                        if (SettingsManager.Difficulty != 3 && frog.Lives < 3)
                            frog.Lives++;
                    }
                    else
                    {
                        score -= 1000;
                        wrong = true;
                        frog.Lives--;
                    }
                    waitTime = gameTime.TotalGameTime.TotalSeconds;
                    frog.Jump();
                }
            }
            else if (!wrong && (!gameEnded || gameEnded && frog.IsDead))
                // Make the magma rise
                magma.Rise(offset);

            // Set wrong and good to false after 3 seconds
            if (good && gameTime.TotalGameTime.TotalSeconds >= waitTime + 3)
                good = false;

            #endregion

            ScreenManager.IsMouseVisible = gameEnded;

            if (touchingObstacle != null && wrong && InputManager.IsPressing(Keys.Space))
            {
                wrong = false;
                touchingObstacle = null;
            }

            if (!gameEnded && touchingObstacle == null)
            {
                #region Game actively running

                // Check if Frog touches obstacle
                foreach (
                    Obstacle obstacle in
                        obstacles.Where(
                            obstacle =>
                                obstacle.IsInViewport(offset) && frog.IsJumpingOnObstacle(obstacle) &&
                                !obstacle.IsDone()))
                    touchingObstacle = obstacle;

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
                    if (!collectable.IsCatching(frog)) continue;
                    score += collectable.CollectableScoreWorth;
                    SoundManager.Play(Sounds.Coin);
                    collectable.IsDone = true;
                }

                // Apply gravity to Frog
                frog.ApplyGravity(gameTime);

                if (magma.IsTouchingFrog(frog))
                {
                    if (!frog.StealthMode)
                    {
                        if (frog.Lives > 1)
                        {
                            frog.StealthMode = true;
                            frog.TimeOfStealthMode = gameTime.TotalGameTime.TotalMilliseconds;
                        }
                        frog.Lives--;
                    }
                    frog.Jump();
                }

                if (frog.StealthMode)
                {
                    if (gameTime.TotalGameTime.TotalMilliseconds < frog.TimeOfStealthMode + 1500)
                    {
                        if ((gameTime.TotalGameTime.Milliseconds >= 0 && gameTime.TotalGameTime.Milliseconds < 125) || (gameTime.TotalGameTime.Milliseconds >= 250 && gameTime.TotalGameTime.Milliseconds <= 375) || (gameTime.TotalGameTime.Milliseconds >= 500 && gameTime.TotalGameTime.Milliseconds < 625) || (gameTime.TotalGameTime.Milliseconds >= 750 && gameTime.TotalGameTime.Milliseconds <= 875))
                            frog.IsVisible = true;
                        else
                            frog.IsVisible = false;
                    }
                    else
                        frog.StealthMode = false;
                }
                else
                    frog.IsVisible = true;

                //Check if frog is out of screen
                if (frog.BoundingBox.Top + offset - ScreenManager.Dimensions.Y > 0 || frog.Lives <= 0)
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
                scoreboard.Update(frog, gameTime);

            #endregion

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            // Draw platforms
            foreach (Platform platform in platforms.Where(platform => platform.IsInViewport(offset)))
                platform.Draw(spriteBatch, offset);

            // Draw collectables
            foreach (
                Collectable collectable in
                    collectables.Where(collectable => collectable.IsInViewport(offset) && !collectable.IsDone))
                collectable.Draw(spriteBatch, offset);

            // Draw obstacles
            foreach (
                Obstacle obstacle in obstacles.Where(obstacle => obstacle.IsInViewport(offset) && !obstacle.IsDone()))
            {
                obstacle.Draw(spriteBatch, offset);
            }

            // Draw frog
            frog.Draw(spriteBatch, offset);

            // Draw magma
            magma.Draw(spriteBatch, offset);

            // Show feedback
            if (wrong)
            {
                spriteBatch.Draw(TextureManager.Wrong, new Vector2(ScreenManager.Dimensions.X / 2 - TextureManager.Wrong.Width / 2, 10));
                touchingObstacle.DrawFeedback(answer, spriteBatch);
            }
            else if (good)
                spriteBatch.Draw(TextureManager.Good, new Vector2(ScreenManager.Dimensions.X / 2 - TextureManager.Good.Width / 2, 300));

           

            // Draw walls
            foreach (Wall wall in walls.Where(wall => wall.IsInViewport(offset)))
                wall.Draw(spriteBatch, offset);


            // Draw question popup
            foreach (Obstacle obstacle in obstacles.Where(obstacle => obstacle.IsInViewport(offset) && !obstacle.IsDone()).Where(obstacle => frog.IsJumpingOnObstacle(obstacle)))
                obstacle.DrawQuestion(spriteBatch);

            // Draw scorescreen of frog is dead
            if (gameEnded)
                scoreboard.Draw(spriteBatch, offset, frog.PlayerName);
            // If the frog is alive, draw the score
            else
            {
                string text = "Score: " + score;
                spriteBatch.DrawString(FontManager.Verdana, text, new Vector2(ScreenManager.Dimensions.X - FontManager.Verdana.MeasureString(text).X - 20, TextureManager.Heart.Height + 10),
                    Color.White);
                for (int i = 1; i <= frog.Lives; i++)
                    spriteBatch.Draw(TextureManager.Heart, new Vector2(ScreenManager.Dimensions.X - 5 - TextureManager.Heart.Width * i, 5));
            }

            if (controlInfoVisible)
            {
                spriteBatch.Draw(TextureManager.QuestionBox, new Vector2(ScreenManager.Dimensions.X / 2 - TextureManager.QuestionBox.Width / 2, ScreenManager.Dimensions.Y / 2 - TextureManager.QuestionBox.Height / 2));
                SpriteFont font = FontManager.Verdana;
                const float lineWidth = 400;
                string introText = FontManager.WrapText("Om dit spel te spelen gebruik je de pijltjes- of de A & D toetsen", font, lineWidth);
                string statusDontShowAgainText = FontManager.WrapText("Als je af gaat krijg je dit bericht " + (dontShowControlInfoAgain ? "niet " : "") + "nog een keer te zien", FontManager.Verdana, lineWidth);
                string changeStatusText = FontManager.WrapText("(Druk op de enter toets om dit aan te passen)", font, lineWidth);
                string continueText = FontManager.WrapText("Druk op de spatiebalk om te beginnen", font, lineWidth);
                const int margin = 10;
                float totalHeight = font.MeasureString(introText).Y + font.MeasureString(statusDontShowAgainText).Y + font.MeasureString(changeStatusText).Y + font.MeasureString(continueText).Y + (margin * 2);
                spriteBatch.DrawString(font, introText, new Vector2(ScreenManager.Dimensions.X / 2 - lineWidth / 2, (ScreenManager.Dimensions.Y / 2 - totalHeight / 2)), Color.Black);
                spriteBatch.DrawString(font, statusDontShowAgainText, new Vector2(ScreenManager.Dimensions.X / 2 - lineWidth / 2, (ScreenManager.Dimensions.Y / 2 - totalHeight / 2) + font.MeasureString(introText).Y + margin), Color.Black);
                spriteBatch.DrawString(font, changeStatusText, new Vector2(ScreenManager.Dimensions.X / 2 - lineWidth / 2, (ScreenManager.Dimensions.Y / 2 - totalHeight / 2) + font.MeasureString(introText).Y + font.MeasureString(statusDontShowAgainText).Y + margin), Color.Black);
                spriteBatch.DrawString(font, continueText, new Vector2(ScreenManager.Dimensions.X / 2 - lineWidth / 2, (ScreenManager.Dimensions.Y / 2 - totalHeight / 2) + totalHeight - font.MeasureString(continueText).Y + margin), Color.Black);
            }
        }
    }
}
