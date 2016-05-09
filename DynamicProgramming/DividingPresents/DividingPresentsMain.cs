namespace DividingPresents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DividingPresentsMain
    {
        public static void Main()
        {
            int[] gifts = Console.ReadLine()
                .Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int targetPrice = gifts.Sum(a => a) / 2;
            var maxPrice = new int[gifts.Length, targetPrice + 1];
            var isTaken = new bool[gifts.Length, targetPrice + 1];

            for (int price = 0; price <= targetPrice; price++)
            {
                if (gifts[0] <= price)
                {
                    maxPrice[0, price] = gifts[0];
                    isTaken[0, price] = true;
                }
            }

            for (int i = 1; i < gifts.Length; i++)
            {
                for (int c = 0; c <= targetPrice; c++)
                {
                    maxPrice[i, c] = maxPrice[i - 1, c];
                    int left = c - gifts[i];

                    if (left > 0 &&
                        maxPrice[i - 1, left] + gifts[i] > maxPrice[i - 1, c])
                    {
                        maxPrice[i, c] = maxPrice[i - 1, left] + gifts[i];
                        isTaken[i, c] = true;
                    }
                }
            }

            var giftsTaken = new List<int>();
            var itemIdex = gifts.Length - 1;

            while (itemIdex >= 0)
            {
                if (isTaken[itemIdex, targetPrice])
                {
                    giftsTaken.Add(gifts[itemIdex]);
                    targetPrice -= gifts[itemIdex];
                }

                itemIdex--;
            }

            int firstSum = giftsTaken.Sum(n => n);
            int secondSum = gifts.Sum() - firstSum;
            int difference = Math.Abs(firstSum - secondSum);

            Console.WriteLine("Difference: " + difference);
            Console.WriteLine("Alan:{0} Bob:{1}", firstSum, secondSum);
            Console.WriteLine("Alan takes:" + string.Join(", ", giftsTaken));
            Console.WriteLine("Bob takes the rest.");
        }
    }
}
