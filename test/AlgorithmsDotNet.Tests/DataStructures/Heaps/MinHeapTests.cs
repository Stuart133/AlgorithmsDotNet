using AlgorithmsDotNet.DataStructures.Heaps;
using AlgorithmsDotNet.Tests.FsCheck;
using FsCheck.Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AlgorithmsDotNet.Tests.DataStructures.Heaps
{
    public class MinHeapTests
    {
        [Property(Arbitrary = new Type[] { typeof(IntLists) })]
        public void ClearMinHeap_LeavesCountOfZero(List<int> data)
        {
            // Arrange
            var heap = new MinHeap<int>(data);

            // Act
            heap.Clear();

            // Assert
            Assert.Empty(heap);
        }

        [Property(Arbitrary = new Type[] { typeof(IntLists) })]

        public void Heap_HasMinHeapProperty_AfterConstruction(List<int> data)
        {
            // Act
            var heap = new MinHeap<int>(data);

            // Assert
            HeapAssertions.IsMinHeap(heap);
        }

        [Property(Arbitrary = new Type[] { typeof(IntLists) })]
        public void Add_MaintainsMinHeapProperty(List<int> data, int valueToAdd)
        {
            // Arrange
            var startCount = data.Count;
            var heap = new MinHeap<int>(data);

            // Act
            heap.Add(valueToAdd);

            // Assert
            Assert.Equal(startCount + 1, heap.Count);
            HeapAssertions.IsMinHeap(heap);
        }

        [Property(Arbitrary = new Type[] { typeof(IntLists) })]
        public void Pop_MaintainsMinHeapProperty_AndReturnsLowestValue(List<int> data)
        {
            // Arrange
            var heap = new MinHeap<int>(data);

            // Act
            var top = heap.Pop();

            // Assert
            Assert.Equal(data.Min(), top);
            Assert.Equal(data.Count() - 1, heap.Count);
            HeapAssertions.IsMinHeap(heap);
        }

        [Property(Arbitrary = new Type[] { typeof(IntLists) })]
        public void Peek_GetsLowestItem_AndDoesntChangeHeapSize(List<int> data)
        {
            // Arrange
            var heap = new MinHeap<int>(data);

            // Act
            var top = heap.Peek();

            // Assert
            Assert.Equal(data.Min(), top);
            Assert.Equal(data.Count(), heap.Count);
            HeapAssertions.IsMinHeap(heap);
        }

        [Property(Arbitrary = new Type[] { typeof(IntLists) })]
        public void RemoveValueInHeap_MaintainsMinHeapProperty_AndReturnsTrue(List<int> data)
        {
            // Arrange
            var startCount = data.Count;
            var heap = new MinHeap<int>(data);

            // Act
            var removed = heap.Remove(data[0]);

            // Assert
            Assert.True(removed);
            Assert.Equal(startCount - 1, heap.Count);
            HeapAssertions.IsMinHeap(heap);
        }

        [Property(Arbitrary = new Type[] { typeof(IntLists) })]
        public void RemoveValue_NotInHeap_ReturnsFalse(List<int> data)
        {
            // Arrange
            var heap = new MinHeap<int>(data);

            // Act
            var removed = heap.Remove(1000);

            // Assert
            Assert.False(removed);
            Assert.Equal(data.Count(), heap.Count);
            HeapAssertions.IsMinHeap(heap);
        }
    }
}
