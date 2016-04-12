namespace RecursionExcersise
{
    using System;
    using System.Linq;

    public class EntryPoint
    {
        public static int counter = 0;

        public static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int sum = FindSum(numbers);

            Console.WriteLine("Sum: {0}", sum);

            Gen01(new int[8]);
            Console.WriteLine(counter);
        }

        private static int FindSum(int[] numbers, int index = 0)
        {
            if (index == numbers.Length)
            {
                return 0;
                // return numbers[numbers.Length - 1];
            }

            return numbers[index] + FindSum(numbers, index + 1);
        }

        private static void Gen01(int[] vector, int index = 7)
        {
            if (index == -1)
            {
                Console.WriteLine(string.Join("", vector));
                return;
            }

            counter++;

            for (int i = 0; i <= 1; i++)
            {
                vector[index] = i;
                Gen01(vector, index - 1);
            }
        }
    }
}
