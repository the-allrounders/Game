using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGame
{
    class TextureManager
    {
        private static TextureManager _instance;
        public static TextureManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TextureManager();
                }
                return _instance;
            }
        }

        public Texture2D Splash;
        public Texture2D Start;
        public Texture2D Settings;

        public Texture2D Fly;
		public Texture2D Platform;
		public Texture2D Frog;
        


        public void Load(ContentManager Content)
        {
            this.Splash = Content.Load<Texture2D>("splash");
            this.Start = Content.Load<Texture2D>("start");
            this.Settings = Content.Load<Texture2D>("settings");
            this.Fly = Content.Load<Texture2D>("fly");
			this.Platform = Content.Load<Texture2D>("platform");
			this.Frog = Content.Load<Texture2D>("frog");
        }
    }
}
