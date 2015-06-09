using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SeriousGame.Managers
{
    class FontManager
    {
        public static SpriteFont Verdana;
        public static SpriteFont VerdanaBold;
        public static SpriteFont VerdanaRegular;

        public static void Load(ContentManager content)
        {
            Verdana = content.Load<SpriteFont>("Verdana");
            VerdanaBold = content.Load<SpriteFont>("Verdana35Bold");
            VerdanaRegular = content.Load<SpriteFont>("Verdana35Regular");
        }
    }
}
