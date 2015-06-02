using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace SeriousGame
{
    class ScreenManager
    {
        private static Vector2 dimensions = new Vector2(1280, 720);
        public static Vector2 Dimensions { 
            private set
            {
                dimensions = value;
            }
            get
            {
                return dimensions;
            }
        }
        public static float leftBound { private set; get; }
        public static float rightBound { private set; get; }

        public static ContentManager Content { private set; get; }

        private static GameScreen _currentScreen;
        public static GameScreen CurrentScreen
        {
            set
            {
                if(_currentScreen != null){
                    _currentScreen.Unload();
                }
                
                value.Load();
                _currentScreen = value;
            }
            get
            {
                return _currentScreen;
            }
        }

        public static Game1 Game;
        
        public static void Load(Game1 game)
        {
            leftBound = 200;
            rightBound = Dimensions.X - 200;
            CurrentScreen = new SplashScreen();
            Game = game;
        }

        public static void UnloadContent()
        {
            
        }

        public static void Update(GameTime gameTime)
        {
            CurrentScreen.Update(gameTime);
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            CurrentScreen.Draw(spriteBatch);
        }


    }
}
