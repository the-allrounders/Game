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
        private Rectangle backButton =          new Rectangle(0, 0, 150, 75);
        private Rectangle difficultyButton =    new Rectangle(340, 115, 550, 100);
        private Rectangle musicButton =         new Rectangle(340, 300, 550, 110);
        private Rectangle soundButton =         new Rectangle(340, 460, 550, 100);
        
        public override void Update(GameTime gameTime)
        {
            if (InputManager.IsPressing(Keys.Escape) || InputManager.IsClicking(backButton))
            {
                ScreenManager.CurrentScreen = new StartScreen();
            }
            else if (InputManager.IsClicking(difficultyButton))
            {
                SettingsManager.Difficulty += 1;
                if (SettingsManager.Difficulty == 4) 
                    SettingsManager.Difficulty = 1;
            }
            else if (InputManager.IsClicking(musicButton))
            {
                SettingsManager.Music = !SettingsManager.Music;
            }
            else if (InputManager.IsClicking(soundButton))
            {
                SettingsManager.Sound = !SettingsManager.Sound;
            }
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
            spriteBatch.Draw(TextureManager.Settings, new Vector2(0, 0));
            DrawSetting(spriteBatch, SettingsManager.Difficulty.ToString(), new Vector2(702, 128));

            string music = "on";
            if(!SettingsManager.Music)
            {
                music = "off";
            }
            DrawSetting(spriteBatch, music, new Vector2(702, 300));

            string sound = "on";
            if (!SettingsManager.Sound)
            {
                sound = "off";
            }
            DrawSetting(spriteBatch, sound, new Vector2(702, 470));

            string fullscreen = "on";
            if (!SettingsManager.Fullscreen)
            {
                fullscreen = "off";
            }
            DrawSetting(spriteBatch, fullscreen, new Vector2(810, 625));
        }
    }
}
