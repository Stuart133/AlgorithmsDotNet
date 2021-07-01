using System.Collections.Generic;

namespace AlgorithmsDotNet.DataStructures.Trees
{
    public class BinarySearchTree<T>
    {
        private readonly Comparer<T> _comparer = Comparer<T>.Default;
        private Node _root;

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
            Node parent = null;
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
                _root = new Node(item, null);
                return;
            }
            else if (_comparer.Compare(parent.Value, item) >= 0)
            {
                parent.Left = new Node(item, parent);
            }
            else
            {
                parent.Right = new Node(item, parent);
            }
        }

        public void Remove(T item)
        {
            var nodeToRemove = Find(item);

            if (nodeToRemove == null)
            {
                return;
            }

            if (nodeToRemove.Left == null && nodeToRemove.Right == null)
            {
                
            }
        }

        public bool Contains(T item)
        {
            return Find(item) != null;
        }

        public T Successor(T item)
        {
            var node = Find(item);

            if (node.Right != null)
            {
                return node.Right.Min();
            }

            var parent = node.Parent;
            while (parent != null && node == parent.Right)
            {
                node = parent;
                parent = parent.Parent;
            }

            if (parent == null)
            {
                return default;
            }
            else
            {
                return parent.Value;
            }
        }

        private Node Find(T item)
        {
            var current = _root;

            while (current != null)
            {
                if (_comparer.Compare(current.Value, item) == 0)
                {
                    return current;
                }
                else if (_comparer.Compare(current.Value, item) > 0)
                {
                    current = current.Left;
                }
                else
                {
                    current = current.Right;
                }
            }

            // Not found
            return null;
        }

        public T Max()
        {
            return _root.Max();
        }

        public T Min()
        {
            return _root.Min();
        }

        public IEnumerable<T> InOrderWalk()
        {
            return InOrderWalk(_root);
        }

        private IEnumerable<T> InOrderWalk(Node root)
        {
            if (root != null)
            {
                foreach(var node in InOrderWalk(root.Left))
                {
                    yield return node;
                }
                yield return root.Value;
                foreach (var node in InOrderWalk(root.Right))
                {
                    yield return node;
                }
            }
        }

        private class Node
        {
            internal Node(T value, Node parent)
            {
                Value = value;
                Parent = parent;
            }

            internal T Value { get; set; }
            internal Node Parent { get; set; }
            internal Node Right { get; set; }
            internal Node Left { get; set; }

            internal T Max()
            {
                if (this == null)
                {
                    return default;
                }

                var current = this;

                while (current.Right != null)
                {
                    current = current.Right;
                }

                return current.Value;
            }

            public T Min()
            {
                if (this == null)
                {
                    return default;
                }

                var current = this;

                while (current.Left != null)
                {
                    current = current.Left;
                }

                return current.Value;
            }
        }
    }
}
