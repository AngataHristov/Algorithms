namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;

    using Contracts;
    using BinaryHeap;

    public class HeapSorter<T> : ISorter<T>
        where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            var heap = new BinaryHeap<T>(collection);

            List<T> elements = new List<T>(heap.Count);

            int position = heap.Count - 1;
            while (heap.Count > 0)
            {
                var maxElement = heap.ExtractMax();
                collection[position] = maxElement;
                position--;
            }
        }
    }
}
