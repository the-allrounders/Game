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

        private List<string> answers = new List<string>();
        public List<string> Answers
        {
            get
            {
                if (answers.Count == 0)
                {
                    answers = WrongAnswers;
                    answers.Add(RightAnswer);
                    answers = answers.Randomize();
                }
                return answers;
            }
        }
    }
    
    public class PopUp
    {
        public readonly List<Question> questions = new List<Question>
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
            },
            new Question
            {
                QuestionString = "Hoe heet een vulkaan die op het moment niet actief is maar wel terug actief kan worden?",
                RightAnswer = "Slapende vulkaan",
                WrongAnswers = new List<string>{"Inactieve vulkaan", "Rustende vulkaan", "Snurkende vulkaan"},
                WrongText = "Nee, een vulkaan die nog actief kan worden heet een slapende vulkaan. Zodra hij nooit meer actief zal worden is het een dode vulkaan."
            },
            new Question
            {
                QuestionString = "Hoe worden vulkanen genoemd die zich onder het wateroppervlak bevinden?",
                RightAnswer = "Submariene vulkanen",
                WrongAnswers = new List<string>{ "Stratovulkanen", "Oceanische vulkanen", "Schildvulkanen"},
                WrongText = "Het goede antwoord was 'submariene vulkanen'! Wist je dat 75% van alle magma uit submariene vulkanen komt?"
            },
            new Question
            {
                QuestionString = "Wat is de grootste actieve vulkaan in Europa?",
                RightAnswer = "Etna",
                WrongAnswers = new List<string>{"Vesuvius", "Stromboli", "Vulcano"},
                WrongText = "De Etna ligt in Italië en is met zijn ruim 3300 meter hoogte de grootste van Europa!"
            },
            new Question
            {
                QuestionString = "Hoe noemt men een vulkaan die is uitgedoofd?",
                RightAnswer = "Dode vulkaan",
                WrongAnswers = new List<string>{"Arme vulkaan", "Levenloze vulkaan", "Slapende vulkaan"},
                WrongText = "Een vulkaan die nooit meer actief zal worden heet een 'dode vulkaan'. Als een vulkaan wel nog actief kan worden, maar dat nu niet is, heet deze een 'slapende vulkaan'!"
            },
            new Question
            {
                QuestionString = "Afgekoelde lava is:",
                RightAnswer = "Vruchtbaar",
                WrongAnswers = new List<string>{"Warm", "Eetbaar", "Vloeibaar"},
                WrongText = "Het klinkt misschien vreemd, maar net als as is afgekoelde lava vruchtbaar! En niet zo'n beetje ook!"
            },
            new Question
            {
                QuestionString = "Welk land heeft de meeste vulkanen?",
                RightAnswer = "Indonesië",
                WrongAnswers = new List<string>{ "Italië", "Nieuw-Zeeland", "Nederland"},
                WrongText = "Indonesië is met zijn 150 vulkanen het land met de meeste vulkanen ter wereld! Hiervan is ruim de helft actief, waardoor er regelmatig uitbarstingen zijn."
            },
            new Question
            {
                QuestionString = "Hoe heet het gat aan de top van een vulkaan?",
                RightAnswer = "De krater",
                WrongAnswers = new List<string>{ "De kraterpijp", "De mond", "De kuil"},
                WrongText = "De gaten in de maan, maar ook de openingen van vulkanen heten 'kraters'!"
            },
            new Question
            {
                QuestionString = "Wat is geen soort vulkaan?",
                RightAnswer = "Pacificvulkaan",
                WrongAnswers = new List<string>{ "Spleetvulkaan", "Caldeira", "Stratovulkaan"},
                WrongText = "De Pacific mag dan een oceaan zijn (in het Nederlands 'de grote/stille oceaan'), een vulkaan is het niet!"
            }
        };

        private readonly int questionNumber;

        public PopUp(int questionNumber)
        {
            this.questionNumber = questionNumber;
        }

        public void Draw(SpriteBatch spritebatch)
        {
            int lineWidth = 400;
            SpriteFont font = FontManager.Verdana;
            string question = FontManager.WrapText(questions[questionNumber].QuestionString, FontManager.Verdana, 400);
            string answer1 = FontManager.WrapText("1) " + questions[questionNumber].Answers[0], FontManager.Verdana, 200);
            string answer2 = FontManager.WrapText("2) " + questions[questionNumber].Answers[1], FontManager.Verdana, 200);
            string answer3 = FontManager.WrapText("3) " + questions[questionNumber].Answers[2], FontManager.Verdana, 200);
            string answer4 = FontManager.WrapText("4) " + questions[questionNumber].Answers[3], FontManager.Verdana, 200);
            const int margin = 10;
            float totalHeight = font.MeasureString(question).Y + font.MeasureString(answer1).Y + font.MeasureString(answer2).Y + font.MeasureString(answer3).Y + font.MeasureString(answer4).Y + (margin * 2) +100;
            spritebatch.Draw(TextureManager.QuestionBox, new Vector2(ScreenManager.Dimensions.X / 2 - TextureManager.QuestionBox.Width / 2, ScreenManager.Dimensions.Y / 2 - TextureManager.QuestionBox.Height / 2));
            spritebatch.DrawString(FontManager.Verdana, question, new Vector2(ScreenManager.Dimensions.X / 2 - lineWidth / 2, (ScreenManager.Dimensions.Y / 2 - totalHeight / 2)), Color.Black);
            spritebatch.DrawString(FontManager.Verdana, answer1, new Vector2(ScreenManager.Dimensions.X / 2 - lineWidth / 2, (ScreenManager.Dimensions.Y / 2 - totalHeight / 2) + font.MeasureString(question).Y + margin), Color.Black);
            spritebatch.DrawString(FontManager.Verdana, answer2, new Vector2(ScreenManager.Dimensions.X / 2 - lineWidth / 2, (ScreenManager.Dimensions.Y / 2 - totalHeight / 2) + font.MeasureString(question).Y + margin + font.MeasureString(answer1).Y + margin), Color.Black);
            spritebatch.DrawString(FontManager.Verdana, answer3, new Vector2(ScreenManager.Dimensions.X / 2 - lineWidth / 2, (ScreenManager.Dimensions.Y / 2 - totalHeight / 2) + font.MeasureString(question).Y + margin + font.MeasureString(answer1).Y + margin + font.MeasureString(answer2).Y + margin), Color.Black);
            spritebatch.DrawString(FontManager.Verdana, answer4, new Vector2(ScreenManager.Dimensions.X / 2 - lineWidth / 2, (ScreenManager.Dimensions.Y / 2 - totalHeight / 2) + font.MeasureString(question).Y + margin + font.MeasureString(answer1).Y + margin + font.MeasureString(answer2).Y + margin + font.MeasureString(answer3).Y + margin), Color.Black);
            spritebatch.DrawString(FontManager.Verdana, "Beantwoord de vraag met de cijfer toetsen.", new Vector2(ScreenManager.Dimensions.X / 2 - lineWidth / 2, (ScreenManager.Dimensions.Y / 2 - totalHeight / 2) + font.MeasureString(question).Y + margin + font.MeasureString(answer1).Y + margin + font.MeasureString(answer2).Y + margin + font.MeasureString(answer3).Y + margin + font.MeasureString(answer4).Y + margin), Color.Black);

        }

        public bool ChooceAnswer(string answer)
        {
            return answer == questions[questionNumber].RightAnswer;
        }

        public void DrawFeedback(string answer, SpriteBatch spriteBatch)
        {
            int lineWidth = 400;
            SpriteFont font = FontManager.Verdana;
            string feedback = FontManager.WrapText(questions[questionNumber].WrongText,FontManager.Verdana, 400);
            const int margin = 10;
            float totalHeight = font.MeasureString(feedback).Y + (margin * 2) + 100;
            spriteBatch.Draw(TextureManager.QuestionBox, new Vector2(ScreenManager.Dimensions.X / 2 - TextureManager.QuestionBox.Width / 2, ScreenManager.Dimensions.Y / 2 - TextureManager.QuestionBox.Height / 2 ));
            spriteBatch.DrawString(FontManager.Verdana, feedback, new Vector2(ScreenManager.Dimensions.X / 2 - lineWidth / 2, (ScreenManager.Dimensions.Y / 2 - totalHeight / 2)), Color.Black);
            spriteBatch.DrawString(FontManager.Verdana, "Druk op spatie om weer verder te gaan", new Vector2(ScreenManager.Dimensions.X / 2 - lineWidth / 2, (ScreenManager.Dimensions.Y / 2 - totalHeight / 2) + font.MeasureString(feedback).Y + margin + 50), Color.Black);
        }
    }
}
