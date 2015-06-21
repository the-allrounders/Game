using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SeriousGame.Managers;

namespace SeriousGame.Screens
{
    class IntroScreen : GameScreen
    {
        private int currentBackground = 0;
        private int maxBackgroundIndex = 2;
        private Rectangle roleHeight = new Rectangle(0, 0, TextureManager.LetterNoBottom.Width, 100);
        private int timeNewBackground;

        public override void Load()
        {
            SongManager.Play(Songs.SuperMario);
        }

        public override void Update(GameTime gameTime)
        {
            if (InputManager.IsPressing(Keys.Space))
                ScreenManager.CurrentScreen = new JumpScreen();
            else if (InputManager.IsPressing(Keys.Escape))
                ScreenManager.CurrentScreen = new StartScreen();

            if (timeNewBackground == 0)
                timeNewBackground = gameTime.TotalGameTime.Seconds;
            else if (gameTime.TotalGameTime.Seconds >= timeNewBackground + 5)
            {
                timeNewBackground = gameTime.TotalGameTime.Seconds;
                currentBackground++;
                if (currentBackground > maxBackgroundIndex)
                    currentBackground = 0;
            }
            if (roleHeight.Height < TextureManager.LetterNoBottom.Height)
                roleHeight.Height += 10;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Vector2 rolePosition = new Vector2(500, 0);
            spriteBatch.Draw(TextureManager.IntroBackground[currentBackground], new Vector2(0, 0));
            spriteBatch.Draw(TextureManager.LetterNoBottom, rolePosition, roleHeight, Color.White, 0, new Vector2(0, 0), 1, SpriteEffects.None, 0);
            spriteBatch.Draw(TextureManager.LetterBottom, new Vector2(rolePosition.X, rolePosition.Y + roleHeight.Height - 90));
        }
    }
}
