using System;
using System.Collections.Generic;

namespace BinaryTree
{
    [Serializable]
    public class IterativeTree<TItem> : BinarySearchTree<TItem> where TItem : IComparable<TItem>
    {
        private const string ErrorMessageInputCode = "This node already exist";
        public IterativeTree() : base()
        {
        }

        public IterativeTree(TItem item) : base(item)
        {

        }

        public IterativeTree(IEnumerable<TItem> collection) : base(collection)
        {

        }

        public override void Add(TItem item)
        {
            if (IsEmpty)
            {
                Root = new Node<TItem>(item);
                return;
            }

            var parentNode = (Node<TItem>)null;

            var curentNode = Root;

            while (curentNode != null)
            {
                parentNode = curentNode;

                var compareResult = Compare(item, curentNode);

                if (compareResult == 0)
                {
                    throw new InvalidOperationException(ErrorMessageInputCode);
                }

                curentNode = compareResult > 0 ? curentNode.Left : curentNode.Right;
            }

            if (parentNode != null)
            {
                var newNode = new Node<TItem>(item);

                if (Compare(item, parentNode) > 0)
                {
                    parentNode.Left = newNode;
                }
                else
                {
                    parentNode.Right = newNode;
                }
            }
        }

        public override Node<TItem> Find(TItem data)
        {
            return Find(data, out _);
        }

        protected override Node<TItem> Find(TItem data, out Node<TItem> parent)
        {
            parent = null;

            var currentNode = Root;

            while (currentNode != null && Compare(data, currentNode) != 0)
            {
                parent = currentNode;

                currentNode = Compare(data, currentNode) > 0 ? currentNode.Left : currentNode.Right;
            }

            return currentNode;
        }

        public override IEnumerator<TItem> GetEnumerator()
        {
            if (IsEmpty)
            {
                yield break;
            }

            var stack = new Stack<Node<TItem>>();
            var currentNode = Root;

            while (stack.Count > 0 || currentNode != null)
            {
                if (currentNode != null)
                {
                    stack.Push(currentNode);

                    currentNode = currentNode.Left;
                }
                else
                {
                    currentNode = stack.Pop();

                    yield return currentNode.Data;

                    currentNode = currentNode.Right;
                }
            }
        }
    }
}
