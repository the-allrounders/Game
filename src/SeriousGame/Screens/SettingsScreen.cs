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
        private MouseState previousMouse;
        
        private Rectangle backButton =          new Rectangle(0, 0, 150, 75);
        private Rectangle difficultyButton =    new Rectangle(340, 115, 550, 100);
        private Rectangle musicButton =         new Rectangle(340, 300, 550, 110);
        private Rectangle soundButton =         new Rectangle(340, 460, 550, 100);
        
        public override void Update(GameTime gameTime)
        {
            KeyboardState keyboard = Keyboard.GetState();
            MouseState mouse = Mouse.GetState();
            Rectangle mousePosition = new Rectangle(mouse.Position.X, mouse.Position.Y, 1, 1);
            bool clicked = (mouse.LeftButton == ButtonState.Pressed && previousMouse.LeftButton == ButtonState.Released);

            if (keyboard.IsKeyDown(Keys.Escape) || (clicked && backButton.Intersects(mousePosition)))
            {
                ScreenManager.Instance.CurrentScreen = new StartScreen();
            }
            else if (clicked && difficultyButton.Intersects(mousePosition))
            {
                SettingsManager.Instance.Difficulty += 1;
                if (SettingsManager.Instance.Difficulty == 4) 
                    SettingsManager.Instance.Difficulty = 1;
            }
            else if (clicked && musicButton.Intersects(mousePosition))
            {
                SettingsManager.Instance.Music = !SettingsManager.Instance.Music;
            }
            else if (clicked && soundButton.Intersects(mousePosition))
            {
                SettingsManager.Instance.Sound = !SettingsManager.Instance.Sound;
            }

            previousMouse = mouse;
        }
        
        private void DrawSetting(SpriteBatch spriteBatch, string text, Vector2 position){
            spriteBatch.DrawString(
                FontManager.Instance.Verdana, 
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
            spriteBatch.Draw(TextureManager.Instance.Settings, new Vector2(0, 0));
            DrawSetting(spriteBatch, SettingsManager.Instance.Difficulty.ToString(), new Vector2(702, 128));

            string music = "on";
            if(!SettingsManager.Instance.Music)
            {
                music = "off";
            }
            DrawSetting(spriteBatch, music, new Vector2(702, 300));

            string sound = "on";
            if (!SettingsManager.Instance.Sound)
            {
                sound = "off";
            }
            DrawSetting(spriteBatch, sound, new Vector2(702, 470));
        }
    }
}
