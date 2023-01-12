using System;

namespace BinaryTree
{
    [Serializable]
    public class Node<TItem> : IComparable<Node<TItem>>, IEquatable<Node<TItem>> where TItem : IComparable<TItem>
    {
        public Node()
        {

        }
        public Node(TItem item)
        {
            Data = item;
        }

        public TItem Data { get; set; }

        public Node<TItem> Left { get; set; }
        public Node<TItem> Right { get; set; }

        public int CompareTo(Node<TItem> node)
        {
            if (node is null)
            {
                return -1;
            }

            return Data.CompareTo(node.Data);
        }

        public bool Equals(Node<TItem> node)
        {
            return node != null && Data.CompareTo(node.Data) == 0;
        }
    }
}
