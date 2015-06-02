using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGame
{
    class SettingsManager
    {
        private static SettingsManager _instance;
        public static SettingsManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SettingsManager();
                }
                return _instance;
            }
        }

        public int Difficulty = 1;
        public bool Music = true;
        public bool Sound = true;

        private bool fullscreen = false;
        public bool Fullscreen
        {
            get
            {
                return fullscreen;
            }
            set
            {
                fullscreen = value;
                ScreenManager.Instance.Game.setFullScreen(value);
            }
        }
    }
}
