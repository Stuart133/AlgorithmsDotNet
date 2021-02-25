using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsDotNet.DataStructures.Heaps
{
    /// <summary>
    /// A binary max heap data structure
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MaxHeap<T> : IHeap<T>
        where T : IComparable<T>
    {
        private readonly IList<T> _data;

        public int Count => _data.Count;
        public bool IsReadOnly => false;

        public MaxHeap(IEnumerable<T> data)
        {
            _data = data.ToList();
            BuildMaxHeap();
        }

        private void BuildMaxHeap()
        {
            for (int i = _data.Count / 2; i >= 0; i--)
            {
                MaxHeapify(i);
            }
        }

        private void MaxHeapify(int index)
        {
            var leftIndex = GetLeft(index);
            var rightIndex = GetRight(index);
            int indexOfLargest;

            if (leftIndex < _data.Count && _data[leftIndex].CompareTo(_data[index]) > 0)
            {
                indexOfLargest = leftIndex;
            }
            else if (rightIndex < _data.Count && _data[rightIndex].CompareTo(_data[index]) > 0)
            {
                indexOfLargest = rightIndex;
            }
            else
            {
                indexOfLargest = index;
            }

            if (indexOfLargest != index)
            {
                // Swap
                SwapValues(index, indexOfLargest);
                MaxHeapify(indexOfLargest);
            }
        }

        private int GetParent(int index)
        {
            if (index <= 1)
            {
                throw new ArgumentException("Index must be greater than 1 to get parent");
            }

            return index / 2;
        }

        private int GetLeft(int index)
        {
            return index * 2;
        }

        private int GetRight(int index)
        {
            return (index * 2) + 1;
        }

        private void SwapValues(int i, int j)
        {
            var tmp = _data[i];
            _data[i] = _data[j];
            _data[j] = tmp;
        }

        #region IHeap Implementation

        public IList<T> ToList()
        {
            return _data;
        }

        #endregion

        #region ICollection Implementation

        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            _data.Clear();
        }

        public bool Contains(T item)
        {
            return _data.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _data.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        #endregion
    }
}
