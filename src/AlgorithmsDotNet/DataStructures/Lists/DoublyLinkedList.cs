using System;
using System.Collections;
using System.Collections.Generic;

namespace AlgorithmsDotNet.DataStructures.Lists
{
    public class DoublyLinkedList<T> : IList<T>
    {
        private ListNode _head;
        private ListNode _tail;

        public T this[int index]
        {
            get => Traverse(index).Data;
            set => Traverse(index).Data = value;
        }

        public int Count { get; private set; }

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            if (_head is null)
            {
                _head = new ListNode(item);
                _tail = _head;
            }
            else
            {
                var newNode = new ListNode(item)
                {
                    Previous = _tail
                };

                _tail.Next = newNode;
                _tail = newNode;
            }

            Count++;
        }

        public void Clear()
        {
            _head = null;
            _tail = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            return Find(item) != null;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            var current = _head;
            for (var i = arrayIndex; current != null; i++)
            {
                array[i] = current.Data;
                current = current.Next;
            }
        }

        public int IndexOf(T item)
        {
            var current = _head;
            var i = 0;

            while (current != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Data, item))
                {
                    return i;
                }

                current = current.Next;
                i++;
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            var insertAfter = Traverse(index);
            var nextNode = insertAfter.Next;
            var newNode = new ListNode(item)
            {
                Previous = insertAfter,
                Next = nextNode
            };

            insertAfter.Next = newNode;
            nextNode.Previous = newNode;

            Count++;
        }

        public bool Remove(T item)
        {
            // Find item - If not in list return false
            var nodeToRemove = Find(item);
            if (nodeToRemove is null)
            {
                return false;
            }

            var nextNode = nodeToRemove.Next;

            // Cut out node to remove
            nodeToRemove.Previous.Next = nextNode;
            nextNode.Previous = nodeToRemove.Previous;

            Count--;
            return true;
        }

        public void RemoveAt(int index)
        {
            var nodeToRemove = Traverse(index);
            var nextNode = nodeToRemove.Next;

            // Cut out node to remove
            nodeToRemove.Previous.Next = nextNode;
            nextNode.Previous = nodeToRemove.Previous;

            Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = _head;

            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private ListNode Traverse(int offset)
        {
            if (offset >= Count)
            {
                throw new InvalidOperationException("Index is out of bounds");
            }

            var current = _head;
            for (int i = 0; i <= offset; i++)
            {
                current = current.Next;
            }

            return current;
        }

        private ListNode Find(T item)
        {
            var current = _head;
            while (current != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Data, item))
                {
                    return current;
                }

                current = current.Next;
            }

            return null;
        }

        private class ListNode
        {
            internal ListNode(T data)
            {
                Data = data;
            }

            internal T Data { get; set; }
            internal ListNode Next { get; set; }
            internal ListNode Previous { get; set; }
        }
    }
}
