using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Board
    {
        public const int BOARD_SIZE = 3; // kich thuoc co dinh
        public Cell[,] board; // khai bao ma tran 2 chieu
        // khoi tao bang rong
        public Board()
        {
            board = new Cell[BOARD_SIZE, BOARD_SIZE];
            for (int i = 0; i < BOARD_SIZE; i++)
            {
                for (int j = 0; j < BOARD_SIZE; j++)
                {
                    board[i, j] = new Cell();
                }
            }
        }

        public void printBoard()
        {
            int fieldNumber = 1;

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("______");
            Console.ForegroundColor= ConsoleColor.White;
            for (int i = 0; i < BOARD_SIZE; i++)
            {
                for (int j = 0; j < BOARD_SIZE; j++)
                {
                    if (board[i, j].isEmpty())
                    {
                        Console.Write(fieldNumber);
                    }else
                    {
                        if ((char)(board[i, j].getFieldState()) == 'X')
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        Console.Write((char)(board[i, j].getFieldState()));  //X hay
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    fieldNumber++;
                    Console.ForegroundColor = ConsoleColor.Blue;

                    if (j < BOARD_SIZE)
                    {

                        Console.Write("|");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("_____");
            Console.ForegroundColor = ConsoleColor.White;
        }
        
        public void putMark(Player player, int fieldNumber)
        {
            int verticalY = (fieldNumber - 1) / BOARD_SIZE;
            int horizontalX = (fieldNumber - 1) % BOARD_SIZE;
            if (fieldNumber < 1 || fieldNumber > 9)
            {
                Console.WriteLine("Invalid Input. Please enter number between 1-9!");
                putMark(player, player.takeTurn());
            }
            if (board[verticalY, horizontalX].isEmpty())
            {
                board[verticalY, horizontalX].markField(player);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("this place is taken. Select the field again");
                Console.ForegroundColor = ConsoleColor.White;
                putMark(player, player.takeTurn());
            }
        }
        public void clearBoard()
        {
            Console.Clear();
        }
    }
}
