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

        /// <summary>
        /// Gets the number of items contained in the heap
        /// </summary>
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

        /// <summary>
        /// Returns the heap as a list
        /// </summary>
        /// <returns>The heap as a list</returns>
        public IList<T> ToList()
        {
            return _data;
        }

        /// <summary>
        /// Pops the top item off the heap, maintaining the max heap property
        /// </summary>
        public T Pop()
        {
            var value = _data[0];

            // Move the top value to the end of the list and remove it
            SwapValues(0, _data.Count - 1);
            _data.RemoveAt(_data.Count - 1);

            // Maintain max heap property
            MaxHeapify(0);

            return value;
        }

        /// <summary>
        /// Pops the top item off the heap, maintaining the heap property
        /// </summary>
        /// <returns>The top item</returns>
        public T Peek()
        {
            return _data[0];
        }

        #endregion

        #region ICollection Implementation

        /// <summary>
        /// Adds an item to the heap, maintaining the max heap property
        /// </summary>
        /// <param name="item">The item to add</param>
        public void Add(T item)
        {
            _data.Add(item);

            var itemIndex = _data.Count - 1;
            var itemParentIndex = GetParent(itemIndex);

            while (item.CompareTo(_data[itemParentIndex]) >= 0 && itemIndex != 0)
            {
                SwapValues(itemIndex, itemParentIndex);
                itemIndex = itemParentIndex;
                itemParentIndex = GetParent(itemIndex);
            }
        }

        /// <summary>
        /// Clear the heap
        /// </summary>
        public void Clear()
        {
            _data.Clear();
        }

        /// <summary>
        /// Determines whether the heap contains a specific value
        /// </summary>
        /// <param name="item">The value</param>
        /// <returns></returns>
        public bool Contains(T item)
        {
            return _data.Contains(item);
        }

        /// <summary>
        /// Copies the values of the heap to an array, starting at the specified index
        /// </summary>
        /// <param name="array">The array to copy into</param>
        /// <param name="arrayIndex">The array index to start at</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            _data.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Removes an item from the heap, maintaining the max heap property
        /// </summary>
        /// <param name="item">The item to remove</param>
        /// <returns>True if the item was in the heap, false otherwise</returns>
        public bool Remove(T item)
        {
            var itemIndex = _data.IndexOf(item);

            if (itemIndex == -1)
            {
                return false;
            }

            // Move the item to the end of the list and remove it
            SwapValues(itemIndex, _data.Count - 1);
            _data.RemoveAt(_data.Count - 1);

            // Maintain max heap property
            MaxHeapify(itemIndex);

            return true;
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
