using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SeriousGame.Managers
{
    class FontManager
    {
        public static SpriteFont Verdana;
        public static SpriteFont VerdanaBold;

        public static void Load(ContentManager content)
        {
            Verdana = content.Load<SpriteFont>("Fonts/Verdana");
            VerdanaBold = content.Load<SpriteFont>("Fonts/Verdana");
        }

        public static string WrapText(string text, SpriteFont font, float MaxLineWidth)
        {
            if (font.MeasureString(text).X < MaxLineWidth)
            {
                return text;
            }

            string[] words = text.Split(' ');
            StringBuilder wrappedText = new StringBuilder();
            float linewidth = 0f;
            float spaceWidth = font.MeasureString(" ").X;
            for (int i = 0; i < words.Length; ++i)
            {
                Vector2 size = font.MeasureString(words[i]);
                if (linewidth + size.X < MaxLineWidth)
                {
                    linewidth += size.X + spaceWidth;
                }
                else
                {
                    wrappedText.Append("\n");
                    linewidth = size.X + spaceWidth;
                }
                wrappedText.Append(words[i]);
                wrappedText.Append(" ");
            }

            return wrappedText.ToString();
        }
    }
}
