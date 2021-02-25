using AlgorithmsDotNet.DataStructures.Heaps;
using System;
using Xunit;

namespace AlgorithmsDotNet.Tests.DataStructures.Heaps
{
    public class MaxHeapTests
    {
        private readonly int[] data = { 12, 34, 5, 323, 12, 5, 10 };

        [Fact]
        public void ClearMaxHeap_LeavesCountOfZero()
        {
            // Arrange
            var heap = new MaxHeap<int>(data);

            // Act
            heap.Clear();

            // Assert
            Assert.Empty(heap);
        }
        
        [Fact]
        public void Heap_HasMaxHeapProperty_AfterConstruction()
        {
            // Act
            var heap = new MaxHeap<int>(data);

            // Assert
            HeapAssertions.IsMaxHeap<int>(heap);
        }
    }
}
