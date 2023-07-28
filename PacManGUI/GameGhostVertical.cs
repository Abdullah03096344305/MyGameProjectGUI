﻿using System;
using PacMan.GameGL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace PacMan.GameGL
{
    class GameGhostVertical : GameGhost
    {
        GameDirection direction = GameDirection.Down;

        public GameGhostVertical(Image ghostImage, GameCell startCell) : base(ghostImage)
        {
            this.CurrentCell = startCell;
        }

        public override void move(GameCell gameCell)
        {
            if (this.CurrentCell != null)
            {
                this.CurrentCell.setGameObject(Game.getBlankGameObject());

            }
            CurrentCell = gameCell;
        }

        public override GameCell nextCell()
        {

            GameCell nextCell = this.CurrentCell;

            GameCell potentialNextCell = this.CurrentCell.nextCell(direction);

            if (potentialNextCell == nextCell)
            {
                if (direction == GameDirection.Up)
                {
                    direction = GameDirection.Down;
                }
                else if (direction == GameDirection.Down)
                {
                    direction = GameDirection.Up;
                }
            }
            else
            {
                nextCell = potentialNextCell;
            }
            return nextCell;

        }

    }
}
