﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsDotNet.DataStructures.Heaps
{
    /// <summary>
    /// A binary max heap data structure
    /// </summary>
    /// <typeparam name="T">Item stored in heap</typeparam>
    public class MaxHeap<T> : Heap<T>
    {
        /// <summary>
        /// Create a max heap with initial data using the default comparer
        /// This method copies the passed in data to a new container so does not alter the passed in data
        /// </summary>
        /// <param name="data">Initial data</param>
        public MaxHeap(IEnumerable<T> data)
            : this(data.ToList())
        {
        }

        /// <summary>
        /// Create a max heap with initial data using the default comparer 
        /// This uses the data directly so will alter the passed in data
        /// </summary>
        /// <param name="data"></param>
        public MaxHeap(IList<T> data)
            : base(MaxHeapComparison(Comparer<T>.Default))
        {
            _data = data;
            Count = _data.Count;
            BuildHeap();
        }

        /// <summary>
        /// Create a max heap with initial data using supplied comparer
        /// </summary>
        /// <param name="data">Initial data</param>
        /// <param name="comparer">Comparer used to make heap</param>
        public MaxHeap(IEnumerable<T> data, IComparer<T> comparer)
            : base(MaxHeapComparison(comparer))
        {
            _data = data.ToList();
            BuildHeap();
        }
        
        private static Func<T, T, bool> MaxHeapComparison(IComparer<T> comparer)
        {
            return (childItem, item) => comparer.Compare(childItem, item) > 0;
        }
    }
}
