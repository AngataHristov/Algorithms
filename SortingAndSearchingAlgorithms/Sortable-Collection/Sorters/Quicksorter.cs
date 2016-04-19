namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;

    using Sortable_Collection.Contracts;

    public class Quicksorter<T> : ISorter<T>
        where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            this.Quicksort(collection, 0, collection.Count - 1);
        }

        private void Quicksort(List<T> array, int start, int end)
        {
            if (end <= start)
            {
                return;
            }

            int p = this.Partition(array, start, end);
            this.Quicksort(array, start, p);
            this.Quicksort(array, p + 1, end);
        }

        private int Partition(List<T> array, int start, int end)
        {
            T pivot = array[start];
            int storeIndex = start + 1;

            for (int i = start + 1; i <= end; i++)
            {
                if (array[i].CompareTo(pivot) < 0)
                {
                    this.Swap(array, i, storeIndex);
                    storeIndex++;
                }
            }

            storeIndex--;
            this.Swap(array, start, storeIndex);

            return storeIndex;
        }

        private void Swap<T>(List<T> array, int first, int second)
        {
            if (first.Equals(second))
            {
                return;
            }

            T oldFirst = array[first];
            array[first] = array[second];
            array[second] = oldFirst;
        }
    }
}
