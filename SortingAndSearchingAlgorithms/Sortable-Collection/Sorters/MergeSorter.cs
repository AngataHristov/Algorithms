namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;

    using Contracts;

    public class MergeSorter<T> : ISorter<T>
        where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            this.MergeSort(collection, 0, collection.Count - 1);
        }

        private void MergeSort(List<T> array, int start, int end)
        {
            if (start == end || array.Count == 0)
            {
                return;
            }

            int middle = start + (end - start) / 2;

            this.MergeSort(array, start, middle);
            this.MergeSort(array, middle + 1, end);

            this.Merge(array, start, end);
        }

        private void Merge(List<T> array, int start, int end)
        {
            T[] tempArray = new T[end - start + 1];
            int middle = start + (end - start) / 2;
            int left = start;
            int right = middle + 1;
            int result = 0;

            while (left <= middle && right <= end)
            {
                if (array[left].CompareTo(array[right]) <= 0)
                {
                    tempArray[result] = array[left];
                    left++;
                }
                else
                {
                    tempArray[result] = array[right];
                    right++;
                }

                result++;
            }

            while (left <= middle)
            {
                tempArray[result] = array[left];
                result++;
                left++;
            }

            while (right <= end)
            {
                tempArray[result] = array[right];
                result++;
                right++;
            }

            int j = start;

            for (int i = 0; i < tempArray.Length; i++)
            {
                array[j] = tempArray[i];
                j++;
            }
        }
    }
}
