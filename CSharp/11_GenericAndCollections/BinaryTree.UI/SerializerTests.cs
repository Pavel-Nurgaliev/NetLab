using Student;
using System;
using System.Collections.Generic;

namespace BinaryTree.UI
{
    public static class SerializerTests
    {
        public const string SerializationExceptionMessage = "Serialization excetpion";

        public static void TestXmlSerialize(IEnumerable<StudentData> students, string filePath)
        {
            try
            {
                TestTreeWithXmlSerialization<StudentData>(new IterativeTree<StudentData>(),
                students, filePath);
            }
            catch (Exception)
            {
                Console.WriteLine(SerializationExceptionMessage);
            }

            try
            {
                TestTreeWithXmlSerialization(new RecursiveTree<StudentData>(),
                    students, filePath);
            }
            catch (Exception)
            {
                Console.WriteLine(SerializationExceptionMessage);
            }
        }

        public static void TestBinSerialize(IEnumerable<StudentData> students, int[] numbers,
            string filePathForStudentData, string filePathForNumbers)
        {
            try
            {
                TestTreeWithBinSerialization<StudentData>(new IterativeTree<StudentData>(),
                students, filePathForStudentData);
            }
            catch (Exception)
            {
                Console.WriteLine(SerializationExceptionMessage);
            }

            try
            {
                TestTreeWithBinSerialization<int>(new RecursiveTree<int>(),
                    numbers, filePathForNumbers);
            }
            catch (Exception)
            {
                Console.WriteLine(SerializationExceptionMessage);
            }
        }

        private static void TestTreeWithBinSerialization<T>(BinarySearchTree<T> tree, IEnumerable<T> items,
            string filePathForStudentData) where T : IComparable<T>
        {
            tree.AddRange(items);

            BinarySearchTreeSerializer.SerializeByBinary<T>(tree, filePathForStudentData);

            RemoveElementsOfTree(tree, items);

            tree = BinarySearchTreeSerializer.DeserializeByBinary<T>(filePathForStudentData);

            PrintItems(tree);
        }

        private static void TestTreeWithXmlSerialization<T>(BinarySearchTree<T> tree, IEnumerable<T> items, string filePath) where T : IComparable<T>
        {
            tree.AddRange(items);

            XmlStore(tree, items, filePath);

            RemoveElementsOfTree(tree, items);

            tree = ReadXmlToTree<T>(tree.GetType(), filePath);

            PrintItems(tree);
        }

        private static void RemoveElementsOfTree<T>(BinarySearchTree<T> tree, IEnumerable<T> items) where T : IComparable<T>
        {
            foreach (var item in items)
                tree.Remove(item);
        }

        private static BinarySearchTree<T> ReadXmlToTree<T>(Type treeType, string filePath) where T : IComparable<T>
        {
            var tree = BinarySearchTreeSerializer.DeserializeXmlToTree<T>(treeType, filePath);

            return tree;
        }

        private static void XmlStore<T>(BinarySearchTree<T> tree, IEnumerable<T> items, string filePath) where T : IComparable<T>
        {
            BinarySearchTreeSerializer.SerializeToXml(tree, filePath);
        }

        public static void PrintItems<T>(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }

    }
}
