using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace BinaryTree
{
    [Serializable]
    public abstract class BinarySearchTree<TItem> : IEnumerable<TItem>, IXmlSerializable where TItem : IComparable<TItem>
    {
        public Node<TItem> Root { get; set; }
        public bool IsEmpty => Root == null;

        public BinarySearchTree()
        {
        }

        public BinarySearchTree(TItem item)
        {
            Add(item);
        }

        public BinarySearchTree(IEnumerable<TItem> collection)
        {
            AddRange(collection);
        }

        public abstract void Add(TItem data);

        public void AddRange(IEnumerable<TItem> data)
        {
            foreach (var item in data)
            {
                Add(item);
            }
        }

        public abstract Node<TItem> Find(TItem data);
        protected abstract Node<TItem> Find(TItem data, out Node<TItem> parent);

        public abstract IEnumerator<TItem> GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        public TItem GetMax()
        {
            return this.Last();
        }

        public TItem GetMin()
        {
            var items = new List<TItem>(this);

            return this.First();
        }

        protected int Compare(TItem data, Node<TItem> node)
        {
            return node.Data.CompareTo(data);
        }

        public bool Remove(TItem data)
        {
            var nodeToRemove = Find(data, out var parent);

            if (nodeToRemove == null)
            {
                return false;
            }
            if (nodeToRemove.Left == null && nodeToRemove.Right == null)
            {
                RemoveNodeHavingNoChildren(nodeToRemove, parent);
            }
            else if (nodeToRemove.Left != null && nodeToRemove.Right == null ||
               nodeToRemove.Left == null && nodeToRemove.Right != null)
            {
                RemoveNodeHavingOneChild(nodeToRemove, parent);
            }
            else
            {
                RemoveNodeHavingBothChildren(nodeToRemove, parent);
            }

            return true;
        }

        private void RemoveNodeHavingNoChildren(Node<TItem> nodeToRemove, Node<TItem> parent)
        {
            if (parent == null)
            {
                Root = null;
            }
            else
            {
                if (Compare(nodeToRemove.Data, parent) > 0)
                {
                    parent.Left = null;
                }
                else
                {
                    parent.Right = null;
                }
            }
        }

        private void RemoveNodeHavingOneChild(Node<TItem> nodeToRemove, Node<TItem> parent)
        {
            var child = nodeToRemove.Left ?? nodeToRemove.Right;

            if (parent == null)
            {
                Root = child;
            }
            else
            {
                if (Compare(nodeToRemove.Data, parent) > 0)
                {
                    parent.Left = child;
                }
                else
                {
                    parent.Right = child;
                }
            }
        }

        private void RemoveNodeHavingBothChildren(Node<TItem> nodeToRemove, Node<TItem> parent)
        {
            Node<TItem>? root = Root;

            Root = nodeToRemove.Left;
            Node<TItem>? replacement = Find(GetMax(), out Node<TItem>? replacementParent);

            Root = root;

            if (replacement is null)
            {
                return;
            }

            if (parent == null)
            {
                Root = replacement;
            }
            else
            {
                if (nodeToRemove.CompareTo(parent) < 0)
                {
                    parent.Left = replacement;
                }
                else
                {
                    parent.Right = replacement;
                }
            }

            if (replacementParent is not null && replacementParent != nodeToRemove)
            {
                replacementParent.Right = null;
            }

            if (replacement != nodeToRemove.Left)
            {
                replacement.Left = nodeToRemove.Left;
            }

            replacement.Right = nodeToRemove.Right;
        }

        public XmlSchema GetSchema()
        {
            return (null);
        }

        public void ReadXml(XmlReader reader)
        {
            var serializer = new XmlSerializer(typeof(Node<TItem>));

            reader.ReadStartElement();

            Root = (Node<TItem>?)serializer.Deserialize(reader);

            reader.ReadEndElement();
        }

        public void WriteXml(XmlWriter writer)
        {
            var serializer = new XmlSerializer(typeof(Node<TItem>));

            serializer.Serialize(writer, Root);
        }
    }
}