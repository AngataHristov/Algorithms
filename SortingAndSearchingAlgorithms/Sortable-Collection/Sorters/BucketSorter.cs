namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Sortable_Collection.Contracts;

    public class BucketSorter : ISorter<int>
    {
        public double Max { get; set; }

        public void Sort(List<int> collection)
        {
            List<int>[] buckets = new List<int>[collection.Count];

            foreach (int element in collection)
            {
                int bucketIndex = (int)(element / this.Max * collection.Count);

                if (buckets[bucketIndex] == null)
                {
                    buckets[bucketIndex] = new List<int>();
                }

                buckets[bucketIndex].Add(element);
            }

            this.SortBuckets(buckets);

            int index = 0;

            foreach (var bucket in buckets)
            {
                if (bucket == null)
                {
                    continue;
                }

                foreach (int item in bucket)
                {
                    collection[index] = item;
                    index++;
                }
            }
        }

        private void SortBuckets(List<int>[] buckets)
        {
            var sorter = new Quicksorter<int>();

            for (int i = 0; i < buckets.Length; i++)
            {
                List<int> currentBucket = buckets[i];

                if (currentBucket != null)
                {
                    sorter.Sort(currentBucket);
                }
            }
        }
    }
}
