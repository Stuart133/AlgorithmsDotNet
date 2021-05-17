using System;
using System.Collections;
using System.Collections.Generic;

namespace AlgorithmsDotNet.DataStructures.Lists
{
    public class SinglyLinkedList<T> : IList<T>
    {
        private ListNode _head;
        private ListNode _tail;

        public T this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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
                _tail.Next = new ListNode(item);
            }
        }

        public void Clear()
        {
            _head = null;
            _tail = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        private class ListNode
        {
            internal ListNode(T data)
            {
                Data = data;
            }

            internal T Data { get; }
            internal ListNode Next { get; set; }
        }
    }
}
