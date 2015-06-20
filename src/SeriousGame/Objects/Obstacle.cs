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
            spritebatch.Draw(texture, new Vector2(JumpScreen.Padding, position.Y + offset));
        }

        public Rectangle BoundingBox
        {
            get
            {
                Rectangle rect = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
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
            return popUp.chooceAnswer(answer);
        }

        public Boolean IsDone()
        {
            return done;
        }

        public void FinishedQuestion()
        {
            done = true;
        }

        static void Shuffle<T>(T[] array)
        {
            int n = array.Length;
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                int r = i + (int)(random.NextDouble() * (n - i));
                T t = array[r];
                array[r] = array[i];
                array[i] = t;
            }
        }

        public static List<Obstacle> GenerateList()
        {
            List<Obstacle> platforms = new List<Obstacle>();
            int question = 0;
            int[] questionNumbers = {0,1,2,3,4,5,6,7,8,9};
            Shuffle(questionNumbers);
            for (int i = JumpScreen.GameHeight / 10 * -1; i > JumpScreen.GameHeight * -1; i -= JumpScreen.GameHeight / 10)
            {
                Obstacle obstacle = new Obstacle(new Vector2(JumpScreen.Padding, i), questionNumbers[question]);
                platforms.Add(obstacle);
                if (question < questionNumbers.Length - 1)
                {
                    question++;
                }
                else
                {
                    question = 0;
                }
            }
            return platforms;
        }
    }
}

