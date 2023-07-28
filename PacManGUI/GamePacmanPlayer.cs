using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Threading.Tasks;

namespace PacMan.GameGL
{
    public class GamePacManPlayer : GameObject
    {
        public GamePacManPlayer(Image image, GameCell startCell) : base(GameObjectType.PLAYER, image)
        {
            this.CurrentCell = startCell;
        }

        public void move(GameCell gameCell)
        {
            CurrentCell = gameCell;
        }
    }
}
