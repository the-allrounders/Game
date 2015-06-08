using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGame.Objects
{
    class PopUp
    {
        private string[,] _questions = new string[,]{
                                                    {"Hoe heet het heete rode spul dat van onderen komt?", 
                                                    "A) Mugma","B) Mogma", "C) Magma", "D) Ian"}, 
                                                    {"Hoe heet de vader van Bart", 
                                                    "A) Peter","B) Henk", "C) Harry", "D) Bart"},   
                                                    {"het is groen en het kan vliegen", 
                                                    "A) Appels","B) Voetballen", "C) Wortels", "D) Groene vogels"},   
                                                    {"Zijn bananen krom?", 
                                                    "A) Ja","B) Nee", "C) Misschien", "D) Als je elleboog op tafel doet misschien"},   
                                            };
        private int[,] _answers = new int[,] {
                                                {2},
                                                {2},
                                                {4},
                                                {1},
        };
        private int _questionNumber;
        private string _choices;
        private int _answer;
        
        public PopUp(int questionNumber)
        {
            _questionNumber = questionNumber;
            string asd = "QuestionNumber:" + questionNumber + "  QuestionNumber:" + _questions.Length;
            Console.WriteLine(asd);
            if (questionNumber < _questions.Length)
            {
                _choices = _questions[questionNumber, 1] + "   " + _questions[questionNumber, 2] + "   " + _questions[questionNumber, 3] + "   " + _questions[questionNumber, 4];
                _answer = _answers[_questionNumber, 0];
            }
            else
            {
                _choices = _questions[0, 1] + _questions[0, 2] + _questions[0, 3] + _questions[0, 4];
                _answer = _answers[0,0];
            }

        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.DrawString(FontManager.Verdana, _choices, new Vector2(200, 40), Color.Black);
            if (_questions[_questionNumber,0] != null)
            {
                spritebatch.DrawString(FontManager.Verdana, _questions[_questionNumber, 0], new Vector2(200, 20), Color.Black);
            }
            else
            {
                spritebatch.DrawString(FontManager.Verdana, _questions[0, 0], new Vector2(200, 20), Color.Black);
               
            }
        }

        public Boolean chooceAnswer(int answer)
        {
            if (_answer == answer) 
            {
                return true;
            }
            return false;
        }
    }
}
