namespace Permutations
{
    using System;
    using System.Linq;

    public class PermutationsMain
    {
        private static long counter = new long();

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int[] arr = Enumerable.Range(1, n).ToArray();

            PermutationsWithoutRepetition(arr);

            Console.WriteLine("Number of permutations: {0}", counter);
        }

        private static void PermutationsWithoutRepetition<T>(T[] arr, int startIndex = 0)
        {
            if (startIndex >= arr.Length)
            {
                counter++;
                Print(arr);
            }
            else
            {
                PermutationsWithoutRepetition<T>(arr, startIndex + 1);

                for (int i = startIndex + 1; i < arr.Length; i++)
                {
                    Swap(ref arr[startIndex], ref arr[i]);
                    PermutationsWithoutRepetition(arr, startIndex + 1);
                    Swap(ref arr[startIndex], ref arr[i]);
                }
            }
        }

        private static void Print<T>(T[] nums)
        {
            string result = string.Format("[{0}]", string.Join(",", nums));

            Console.WriteLine(result);
        }

        static void Swap<T>(ref T first, ref T second)
        {
            if (first.Equals(second))
            {
                return;
            }

            T oldFirst = first;
            first = second;
            second = oldFirst;
        }
    }
}
