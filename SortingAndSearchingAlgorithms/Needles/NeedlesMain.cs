namespace Needles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class NeedlesMain
    {
        public static void Main()
        {
            int[] sizes = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] numbersWithHoles = new int[sizes[0]];
            numbersWithHoles = Console.ReadLine()
             .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
             .Select(int.Parse)
             .ToArray();

            int[] needles = new int[sizes[0]];
            needles = Console.ReadLine()
                 .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();

            List<int> indeces = FillTheGaps(numbersWithHoles, needles);

            Console.WriteLine(string.Join(" ", indeces));
        }

        private static List<int> FillTheGaps(int[] numbersWithHoles, int[] needles)
        {
            List<int> indexes = new List<int>();

            for (int i = 0; i < needles.Length; i++)
            {
                for (int j = 1; j < numbersWithHoles.Length; j++)
                {
                    if (needles[i] <= numbersWithHoles[0])
                    {
                        indexes.Add(0);
                        break;
                    }

                    if (j < numbersWithHoles.Length - 1 && numbersWithHoles[j] == 0)
                    {
                        int counter = j;
                        int previous = numbersWithHoles[j - 1];
                        while (numbersWithHoles[counter] == 0)
                        {
                            counter++;
                        }

                        int next = numbersWithHoles[counter];
                        if (needles[i] >= previous && needles[i] <= next)
                        {
                            indexes.Add(j);
                            break;
                        }

                        j = counter;
                    }

                    if (needles[i] >= numbersWithHoles[j - 1] && needles[i] <= numbersWithHoles[j])
                    {
                        indexes.Add(j);
                        break;
                    }

                    if (numbersWithHoles[numbersWithHoles.Length - 1] != 0 && needles[i] > numbersWithHoles[numbersWithHoles.Length - 1])
                    {
                        indexes.Add(numbersWithHoles.Length);
                        break;
                    }
                }
            }

            return indexes;
        }
    }
}
