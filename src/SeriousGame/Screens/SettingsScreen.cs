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
        
        private Rectangle backButton = new Rectangle(0, 0, 150, 75);
        private Rectangle difficulty = new Rectangle(340, 115, 500, 100);
        
        public override void Update(GameTime gameTime)
        {
            // Doe iets met SettingsManager.Instance.Difficulty ofzo
            KeyboardState keyboard = Keyboard.GetState();
            MouseState mouse = Mouse.GetState();
            Rectangle mousePosition = new Rectangle(mouse.Position.X, mouse.Position.Y, 1, 1);
            bool clicked = (mouse.LeftButton == ButtonState.Pressed && previousMouse.LeftButton == ButtonState.Released);

            if (keyboard.IsKeyDown(Keys.Escape) || (clicked && backButton.Intersects(mousePosition)))
            {
                ScreenManager.Instance.CurrentScreen = new StartScreen();
            }
            else if (clicked && difficulty.Intersects(mousePosition))
            {
                SettingsManager.Instance.Difficulty += 1;
                if (SettingsManager.Instance.Difficulty == 4) SettingsManager.Instance.Difficulty = 1;
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
            DrawSetting(spriteBatch, SettingsManager.Instance.Music.ToString(), new Vector2(702, 300));
            DrawSetting(spriteBatch, SettingsManager.Instance.Sound.ToString(), new Vector2(702, 470));
        }
    }
}
