using AlgorithmsDotNet.DataStructures.Lists;
using FsCheck.Xunit;
using Xunit;

namespace AlgorithmsDotNet.Tests.DataStructures.Lists
{
    public class DoublyLinkedListTests
    {
        [Property]
        public void Add_ToEmptyList_IncrementsCount(int itemToAdd)
        {
            // Arrange
            var list = new DoublyLinkedList<int>();

            // Act
            list.Add(itemToAdd);

            // Assert
            Assert.Single(list);
            Assert.Equal(itemToAdd, list[0]);
        }
    }
}
