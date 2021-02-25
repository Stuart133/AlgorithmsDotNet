using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsDotNet.DataStructures.Heaps
{
    /// <summary>
    /// A binary min heap data structure
    /// </summary>
    /// <typeparam name="T">Item stored in heap</typeparam>
    public class MinHeap<T> : Heap<T>
        where T : IComparable<T>
    {
        public MinHeap(IEnumerable<T> data)
            : base(MinHeapComparison)
        {
            _data = data.ToList();
            BuildHeap();
        }

        private static bool MinHeapComparison(T childItem, T item)
        {
            var compare = childItem.CompareTo(item);
            return childItem.CompareTo(item) < 0;
        }
    }
}
