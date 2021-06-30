using AlgorithmsDotNet.DataStructures.Lists;
using AlgorithmsDotNet.Tests.FsCheck;
using FsCheck.Xunit;
using System;
using System.Collections.Generic;
using Xunit;

namespace AlgorithmsDotNet.Tests.DataStructures.Lists
{
    public class DoublyLinkedListTests
    {
        [Property(Arbitrary = new Type[] { typeof(IntLists) })]
        public void Add_ToList_IncrementsCountAndAddsItem(List<int> data)
        {
            // Arrange
            var list = new DoublyLinkedList<int>();

            // Act
            var i = 0;
            foreach(var item in data)
            {
                // Act
                list.Add(item);
                i++;

                // Assert
                Assert.Equal(i, list.Count);
                Assert.Equal(item, list[i - 1]);
            }
        }

        [Property(Arbitrary = new Type[] { typeof(IntLists) })]
        public void Reverse_ReversesList(List<int> data)
        {
            // Arrange
            var list = new DoublyLinkedList<int>(data);
            data.Reverse();

            // Act
            list.Reverse();

            // Assert
            Assert.Equal(list, data);
        }

        [Property]
        public void Clear_List_LeavesAnEmptyList(List<int> data)
        {
            // Arrange
            var list = new DoublyLinkedList<int>(data);

            // Act
            list.Clear();

            // Assert
            Assert.Empty(list);
        }
    }
}
