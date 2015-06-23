using System;

namespace SeriousGame.Managers
{
    class SettingsManager
    {
        public static int Difficulty = 1;

        public static bool ShowControlInfo = true;

        private static bool music = false;
        public static bool Music
        {
            get { return music; }
            set
            {
                music = value;
                SongManager.Muted = !value;
            }
        }

        public static bool Sound = false;

        public static readonly bool FullscreenPossible = Environment.OSVersion.ToString().Substring(0, 4) != "Unix";
        private static bool fullscreen;
        public static bool Fullscreen
        {
            get
            {
                return fullscreen;
            }
            set
            {
                fullscreen = (FullscreenPossible && value);
                ScreenManager.Game.Fullscreen = fullscreen;
            }
        }
        /// <summary>
        /// 0 = boy
        /// 1 = girl
        /// </summary>
        public static int FrogType = 0;
    }
}
