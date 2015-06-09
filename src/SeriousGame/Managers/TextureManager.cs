using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SeriousGame.Managers
{
    class TextureManager
    {
        public static Texture2D Splash;
        public static Texture2D Start;
        public static Texture2D Settings;

        public static Texture2D Fly;
        public static Texture2D Platform;
        public static Texture2D FrogLeft;
		public static Texture2D FrogRight;
        public static Texture2D Magma;

        public static Texture2D Obstacle;

        public static Texture2D WallLeft;
        public static Texture2D WallRight;
        public static Texture2D InputMedium;

        public static void Load(ContentManager content)
        {
            Splash = content.Load<Texture2D>("SplashScreen/Textures/splash");
            Start = content.Load<Texture2D>("StartScreen/Textures/start");
            Settings = content.Load<Texture2D>("SettingsScreen/Textures/settings");
            Fly = content.Load<Texture2D>("JumpScreen/Textures/fly");
            Platform = content.Load<Texture2D>("JumpScreen/Textures/platform");
            FrogLeft = content.Load<Texture2D>("JumpScreen/Textures/frogflip");
            FrogRight = content.Load<Texture2D>("JumpScreen/Textures/frog");
            Magma = content.Load<Texture2D>("JumpScreen/Textures/magma");
            Obstacle = content.Load<Texture2D>("JumpScreen/Textures/obstacle");
            WallLeft = content.Load<Texture2D>("JumpScreen/Textures/wall_left");
            WallRight = content.Load<Texture2D>("JumpScreen/Textures/wall_right");
            InputMedium = content.Load<Texture2D>("JumpScreen/Textures/input_medium");
        }
    }
}
