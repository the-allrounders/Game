using Microsoft.Xna.Framework;

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