using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fefteen
{
    class Game
    {
        private Fifteen.Puzzle puzzle = new Fifteen.Puzzle();

        public void Start()
        {
            Console.CursorVisible = false;
            puzzle.FieldMap();
            puzzle.FieldPositions();
            puzzle.ShufflePositions();
            puzzle.PrintMap();
            puzzle.PrintPositions();
            
            while (true)
            {
                puzzle.Move();
                if (puzzle.CheckWin())
                {
                    Console.Clear();
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("You win!");
                    break;
                }
            }
        }
    }
}
