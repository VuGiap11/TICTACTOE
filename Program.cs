using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class Program
    {
        static void Main(string[] args)
        {

            TicTacToe<string> game = new TicTacToe<string>();
            bool check = true;
            while (check)
            {
                int choose;
                Console.WriteLine("1.[1-1]");
                Console.WriteLine("2.[1-0]");
                Console.WriteLine("3.[0-0]");
                Console.WriteLine("4.exit");
                choose = (int.Parse(Console.ReadLine()));
                switch (choose)
                {
                    case 1:
                        game.play(true, true);
                        break;
                    case 2:
                        game.play(true, false);
                        break;

                    case 3:
                        game.play(false, false);
                        break;
                    case 4:
                        check = false;
                        break;
                }
            }
        }
    }
}
