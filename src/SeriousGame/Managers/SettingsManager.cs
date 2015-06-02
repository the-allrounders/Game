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

        private static bool fullscreen = false;
        public static bool Fullscreen
        {
            get
            {
                return fullscreen;
            }
            set
            {
                fullscreen = value;
                ScreenManager.Game.setFullScreen(value);
            }
        }
    }
}
