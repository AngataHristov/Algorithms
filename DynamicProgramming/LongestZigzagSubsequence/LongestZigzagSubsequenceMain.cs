namespace LongestZigzagSubsequence
{
    using System;
    using System.Linq;

    public class LongestZigzagSubsequenceMain
    {
        private static int[] numbers;
        private static int[] lengths;
        private static int[] prevIndeces;
        private static int[] difference;

        private static int maxLength;
        private static int lastIndex;

        public static void Main()
        {
            numbers = Console.ReadLine()
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            maxLength = 0;
            lastIndex = -1;

            lengths = new int[numbers.Length];
            prevIndeces = new int[numbers.Length];
            difference = new int[numbers.Length];

            FindLongestZigzagSubsequence();
            var result = RestoreSubsequence();
            Console.WriteLine(string.Join(" ", result));
        }

        private static void FindLongestZigzagSubsequence()
        {
            for (int x = 0; x < numbers.Length; x++)
            {
                lengths[x] = 1;
                prevIndeces[x] = -1;
                difference[x] = 0;

                for (int i = 0; i < x; i++)
                {
                    int currentDiff = numbers[x] - numbers[i];
                    bool isZigZag = (difference[i] < 0 && currentDiff > 0) ||
                                    (difference[i] > 0 && currentDiff < 0);

                    if ((difference[i] == 0 || isZigZag)
                        && lengths[i] + 1 > lengths[x])
                    {
                        lengths[x] = lengths[i] + 1;
                        prevIndeces[x] = i;
                        difference[x] = currentDiff;
                    }
                }

                if (lengths[x] > maxLength)
                {
                    maxLength = lengths[x];
                    lastIndex = x;
                }
            }
        }

        private static int[] RestoreSubsequence()
        {
            int[] result = new int[maxLength];
            int index = maxLength - 1;

            while (lastIndex != -1)
            {
                result[index] = numbers[lastIndex];
                lastIndex = prevIndeces[lastIndex];
                index--;
            }

            return result;
        }
    }
}
