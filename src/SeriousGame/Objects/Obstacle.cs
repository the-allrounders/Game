using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SeriousGame.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGame
{
    public class Obstacle
    {
        private int             _question;
        private Vector2         _position;
        private Color           _color;
        private Texture2D       _texture;

        private SpriteFont      _font;
        private SpriteFont      _fontBold;
        private PopUp           _popUp;
        private Boolean         _done = false;

        public Obstacle (Color color, Vector2 position, int question)
        {
            _question = question;
            _position = position;
            _color = color;
            _texture = TextureManager.Obstacle;
            _font = FontManager.Verdana;
            _fontBold = FontManager.VerdanaBold;
        }

        public bool IsInViewport(int offset)
        {
            return (
                BoundingBox.Bottom + offset > 0 &&
                BoundingBox.Top + offset < ScreenManager.Dimensions.Y
            );
        }

        public void Update()
        {
        }

        public void Draw(SpriteBatch spritebatch, int offset)
        {
            spritebatch.Draw(_texture, new Vector2(200, _position.Y + offset), _color);
        }

        public Rectangle BoundingBox
        {
            get
            {
                Rectangle rect = new Rectangle((int)_position.X, (int)_position.Y, (int)_texture.Width, (int)_texture.Height); ;
                return rect;
            }
        }

        public void openQuestion ()
        {
            _popUp = new PopUp(_question);
        }

        public void DrawQuestion (SpriteBatch spritebatch)
        {
            if (_popUp != null)
            {
                _popUp.Draw(spritebatch);
            }
        }

        public Boolean checkAnswer(int answer)
        {
            return _popUp.chooceAnswer(answer);
        }

        public Boolean isDone()
        {
            return _done;
        }

        public void finishedQuestion()
        {
            _done = true;
        }
    }
}
