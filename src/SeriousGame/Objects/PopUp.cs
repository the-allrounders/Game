using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SeriousGame.Managers;

namespace SeriousGame.Objects
{
    public class Question
    {
        public string QuestionString { get; set; }
        public string RightAnswer { get; set; }
        public List<string> WrongAnswers { get; set; }
        public string WrongText { get; set; }

        public List<string> Answers
        {
            get
            {
                List<string> answers = WrongAnswers;
                answers.Add(RightAnswer);
                answers.Shuffle(); // ofzoiets
                return answers;
            }
        }
    }
    
    class PopUp
    {
        private readonly List<Question> questions = new List<Question>
        {
            new Question
            {
                QuestionString = "Hoe wordt vloeibaar gesteente genoemd dat zich onder het aardoppervlak bevindt?",
                RightAnswer = "Magma",
                WrongAnswers = new List<string>{"Lava", "Karma", "Vloeibaar gesteente"},
                WrongText = "Magma bevindt zich onder het aardoppervlak en lava is wat er uit de vulkaan is gekomen. Het is dus hetzelfde spul, maar dan op een andere plek!"
            },
            new Question
            {
                QuestionString = "Hoe wordt de wolk genoemd die te zien is tijdens een vulkaanuitbarsting?",
                RightAnswer = "Aswolk",
                WrongAnswers = new List<string>{"Vuurwolk", "Rookwolk", "Regenwolk"},
                WrongText = "Tijdens een vulkaanuitbarsting komt er door de hitte veel as vrij. Alles wat er wordt verbrand door de lava verandert in een grote aswolk."
            }
        };



        private readonly string[,] questionss = {
			{"Hoe wordt vloeibaar gesteente genoemd dat zich onder het aardoppervlak bevindt?", 
				"1) Lava","2) Karma", "3) Magma", "4) Vloeibaar gesteente", 
                "Helaas, het goede antwoord was 'magma'. Magma bevindt zich onder het aardoppervlak en lava is wat er uit de vulkaan is gekomen. Het is dus hetzelfde spul, maar dan op een andere plek!"},
			{"Hoe wordt de wolk genoemd die te zien is tijdens een vulkaanuitbarsting?", 
				"1) Vuurwolk", "2) Rookwolk", "3) Aswolk", "4) Regenwolk",
                "Tijdens een vulkaanuitbarsting komt er door de hitte veel as vrij. Alles wat er wordt verbrand door de lava verandert in een grote aswolk."},
			{"Hoe heet een vulkaan die op het moment niet actief is maar wel terug actief kan worden?", 
                "1) Slapende vulkaan","2) Inactieve vulkaan", "3) Rustende vulkaan", "4) Snurkende vulkaan",
                "Nee, een vulkaan die nog actief kan worden heet een slapende vulkaan. Zodra hij nooit meer actief zal worden is het een dode vulkaan."}, 
			{"Hoe worden vulkanen genoemd die zich onder het wateroppervlak bevinden?", 
                "1) Stratovulkanen","2) Oceanische vulkanen", "3) Schildvulkanen", "4) Submarine vulkanen",
                "Het goede antwoord was 'submariene vulkanen'! Wist je dat 75% van alle magma uit submariene vulkanen komt?"},   
			{"Wat is de grootste actieve vulkaan in Europa?", 
               "1) Vesuvius","2) Stromboli", "3) Etna", "4) Vulcano",
                "De Etna ligt in Italië en is met zijn ruim 3300 meter hoogte de grootste van Europa!"},   
			{"Hoe noemt men een vulkaan die is uitgedoofd?", 
				"1) Arme vulkaan","2) Dode vulkaan", "3) Levenloze vulkaan", "4) Een slapende vulkaan",
                "Een vulkaan die nooit meer actief zal worden heet een 'dode vulkaan'. Als een vulkaan wel nog actief kan worden, maar dat nu niet is, heet deze een 'slapende vulkaan'!"},  
			{"Afgekoelde lava is", 
				"1) Vruchtbaar", "2) Warm", "3) Eetbaar", "4) Vloeibaar",
                "Het klinkt misschien vreemd, maar net als as is afgekoelde lava vruchtbaar! En niet zo'n beetje ook!"},  
			{"Welk land heeft de meeste vulkanen?", 
				"1) Italië", "2) Indonesië", "3) Nieuw-Zeeland", "4) Nederland",
                "Indonesië is met zijn 150 vulkanen het land met de meeste vulkanen ter wereld! Hiervan is ruim de helft actief, waardoor er regelmatig uitbarstingen zijn."},
			{"Hoe heet het gat aan de top van een vulkaan?", 
				"1) De krater", "2) De kraterpijp", "3) De mond", "4) De kuil",
                "De gaten in de maan, maar ook de openingen van vulkanen heten 'kraters'!"},
			{"Wat is geen soort vulkaan?", 
				"1) Spleetvulkaan","2) Caldeira","3) Pacificvulkaan", "4) Stratovulkaan",
                "De Pacific mag dan een oceaan zijn (in het Nederlands 'de grote/stille oceaan'), een vulkaan is het niet!"}
			
                                            };
        private readonly int[]  answers = {
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
        private int             _questionNumber;
        private string[]        _choices = new string[100];
        private int             _answer;

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
            spritebatch.Draw(TextureManager.QuestionBox, new Vector2(400, 180));
            spritebatch.DrawString(FontManager.Verdana, FontManager.WrapText(questions[_questionNumber, 0], FontManager.Verdana, 400), new Vector2(440, 200), Color.Black);
            spritebatch.DrawString(FontManager.Verdana, FontManager.WrapText(_choices[0], FontManager.Verdana, 200), new Vector2(440, 280), Color.Black);
            spritebatch.DrawString(FontManager.Verdana, FontManager.WrapText(_choices[1], FontManager.Verdana, 200), new Vector2(440, 330), Color.Black);
            spritebatch.DrawString(FontManager.Verdana, FontManager.WrapText(_choices[2], FontManager.Verdana, 200), new Vector2(440, 380), Color.Black);
            spritebatch.DrawString(FontManager.Verdana, FontManager.WrapText(_choices[3], FontManager.Verdana, 200), new Vector2(440, 430), Color.Black);
            spritebatch.DrawString(FontManager.Verdana, "Beantwoord de vraag met de cijfer toetsen.", new Vector2(440, 500), Color.Black);

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

        public void DrawFeedback(int answer, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(TextureManager.QuestionBox, new Vector2(380, 300));
            spriteBatch.DrawString(FontManager.Verdana, FontManager.WrapText(questions[_questionNumber, 5], FontManager.Verdana, 400), new Vector2(420, 320), Color.Black);
            spriteBatch.DrawString(FontManager.Verdana, "Druk op spatie om weer verder te gaan", new Vector2(420, 620), Color.Black);
        }
    }
}
