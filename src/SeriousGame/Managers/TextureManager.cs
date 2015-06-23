using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SeriousGame.Managers
{
    class TextureManager
    {
        public static Texture2D Splash;

        public static Texture2D Start;
        public static Texture2D StartHover;
        public static Texture2D CreditsHover;
        public static Texture2D LeaderboardHover;
        public static Texture2D SettingsHover;

        public static Texture2D Settings;
        public static Texture2D SettingsLevel1;
        public static Texture2D SettingsLevel2;
        public static Texture2D SettingsLevel3;
        public static Texture2D SettingsCheckboxUnchecked;
        public static Texture2D SettingsCheckboxChecked;
        public static Texture2D[] SettingsFrog = new Texture2D[2];

        public static Texture2D Fly;
        public static Texture2D Platform;
        public static Texture2D[] Frog = new Texture2D[2];
        public static Texture2D Magma;
        public static Texture2D Heart;
        public static Texture2D WonGameBackground;

        public static Texture2D WallLeft;
        public static Texture2D WallRight;
        public static Texture2D LastWallLeft;
        public static Texture2D LastWallRight;

        public static Texture2D InputMedium;
        public static Texture2D Caret;

        public static Texture2D Obstacle;
        public static Texture2D QuestionBox;
        public static Texture2D Good;
        public static Texture2D Wrong;

        public static Texture2D[] IntroBackground = new Texture2D[4];
        public static Texture2D LetterNoBottom;
        public static Texture2D LetterBottom;


        public static void Load(ContentManager content)
        {
            Splash = content.Load<Texture2D>("SplashScreen/Textures/splash");
            Start = content.Load<Texture2D>("StartScreen/Textures/start");
            StartHover = content.Load<Texture2D>("StartScreen/Textures/starthover");
            CreditsHover = content.Load<Texture2D>("StartScreen/Textures/credits");
            LeaderboardHover = content.Load<Texture2D>("StartScreen/Textures/leaderbord");
            SettingsHover = content.Load<Texture2D>("StartScreen/Textures/setting");
            Settings = content.Load<Texture2D>("SettingsScreen/Textures/settings");
            SettingsLevel1 = content.Load<Texture2D>("SettingsScreen/Textures/level1");
            SettingsLevel2 = content.Load<Texture2D>("SettingsScreen/Textures/level2");
            SettingsLevel3 = content.Load<Texture2D>("SettingsScreen/Textures/level3");
            SettingsCheckboxUnchecked = content.Load<Texture2D>("SettingsScreen/Textures/checkbox");
            SettingsCheckboxChecked = content.Load<Texture2D>("SettingsScreen/Textures/checkmark");
            SettingsFrog[0] = content.Load<Texture2D>("SettingsScreen/Textures/boy");
            SettingsFrog[1] = content.Load<Texture2D>("SettingsScreen/Textures/girl");
            Fly = content.Load<Texture2D>("JumpScreen/Textures/FlySpriteSheet");
            Platform = content.Load<Texture2D>("JumpScreen/Textures/platform");
            Frog[0] = content.Load<Texture2D>("JumpScreen/Textures/frog");
            Frog[1] = content.Load<Texture2D>("JumpScreen/Textures/froggirl");
            Magma = content.Load<Texture2D>("JumpScreen/Textures/magma");
            Obstacle = content.Load<Texture2D>("JumpScreen/Textures/obstacle");
            WallLeft = content.Load<Texture2D>("JumpScreen/Textures/wall_left");
            WallRight = content.Load<Texture2D>("JumpScreen/Textures/wall_right");
            LastWallLeft = content.Load<Texture2D>("JumpScreen/Textures/wall_topleft");
            LastWallRight = content.Load<Texture2D>("JumpScreen/Textures/wall_topright");
            InputMedium = content.Load<Texture2D>("JumpScreen/Textures/input_medium");
            Caret = content.Load<Texture2D>("JumpScreen/Textures/caret");
            QuestionBox = content.Load<Texture2D>("JumpScreen/Textures/questionbox");
            Good = content.Load<Texture2D>("JumpScreen/Textures/goed");
            Wrong = content.Load<Texture2D>("JumpScreen/Textures/fout");
            Heart = content.Load<Texture2D>("JumpScreen/Textures/heart");
            WonGameBackground = content.Load<Texture2D>("JumpScreen/Textures/endscreen");
            IntroBackground[0] = content.Load<Texture2D>("IntroScreen/Textures/d1");
            IntroBackground[1] = content.Load<Texture2D>("IntroScreen/Textures/d2");
            IntroBackground[2] = content.Load<Texture2D>("IntroScreen/Textures/d3");
            IntroBackground[3] = content.Load<Texture2D>("IntroScreen/Textures/d4");
            LetterNoBottom = content.Load<Texture2D>("IntroScreen/Textures/letternobottom");
            LetterBottom = content.Load<Texture2D>("IntroScreen/Textures/bottomletter");
        }
    }
}
