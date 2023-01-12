using System;
using Student;
using System.Collections.Generic;
using System.Globalization;

namespace BinaryTree.UI
{
    internal class Program
    {

        private const string PathOfSerializeStudentDataByBinary = "SerializeStudentDataByBinary.txt";
        private const string PathOfSerializeStudentDataByXml = "SerializeStudentDataByXml.xml";

        private const string PathOfSerializeNumbersByBinary = "SerializeNumbersByBinary.txt";
        static void Main(string[] args)
        {
            var students = InitStudents();
            var numbers = new int[8] { 8, 3, 2, 1, 5, 4, 6, 12 };

            SerializerTests.TestXmlSerialize(students, PathOfSerializeStudentDataByXml);
            SerializerTests.TestBinSerialize(students, numbers, PathOfSerializeStudentDataByBinary, PathOfSerializeNumbersByBinary);
        }

        private static IEnumerable<StudentData> InitStudents()
        {
            var students = new List<StudentData>();

            var student1 = new StudentData(
                "Pavel", "Nurgaliev", "SQL", 100, DateTime.Parse("22.05.2022",
                CultureInfo.GetCultureInfo("ru-Ru")), 4);
            students.Add(student1);

            var student2 = new StudentData(
                "Sergey", "Sidorov", "SQL", 200, DateTime.Parse("23.05.2022",
                CultureInfo.GetCultureInfo("ru-Ru")), 5);
            students.Add(student2);

            var student3 = new StudentData(
                "Ivan", "Ivanov", "SQL", 300, DateTime.Parse("21.05.2022",
                CultureInfo.GetCultureInfo("ru-Ru")), 2);
            students.Add(student3);

            var student4 = new StudentData(
               "Artyom", "Ivanov", "SQL", 100, DateTime.Parse("05.05.2022",
               CultureInfo.GetCultureInfo("ru-Ru")), 3);
            students.Add(student4);

            var student5 = new StudentData("Pavel", "Nurgaliev", "XML", 100, DateTime.Parse("28.05.2022",
                CultureInfo.GetCultureInfo("ru-Ru")), 3);
            students.Add(student5);

            var student6 = new StudentData("Pavel", "Nurgaliev", "CSS", 100, DateTime.Parse("28.05.2022",
                CultureInfo.GetCultureInfo("ru-Ru")), 3);
            students.Add(student6);

            return students;
        }
    }
}
