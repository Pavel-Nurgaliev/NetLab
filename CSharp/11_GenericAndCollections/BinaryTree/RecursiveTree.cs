using System;
using System.Collections.Generic;

namespace BinaryTree
{
    [Serializable]
    public class RecursiveTree<TItem> : BinarySearchTree<TItem> where TItem : IComparable<TItem>
    {
        private const string ErrorMessageInputCode = "This node already exist";
        public RecursiveTree() : base()
        {
        }

        public RecursiveTree(TItem item) : base(item)
        {

        }

        public RecursiveTree(IEnumerable<TItem> collection) : base(collection)
        {

        }

        public override void Add(TItem item)
        {
            if (IsEmpty)
            {
                Root = new Node<TItem>(item);
            }
            else
            {
                AddItem(Root, item);
            }
        }

        private void AddItem(Node<TItem> node, TItem item)
        {
            if (node.Data.CompareTo(item) > 0)
            {
                if (node.Left == null)
                    node.Left = new Node<TItem>(item);
                else
                    AddItem(node.Left, item);
            }
            else if (node.Data.CompareTo(item) < 0)
            {
                if (node.Right == null)
                    node.Right = new Node<TItem>(item);
                else
                    AddItem(node.Right, item);
            }
            else
            {
                throw new InvalidOperationException(ErrorMessageInputCode);
            }
        }

        public override Node<TItem> Find(TItem data)
        {
            return Find(data, out var parent);
        }

        protected override Node<TItem> Find(TItem data, out Node<TItem> parent)
        {
            return Find(data, Root, null, out parent);
        }

        private Node<TItem> Find(TItem data, Node<TItem> currentNode, Node<TItem> currentParent, out Node<TItem> parent)
        {
            if (currentNode != null && Compare(data, currentNode) != 0)
            {
                var childNode = Compare(data, currentNode) > 0 ? currentNode.Left : currentNode.Right;

                return Find(data, childNode, currentNode, out parent);
            }

            parent = currentParent;

            return currentNode;
        }

        private IEnumerable<Node<TItem>> GetEnumerable(Node<TItem> node)
        {
            if (node == null)
                yield break;

            if (node.Left != null)
            {
                foreach (var element in GetEnumerable(node.Left))
                    yield return element;
            }

            yield return node;

            if (node.Right != null)
            {
                foreach (var element in GetEnumerable(node.Right))
                    yield return element;
            }
        }

        public override IEnumerator<TItem> GetEnumerator()
        {
            foreach (var item in GetEnumerable(Root))
            {
                yield return item.Data;
            }
        }
    }
}

