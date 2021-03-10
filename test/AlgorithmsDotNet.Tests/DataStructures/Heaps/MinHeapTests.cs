using AlgorithmsDotNet.DataStructures.Heaps;
using FsCheck.Xunit;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AlgorithmsDotNet.Tests.DataStructures.Heaps
{
    public class MinHeapTests
    {
        [Property]
        public void ClearMinHeap_LeavesCountOfZero(List<int> data)
        {
            // Arrange
            var heap = new MinHeap<int>(data);

            // Act
            heap.Clear();

            // Assert
            Assert.Empty(heap);
        }

        [Property]
        public void Heap_HasMinHeapProperty_AfterConstruction(List<int> data)
        {
            // Act
            var heap = new MinHeap<int>(data);

            // Assert
            HeapAssertions.IsMinHeap(heap);
        }

        [Property]
        public void Add_MaintainsMinHeapProperty(List<int> data)
        {
            // Arrange
            var heap = new MinHeap<int>(data);

            // Act
            heap.Add(56);

            // Assert
            Assert.Equal(data.Count() + 1, heap.Count);
            HeapAssertions.IsMinHeap(heap);
        }

        [Property]
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

        [Property]
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

        [Property]
        public void RemoveValueInHeap_MaintainsMinHeapProperty_AndReturnsTrue(List<int> data)
        {
            // Arrange
            var heap = new MinHeap<int>(data);

            // Act
            var removed = heap.Remove(34);

            // Assert
            Assert.True(removed);
            Assert.Equal(data.Count() - 1, heap.Count);
            HeapAssertions.IsMinHeap(heap);
        }

        [Property]
        public void RemoveValue_NotInHeap_ReturnsFalse(List<int> data)
        {
            // Arrange
            var heap = new MinHeap<int>(data);

            // Act
            var removed = heap.Remove(35);

            // Assert
            Assert.False(removed);
            Assert.Equal(data.Count(), heap.Count);
            HeapAssertions.IsMinHeap(heap);
        }
    }
}
