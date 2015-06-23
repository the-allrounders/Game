using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SeriousGame.Managers;

namespace SeriousGame.Screens
{
    class SettingsScreen : GameScreen
    {
        public override void Load()
        {
            SongManager.Play(Songs.SuperMarioIce);
        }

        public override void Update(GameTime gameTime)
        {
            // If ESC button is pressed or if back button is clicked
            if (InputManager.IsPressing(Keys.Escape) || InputManager.IsClicking(new Rectangle(0, 0, 150, 75)))
            {
                ScreenManager.CurrentScreen = new StartScreen();
            }

            // If difficulty is clicked
            else if (InputManager.IsClicking(new Rectangle(300, 60, 500, 75)))
            {
                SettingsManager.Difficulty += 1;
                if (SettingsManager.Difficulty == 4)
                    SettingsManager.Difficulty = 1;
                SoundManager.Play(Sounds.Hammer);
            }

            else if (InputManager.IsClicking(new Rectangle(820, 96, 50, 67)))
            {
                if (SettingsManager.Difficulty != 1) SoundManager.Play(Sounds.Hammer);
                SettingsManager.Difficulty = 1;
                
            }

            else if (InputManager.IsClicking(new Rectangle(870, 96, 53, 67)))
            {
                if (SettingsManager.Difficulty != 2) SoundManager.Play(Sounds.Hammer);
                SettingsManager.Difficulty = 2;
            }

            else if (InputManager.IsClicking(new Rectangle(922, 96, 50, 67)))
            {
                if (SettingsManager.Difficulty != 3) SoundManager.Play(Sounds.Hammer);
                SettingsManager.Difficulty = 3;
            }

            // If music is clicked
            else if (InputManager.IsClicking(new Rectangle(300, 180, 700, 70)))
            {
                SettingsManager.Music = !SettingsManager.Music;
                SoundManager.Play(Sounds.Hammer);
            }

            // If sound is clicked
            else if (InputManager.IsClicking(new Rectangle(300, 295, 700, 70)))
            {
                SettingsManager.Sound = !SettingsManager.Sound;
                SoundManager.Play(Sounds.Hammer);
            }

            // If fullscreen is clicked
            else if (InputManager.IsClicking(new Rectangle(300, 405, 700, 70)))
            {
                SettingsManager.Fullscreen = !SettingsManager.Fullscreen;
                SoundManager.Play(Sounds.Hammer);
            }

            // If difficulty is clicked
            else if (InputManager.IsClicking(new Rectangle(300, 523, 500, 75)))
            {
                if (SettingsManager.FrogType == 0) SettingsManager.FrogType = 1;
                else SettingsManager.FrogType = 0;
                SoundManager.Play(Sounds.Hammer);
            }

            else if (InputManager.IsClicking(new Rectangle(820, 523, 95, 75)))
            {
                if (SettingsManager.FrogType != 0) SoundManager.Play(Sounds.Hammer);
                SettingsManager.FrogType = 0;
            }

            else if (InputManager.IsClicking(new Rectangle(915, 523, 95, 75)))
            {
                if (SettingsManager.FrogType != 1) SoundManager.Play(Sounds.Hammer);
                SettingsManager.FrogType = 1;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            // Draw settings background
            spriteBatch.Draw(TextureManager.Settings, new Vector2(0, 0));

            // Draw difficulty
            if (SettingsManager.Difficulty == 1)
            {
                spriteBatch.Draw(TextureManager.SettingsLevel1, new Vector2(822, 68));
            }
            else if (SettingsManager.Difficulty == 2)
            {
                spriteBatch.Draw(TextureManager.SettingsLevel2, new Vector2(822, 68));
            }
            else
            {
                spriteBatch.Draw(TextureManager.SettingsLevel3, new Vector2(822, 68));
            }

            // Draw music
            if (SettingsManager.Music)
            {
                spriteBatch.Draw(TextureManager.SettingsCheckboxChecked, new Vector2(822, 180));
            }
            else
            {
                spriteBatch.Draw(TextureManager.SettingsCheckboxUnchecked, new Vector2(822, 180));
            }

            // Draw sound
            if (SettingsManager.Sound)
            {
                spriteBatch.Draw(TextureManager.SettingsCheckboxChecked, new Vector2(822, 295));
            }
            else
            {
                spriteBatch.Draw(TextureManager.SettingsCheckboxUnchecked, new Vector2(822, 295));
            }

            // Draw fullscreen
            if (SettingsManager.Fullscreen)
            {
                spriteBatch.Draw(TextureManager.SettingsCheckboxChecked, new Vector2(822, 410));
            }
            else
            {
                spriteBatch.Draw(TextureManager.SettingsCheckboxUnchecked, new Vector2(822, 410));
            }

            // Draw frogs
            spriteBatch.Draw(TextureManager.SettingsFrog[0], new Vector2(822, 523), Color.White * (float)(SettingsManager.FrogType == 0 ? 1 : 0.4));
            spriteBatch.Draw(TextureManager.SettingsFrog[1], new Vector2(920, 523), Color.White * (float)(SettingsManager.FrogType == 1 ? 1 : 0.4));
        }
    }
}
