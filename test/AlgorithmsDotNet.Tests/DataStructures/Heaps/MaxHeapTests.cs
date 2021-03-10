using AlgorithmsDotNet.DataStructures.Heaps;
using FsCheck;
using FsCheck.Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AlgorithmsDotNet.Tests.DataStructures.Heaps
{
    public class MaxHeapTests
    {
        [Property(Arbitrary = new Type[] { typeof(Test) })]
        public void ClearMaxHeap_LeavesCountOfZero(List<int> data)
        {
            // Arrange
            var heap = new MaxHeap<int>(data);

            // Act
            heap.Clear();

            // Assert
            Assert.Empty(heap);
        }

        [Property(Arbitrary = new Type[] { typeof(Test) })]
        public void Heap_HasMaxHeapProperty_AfterConstruction(List<int> data)
        {
            // Act
            var heap = new MaxHeap<int>(data);

            // Assert
            HeapAssertions.IsMaxHeap(heap);
        }

        [Property(Arbitrary = new Type[] { typeof(Test) })]
        public void Add_MaintainsMaxHeapProperty(List<int> data)
        {
            // Arrange
            var heap = new MaxHeap<int>(data);

            // Act
            heap.Add(56);

            // Assert
            Assert.Equal(data.Count() + 1, heap.Count);
            HeapAssertions.IsMaxHeap(heap);
        }

        [Property(Arbitrary = new Type[] { typeof(Test) })]
        public void Pop_MaintainsMaxHeapProperty_AndReturnsHighestValue(List<int> data)
        {
            // Arrange
            var heap = new MaxHeap<int>(data);

            // Act
            var top = heap.Pop();

            // Assert
            Assert.Equal(data.Max(), top);
            Assert.Equal(data.Count() - 1, heap.Count);
            HeapAssertions.IsMaxHeap(heap);
        }

        [Property(Arbitrary = new Type[] { typeof(Test) })]
        public void Peek_GetsHighestItem_AndDoesntChangeHeapSize(List<int> data)
        {
            // Arrange
            var heap = new MaxHeap<int>(data);

            // Act
            var top = heap.Peek();

            // Assert
            Assert.Equal(data.Max(), top);
            Assert.Equal(data.Count(), heap.Count);
            HeapAssertions.IsMaxHeap(heap);
        }

        [Property(Arbitrary = new Type[] { typeof(Test) })]
        public void RemoveValueInHeap_MaintainsMaxHeapProperty_AndReturnsTrue(List<int> data)
        {
            // Arrange
            var heap = new MaxHeap<int>((IEnumerable<int>)data);

            // Act
            var removed = heap.Remove(data[0]);

            // Assert
            Assert.True(removed);
            Assert.Equal(data.Count() - 1, heap.Count);
            HeapAssertions.IsMaxHeap(heap);
        }

        [Property(Arbitrary = new Type[]{ typeof(Test) })]
        public void RemoveValue_NotInHeap_ReturnsFalse(List<int> data)
        {
            // Arrange
            var heap = new MaxHeap<int>(data);

            // Act
            var removed = heap.Remove(35);

            // Assert
            Assert.False(removed);
            Assert.Equal(data.Count(), heap.Count);
            HeapAssertions.IsMaxHeap(heap);
        }
    }

    public class Test
    {
        public static Arbitrary<List<int>> ListOfAtLeastOne()
        {
            return Arb.Default.List<int>().Filter(l => l.Count > 0);
        }
    }
}
