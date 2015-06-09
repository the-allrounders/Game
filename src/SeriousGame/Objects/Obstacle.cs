using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SeriousGame.Managers;
using SeriousGame.Screens;

namespace SeriousGame.Objects
{
    public class Obstacle
    {
        private readonly int question;
        private Vector2 position;
        private readonly Texture2D texture;

        private SpriteFont font;
        private SpriteFont fontBold;
        private PopUp popUp;
        private Boolean done;

        public Obstacle(Vector2 position, int question)
        {
            this.question = question;
            this.position = position;
            texture = TextureManager.Obstacle;
            font = FontManager.Verdana;
            fontBold = FontManager.VerdanaBold;
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
            spritebatch.Draw(texture, new Vector2(190, position.Y + offset));
        }

        public Rectangle BoundingBox
        {
            get
            {
                Rectangle rect = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height); ;
                return rect;
            }
        }

        public void OpenQuestion()
        {
            popUp = new PopUp(question);
        }

        public void DrawQuestion(SpriteBatch spritebatch)
        {
            if (popUp != null)
            {
                popUp.Draw(spritebatch);
            }
        }

        public Boolean CheckAnswer(int answer)
        {
            return popUp.ChooceAnswer(answer);
        }

        public Boolean IsDone()
        {
            return done;
        }

        public void FinishedQuestion()
        {
            done = true;
        }

        public static List<Obstacle> GenerateList()
        {
            int question = -2;
            List<Obstacle> platforms = new List<Obstacle>();
            for (int i = 1000; i > JumpScreen.GameHeight * -1; i -= 2000)
            {
                question++;
                platforms.Add(new Obstacle(new Vector2(50, i), question));
            }
            return platforms;
        }
    }
}
