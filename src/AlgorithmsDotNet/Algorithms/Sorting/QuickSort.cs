using System;
using System.Collections.Generic;

namespace AlgorithmsDotNet.Algorithms.Sorting
{
    public class QuickSort<T> : ISorter<T>
    {
        private Comparer<T> _comparer = Comparer<T>.Default;

        public IEnumerable<T> SortAscending(IEnumerable<T> data)
        {
            throw new NotImplementedException();
        }

        public IList<T> SortAscending(IList<T> data)
        {
            Partition(data, 0, data.Count - 1);
            return data;
        }

        public IEnumerable<T> SortDescending(IEnumerable<T> data)
        {
            throw new NotImplementedException();
        }

        public IList<T> SortDescending(IList<T> data)
        {
            throw new NotImplementedException();
        }

        private int Partition(IList<T> data, int p, int r)
        {
            // Get our pivot value
            var pivot = data[r];

            // Compare each item in the data section to the pivot and swap them if they are larger
            var i = p;            
            for (var j = p; j < r - 1; j++)
            {
                if (_comparer.Compare(data[j], pivot) <= 0)
                {
                    SwapValues(data, i, j);
                    i++;
                }
            }

            // Swap the pivot to the tail of the lower portion of the partition
            SwapValues(data, i, r);

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
    }
}
