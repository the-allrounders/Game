using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SeriousGame.Managers;

namespace SeriousGame.Objects
{
    class PopUp
    {
        private readonly string[,] questions = {
                                                    {"Hoe heet het heete rode spul dat van onderen komt?", 
                                                    "A) Mugma","B) Mogma", "C) Magma", "D) Ian"}, 
                                                    {"Hoe heet de vader van Bart", 
                                                    "A) Peter","B) Henk", "C) Harry", "D) Bart"},   
                                                    {"het is groen en het kan vliegen", 
                                                    "A) Appels","B) Voetballen", "C) Wortels", "D) Groene vogels"},   
                                                    {"Zijn bananen krom?", 
                                                    "A) Ja","B) Nee", "C) Misschien", "D) Als je elleboog op tafel doet misschien"}   
                                            };
        private readonly int[,] answers = {
                                                {3},
                                                {2},
                                                {4},
                                                {1}
        };
        private readonly int questionNumber;
        private readonly string choices;
        private readonly int answer;

        public PopUp(int questionNumber)
        {
            this.questionNumber = questionNumber;
            string asd = "QuestionNumber:" + questionNumber + "  QuestionNumber:" + questions.GetLength(0);
            Console.WriteLine(asd);
            if (questionNumber < questions.GetLength(0))
            {
                choices = questions[questionNumber, 1] + "   " + questions[questionNumber, 2] + "   " + questions[questionNumber, 3] + "   " + questions[questionNumber, 4];
                answer = answers[this.questionNumber, 0];
            }
            else
            {
                choices = choices = questions[0, 1] + "   " + questions[0, 2] + "   " + questions[0, 3] + "   " + questions[0, 4];
                answer = answers[0, 0];
            }

        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.DrawString(FontManager.Verdana, choices, new Vector2(200, 40), Color.White);
            if (questionNumber < questions.GetLength(0))
            {
                spritebatch.DrawString(FontManager.Verdana, questions[questionNumber, 0], new Vector2(200, 20), Color.White);
            }
            else
            {
                spritebatch.DrawString(FontManager.Verdana, questions[0, 0], new Vector2(200, 20), Color.White);

            }
        }

        public Boolean ChooceAnswer(int answer)
        {
            if (this.answer == answer)
            {
                return true;
            }
            return false;
        }
    }
}
