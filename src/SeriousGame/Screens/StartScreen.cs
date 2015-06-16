using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SeriousGame.Managers;

namespace SeriousGame.Screens
{
    class StartScreen : GameScreen
    {
        public override void Load()
        {
            SongManager.Play(Songs.SuperMario);
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
            else if (InputManager.IsPressing(Keys.C))
            {
                ScreenManager.CurrentScreen = new Creditsscreen();
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
