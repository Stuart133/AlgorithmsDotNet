using AlgorithmsDotNet.DataStructures.Heaps;
using System;
using Xunit;

namespace AlgorithmsDotNet.Tests.DataStructures.Heaps
{
    public static class HeapAssertions
    {
        public static void IsMaxHeap<T>(IHeap<T> heap)
            where T : IComparable<T>
        {
            var heapList = heap.ToList();

            for (int i = 0; i < heap.Count; i++)
            {
                if (2 * i < heap.Count)
                {
                    Assert.True(heapList[i].CompareTo(heapList[2 * i]) >= 0,
                        $"Value {heapList[i]} at index {i} is less than {heapList[2 * i]} at index {2 * 1}");
                }
                if ((2 * i) + 1 < heap.Count)
                {
                    Assert.True(heapList[i].CompareTo(heapList[(2 * i) + 1]) >= 0,
                        $"Value {heapList[i]} at index {i} is less than {heapList[(2 * i) + 1]} at index {(2 * i) + 1}");
                }
            }
        }

        public static void IsMinHeap<T>(IHeap<T> heap)
            where T : IComparable<T>
        {
            var heapList = heap.ToList();

            for (int i = 0; i < heap.Count; i++)
            {
                if (2 * i < heap.Count)
                {
                    Assert.True(heapList[i].CompareTo(heapList[2 * i]) <= 0,
                        $"Value {heapList[i]} at index {i} is greater than {heapList[2 * i]} at index {2 * 1}");
                }
                if ((2 * i) + 1 < heap.Count)
                {
                    Assert.True(heapList[i].CompareTo(heapList[(2 * i) + 1]) <= 0,
                        $"Value {heapList[i]} at index {i} is greater than {heapList[(2 * i) + 1]} at index {(2 * i) + 1}");
                }
            }
        }
    }
}
