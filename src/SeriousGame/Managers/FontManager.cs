﻿using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SeriousGame
{
    class FontManager
    {
        public static SpriteFont Verdana;
        public static SpriteFont VerdanaBold;
        public static SpriteFont VerdanaRegular;

        public static void Load(ContentManager Content)
        {
            Verdana = Content.Load<SpriteFont>("Verdana");
            VerdanaBold = Content.Load<SpriteFont>("Verdana35Bold");
            VerdanaRegular = Content.Load<SpriteFont>("Verdana35Regular");
        }
    }
}
