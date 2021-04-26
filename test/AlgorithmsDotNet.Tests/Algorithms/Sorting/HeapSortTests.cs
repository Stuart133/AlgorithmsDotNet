using AlgorithmsDotNet.Algorithms.Sorting;
using FsCheck.Xunit;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AlgorithmsDotNet.Tests.Algorithms.Sorting
{
    public class HeapSortTests
    {
        [Property]
        public void SortAscending_SortsData(List<int> data)
        {
            // Arrange
            var heapSorter = new HeapSorter<int>();

            // Act
            var sortedData = heapSorter.SortAscending((IEnumerable<int>)data);

            // Assert
            Assert.Equal(data.OrderBy(i => i), sortedData);
        }

        [Property]
        public void SortDescending_SortsData(List<int> data)
        {
            // Arrange
            var heapSorter = new HeapSorter<int>();

            // Act
            var sortedData = heapSorter.SortDescending((IEnumerable<int>)data);

            // Assert
            Assert.Equal(data.OrderByDescending(i => i), sortedData);
        }
    }
}
