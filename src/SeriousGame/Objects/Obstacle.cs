using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SeriousGame.Managers;
using SeriousGame.Screens;
using System.Linq;

namespace SeriousGame.Objects
{
    public class Obstacle
    {
        public int question { get; private set; }
        private Vector2 position;
        private readonly Texture2D texture;

        private SpriteFont font;
        private SpriteFont fontBold;
        public PopUp popUp { get; private set; }
        private bool done;

        public Obstacle(Vector2 position, int question)
        {
            this.question = question;
            this.position = position;
            this.popUp = new PopUp(question);
            texture = TextureManager.Obstacle;
            font = FontManager.MarkerFelt12;
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

        public void DrawQuestion(SpriteBatch spritebatch)
        {
            if(popUp != null)
                popUp.Draw(spritebatch);
        }

        public bool CheckAnswer(string answer)
        {
            return popUp.ChooceAnswer(answer);
        }

        public bool IsDone()
        {
            return done;
        }

        public void FinishedQuestion()
        {
            done = true;
        }

        public void DrawFeedback(string answer, SpriteBatch spritebatch)
        {
            popUp.DrawFeedback(answer, spritebatch);
        }

        public static List<Obstacle> GenerateList()
        {
            List<Obstacle> platforms = new List<Obstacle>();
            var nums = Enumerable.Range(0, 10).ToArray();
            var rnd = new Random();

            for (int i = 0; i < nums.Length; ++i)
            {
                int randomIndex = rnd.Next(nums.Length);
                int temp = nums[randomIndex];
                nums[randomIndex] = nums[i];
                nums[i] = temp;
            }
            int a = 0;
            for (int i = JumpScreen.GameHeight / 10 * -1; i > JumpScreen.GameHeight * -1; i -= JumpScreen.GameHeight / 10)
            {
                platforms.Add(new Obstacle(new Vector2(JumpScreen.Padding, i), nums[a]));
                a++;
            }
            return platforms.Randomize();
        }
    }
}

