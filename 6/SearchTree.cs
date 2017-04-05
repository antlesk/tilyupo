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
        private Random rand = new Random();

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
        private Node Merge(Node firstTree, Node secondTree)
        {
            if (firstTree == null)
            {
                return secondTree;
            }

            if (secondTree == null)
            {
                return firstTree;
            }

            if (firstTree.Value > secondTree.Value)
            {
                Node temp = firstTree;
                firstTree = secondTree;
                secondTree = temp;
            }

            Node result;
            if (rand.Next() % 2 == 0)
            {
                result = firstTree;

                firstTree.Right = Merge(firstTree.Right, secondTree);
            }
            else
            {
                result = secondTree;

                result.Left = Merge(result.Left, firstTree);
            }

            return result;
        }

        public bool Find(int value)
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
                    return true;
                }
            }

            return false;
        }

        public void Pop(int value)
        {
            var currentNode = _root;

            while (currentNode != null)
            {
                if (currentNode.Value > value)
                {
                    currentNode = currentNode.Left;
                }
                else if (currentNode.Value < value)
                {
                    currentNode = currentNode.Right;
                }
                else
                {
                    Node newNode = Merge(currentNode.Left, currentNode.Right);
                    if (currentNode.Parent == null)
                    {
                        _root = newNode;
                    }
                    else if (currentNode.Parent.Value > currentNode.Value)
                    {
                        currentNode.Parent.Left = newNode;
                    }
                    else
                    {
                        currentNode.Parent.Right = newNode;
                    }

                    break;
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

            Node currentNode = _root;
            while (true)
            {
                if (currentNode.Value > value)
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
            foreach (var item in Go(_root))
            {
                yield return item;
            }
        }

        private IEnumerable<int> Go(Node node)
        {
            if (node != null)
            {
                foreach (var item in Go(node.Left))
                {
                    yield return item;
                }

                yield return node.Value;

                foreach (var item in Go(node.Right))
                {
                    yield return item;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
