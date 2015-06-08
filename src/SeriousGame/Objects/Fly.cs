using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGame
{
    class Fly : Collectable
    {
        public Fly(Vector2 pos, int scrWrth)
            : base(pos, TextureManager.Fly, scrWrth)
        {

        }
    }
}