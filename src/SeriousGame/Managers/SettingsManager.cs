using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGame
{
    class SettingsManager
    {
        public static int Difficulty = 1;
        public static bool Music = true;
        public static bool Sound = true;

        public static readonly bool fullscreenPossible = Environment.OSVersion.ToString().Substring(0, 4) != "Unix";
        private static bool fullscreen = false;
        public static bool Fullscreen
        {
            get
            {
                return fullscreen;
            }
            set
            {
                fullscreen = (fullscreenPossible && value);
                ScreenManager.Game.setFullScreen(fullscreen);
            }
        }
    }
}
