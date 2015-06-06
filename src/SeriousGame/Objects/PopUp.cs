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
                                                    "A) Mugma","B) Mogma", "C) Magma", "D) Ian"}                                          
                                            };
        private int[,] _answer = new int[,] {
                                                {2}
        };
        private int _questionNumber;
        
        public PopUp(int questionNumber)
        {
            _questionNumber = questionNumber;
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.DrawString(FontManager.Verdana, _questions[0,0], new Vector2(20, 20), Color.Black);
        }
    }
}
