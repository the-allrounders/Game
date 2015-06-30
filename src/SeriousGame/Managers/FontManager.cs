using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Frogano.Managers
{
    class FontManager
    {
        public static SpriteFont MarkerFelt12;
        public static SpriteFont MarkerFelt100;

        public static void Load(ContentManager content)
        {
            MarkerFelt12 = content.Load<SpriteFont>("Fonts/MarkerFelt12");
            MarkerFelt100 = content.Load<SpriteFont>("Fonts/MarkerFelt100");
        }

        public static string WrapText(string text, SpriteFont font, float MaxLineWidth)
        {
            if (font.MeasureString(text).X < MaxLineWidth)
                return text;
            string[] words = text.Split(' ');
            StringBuilder wrappedText = new StringBuilder();
            float linewidth = 0f;
            float spaceWidth = font.MeasureString(" ").X;
            foreach (string t in words)
            {
                Vector2 size = font.MeasureString(t);
                if (linewidth + size.X < MaxLineWidth)
                    linewidth += size.X + spaceWidth;
                else
                {
                    wrappedText.Append("\n");
                    linewidth = size.X + spaceWidth;
                }
                wrappedText.Append(t);
                wrappedText.Append(" ");
            }
            return wrappedText.ToString();
        }
    }
}
