namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;

    using Sortable_Collection.Contracts;

    public class InsertionSorter<T> : ISorter<T>
        where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            for (int i = 0; i < collection.Count - 1; i++)
            {
                int j = i + 1;

                while (j > 0)
                {
                    if (collection[j - 1].CompareTo(collection[j]) > 0)
                    {
                        T temp = collection[j - 1];
                        collection[j - 1] = collection[j];
                        collection[j] = temp;
                    }

                    j--;
                }
            }
        }
    }
}
