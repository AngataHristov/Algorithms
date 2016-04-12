namespace ConnectedAreasInMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ConnectedAreasInMatrixMain
    {
        static char[,] matrix =
        {
            {' ', ' ', ' ', '*', ' ',' ',' ','*', ' '},
            {' ', ' ', ' ', '*', ' ',' ',' ','*', ' '},
            {' ', ' ', ' ', '*', ' ',' ',' ','*', ' '},
            {' ', ' ', ' ', ' ', '*',' ','*',' ', ' '}
        };

        private static int counter = 0;

        public static void Main()
        {
            StringBuilder result = new StringBuilder();
            int areaCount = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == ' ')
                    {
                        Move(row, col);

                        areaCount++;

                        result.AppendFormat("Area #{0} at ({1}, {2}), size: {3}\n", areaCount, row, col, counter);

                        counter = 0;
                    }
                }
            }

            Console.WriteLine("Total areas found: {0}", areaCount);
            Console.WriteLine(result.ToString());
        }

        private static void Move(int row, int col)
        {
            if (IsOutsideTheMaze(row, col))
            {
                return;
            }

            if (matrix[row, col] == '*' || matrix[row, col] == '.')
            {
                return;
            }

            matrix[row, col] = '.';

            counter++;

            Move(row, col - 1);
            Move(row, col + 1);
            Move(row - 1, col);
            Move(row + 1, col);
        }

        private static bool IsOutsideTheMaze(int row, int col)
        {
            bool isOutsideRows = row < 0 || row > matrix.GetLength(0) - 1;
            bool isOutsideCols = col < 0 || col > matrix.GetLength(1) - 1;

            return isOutsideCols || isOutsideRows;
        }
    }
}

