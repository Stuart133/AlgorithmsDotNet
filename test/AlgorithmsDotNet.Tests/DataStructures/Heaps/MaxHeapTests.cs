using AlgorithmsDotNet.DataStructures.Heaps;
using System.Linq;
using Xunit;

namespace AlgorithmsDotNet.Tests.DataStructures.Heaps
{
    public class MaxHeapTests
    {
        // TODO: Replace this with fsCheck generated data
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
            HeapAssertions.IsMaxHeap(heap);
        }

        [Fact]
        public void Add_MaintainsMaxHeapProperty()
        {
            // Arrange
            var heap = new MaxHeap<int>(data);

            // Act
            heap.Add(56);

            // Assert
            Assert.Equal(data.Length + 1, heap.Count);
            HeapAssertions.IsMaxHeap(heap);
        }

        [Fact]
        public void Pop_MaintainsMaxHeapProperty_AndReturnsHighestValue()
        {
            // Arrange
            var heap = new MaxHeap<int>(data);

            // Act
            var top = heap.Pop();

            // Assert
            Assert.Equal(data.Max(), top);
            Assert.Equal(data.Length - 1, heap.Count);
            HeapAssertions.IsMaxHeap(heap);
        }

        [Fact]
        public void Peek_GetsHighestItem_AndDoesntChangeHeapSize()
        {
            // Arrange
            var heap = new MaxHeap<int>(data);

            // Act
            var top = heap.Peek();

            // Assert
            Assert.Equal(data.Max(), top);
            Assert.Equal(data.Length, heap.Count);
            HeapAssertions.IsMaxHeap(heap);
        }

        [Fact]
        public void RemoveValueInHeap_MaintainsMaxHeapProperty_AndReturnsTrue()
        {
            // Arrange
            var heap = new MaxHeap<int>(data);

            // Act
            var removed = heap.Remove(34);

            // Assert
            Assert.True(removed);
            Assert.Equal(data.Length - 1, heap.Count);
            HeapAssertions.IsMaxHeap(heap);
        }
    }
}
