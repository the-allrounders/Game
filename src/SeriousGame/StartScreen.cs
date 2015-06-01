using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGame
{
    class StartScreen : GameScreen
    {
        public override void Load()
        {
            // Startscherm geladen
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            if(Keyboard.GetState().IsKeyDown(Keys.Space)){
                ScreenManager.Instance.CurrentScreen = new JumpScreen();
            }
        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            // TODO: Super cool plaatje met <press space to start>
        }
    }
}
