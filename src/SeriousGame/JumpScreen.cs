using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGame
{
    class JumpScreen : GameScreen
    {
        int offset = 0;
        
        public override void Load()
        {
            // START THE JUMPING
        }

        public override void Unload()
        {
            // END THE JUMPING
        }

        public override void Update(GameTime gameTime)
        {
            offset += 1;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(TextureManager.Instance.Fly, new Vector2(0, 0 + offset));
            spriteBatch.Draw(TextureManager.Instance.Fly, new Vector2(1050, 650 + offset));

        }
    }
}
