using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_2_26
{
    class SearchTree : IEnumerable<int>
    {
        private class Node
        {
            public Node Left { get; set; } = null;
            public Node Right { get; set; } = null;
            public Node Parent { get; set; } = null;

            public int Value { get; set; }
        }

        private Node _root = null;
        private static readonly Random rand = new Random(1);

        public SearchTree(IEnumerable list)
        {
            foreach (int item in list)
            {
                Insert(item);
            }
        }

        public SearchTree()
        {
        }

        public bool Find(int value)
        {
            return FindNode(value) != null;
        }

        private Node FindNode(int value)
        {
            var currentNode = _root;

            while (currentNode != null)
            {
                if (currentNode.Value < value)
                {
                    currentNode = currentNode.Right;
                }
                else if (currentNode.Value > value)
                {
                    currentNode = currentNode.Left;
                }
                else
                {
                    return currentNode;
                }
            }

            return null;
        }

        public void Remove(int value)
        {
            if (!Find(value))
            {
                return;
            }
            
            RemoveNode(FindNode(value));
        }

        private void RemoveNode(Node node)
        {
            if (node == null)
            {
                return;
            }
            else if (node.Left == null && node.Right == null)
            {
                if (node.Parent != null)
                {
                    if (node.Value < node.Parent.Value)
                    {
                        node.Parent.Left = null;
                    }
                    else
                    {
                        node.Parent.Right = null;
                    }
                }
                else
                {
                    _root = null;
                }
            }
            else if (node.Right == null)
            {
                node.Value = node.Left.Value;
                node.Right = node.Left.Right;
                node.Left = node.Left.Left;
            }
            else if (node.Left == null)
            {
                node.Value = node.Right.Value;
                node.Left = node.Right.Left;
                node.Right = node.Right.Right;
            }
            else
            {
                var newNode = node.Right;
                while (newNode.Left != null)
                {
                    newNode = newNode.Left;
                }

                if (newNode == node.Right)
                {
                    node.Value = newNode.Value;
                    node.Right = newNode.Right;
                }
                else
                {
                    node.Value = newNode.Value;
                    RemoveNode(newNode);
                }
            }
        }

        public void Insert(int value)
        {
            if (Find(value))
            {
                return;
            }

            if (_root == null)
            {
                _root = new Node { Value = value };
                return;
            }

            var currentNode = _root;
            while (true)
            {
                if (value < currentNode.Value)
                {
                    if (currentNode.Left == null)
                    {
                        currentNode.Left = new Node { Value = value, Parent = currentNode };
                        break;
                    }
                    else
                    {
                        currentNode = currentNode.Left;
                    }
                }
                else
                {
                    if (currentNode.Right == null)
                    {
                        currentNode.Right = new Node { Value = value, Parent = currentNode };
                        break;
                    }
                    else
                    {
                        currentNode = currentNode.Right;
                    }
                }
            }
        }

        public IEnumerator<int> GetEnumerator()
        {
            foreach (var item in WalkOn(_root))
            {
                yield return item;
            }
        }

        private IEnumerable<int> WalkOn(Node node)
        {
            if (node != null)
            {
                foreach (var item in WalkOn(node.Left))
                {
                    yield return item;
                }

                yield return node.Value;

                foreach (var item in WalkOn(node.Right))
                {
                    yield return item;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
