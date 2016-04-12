namespace PathsBetweenCellsInMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PathsBetweenCellsInMatrixMain
    {
        static char[,] maze =
        {
            {'S', ' ', ' ', ' ', ' ', ' '},
            {' ', '*', '*', ' ', '*', ' '},
            {' ', '*', '*', ' ', '*', ' '},
            {' ', '*', 'E', ' ', ' ', ' '},
            {' ', ' ', ' ', '*', ' ', ' '}
        };

        private static int solutionsFound = 0;

        private static Stack<char> path = new Stack<char>();

        public static void Main()
        {
            Move('S');

            Console.WriteLine("Total found paths: {0}", solutionsFound);
        }

        private static void Move(char direction, int row = 0, int col = 0)
        {
            if (IsOutsideTheMaze(row, col))
            {
                return;
            }

            if (maze[row, col] == '*' || maze[row, col] == '.')
            {
                return;
            }

            if (maze[row, col] == 'E')
            {
                solutionsFound++;
                path.Push(direction);
                var revPath = path.Reverse();

                Console.WriteLine();
                Console.WriteLine(string.Join("", revPath));

                PrintMatrix();

                path.Pop();

                return;
            }

            maze[row, col] = '.';

            path.Push(direction);

            Move('L', row, col - 1);
            Move('R', row, col + 1);
            Move('U', row - 1, col);
            Move('D', row + 1, col);

            maze[row, col] = ' ';

            path.Pop();
        }

        private static bool IsOutsideTheMaze(int row, int col)
        {
            bool isOutsideRows = row < 0 || row > maze.GetLength(0) - 1;
            bool isOutsideCols = col < 0 || col > maze.GetLength(1) - 1;

            return isOutsideCols || isOutsideRows;
        }

        private static void PrintMatrix()
        {
            Console.WriteLine(new string('-', 14));

            for (int row = 0; row < maze.GetLength(0); row++)
            {
                Console.Write("|");
                for (int col = 0; col < maze.GetLength(1); col++)
                {
                    Console.Write("{0} ", maze[row, col]);
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine(new string('-', 14));

        }
    }
}
