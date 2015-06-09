using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;

namespace SeriousGame.Managers
{

    public enum Songs
    {
        None,
        SuperMario,
        SuperMarioIce,
    }
    
    class SongManager
    {
        private static Dictionary<Songs, Song> songs;
        private static Songs playing;

        public static bool Muted
        {
            set { MediaPlayer.IsMuted = value; }
        }

        public static void Load(ContentManager content)
        {
            /*songs = new Dictionary<Songs, Song>()
            {
//                {Songs.SuperMario, content.Load<Song>("music_super_mario")},
//                {Songs.SuperMarioIce, content.Load<Song>("music_super_mario_ice_world")}
            };
            MediaPlayer.IsRepeating = true;*/
        }

        public static void Play(Songs song, bool startFromBeginning = false)
        {
            if (!startFromBeginning && playing == song) return;
            //MediaPlayer.Play(songs[song]);
            playing = song;
        }
    }
}
