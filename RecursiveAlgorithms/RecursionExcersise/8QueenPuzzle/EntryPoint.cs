namespace _8QueenPuzzle
{
    using System;
    using System.Collections.Generic;

    public class EntryPoint
    {
        public const int Size = 8;

        public static int solutionFound = 0;
        public static bool[,] chessBoard = new bool[Size, Size];
        public static HashSet<int> attackedRows = new HashSet<int>();
        public static HashSet<int> attackedColumns = new HashSet<int>();
        public static HashSet<int> attackedLeftDiagonals = new HashSet<int>();
        public static HashSet<int> attackedRightDiagonals = new HashSet<int>();

        public static void Main()
        {
            PutQueens(0);
            Console.WriteLine(solutionFound);
        }

        public static void PutQueens(int row)
        {
            if (row == Size)
            {
                PrintSolution();
            }
            else
            {
                for (int col = 0; col < Size; col++)
                {
                    if (CanPlaceQueen(row, col))
                    {
                        MarkAllAttackedPositions(row, col);
                        PutQueens(row + 1);
                        UnMarkAllAttackedPositions(row, col);
                    }
                }
            }
        }

        private static void MarkAllAttackedPositions(int row, int col)
        {
            attackedRows.Add(row);
            attackedColumns.Add(col);
            attackedLeftDiagonals.Add(col - row);
            attackedRightDiagonals.Add(row + col);

            chessBoard[row, col] = true;
        }

        private static void UnMarkAllAttackedPositions(int row, int col)
        {
            attackedRows.Remove(row);
            attackedColumns.Remove(col);
            attackedLeftDiagonals.Remove(col - row);
            attackedRightDiagonals.Remove(row + col);

            chessBoard[row, col] = false;
        }

        private static bool CanPlaceQueen(int row, int col)
        {
            bool positionOccupied =
                attackedRows.Contains(row) ||
                attackedColumns.Contains(col) ||
                attackedLeftDiagonals.Contains(col - row) ||
                attackedRightDiagonals.Contains(row + col);

            return !positionOccupied;
        }

        private static void PrintSolution()
        {
            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    if (chessBoard[row, col])
                    {
                        Console.Write('*'+" ");
                    }
                    else
                    {
                        Console.Write('-' + " ");
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine();

            solutionFound++;
        }
    }
}
