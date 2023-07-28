using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using PacMan.GameGL;
using EZInput;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PacManGUI
{
    public partial class Form1 : Form
    {
        Game game;
        GameCollisionDetector collider;
        public Form1()
        {
            InitializeComponent();
            game = new Game(this);
            collider = new GameCollisionDetector();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GameGhostVertical gv1 = new GameGhostVertical(game.getBlueGhostImage(), game.getCell(3, 6));
            GameGhostVertical gv3 = new GameGhostVertical(game.getBlueGhostImage(), game.getCell(7, 10));
            GameGhostHorizontal gv2 = new GameGhostHorizontal(game.getOrangeGhostImage(), game.getCell(3, 22));
            GameGhostRandom gv4 = new GameGhostRandom(game.getRedGhostImage(), game.getCell(10, 22));

            game.addGhost(gv1);
            game.addGhost(gv2);
            game.addGhost(gv3);
            game.addGhost(gv4);
        }

        private void gameLoop_Tick(object sender, EventArgs e)
        {
            movePacMan();
            moveGhosts();
            showScore();
        }
        public void moveGhosts()
        {
            foreach (GameGhost g in game.ghosts)
            {
                if (collider.isGhostCollideWithPacMan(g))
                {
                    game.addScorePoints(-1);
                }
                /*if (collider.isGhostCollideWithPallet(g))
                {
                    game.addScorePoints(-1);
                }*/
                g.move(g.nextCell());


            }
        }
        private void showScore()
        {

            lblScoreValue.Text = game.getScore().ToString();
        }
        private void movePacMan()
        {
            GamePacManPlayer pacman = game.getPacManPlayer();
            GameCell potentialNewCell = pacman.CurrentCell;
            if (Keyboard.IsKeyPressed(Key.LeftArrow))
            {
                potentialNewCell = pacman.CurrentCell.nextCell(GameDirection.Left);
            }
            if (Keyboard.IsKeyPressed(Key.RightArrow))
            {
                potentialNewCell = pacman.CurrentCell.nextCell(GameDirection.Right);
            }
            if (Keyboard.IsKeyPressed(Key.UpArrow))
            {
                potentialNewCell = pacman.CurrentCell.nextCell(GameDirection.Up);
            }
            if (Keyboard.IsKeyPressed(Key.DownArrow))
            {
                potentialNewCell = pacman.CurrentCell.nextCell(GameDirection.Down);
            }
            GameCell currentCell = pacman.CurrentCell;
            currentCell.setGameObject(Game.getBlankGameObject());
            if (collider.isPacManCollideWithPallet(potentialNewCell))
            {
                game.addScorePoints(1);
            }
            pacman.move(potentialNewCell);
        }
    }
}
