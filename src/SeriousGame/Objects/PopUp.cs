using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SeriousGame.Managers;

namespace SeriousGame.Objects
{
    class PopUp
    {
        private readonly string[,] questions = {
			{"Hoe wordt vloeibaar gesteente genoemd dat zich onder het aardoppervlak bevindt?", 
				"1) Lava","2) Karma", "3) Magma", "4) Vloeibaar gesteente"},
			{"Hoe wordt de wolk genoemd die te zien is tijdens een vulkaanuitbarsting?", 
				"1) Vuurwolk", "2) Rookwolk", "3) Aswolk", "4) Regenwolk"},
			{"Hoe heet een vulkaan die op het moment niet actief is maar wel terug actief kan worden?", 
                "1) Slapende vulkaan","2) Inactieve vulkaan", "3) Rustende vulkaan", "4) Snurkende vulkaan"}, 
			{"Hoe worden vulkanen genoemd die zich onder het wateroppervlak bevinden?", 
                "1) Stratovulkanen","2) Oceanische vulkanen", "3) Schildvulkanen", "4) Submarine vulkanen"},   
			{"Wat is de grootste actieve vulkaan in Europa?", 
               "1) Vesuvius","2) Stromboli", "3) Etna", "4) Vulcano"},   
			{"Hoe noemt men een vulkaan die is uitgedoofd?", 
				"1) Arme vulkaan","2) Dode vulkaan", "3) Levenloze vulkaan", "4) Een slapende vulkaan"},  
			{"Afgekoelde lava is", 
				"1) Vruchtbaar", "2) Warm", "3) Eetbaar", "4) Vloeibaar"},  
			{"Welk land heeft de meeste vulkanen?", 
				"1) Italie", "2) Indonesie", "3) Nieuw-Zeeland", "4) Nederland"},
			{"Hoe heet het gat aan de top van een vulkaan?", 
				"1) De krater", "2) De kraterpijp", "3) De mond", "4) De kuil"},
			{"Wat is geen soort vulkaan?", 
				"1) Spleetvulkaan","2) Caldeira","3) Pacificvulkaan", "4) Stratovulkaan"}
			
                                            };
        private readonly int[] answers = {
												3,
												3,
                                                1,
                                                4,
                                                3,
												2,
												1,
												2,
												1,
												3

                                                
        };
        private int _questionNumber;
        private string[] _choices = new string[100];
        private int _answer;

        public PopUp(int questionNumber)
        {
            _questionNumber = questionNumber;
            if (questionNumber < questions.GetLength(0))
            {
                int a = 0;
                for (int i = 1; i <= 4; i++)
                {
                    _choices[a] = questions[_questionNumber, i];
                    a++;
                }
                _answer = answers[_questionNumber];
            }
        }

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(TextureManager.QuestionBox, new Vector2(200, 30));
            spritebatch.DrawString(FontManager.Verdana, questions[_questionNumber, 0], new Vector2(250, 100), Color.Black);
            spritebatch.DrawString(FontManager.Verdana, _choices[0], new Vector2(300, 200), Color.Black);
            spritebatch.DrawString(FontManager.Verdana, _choices[1], new Vector2(760, 200), Color.Black);
            spritebatch.DrawString(FontManager.Verdana, _choices[2], new Vector2(300, 400), Color.Black);
            spritebatch.DrawString(FontManager.Verdana, _choices[3], new Vector2(760, 400), Color.Black);

        }

        public Boolean chooceAnswer(int answer)
        {
            if (_answer == answer)
            {
                Console.WriteLine(_answer +" "+ answer);
                return true;
            }
            return false;
        }
    }
}
