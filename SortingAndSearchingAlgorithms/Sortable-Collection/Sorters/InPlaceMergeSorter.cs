namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;

    using Contracts;

    public class InPlaceMergeSorter<T> : ISorter<T>
        where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            this.InPlaceMergeSort(collection, 0, collection.Count - 1);
        }


        private void InPlaceMergeSort(List<T> array, int start, int end)
        {
            if (start == end || array.Count == 0)
            {
                return;
            }

            int middle = start + (end - start) / 2;

            this.InPlaceMergeSort(array, start, middle);
            this.InPlaceMergeSort(array, middle + 1, end);

            this.InPlaceMerge(array, start, middle, end);
        }

        private void InPlaceMerge(List<T> array, int start, int middle, int end)
        {
            int secondArrayStart = middle + 1;
            int prevPlaced = middle + 1;
            int q = middle + 1;

            while (start < middle + 1 && q <= end)
            {
                bool swapped = false;

                if (array[start].CompareTo(array[q]) > 0)
                {
                    this.Swap(array, start, q);
                    swapped = true;
                }

                if (q != secondArrayStart && array[start].CompareTo(array[secondArrayStart]) > 0)
                {
                    this.Swap(array, start, secondArrayStart);
                    swapped = true;
                }

                if (swapped && secondArrayStart + 1 <= end && array[secondArrayStart + 1].CompareTo(array[secondArrayStart]) < 0)
                {
                    prevPlaced = this.PlaceInOrder(array, secondArrayStart, prevPlaced);
                }

                start++;

                if (q < end)
                {
                    q++;
                }
            }
        }

        private int PlaceInOrder(List<T> array, int secondArrayStart, int prevPlaced)
        {
            for (int i = secondArrayStart; i < array.Count; i++)
            {
                if (secondArrayStart < prevPlaced)
                {
                    this.Swap(array, secondArrayStart, secondArrayStart + 1);
                    secondArrayStart++;

                    continue;
                }

                if (array[i].CompareTo(array[secondArrayStart]) < 0)
                {
                    this.Swap(array, i, secondArrayStart);
                    secondArrayStart++;
                }
                else if (i != secondArrayStart && array[i].CompareTo(array[secondArrayStart]) > 0)
                {
                    break;
                }
            }

            return secondArrayStart;
        }

        private void Swap(List<T> array, int first, int second)
        {
            T temp = array[first];
            array[first] = array[second];
            array[second] = temp;
        }
    }
}
