namespace CombinationsWithRepetition
{
    using System;

    public class CombinationsWithRepetitionMain
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            int[] numbers = new int[k];

            PrintCombinations(numbers, n);
        }

        private static void PrintCombinations(int[] numbers, int endNum, int index = 0, int startNum = 1)
        {
            if (index >= numbers.Length)
            {
                Console.WriteLine("({0})", string.Join(" ", numbers));
            }
            else
            {
                for (int i = startNum; i <= endNum; i++)
                {
                    numbers[index] = i;

                    PrintCombinations(numbers, endNum, index + 1, i);
                }
            }
        }
    }
}

