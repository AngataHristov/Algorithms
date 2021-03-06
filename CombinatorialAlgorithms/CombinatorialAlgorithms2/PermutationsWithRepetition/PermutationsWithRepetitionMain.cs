﻿namespace PermutationsWithRepetition
{
    using System;
    using System.Linq;

    public class PermutationsWithRepetitionMain
    {
        public static void Main()
        {
            int[] elements = Console.ReadLine()
                                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();

            Array.Sort(elements);
            PermuteRep(elements, 0, elements.Length - 1);
        }

        static void PermuteRep(int[] arr, int start, int end)
        {
            Print(arr);

            for (int left = end - 1; left >= start; left--)
            {
                for (int right = left + 1; right <= end; right++)
                {
                    if (arr[left] != arr[right])
                    {
                        Swap(ref arr[left], ref arr[right]);
                        PermuteRep(arr, left + 1, end);
                    }
                }

                var firstElement = arr[left];
                for (int i = left; i <= end - 1; i++)
                {
                    arr[i] = arr[i + 1];
                }
                arr[end] = firstElement;
            }
        }

        static void Print<T>(T[] arr)
        {
            Console.WriteLine("(" + string.Join(", ", arr) + ")");
        }

        static void Swap<T>(ref T first, ref T second)
        {
            T oldFirst = first;
            first = second;
            second = oldFirst;
        }
    }
}

