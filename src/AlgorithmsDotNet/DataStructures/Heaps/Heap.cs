using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsDotNet.DataStructures.Heaps
{
    /// <summary>
    /// Binary heap data structure base class
    /// </summary>
    /// <typeparam name="T">Item stored in heap</typeparam>
    public abstract class Heap<T> : IHeap<T>
    {
        protected IList<T> _data;
        private Func<T, T, bool> _comparisonPredicate;

        /// <summary>
        /// Gets the number of items contained in the heap
        /// </summary>
        public int Count { get; protected set; }
        public bool IsReadOnly => false;

        protected Heap(Func<T, T, bool> comparisonPredicate)
        {
            _comparisonPredicate = comparisonPredicate;
        }

        protected void BuildHeap()
        {
            for (int i = Count / 2; i >= 0; i--)
            {
                Heapify(i);
            }
        }

        protected void Heapify(int index)
        {
            var leftIndex = GetLeft(index);
            var rightIndex = GetRight(index);
            int indexToSwap = index;

            if (leftIndex < Count && _comparisonPredicate(_data[leftIndex], _data[index]))
            {
                indexToSwap = leftIndex;
            }
            if (rightIndex < Count && _comparisonPredicate(_data[rightIndex], _data[indexToSwap]))
            {
                indexToSwap = rightIndex;
            }

            if (indexToSwap != index)
            {
                // Swap
                SwapValues(index, indexToSwap);
                Heapify(indexToSwap);
            }
        }

        protected int GetParent(int index)
        {
            return index / 2;
        }

        protected int GetLeft(int index)
        {
            return index * 2;
        }

        protected int GetRight(int index)
        {
            return (index * 2) + 1;
        }

        protected void SwapValues(int i, int j)
        {
            var tmp = _data[i];
            _data[i] = _data[j];
            _data[j] = tmp;
        }

        #region IHeap Implementation

        /// <summary>
        /// Peeks the top item in the heap, maintaining the heap property
        /// </summary>
        /// <returns>The top item</returns>
        public T Peek()
        {
            return _data[0];
        }

        /// <summary>
        /// Pops the top item off the heap, maintaining the heap property
        /// </summary>
        public T Pop()
        {
            var value = _data[0];

            // Move the top value to the end of the list and reduce count (Leave the actual data there)
            SwapValues(0, Count - 1);
            Count--;

            // Maintain max heap property
            Heapify(0);

            return value;
        }

        /// <summary>
        /// Returns the heap as a list
        /// </summary>
        /// <returns>The heap as a list</returns>
        public IList<T> ToList()
        {
            return _data;
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
            Count++;

            var itemIndex = Count - 1;
            var itemParentIndex = GetParent(itemIndex);

            while (_comparisonPredicate(item, _data[itemParentIndex]) && itemIndex != 0)
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
            Count = 0;
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
            SwapValues(itemIndex, Count - 1);
            _data.RemoveAt(Count - 1);
            Count--;

            // Maintain max heap property
            Heapify(itemIndex);

            return true;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _data.Take(Count).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _data.Take(Count).GetEnumerator();
        }

        #endregion
    }
}
