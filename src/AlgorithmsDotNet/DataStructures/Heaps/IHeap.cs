using System;
using System.Collections.Generic;

namespace AlgorithmsDotNet.DataStructures.Heaps
{
    /// <summary>
    /// Defines a generic heap
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IHeap<T> : ICollection<T>
        where T : IComparable<T>
    {
        /// <summary>
        /// Returns the heap as a list
        /// </summary>
        /// <returns>The heap as a list</returns>
        IList<T> ToList();

        /// <summary>
        /// Pops the top item off the heap, maintaining the heap property
        /// </summary>
        /// <returns>The top item</returns>
        T Pop();

        /// <summary>
        /// Peeks at the top item in the heap
        /// </summary>
        /// <returns>The top item</returns>
        T Peek();
    }
}
