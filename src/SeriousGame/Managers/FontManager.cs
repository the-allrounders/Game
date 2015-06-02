using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGame
{
    class FontManager
    {
        private static FontManager _instance;
        public static FontManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FontManager();
                }
                return _instance;
            }
        }


        public SpriteFont Verdana;
        public SpriteFont VerdanaBold;
        public SpriteFont VerdanaRegular;


        public void Load(ContentManager Content)
        {
            this.Verdana = Content.Load<SpriteFont>("Verdana");
            this.VerdanaBold = Content.Load<SpriteFont>("Verdana35Bold");
            this.VerdanaRegular = Content.Load<SpriteFont>("Verdana35Regular");
        }
    }
}
