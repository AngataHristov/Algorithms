namespace Sortable_Collection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;

    public class SortableCollection<T>
        where T : IComparable<T>
    {
        public SortableCollection()
        {
            this.Items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.Items = new List<T>(items);
        }

        public SortableCollection(params T[] items)
            : this(items.AsEnumerable())
        {
        }

        public List<T> Items { get; private set; }

        public int Count => this.Items.Count;

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.Items);
        }

        public int BinarySearch(T item)
        {
            int result = this.BinarySearchProcedure(item, 0, this.Items.Count - 1);

            return result;
        }

        public int InterpolationSearch(int item)
        {
            if (this.Items.Count == 0)
            {
                return -1;
            }

            int result = this.InterpolationSearchProcedure(item);

            return result;
        }

        public IEnumerable<T> Shuffle(IEnumerable<T> items)
        {
            var collection = items.ToList();
            return this.ShuffleCollection(collection);
        }

        public T[] ToArray()
        {
            return this.Items.ToArray();
        }

        public override string ToString()
        {
            return string.Format("[{0}]", string.Join(", ", this.Items));
        }

        private int BinarySearchProcedure(T target, int startIndex, int endIndex)
        {
            if (endIndex < startIndex)
            {
                return -1;
            }

            int middleIndex = startIndex + (endIndex - startIndex) / 2;

            if (this.Items[middleIndex].CompareTo(target) < 0)
            {
                return this.BinarySearchProcedure(target, middleIndex + 1, endIndex);
            }

            if (this.Items[middleIndex].CompareTo(target) > 0)
            {
                return this.BinarySearchProcedure(target, startIndex, middleIndex - 1);
            }

            return middleIndex;
        }

        private int InterpolationSearchProcedure(int target)
        {
            int low = 0;
            int high = this.Items.Count - 1;

            IList<int?> elements = new List<int?>(this.Items.Count);

            foreach (T item in this.Items)
            {
                elements.Add(item as int?);
            }

            while (elements[low] <= target && elements[high] >= target)
            {
                int mid = (int)(low + ((target - elements[low]) * (high - low)) / (elements[high] - elements[low]));

                if (elements[mid] < target)
                {
                    low = mid + 1;
                }
                else if (elements[mid] > target)
                {
                    high = mid - 1;
                }
                else
                {
                    return mid;
                }
            }

            if (elements[low] == target)
            {
                return low;
            }
            else
            {
                return -1;
            }
        }

        private IEnumerable<T> ShuffleCollection(List<T> collection)
        {
            Random rnd = new Random();

            var array = collection.ToArray();
            int n = array.Length;

            for (int i = 0; i < n; i++)
            {
                int r = i + rnd.Next(0, n - i);
                T temp = array[i];
                array[i] = array[r];
                array[r] = temp;
            }

            return array;
        }
    }
}