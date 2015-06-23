using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SeriousGame.Managers;

namespace SeriousGame.Screens
{
    class IntroScreen : GameScreen
    {
        private int currentBackground = 0;
        private readonly int maxBackgroundIndex = TextureManager.IntroBackground.Count() - 1;
        private Rectangle roleHeight = new Rectangle(0, 0, TextureManager.LetterNoBottom.Width, 100);
        private double timeNewBackground;
        private double timeScreenLoaded;
        private double opacityNewBackground = 1;
        private double opacityOldBackground;
        private int oldBackground;

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
            {
                timeNewBackground = gameTime.TotalGameTime.TotalMilliseconds;
                timeScreenLoaded = gameTime.TotalGameTime.TotalMilliseconds;
            }
            else if (gameTime.TotalGameTime.TotalMilliseconds >= timeNewBackground + 3500)
            {
                timeNewBackground = gameTime.TotalGameTime.TotalMilliseconds;
                oldBackground = currentBackground;
                currentBackground++;
                if (currentBackground > maxBackgroundIndex)
                {
                    currentBackground = 0;
                    oldBackground = maxBackgroundIndex;
                }
                opacityNewBackground = 0;
                opacityOldBackground = 1;
            }

            if (gameTime.TotalGameTime.TotalMilliseconds >= timeScreenLoaded + 300 && roleHeight.Height < TextureManager.LetterNoBottom.Height)
                roleHeight.Height += 10;
            
            int animationDuration = 500;
            if (gameTime.TotalGameTime.TotalMilliseconds < timeNewBackground + animationDuration)
            {
                double newOpacity = (gameTime.TotalGameTime.TotalMilliseconds - timeNewBackground) / animationDuration;
                opacityNewBackground = newOpacity;
                opacityOldBackground = 1 - newOpacity;
            }
                
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Vector2 rolePosition = new Vector2(650, 0);
            spriteBatch.Draw(TextureManager.IntroBackground[oldBackground], new Vector2(0, 0), Color.White * (float)opacityOldBackground);
            spriteBatch.Draw(TextureManager.IntroBackground[currentBackground], new Vector2(0, 0), Color.White * (float)opacityNewBackground);
            spriteBatch.Draw(TextureManager.LetterNoBottom, rolePosition, roleHeight, Color.White, 0, new Vector2(0, 0), 1, SpriteEffects.None, 0);
            spriteBatch.Draw(TextureManager.LetterBottom, new Vector2(rolePosition.X - 20, rolePosition.Y + roleHeight.Height - 95));
        }
    }
}
