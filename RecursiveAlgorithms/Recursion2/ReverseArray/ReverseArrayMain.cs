namespace ReverseArray
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ReverseArrayMain
    {
        private static StringBuilder result = new StringBuilder();

        public static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            ReverseCollection(numbers, numbers.Length - 1);

            Console.WriteLine(result.ToString().Trim());

            Console.WriteLine();
        }

        private static void ReverseCollection(IList<int> collection, int index)
        {
            if (index == -1)
            {
                return;
            }

            int curentNumber = collection[index];

            // Console.Write("{0} ", curentNumber);

            result.AppendFormat("{0} ", curentNumber);

            ReverseCollection(collection, index - 1);
        }
    }
}
