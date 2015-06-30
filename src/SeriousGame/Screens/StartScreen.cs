using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Frogano.Managers;

namespace Frogano.Screens
{
    class StartScreen : GameScreen
    {
        private Rectangle startPos = new Rectangle(
            349,
            55,
            TextureManager.StartHover.Width,
            TextureManager.StartHover.Height
        );

        private Rectangle creditsPos = new Rectangle(
            466, 
            419, 
            TextureManager.CreditsHover.Width, 
            TextureManager.CreditsHover.Height
        );
        
        private Rectangle settingsPos = new Rectangle(
            76,
            472,
            TextureManager.SettingsHover.Width,
            TextureManager.SettingsHover.Height
        );
        
        private Rectangle leaderboardPos = new Rectangle(
            632,
            482,
            TextureManager.LeaderboardHover.Width,
            TextureManager.LeaderboardHover.Height
        );
        
        public override void Load()
        {
            SongManager.Play(Songs.SuperMario);
        }

        public override void Update(GameTime gameTime)
        {
            if (InputManager.IsPressing(Keys.Space) || InputManager.IsClicking(startPos))
            {
                ScreenManager.CurrentScreen = new IntroScreen();
            }
            else if (InputManager.IsPressing(Keys.S) || InputManager.IsClicking(settingsPos))
            {
                ScreenManager.CurrentScreen = new SettingsScreen();
            }
            else if (InputManager.IsPressing(Keys.C) || InputManager.IsClicking(creditsPos))
            {
                ScreenManager.CurrentScreen = new CreditsScreen();
            }
            else if (InputManager.IsPressing(Keys.L) || InputManager.IsClicking(leaderboardPos))
            {
                ScreenManager.CurrentScreen = new LeaderboardScreen(); 
            }
            else if (InputManager.IsPressing(Keys.Escape))
            {
                //ScreenManager.Game.Exit();
            }
            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(TextureManager.Start, new Vector2(0, 0));

            if (InputManager.IsHovering(startPos))
            {
                spriteBatch.Draw(TextureManager.StartHover, new Vector2(startPos.X, startPos.Y));
            }

            if (InputManager.IsHovering(creditsPos))
            {
                spriteBatch.Draw(TextureManager.CreditsHover, new Vector2(creditsPos.X, creditsPos.Y));
            }

            if (InputManager.IsHovering(leaderboardPos))
            {
                spriteBatch.Draw(TextureManager.LeaderboardHover, new Vector2(leaderboardPos.X, leaderboardPos.Y));
            }

            if (InputManager.IsHovering(settingsPos))
            {
                spriteBatch.Draw(TextureManager.SettingsHover, new Vector2(settingsPos.X, settingsPos.Y));
            }
            

        }
    }
}
