using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SeriousGame.Managers;
using SeriousGame.Screens;

namespace SeriousGame.Objects
{
    class Scoreboard
    {
        private int score;
        private bool buttonIsSaveButton = true;
        private bool isDead;
        private bool caretVisible = true;

        public Scoreboard(int scr, bool dead)
        {
            score = scr;
            isDead = dead;
        }

        public void BuildPlayerName(Frog frog)
        {
            if (InputManager.IsPressing(Keys.Back))
            {
                frog.RemoveCharFromName();
            }
            else if (InputManager.IsPressing(Keys.Space))
                frog.AddCharToName(Keys.Space);
            else
            {
                for (Keys key = Keys.A; key <= Keys.Z; key++)
                {
                    if (InputManager.IsPressing(key))
                    {
                        frog.AddCharToName(key);
                    }
                }
            }
        }

        public void Update(Frog frog, GameTime gameTime)
        {
            if (InputManager.IsPressing(Keys.Enter) || InputManager.IsClicking(new Rectangle((int)ScreenManager.Dimensions.X / 2 - 40, (int)ScreenManager.Dimensions.Y / 2, 100, 20)))
            {
                if (buttonIsSaveButton)
                {
                    LeaderboardScreen.SaveScore(frog.PlayerName, score);
                    buttonIsSaveButton = false;
                }
                else
                {
                    ScreenManager.CurrentScreen = new LeaderboardScreen();
                }
            }
            else if (InputManager.IsClicking(new Rectangle((int)ScreenManager.Dimensions.X / 2 - 45,
                         (int)ScreenManager.Dimensions.Y / 2 + 35, 100, 20)))
            {
                ScreenManager.CurrentScreen = new JumpScreen();
            }
            else
                BuildPlayerName(frog);
            if (gameTime.TotalGameTime.Milliseconds > 500 && gameTime.TotalGameTime.Milliseconds <= 999)
                caretVisible = true;
            else
                caretVisible = false;
        }

        public void Draw(SpriteBatch spriteBatch, int offset, string playerName)
        {
            string winText = "Hoera, gewonnen! Je scoorde " + score + " punten";
            string loseText = "Helaas, game over! Je scoorde " + score + " punten";
            string text = isDead ? loseText : winText;
            spriteBatch.DrawString(FontManager.Verdana, text,
                 new Vector2(ScreenManager.Dimensions.X / 2 - FontManager.Verdana.MeasureString(text).X / 2, ScreenManager.Dimensions.Y / 2 - 100), Color.White);
            spriteBatch.Draw(TextureManager.InputMedium,
                new Vector2(ScreenManager.Dimensions.X/2 - 100, ScreenManager.Dimensions.Y/2 - 50));
            if (caretVisible)
            {
                float caretDistance = playerName == "<naam>" ? 0 : FontManager.Verdana.MeasureString(playerName).X;
                spriteBatch.Draw(TextureManager.Caret, new Vector2(ScreenManager.Dimensions.X / 2 - 90 + caretDistance + 1, ScreenManager.Dimensions.Y / 2 - 40));
            }
            Color nameColor = playerName == "<naam>" ? Color.Gray : Color.Black;
            spriteBatch.DrawString(FontManager.Verdana, playerName,
                new Vector2(ScreenManager.Dimensions.X/2 - 90, ScreenManager.Dimensions.Y/2 - 40), nameColor);
            if (buttonIsSaveButton)
                spriteBatch.DrawString(FontManager.Verdana, "Opslaan",
                    new Vector2(ScreenManager.Dimensions.X/2 - FontManager.Verdana.MeasureString("Opslaan").X / 2, ScreenManager.Dimensions.Y/2), Color.White);
            else
                spriteBatch.DrawString(FontManager.Verdana, "Ranglijst",
                    new Vector2(ScreenManager.Dimensions.X/2 - FontManager.Verdana.MeasureString("Ranglijst").X / 2, ScreenManager.Dimensions.Y/2), Color.White);
            spriteBatch.DrawString(FontManager.Verdana, "Opnieuw",
                new Vector2(ScreenManager.Dimensions.X/2 - FontManager.Verdana.MeasureString("Opnieuw").X / 2, ScreenManager.Dimensions.Y / 2 + 30), Color.White);
        }
    }
}
