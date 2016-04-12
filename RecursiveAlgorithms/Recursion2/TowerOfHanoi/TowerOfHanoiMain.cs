namespace TowerOfHanoi
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TowerOfHanoiMain
    {
        private static int stepsTaken = 0;

        private static Stack<int> source;
        private static readonly Stack<int> destination = new Stack<int>();
        private static readonly Stack<int> spare = new Stack<int>();

        public static void Main()
        {
            Console.Write("Insert n = ");
            int numberOfDisks = int.Parse(Console.ReadLine());

            source = new Stack<int>(Enumerable.Range(1, numberOfDisks).Reverse());

            MoveDisks(numberOfDisks, source, destination, spare);

            Console.WriteLine("Finished in {0} steps", stepsTaken);
        }

        private static void MoveDisks(int bottomDisk, Stack<int> source, Stack<int> destination, Stack<int> spare)
        {
            if (bottomDisk == 1)
            {
                stepsTaken++;
                destination.Push(source.Pop());
                 Console.WriteLine("Steps #{0}:Moved disk {1}", stepsTaken, bottomDisk);
                PrintPegs();
            }
            else
            {
                MoveDisks(bottomDisk - 1, source, spare, destination);
                destination.Push(source.Pop());
                MoveDisks(bottomDisk - 1, spare, destination, source);
            }
        }

        private static void PrintPegs()
        {
            Console.WriteLine("Source: {0}", string.Join(", ", source.Reverse()));
            Console.WriteLine("Destination: {0}", string.Join(", ", destination.Reverse()));
            Console.WriteLine("Spare: {0}", string.Join(", ", spare.Reverse()));
            Console.WriteLine();
        }
    }
}