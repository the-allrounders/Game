using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SeriousGame
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

        public static void Load(ContentManager Content)
        {
            Splash = Content.Load<Texture2D>("splash");
            Start = Content.Load<Texture2D>("start");
            Settings = Content.Load<Texture2D>("settings");
            Fly = Content.Load<Texture2D>("fly");
            Platform = Content.Load<Texture2D>("platform");
            Frog = Content.Load<Texture2D>("frog");
            Magma = Content.Load<Texture2D>("magma");
            Obstacle = Content.Load<Texture2D>("obstacle");
            WallLeft = Content.Load<Texture2D>("wall_left");
            WallRight = Content.Load<Texture2D>("wall_right");
            InputMedium = Content.Load<Texture2D>("input_medium");
            Caret = Content.Load<Texture2D>("caret");
        }
    }
}
