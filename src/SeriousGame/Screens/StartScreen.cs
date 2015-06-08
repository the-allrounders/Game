using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SeriousGame
{
    class StartScreen : GameScreen
    {
        public override void Load()
        {
            // Startscherm geladen
        }

        public override void Update(GameTime gameTime)
        {
            if (InputManager.IsPressing(Keys.Space))
            {
                ScreenManager.CurrentScreen = new JumpScreen();
            }
            else if (InputManager.IsPressing(Keys.S))
            {
                ScreenManager.CurrentScreen = new SettingsScreen();
            }
            else if (InputManager.IsPressing(Keys.Escape))
            {
                ScreenManager.Game.Exit();
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(TextureManager.Start, new Vector2(0, 0));
        }
    }
}
