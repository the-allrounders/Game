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
        private static ScreenManager _instance;
        public Vector2 Dimensions { private set; get; }

        public ContentManager Content { private set; get; }

        private GameScreen currentScreen;
        public GameScreen CurrentScreen
        {
            set
            {
                this.currentScreen = value;
            }
            get
            {
                return this.currentScreen;
            }
        }

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
            CurrentScreen = new JumpScreen();
        }
        
        public void LoadContent(ContentManager Content)
        {
            this.Content = new ContentManager(Content.ServiceProvider, "Content");
            CurrentScreen.LoadContent();
            TextureManager.Instance.Load();
        }

        public void UnloadContent()
        {
            CurrentScreen.UnloadContent();
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
