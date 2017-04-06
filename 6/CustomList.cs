using System;
using System.Collections;
using System.Collections.Generic;

namespace _5_2_26
{
    sealed class Node<T>
    {
        public Node<T> Next { get; set; } = null;
        public Node<T> Prev { get; set; } = null;

        public T Value { get; set; }
    }

    class CustomList<T> : IEnumerable<T>
    {
        public int Length { get; private set; }

        private Node<T> _head = null;
        private Node<T> _tail = null;

        public CustomList()
        {
        }

        public void Add(T value)
        {
            if (_head == null)
            {
                _head = _tail = new Node<T> { Value = value };
            }
            else
            {
                _tail.Next = new Node<T>() { Value = value, Prev = _tail };
                _tail = _tail.Next;
            }

            Length++;
        }

        private Node<T> IndexOf(int index)
        {
            Node<T> currentNode = _head;
            for (int i = 0; i < index; i++)
            {
                currentNode = currentNode.Next;
            }

            if (currentNode == null)
            {
                throw new ArgumentOutOfRangeException();
            }

            return currentNode;
        }

        public void Remove(int index)
        {
            Node<T> node = IndexOf(index);
            if (node.Prev != null)
            {
                node.Prev.Next = node.Next;
            }

            if (node.Next != null)
            {
                node.Next.Prev = node.Prev;
            }

            Length--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (Node<T> currentNode = _head; currentNode != null; currentNode = currentNode.Next)
            {
                yield return currentNode.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public T this[int index]
        {
            get
            {
                return IndexOf(index).Value;
            }
            set
            {
                IndexOf(index).Value = value;
            }
        }
    }
}
