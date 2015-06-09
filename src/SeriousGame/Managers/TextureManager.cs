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
        public static Texture2D Frog;
        public static Texture2D Magma;

        public static Texture2D Obstacle;

        public static Texture2D WallLeft;
        public static Texture2D WallRight;
        public static Texture2D InputMedium;
        public static Texture2D Caret;

        public static void Load(ContentManager content)
        {
            Splash = content.Load<Texture2D>("splash");
            Start = content.Load<Texture2D>("start");
            Settings = content.Load<Texture2D>("settings");
            Fly = content.Load<Texture2D>("fly");
            Platform = content.Load<Texture2D>("platform");
            Frog = content.Load<Texture2D>("frog");
            Magma = content.Load<Texture2D>("magma");
            Obstacle = content.Load<Texture2D>("obstacle");
            WallLeft = content.Load<Texture2D>("wall_left");
            WallRight = content.Load<Texture2D>("wall_right");
            InputMedium = content.Load<Texture2D>("input_medium");
            Caret = content.Load<Texture2D>("caret");
        }
    }
}
