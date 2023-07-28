using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace PacMan.GameGL
{
    public abstract class GameGhost : GameObject
    {
        public GameGhost(Image ghostImage) : base(GameObjectType.ENEMY, ghostImage)
        {
        }
        public abstract GameCell nextCell();
        public abstract void move(GameCell gameCell);
    }
}
