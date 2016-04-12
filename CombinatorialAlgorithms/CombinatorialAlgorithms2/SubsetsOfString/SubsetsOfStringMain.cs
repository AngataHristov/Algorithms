namespace SubsetsOfString
{
    using System;
    using System.Linq;

    public class SubsetsOfStringMain
    {
        public static void Main()
        {
            string[] words = Console.ReadLine()
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            int k = int.Parse(Console.ReadLine());

            int[] arr = new int[k];
            GenerateSubsets(words, arr, k);
        }

        private static void GenerateSubsets<T>(T[] words, int[] arr, int k, int index = 0, int start = 0)
        {
            if (index >= k)
            {
                PrintCombinations(words, arr);
            }
            else
            {
                for (int i = start; i < words.Length; i++)
                {
                    arr[index] = i;
                    GenerateSubsets<T>(words, arr, k, index + 1, i + 1);
                }
            }
        }

        private static void PrintCombinations<T>(T[] words, int[] arr)
        {
            Console.WriteLine("({0})", string.Join(", ", arr.Select(i => words[i])));
        }
    }
}
