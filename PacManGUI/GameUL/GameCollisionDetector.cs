using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacMan.GameGL;
namespace PacMan.GameUL
{
    class GameCollisionDetector
    {
        public bool isGhostCollideWithPacMan(GameGhost ghost)
        {
            bool flag = false;
            //Write your Code Here
            for (int i = 0; i < 4; i++)
            {
                GameCell nextCell = ghost.CurrentCell.nextCell((GameDirection)i);
                if (nextCell.CurrentGameObject.GameObjectType == GameObjectType.PLAYER)
                {
                    flag = true;
                }
            }
            return flag;
        }
       /* public bool isGhostCollideWithPallet(GameGhost ghost)
        {
            bool flag = false;
            //Write your Code Here
            for (int i = 0; i < 4; i++)
            {
                GameCell nextCell = ghost.CurrentCell.nextCell((GameDirection)i);
                if (nextCell.CurrentGameObject.GameObjectType == GameObjectType.REWARD)
                {
                    flag = true;
                }
            }
            return flag;
        }
*/
        public bool isPacManCollideWithPallet(GameCell potentialCell)
        {
            bool flag = false;
            //Write your Code Here
            if (potentialCell.CurrentGameObject.GameObjectType == GameObjectType.REWARD)
            {
                flag = true;
            }
            return flag;

        }
    }
}
