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
        public Vector2 Dimensions { private set; get; }

        public ContentManager Content { private set; get; }

        private GameScreen _currentScreen;
        public GameScreen CurrentScreen
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
                return this._currentScreen;
            }
        }

        private static ScreenManager _instance;
        public static ScreenManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ScreenManager();
                }
                return _instance;
            }
        }

        public ScreenManager()
        {
            Dimensions = new Vector2(1280, 720);
        }
        
        public void Load()
        {
            CurrentScreen = new SplashScreen();
        }

        public void UnloadContent()
        {
            
        }

        public void Update(GameTime gameTime, Game1 game)
        {
            CurrentScreen.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            CurrentScreen.Draw(spriteBatch);
        }


    }
}
