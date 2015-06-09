using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SeriousGame.Managers;

namespace SeriousGame.Objects
{
    class PopUp
    {
        private readonly string[,] questions = {
			{"Hoe noemt men vloeibaar gesteente dat zich onder het aardoppervlak bevindt?", 
				"1) Lava","2) Karma", "3) Magma", "4) Vulva"},
			{"Hoe wordt de wolk genoemd die te zien is tijdens een vulkaanuitbarsting?", 
				"1) Vuurwolk", "2) Rookwolk", "3) Aswolk"}
			{"Hoe noemt men een vulkaan dat op het moment niet actief is maar wel terug actief kan worden?", 
                "1) Slapende vulkaan","2) Inactieve vulkaan", "3) Rustende vulkaan", "4) Snurkende vulkaan"}, 
			{"Hoe worden vulkanen genoemd die zich onder het wateroppervlak bevinden?", 
                "1) Stratovulkanen","2) Oceanische vulkanen", "3) Schildvulkanen", "4) Submarine vulkanen"},   
			{"Wat is de grootste actieve vulkaan in Europa?", 
               "1) Vesuvius","2) Stromboli", "3) Etna", "4) Vulcano"},   
			{"Hoe noemt men een vulkaan die is uitgedooft?", 
				"1) Arme vulkaan","2) Dode vulkaan", "3) Levensloze vulkaan"},  
			{"Stelling: Afgekoelde lava is vruchtbaar", 
				"1) Onjuist", "2) juist"},  
			{"Welk land heeft de meeste vulkanen?", 
				"1) Italië", "2) Indonesië", "3) Nieuw-Zeeland"},
			{"Hoe heet het gat aan de top van een vulkaan?", 
				"1) De krater", "2) De kraterpijp", "3) De mond"},
			{"Wat is geen soort vulkaan?", 
				"1) Spleetvulkaan","2) Caldeira","3) Pacificvulkaan ", "4) Stratovulkaan", "5) Schildvulkaan"},
			
                                            };
        private readonly int[,] answers = {
												{3},
												{3},
                                                {1},
                                                {4},
                                                {3},
												{2},
												{2},
												{2},
												{1},
												{3}

                                                
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
