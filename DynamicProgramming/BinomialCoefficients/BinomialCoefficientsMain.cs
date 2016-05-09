namespace BinomialCoefficients
{
    using System;

    public class BinomialCoefficientsMain
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            int currentRow = 1;

            if (n == 1 && k == 0)
            {
                Console.WriteLine(currentRow);
            }

            long[] lastRowElements = new long[currentRow + 1];

            lastRowElements[0] = 1;
            lastRowElements[currentRow] = 1;

            while (currentRow < n)
            {
                currentRow++;

                long[] currentRowElements = new long[currentRow + 1];

                currentRowElements[0] = 1;

                for (int i = 1; i < currentRow; i++)
                {
                    currentRowElements[i] = lastRowElements[i - 1] + lastRowElements[i];
                }

                currentRowElements[currentRow] = 1;

                lastRowElements = currentRowElements;
            }

            Console.WriteLine(lastRowElements[k]);

            //int[][] array = new int[n + 1][];

            //array = FillArray(array);

            //Console.WriteLine(array[n][k]);
        }

        //private static int[][] FillArray(int[][] array)
        //{
        //    array[0] = new int[1];
        //    array[0][0] = 1;

        //    for (int row = 1; row < array.Length; row++)
        //    {
        //        array[row] = new int[row + 1];

        //        array[row][0] = 1;

        //        for (int col = 1; col < row; col++)
        //        {
        //            array[row][col] = array[row - 1][col - 1] + array[row - 1][col];
        //        }

        //        array[row][row] = 1;
        //    }

        //    return array;
        //}
    }
}
