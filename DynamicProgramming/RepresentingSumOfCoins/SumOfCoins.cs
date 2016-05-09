namespace RepresentingSumOfCoins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SumOfCoins
    {
        private static int targetSum;
        private static int[] coins;
        private static int totalSums;

        public static void Main(string[] args)
        {
            targetSum = int.Parse(Console.ReadLine());
            coins = Console.ReadLine().Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            totalSums = 0;
            CalculatePossibleSums(0, 0);
            Console.WriteLine(totalSums);
        }

        private static void CalculatePossibleSums(int sum, int start)
        {
            if (sum == targetSum)
            {
                totalSums++;

                return;
            }

            if (sum > targetSum)
            {
                return;
            }

            for (int i = start; i < coins.Length; i++)
            {
                CalculatePossibleSums(sum + coins[i], i + 1);
            }
        }
    }
}
