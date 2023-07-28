using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class TicTacToe<T>
    {
        //Khoi tao
        public TicTacToe()
        {

        }

        //Luot choi
        public void play(bool t1, bool t2)
        {
            int moveCounter = 0;
            Board gameBoard = new Board();
            var playerX = t1 ? new Player('X') : new Robot('X');
            var playerO = t2 ? new Player('O') : new Robot('O');
            var currentPlayer = playerX;


            while (true)
            {
                gameBoard.printBoard();
                Console.WriteLine("Player: {0} Enter the field in which you want to put the character: ", currentPlayer.getSign());
                gameBoard.putMark(currentPlayer, currentPlayer.takeTurn());
                gameBoard.clearBoard();
                moveCounter++;
                if (currentPlayer.checkWin(gameBoard))
                {
                    Console.WriteLine("Player: {0} won!", currentPlayer.getSign());
                    gameBoard.printBoard();
                    break;
                }
                else if (checkDraw(moveCounter))
                {
                    Console.WriteLine("DRAW");
                    gameBoard.printBoard();
                    break;
                }
                currentPlayer = (moveCounter % 2 == 0) ? playerX : playerO;
            }
        }

        //Kiem tra luot di cuoi
        private bool checkDraw(int turnCounter)
        {
            if (turnCounter == 9)
                return true;
            return false;
        }
    }
}
