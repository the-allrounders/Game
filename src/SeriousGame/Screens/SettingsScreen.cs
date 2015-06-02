using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGame
{
    class SettingsScreen : GameScreen
    {
        public override void Update(GameTime gameTime)
        {
            // If ESC button is pressed or if back button is clicked
            if (InputManager.IsPressing(Keys.Escape) || InputManager.IsClicking(new Rectangle(0, 0, 150, 75)))
            {
                ScreenManager.CurrentScreen = new StartScreen();
            }

            // If difficulty is clicked
            else if (InputManager.IsClicking(new Rectangle(340, 115, 550, 100)))
            {
                SettingsManager.Difficulty += 1;
                if (SettingsManager.Difficulty == 4) 
                    SettingsManager.Difficulty = 1;
            }

            // If music is clicked
            else if (InputManager.IsClicking(new Rectangle(340, 300, 550, 110)))
            {
                SettingsManager.Music = !SettingsManager.Music;
            }

            // If sound is clicked
            else if (InputManager.IsClicking(new Rectangle(340, 460, 550, 100)))
            {
                SettingsManager.Sound = !SettingsManager.Sound;
            }

            // If fullscreen is clicked
            else if (InputManager.IsClicking(new Rectangle(340, 610, 650, 100)))
            {
                SettingsManager.Fullscreen = !SettingsManager.Fullscreen;
            }
        }
        
        private void DrawSetting(SpriteBatch spriteBatch, string text, Vector2 position){
            spriteBatch.DrawString(
                FontManager.Verdana,
                text,
                position, 
                Color.Black, 
                new float(), 
                new Vector2(), 
                4, 
                new SpriteEffects(), 
                new float()
            );
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            // Draw settings background
            spriteBatch.Draw(TextureManager.Settings, new Vector2(0, 0));

            // Draw difficulty
            DrawSetting(spriteBatch, SettingsManager.Difficulty.ToString(), new Vector2(702, 128));

            // Draw music
            DrawSetting(spriteBatch, SettingsManager.Music ? "on" : "off", new Vector2(702, 300));

            // Draw sound
            DrawSetting(spriteBatch, SettingsManager.Sound ? "on" : "off", new Vector2(702, 470));

            // Draw fullscreen
            DrawSetting(spriteBatch, SettingsManager.Fullscreen ? "on" : "off", new Vector2(810, 625));
        }
    }
}
