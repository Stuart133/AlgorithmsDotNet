using System.Collections.Generic;

namespace AlgorithmsDotNet.DataStructures.Trees
{
    public class BinarySearchTree<T>
    {
        private readonly Comparer<T> _comparer = Comparer<T>.Default;
        private TreeNode _root;

        public BinarySearchTree() { }

        public BinarySearchTree(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                Add(item);
            }
        }

        public void Add(T item)
        {
            TreeNode parent = null;
            var current = _root;

            while (current != null)
            {
                parent = current;
                // If the current value is greater go left, otherwise go right
                if (_comparer.Compare(current.Value, item) >= 0)
                {
                    current = current.Left;
                }
                else
                {
                    current = current.Right;
                }
            }

            // We've reached the leaf, so create a new node and set the parent branch
            if (parent == null)
            {
                _root = new TreeNode(item);
                return;
            }
            else if (_comparer.Compare(parent.Value, item) >= 0)
            {
                parent.Left = new TreeNode(item);
            }
            else
            {
                parent.Right = new TreeNode(item);
            }
        }

        public IEnumerable<T> InOrderWalk()
        {
            return InOrderWalk(_root);
        }

        private IEnumerable<T> InOrderWalk(TreeNode root)
        {
            if (root != null)
            {
                InOrderWalk(root.Left);
                yield return root.Value;
                InOrderWalk(root.Right);
            }
        }

        private class TreeNode
        {
            internal TreeNode(T value)
            {
                Value = value;
            }

            internal T Value { get; set; }
            internal TreeNode Right { get; set; }
            internal TreeNode Left { get; set; }
        }
    }
}
