using AlgorithmsDotNet.DataStructures.Heaps;
using System.Linq;
using Xunit;

namespace AlgorithmsDotNet.Tests.DataStructures.Heaps
{
    public class MinHeapTests
    {
        // TODO: Replace this with fsCheck generated data
        private readonly int[] data = { 12, 34, 5, 323, 12, 5, 10 };

        [Fact]
        public void ClearMinHeap_LeavesCountOfZero()
        {
            // Arrange
            var heap = new MinHeap<int>(data);

            // Act
            heap.Clear();

            // Assert
            Assert.Empty(heap);
        }

        [Fact]
        public void Heap_HasMinHeapProperty_AfterConstruction()
        {
            // Act
            var heap = new MinHeap<int>(data);

            // Assert
            HeapAssertions.IsMinHeap(heap);
        }

        [Fact]
        public void Add_MaintainsMinHeapProperty()
        {
            // Arrange
            var heap = new MinHeap<int>(data);

            // Act
            heap.Add(56);

            // Assert
            Assert.Equal(data.Length + 1, heap.Count);
            HeapAssertions.IsMinHeap(heap);
        }

        [Fact]
        public void Pop_MaintainsMinHeapProperty_AndReturnsLowestValue()
        {
            // Arrange
            var heap = new MinHeap<int>(data);

            // Act
            var top = heap.Pop();

            // Assert
            Assert.Equal(data.Min(), top);
            Assert.Equal(data.Length - 1, heap.Count);
            HeapAssertions.IsMinHeap(heap);
        }

        [Fact]
        public void Peek_GetsLowestItem_AndDoesntChangeHeapSize()
        {
            // Arrange
            var heap = new MinHeap<int>(data);

            // Act
            var top = heap.Peek();

            // Assert
            Assert.Equal(data.Min(), top);
            Assert.Equal(data.Length, heap.Count);
            HeapAssertions.IsMinHeap(heap);
        }

        [Fact]
        public void RemoveValueInHeap_MaintainsMinHeapProperty_AndReturnsTrue()
        {
            // Arrange
            var heap = new MinHeap<int>(data);

            // Act
            var removed = heap.Remove(34);

            // Assert
            Assert.True(removed);
            Assert.Equal(data.Length - 1, heap.Count);
            HeapAssertions.IsMinHeap(heap);
        }

        [Fact]
        public void RemoveValue_NotInHeap_ReturnsFalse()
        {
            // Arrange
            var heap = new MinHeap<int>(data);

            // Act
            var removed = heap.Remove(35);

            // Assert
            Assert.False(removed);
            Assert.Equal(data.Length, heap.Count);
            HeapAssertions.IsMinHeap(heap);
        }
    }
}
