using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace BinaryTree.UI
{
    public static class BinarySearchTreeSerializer
    {
        public static void SerializeByBinary<T>(BinarySearchTree<T> tree, string filePath) where T : IComparable<T>
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (var stream = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                formatter.Serialize(stream, tree);
            }
        }

        public static BinarySearchTree<T> DeserializeByBinary<T>(string filePath) where T : IComparable<T>
        {
            BinaryFormatter formatter = new BinaryFormatter();

            BinarySearchTree<T> tree;

            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                tree = (BinarySearchTree<T>)formatter.Deserialize(stream);
            }

            return tree;
        }

        public static void SerializeToXml<T>(BinarySearchTree<T> tree, string filePath) where T : IComparable<T>
        {
            using (var stream = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                var serializer = new XmlSerializer(tree.GetType());

                serializer.Serialize(stream, tree);
            }
        }

        public static BinarySearchTree<T> DeserializeXmlToTree<T>(Type treeType, string filePath) where T : IComparable<T>
        {
            BinarySearchTree<T> tree;
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                var serializer = new XmlSerializer(treeType);

                tree = (BinarySearchTree<T>)serializer.Deserialize(stream);
            }

            return tree;
        }
    }
}
