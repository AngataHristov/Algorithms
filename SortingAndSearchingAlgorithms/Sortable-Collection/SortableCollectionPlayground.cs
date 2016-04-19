namespace Sortable_Collection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Sortable_Collection.Sorters;

    public class SortableCollectionPlayground
    {
        private static Random Random = new Random();

        public static void Main(string[] args)
        {
            const int NumberOfElementsToSort = 100;
            const int MaxValue = 999;

            var array = new int[NumberOfElementsToSort];

            for (int i = 0; i < NumberOfElementsToSort; i++)
            {
                array[i] = Random.Next(MaxValue);
            }

            var collectionToSort = new SortableCollection<int>(array);
            collectionToSort.Sort(new BucketSorter
            {
                Max = MaxValue
            });

            Console.WriteLine(collectionToSort);

            Console.WriteLine(new string('*', 20));

            var collection = new SortableCollection<int>(2, -1, 5, 0, -3);
            Console.WriteLine(collection);

            collection.Sort(new Quicksorter<int>());
            Console.WriteLine(collection);

            Console.WriteLine(new string('*', 20));

            var items = new List<int> { 1, 2, 3, 4, 5, 6 };
            Console.WriteLine(string.Join(",", items));

            var shuffler = new SortableCollection<int>();
            items = shuffler.Shuffle(items).ToList();
            Console.WriteLine(string.Join(",", items));


            var collectionSort = new SortableCollection<int>(new[] { 6, 5, 8, 3, 5, 0, 15, 6 });
            collectionSort.Sort(new HeapSorter<int>());

            Console.WriteLine(String.Format("Result: {0}", collectionSort));

        }
    }
}
