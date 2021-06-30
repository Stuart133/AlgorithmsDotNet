using AlgorithmsDotNet.DataStructures.Trees;
using System;
using System.Linq;
using Xunit;

namespace AlgorithmsDotNet.Tests.DataStructures.Trees
{
    public class BinarySearchTreeTests
    {
        private readonly int[] _data = { 2, 234, 524, 5, 123, 6, 1, -23, -56, 0, 14, 123513 };

        [Fact]
        public void Create_BST_CreatesExpectedTree()
        {
            // Arrange

            // Act
            var tree = new BinarySearchTree<int>(_data);

            // Assert
            Array.Sort(_data);
            var treeWalk = tree.InOrderWalk().ToList();
            Assert.Equal(treeWalk, _data);
        }
    }
}
