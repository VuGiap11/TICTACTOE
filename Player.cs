﻿using System;
using System.Collections.Generic;

namespace TicTacToe
{
    public class Player
    {
        char sign;  //ký hiệu người chơi
        //Khởi tạo người chơi
        public Player(char playerSign = 'X')
        {
            sign = playerSign;
        }
        //Lấy ký hiệu người chơi
        public char getSign()
        {
            return sign;
        }
        //Đọc lượt đi người chơi
        public virtual int takeTurn()
        {
            int fieldNumber = int.Parse(Console.ReadLine());
            return fieldNumber;
        }
        //Xác định 3d thẳng hàng
        private bool checkRowCol(FIELD c1, FIELD c2, FIELD c3)
        {
            return (c1 != FIELD.FLD_EMPTY) && (c1 == c2) && (c2 == c3);
        }
        //Kiểm tra 3d hàng ngang
        private bool checkRowsForWin(Board gameBoard)
        {
            for (int i = 0; i < Board.BOARD_SIZE; i++)
            {
                if (checkRowCol(gameBoard.board[i, 0].getFieldState(),
                        gameBoard.board[i, 1].getFieldState(),
                        gameBoard.board[i, 2].getFieldState()))
                    return true;
            }
            return false;
        }
        //Kiểm tra 3d hàng dọc
        private bool checkColumnsForWin(Board gameBoard)
        {
            for (int i = 0; i < Board.BOARD_SIZE; i++)
            {
                if (checkRowCol(gameBoard.board[0, i].getFieldState(),
                        gameBoard.board[1, i].getFieldState(),
                        gameBoard.board[2, i].getFieldState()))
                    return true;
            }
            return false;
        }
        //Kiểm tra 3d hàng chéo
        private bool checkDiagonalsForWin(Board gameBoard)
        {
            return ((checkRowCol(gameBoard.board[0, 0].getFieldState(),
                    gameBoard.board[1, 1].getFieldState(),
                    gameBoard.board[2, 2].getFieldState()) == true) ||
                    (checkRowCol(gameBoard.board[0, 2].getFieldState(),
                    gameBoard.board[1, 1].getFieldState(),
                    gameBoard.board[2, 0].getFieldState()) == true));
        }
        //Kiểm tra trạng thái
        public bool checkWin(Board gameBoard)
        {
            return (checkRowsForWin(gameBoard) || checkColumnsForWin(gameBoard) || checkDiagonalsForWin(gameBoard));
        }

    }
    public class Robot : Player
    {
        List<int> ints;

        public Robot(char t = 'X')
            : base(t)
        {
            ints = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        }
        public override int takeTurn()
        {

            Random random = new Random();
            int randomIndex = random.Next(ints.Count);


            int randomElement = ints[randomIndex];


            ints.RemoveAt(randomIndex);


            return randomElement;
        }

    }
}