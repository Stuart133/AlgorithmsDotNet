using System;
using System.Collections.Generic;

namespace AlgorithmsDotNet.DataStructures.Heaps
{
    public interface IHeap<T> : ICollection<T>
        where T : IComparable<T>
    {
    }
}
