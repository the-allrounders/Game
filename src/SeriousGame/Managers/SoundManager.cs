using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGame.Managers
{
    public enum Sounds
    {
        Coin
    }
    
    class SoundManager
    {
        private static Dictionary<Sounds, SoundEffect> sounds;

        public static void Load(ContentManager content)
        {
            sounds = new Dictionary<Sounds, SoundEffect>()
            {
                {Sounds.Coin, content.Load<SoundEffect>("JumpScreen/Sounds/nsmb_coin")}
            };
        }

        public static void Play(Sounds sound)
        {
            if (SettingsManager.Sound) sounds[sound].Play();
        }
    }
}
