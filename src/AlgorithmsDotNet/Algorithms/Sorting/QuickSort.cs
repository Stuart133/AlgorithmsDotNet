using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsDotNet.Algorithms.Sorting
{
    public class QuickSort<T> : ISorter<T>
    {
        private readonly Comparer<T> _comparer = Comparer<T>.Default;

        public QuickSort() { }

        public QuickSort(Comparer<T> comparer)
        {
            _comparer = comparer;
        }

        public IEnumerable<T> SortAscending(IEnumerable<T> data)
        {
            return Sort(data.ToList(), 0, data.Count() - 1, Compare);
        }

        public IList<T> SortAscending(IList<T> data)
        {
            return Sort(data, 0, data.Count - 1, Compare);
        }

        public IEnumerable<T> SortDescending(IEnumerable<T> data)
        {
            return Sort(data.ToList(), 0, data.Count() - 1, CompareDescending);
        }

        public IList<T> SortDescending(IList<T> data)
        {
            return Sort(data, 0, data.Count - 1, CompareDescending);
        }

        private IList<T> Sort(IList<T> data, int p, int r, Func<T, T, bool> compare)
        {
            // If the upper and lower indices haven't crossed yet, keep going
            if (p < r)
            {
                // Partition data around the pivot
                var q = Partition(data, p, r, compare);

                // Recursively sort the lower and upper sections of data
                Sort(data, p, q - 1, compare);
                Sort(data, q + 1, r, compare);
            }

            return data;
        }

        private int Partition(IList<T> data, int p, int r, Func<T, T, bool> compare)
        {
            // Get our pivot value
            var pivot = data[r];

            // Compare each item in the data section to the pivot and swap them (Direction is set by compare function)
            var i = p;            
            for (var j = p; j < r; j++)
            {
                if (compare(data[j], pivot))
                {
                    SwapValues(data, i, j);
                    i++;
                }
            }

            // Swap the pivot to the tail of the lower portion of the partition
            SwapValues(data, i, r);

            // Return the final pivot position
            return i;
        }

        private void SwapValues(IList<T> data, int i, int j)
        {
            if (i == j)
            {
                return;
            }

            var tmp = data[i];
            data[i] = data[j];
            data[j] = tmp;
        }

        private bool Compare(T x, T y)
        {
            return _comparer.Compare(x, y) <= 0;
        }

        private bool CompareDescending(T x, T y)
        {
            return _comparer.Compare(x, y) >= 0;
        }
    }
}
