using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SeriousGame.Managers
{
    class TextureManager
    {
        public static Texture2D Splash;
        public static Texture2D Start;

        public static Texture2D Settings;
        public static Texture2D SettingsLevel1;
        public static Texture2D SettingsLevel2;
        public static Texture2D SettingsLevel3;
        public static Texture2D SettingsCheckboxUnchecked;
        public static Texture2D SettingsCheckboxChecked;

        public static Texture2D Fly;
        public static Texture2D Platform;
        public static Texture2D FrogLeft;
		public static Texture2D FrogRight;
        public static Texture2D Magma;
        public static Texture2D Heart;

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

        public static Texture2D[] IntroBackground = new Texture2D[3];
        public static Texture2D LetterNoBottom;
        public static Texture2D LetterBottom;


        public static void Load(ContentManager content)
        {
            Splash = content.Load<Texture2D>("SplashScreen/Textures/splash");
            Start = content.Load<Texture2D>("StartScreen/Textures/start");
            Settings = content.Load<Texture2D>("SettingsScreen/Textures/settings");
            SettingsLevel1 = content.Load<Texture2D>("SettingsScreen/Textures/level1");
            SettingsLevel2 = content.Load<Texture2D>("SettingsScreen/Textures/level2");
            SettingsLevel3 = content.Load<Texture2D>("SettingsScreen/Textures/level3");
            SettingsCheckboxUnchecked = content.Load<Texture2D>("SettingsScreen/Textures/checkbox");
            SettingsCheckboxChecked = content.Load<Texture2D>("SettingsScreen/Textures/checkmark");
            Fly = content.Load<Texture2D>("JumpScreen/Textures/FlySpriteSheet");
            Platform = content.Load<Texture2D>("JumpScreen/Textures/platform");
            FrogLeft = content.Load<Texture2D>("JumpScreen/Textures/frogflip");
            FrogRight = content.Load<Texture2D>("JumpScreen/Textures/frog");
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
            IntroBackground[0] = content.Load<Texture2D>("IntroScreen/Textures/d1");
            IntroBackground[1] = content.Load<Texture2D>("IntroScreen/Textures/d2");
            IntroBackground[2] = content.Load<Texture2D>("IntroScreen/Textures/d3");
            LetterNoBottom = content.Load<Texture2D>("IntroScreen/Textures/letternobottom");
            LetterBottom = content.Load<Texture2D>("IntroScreen/Textures/bottomletter");
        }
    }
}
