using System;

namespace SeriousGame
{
    class SettingsManager
    {
        public static int Difficulty = 1;

        public static bool music = true;
        public static bool Music
        {
            get { return music; }
            set
            {
                music = value;
                SongManager.Muted = !value;
            }
        }

        public static bool Sound = true;

        public static readonly bool fullscreenPossible = Environment.OSVersion.ToString().Substring(0, 4) != "Unix";
        private static bool fullscreen;
        public static bool Fullscreen
        {
            get
            {
                return fullscreen;
            }
            set
            {
                fullscreen = (fullscreenPossible && value);
                ScreenManager.Game.Fullscreen = fullscreen;
            }
        }
    }
}
