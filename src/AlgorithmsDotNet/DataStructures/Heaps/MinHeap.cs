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
    {
        /// <summary>
        /// Create a max heap with initial data using the default comparer
        /// </summary>
        /// <param name="data">Initial data</param>
        public MinHeap(IEnumerable<T> data)
            : base(MinHeapComparison(Comparer<T>.Default))
        {
            _data = data.ToList();
            BuildHeap();
        }

        /// <summary>
        /// Create a min heap with initial data using supplied comparer
        /// </summary>
        /// <param name="data">Initial data</param>
        /// <param name="comparer">Comparer used to make heap</param>
        public MinHeap(IEnumerable<T> data, IComparer<T> comparer)
            : base(MinHeapComparison(comparer))
        {
            _data = data.ToList();
            BuildHeap();
        }

        private static Func<T, T, bool> MinHeapComparison(IComparer<T> comparer)
        {
            return (childItem, item) => comparer.Compare(childItem, item) < 0;
        }
    }
}
