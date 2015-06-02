using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGame
{
    class Obstacle
    {
        private int             _question;
        private string[]        _choices;

        private Vector2         _position;
        private Vector2         _size;
        private Color           _color;
        private Texture2D       _texture;

        private SpriteFont      _font;
        private SpriteFont      _fontBold;

        public Obstacle (Color color, Vector2 position, Vector2 size, int question)
        {
            _question = question;
            _position = position;
            _size = size;
            _color = color;
            _texture = TextureManager.Platform;
            _font = FontManager.Verdana;
            _fontBold = FontManager.VerdanaBold;
        }

        public void Update()
        {
        }

        public void Draw(SpriteBatch spritebatch, int offset)
        {
            spritebatch.Draw(_texture, new Vector2(_position.X, _position.Y + offset), _color);
        }

        public Rectangle boundingBox
        {
            get
            {
                Rectangle rect = new Rectangle((int)_position.X, (int)_position.Y, (int)_size.X, (int)_size.Y); ;
                return rect;
            }
        }

        public void openQuestion (SpriteBatch spritebatch)
        {
            spritebatch.DrawString(_font, "Niels is Koning", new Vector2(10, 10), Color.Black);
        }
    }
}
