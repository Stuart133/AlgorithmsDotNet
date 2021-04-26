using AlgorithmsDotNet.Algorithms.Sorting;
using Xunit;

namespace AlgorithmsDotNet.Tests.Algorithms.Sorting
{
    public class QuickSortTests
    {
        [Fact]
        public void Test()
        {
            // Arrange
            var sorter = new QuickSort<int>();
            var data = new int[] { 2, 8, 7, 1, 3, 5, 6, 4 };

            var sortedData = sorter.SortAscending(data);
        }
    }
}
