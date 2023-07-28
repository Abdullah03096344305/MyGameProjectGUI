using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacMan.GameGL;
using System.Drawing;

namespace PacMan.GameUL
{
    public class GameGhostRandom : GameGhost
    {
        private Random random = new Random();

        public GameGhostRandom(Image ghostImage, GameCell startCell)
            : base(ghostImage)
        {
            base.CurrentCell = startCell;
        }

        public override void move(GameCell gameCell)
        {
            if (base.CurrentCell != null)
            {
                base.CurrentCell.setGameObject(Game.getBlankGameObject());
            }

            base.CurrentCell = gameCell;
        }

        public override GameCell nextCell()
        {
            GameDirection[] possibleDirections = { GameDirection.Up, GameDirection.Down, GameDirection.Left, GameDirection.Right };
            GameDirection randomDirection = possibleDirections[random.Next(possibleDirections.Length)];

            GameCell nextCell = base.CurrentCell.nextCell(randomDirection);
            return nextCell;
        }
    }
}
