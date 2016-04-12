namespace PermutationsIteratively
{
    using System;
    using System.Linq;

    public class PermutationsIterativelyMain
    {
        private static long counter = new long();

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int[] arr = Enumerable.Range(1, n).ToArray();
            int[] positions = Enumerable.Range(0, n).ToArray();

            int index = 1;

            PermutationsWithoutRepetition(arr, positions, index);

            Console.WriteLine("Number of permutations: {0}", counter);
        }

        private static void PermutationsWithoutRepetition<T>(T[] arr, int[] positions, int index)
        {
            Print(arr);
            counter++;

            while (index < arr.Length)
            {
                positions[index]--;
                int temp = 0;

                if (index % 2 != 0)
                {
                    temp = positions[index];
                }

                Swap(ref arr[temp], ref arr[index]);

                Print(arr);

                counter++;
                index = 1;

                while (positions[index] == 0)
                {
                    positions[index] = index;
                    index++;

                    if (index >= positions.Length)
                    {
                        break;
                    }
                }
            }
        }

        private static void Print<T>(T[] elements)
        {
            string result = string.Format("[{0}]", string.Join(",", elements));

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
