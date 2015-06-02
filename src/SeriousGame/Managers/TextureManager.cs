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
        public Texture2D Fly;
		public Texture2D Platform;
        


        public void Load(ContentManager Content)
        {
            this.Splash = Content.Load<Texture2D>("splash");
            this.Start = Content.Load<Texture2D>("start");
            this.Fly = Content.Load<Texture2D>("fly");
			this.Platform = Content.Load<Texture2D>("platform");
        }
    }
}
