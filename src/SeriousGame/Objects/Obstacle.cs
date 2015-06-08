using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SeriousGame.Objects;

namespace SeriousGame
{
    public class Obstacle
    {
        private int _question;
        private Vector2 _position;
        private Texture2D _texture;

        private SpriteFont _font;
        private SpriteFont _fontBold;
        private PopUp _popUp;
        private Boolean _done;

        public Obstacle(Vector2 position, int question)
        {
            _question = question;
            _position = position;
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
            spritebatch.Draw(_texture, new Vector2(190, _position.Y + offset));
        }

        public Rectangle BoundingBox
        {
            get
            {
                Rectangle rect = new Rectangle((int)_position.X, (int)_position.Y, _texture.Width, _texture.Height); ;
                return rect;
            }
        }

        public void openQuestion()
        {
            _popUp = new PopUp(_question);
        }

        public void DrawQuestion(SpriteBatch spritebatch)
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

        public static List<Obstacle> GenerateList(int gameHeight)
        {
            int question = -2;
            List<Obstacle> platforms = new List<Obstacle>();
            for (int i = 1000; i > gameHeight * -1; i -= 2000)
            {
                question++;
                platforms.Add(new Obstacle(Color.Red, new Vector2(50, i), question));
            }
            return platforms;
        }
    }
}
