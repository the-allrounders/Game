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
        SuperMarioHipHop
    }
    
    class SongManager
    {
        private static Dictionary<Songs, Song> songs;
        private static Songs playing;

        private static bool muted;
        public static bool Muted
        {
            //set { MediaPlayer.IsMuted = value; } MONOGAME BUG WORKAROUND
            get { return muted; }
            set
            {
                muted = value;
                if (muted)
                    MediaPlayer.Stop();
                else
                    Play(playing);
            }

        }

        public static void Load(ContentManager content)
        {
            songs = new Dictionary<Songs, Song>()
            {
                {Songs.SuperMario, content.Load<Song>("StartScreen/Songs/music_super_mario")},
                {Songs.SuperMarioIce, content.Load<Song>("SettingsScreen/Songs/music_super_mario_ice_world")},
                {Songs.SuperMarioHipHop, content.Load<Song>("JumpScreen/Songs/248998_Supah_Mario_Brothaz")}
            };
            MediaPlayer.IsRepeating = true;
        }

        public static void Play(Songs song, bool startFromBeginning = false)
        {
            if (song == Songs.None)
            {
                Stop();
                return;
            }
            if (!startFromBeginning && playing == song) return;
            playing = song;

            if (!muted)
            {
                MediaPlayer.Play(songs[song]);
            }
        }

        public static void Stop()
        {
            playing = Songs.None;
            MediaPlayer.Stop();
        }
    }
}
