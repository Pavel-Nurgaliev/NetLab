using NUnit.Framework;
using Student;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree.Test
{
    internal class StudentInfoProcessorData
    {
        private static IEnumerable<StudentData> InitStudentsFirst()
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

            var student5 = new StudentData("Pavel", "Nurgaliev", "SQL", 100, DateTime.Parse("28.05.2022",
                CultureInfo.GetCultureInfo("ru-Ru")), 3);
            students.Add(student5);

            var student6 = new StudentData("Pavel", "Nurgaliev", "CSS", 100, DateTime.Parse("28.05.2022",
                CultureInfo.GetCultureInfo("ru-Ru")), 5);
            students.Add(student6);

            return students;
        }

        private static IEnumerable<StudentData> InitStudentsSecond()
        {
            var students = new List<StudentData>();

            var student1 = new StudentData(
                "Pavel", "Nurgaliev", "SQL", 100, DateTime.Parse("12.05.2022",
                CultureInfo.GetCultureInfo("ru-Ru")), 4);
            students.Add(student1);

            var student2 = new StudentData(
                "Sergey", "Sidorov", "SQL", 200, DateTime.Parse("23.05.2022",
                CultureInfo.GetCultureInfo("ru-Ru")), 5);
            students.Add(student2);

            var student3 = new StudentData(
                "Ivan", "Ivanov", "SQL", 300, DateTime.Parse("21.05.2022",
                CultureInfo.GetCultureInfo("ru-Ru")), 3);
            students.Add(student3);

            return students;
        }

        private static IEnumerable<StudentData> InitStudentsWithDifferentDataPassed()
        {
            var students = new List<StudentData>();

            var student1 = new StudentData(
                "Pavel", "Nurgaliev", "SQL", 100, DateTime.Parse("12.03.2022",
                CultureInfo.GetCultureInfo("ru-Ru")), 4);
            students.Add(student1);

            var student2 = new StudentData(
                "Sergey", "Sidorov", "SQL", 200, DateTime.Parse("23.01.2022",
                CultureInfo.GetCultureInfo("ru-Ru")), 5);
            students.Add(student2);

            var student3 = new StudentData(
                "Ivan", "Ivanov", "SQL", 300, DateTime.Parse("21.05.2021",
                CultureInfo.GetCultureInfo("ru-Ru")), 3);
            students.Add(student3);

            return students;
        }

        public static IEnumerable<StudentData> InitStudentsWithSameTestTitle()
        {
            var students = new List<StudentData>();

            var student1 = new StudentData(
                "Pavel", "Nurgaliev", "421asd", 100, DateTime.Parse("12.03.2022",
                CultureInfo.GetCultureInfo("ru-Ru")), 4);
            students.Add(student1);

            var student2 = new StudentData(
                "Ivan", "Ivanov", "SQL", 300, DateTime.Parse("21.05.2021",
                CultureInfo.GetCultureInfo("ru-Ru")), 3);
            students.Add(student2);

            return students;
        }
        public static IEnumerable<TestCaseData> TestOfFirstDatePassedTestData
        {
            get
            {
                yield return new TestCaseData(InitStudentsFirst(), "SQL", 100).Returns(new DateTime(2022, 05, 05));
                yield return new TestCaseData(InitStudentsSecond(), "SQL", 100).Returns(new DateTime(2022, 05, 12));
            }
        }

        public static IEnumerable<TestCaseData> TestOfCountPassedTestInYearData
        {
            get
            {
                yield return new TestCaseData(InitStudentsFirst(), 2022).Returns(6);
                yield return new TestCaseData(InitStudentsSecond(), 2022).Returns(3);
            }
        }

        public static IEnumerable<TestCaseData> TestOfThreeHigherMarksData
        {
            get
            {
                yield return new TestCaseData(InitStudentsFirst()).Returns(new int[3] { 5, 5, 4 });
                yield return new TestCaseData(InitStudentsSecond()).Returns(new int[3] { 5, 4, 3 });
            }
        }

        public static IEnumerable<TestCaseData> TestOfStudentsNamesPassedTestData
        {
            get
            {
                yield return new TestCaseData(InitStudentsFirst()).Returns(
                    StudentsNamesOfFirst());
                yield return new TestCaseData(InitStudentsSecond()).Returns(
                    StudentsNamesOfSecond());
            }
        }

        private static string[] StudentsNamesOfFirst()
        {
            var students = new string[4];

            students[0] = "Artyom Ivanov";
            students[1] = "Ivan Ivanov";
            students[2] = "Pavel Nurgaliev";
            students[3] = "Sergey Sidorov";

            return students;
        }

        private static string[] StudentsNamesOfSecond()
        {
            var students = new string[3];

            students[0] = "Ivan Ivanov";
            students[1] = "Pavel Nurgaliev";
            students[2] = "Sergey Sidorov";

            return students;
        }

        public static IEnumerable<TestCaseData> TestOfExelentAndGoodStudentsData
        {
            get
            {
                yield return new TestCaseData(InitStudentsFirst()).Returns(
                    StudentWithMarksMoreThreeFirst().Select(student => $"{student.FirstName} {student.LastName}"));
                yield return new TestCaseData(InitStudentsSecond()).Returns(
                    StudentWithMarksMoreThreeSecond().Select(student => $"{student.FirstName} {student.LastName}"));
            }
        }

        private static IEnumerable<StudentData> StudentWithMarksMoreThreeSecond()
        {
            var students = new List<StudentData>();


            students.Add(new StudentData(
                "Pavel", "Nurgaliev", "SQL", 100, DateTime.Parse("12.05.2022",
                CultureInfo.GetCultureInfo("ru-Ru")), 4));
            students.Add(new StudentData(
                "Sergey", "Sidorov", "SQL", 200, DateTime.Parse("23.05.2022",
                CultureInfo.GetCultureInfo("ru-Ru")), 5));

            return students;
        }

        private static IEnumerable<StudentData> StudentWithMarksMoreThreeFirst()
        {
            var students = new List<StudentData>();

            students.Add(new StudentData(
                "Sergey", "Sidorov", "SQL", 200, DateTime.Parse("23.05.2022",
                CultureInfo.GetCultureInfo("ru-Ru")), 5));

            return students;
        }

        public static IEnumerable<TestCaseData> TestOfTitleTestWhichPassedOnTwoData
        {
            get
            {
                yield return new TestCaseData(InitStudentsFirst()).Returns(new string[] { $"SQL-300" });
                yield return new TestCaseData(InitStudentsSecond()).Returns("");
            }
        }

        public static IEnumerable<TestCaseData> TestOfAverageScoreOfStudentData
        {
            get
            {
                yield return new TestCaseData(InitStudentsFirst()).Returns(GetStudentsWithAverageMarkFirst());
                yield return new TestCaseData(InitStudentsSecond()).Returns(GetStudentsWithAverageMarkSecond());
            }
        }

        private static string[] GetStudentsWithAverageMarkFirst()
        {
            var students = new string[4];

            students[0] = "Artyom Ivanov: 3";
            students[1] = "Ivan Ivanov: 2";
            students[2] = "Pavel Nurgaliev: 4";
            students[3] = "Sergey Sidorov: 5";

            return students;
        }

        private static string[] GetStudentsWithAverageMarkSecond()
        {
            var students = new string[3];

            students[0] = "Ivan Ivanov: 3";
            students[1] = "Pavel Nurgaliev: 4";
            students[2] = "Sergey Sidorov: 5";

            return students;
        }

        public static IEnumerable<TestCaseData> TestOfStudentsInfoOfDatePassedData
        {
            get
            {
                yield return new TestCaseData(InitStudentsWithDifferentDataPassed(), 5, 2021).Returns(GetStudentDataOfDatePassedFirst());
                yield return new TestCaseData(InitStudentsSecond(), 5, 2022).Returns(GetStudentDataOfDatePassedSecond());
            }
        }

        private static IEnumerable<StudentData> GetStudentDataOfDatePassedSecond()
        {
            return InitStudentsSecond();
        }
        private static IEnumerable<StudentData> GetStudentDataOfDatePassedFirst()
        {
            var studentsList = new List<StudentData>();

            studentsList.Add(new StudentData(
                "Ivan", "Ivanov", "SQL", 300, DateTime.Parse("21.05.2021",
                CultureInfo.GetCultureInfo("ru-Ru")), 3));

            return studentsList;
        }

        public static IEnumerable<TestCaseData> TestOfIsTestTitleEqualPatternData
        {
            get
            {
                yield return new TestCaseData(InitStudentsWithDifferentDataPassed()).Returns(string.Empty);
                yield return new TestCaseData(InitStudentsWithSameTestTitle()).Returns(new string[] { "421asd-100" });
            }
        }

        public static IEnumerable<TestCaseData> TestOfStudentsWhichRepassedTestsData
        {
            get
            {
                yield return new TestCaseData(InitStudentsFirst()).Returns(new string[] { "Pavel Nurgaliev" });
                yield return new TestCaseData(InitStudentsWithSameTestTitle()).Returns(new string[0]);
            }
        }

        public static IEnumerable<TestCaseData> TestOfStudentNotPassedInYearData
        {
            get
            {
                yield return new TestCaseData(InitStudentsWithDifferentDataPassed(), 2021).Returns(new string[]
                {
                "Pavel Nurgaliev",
                "Sergey Sidorov"
                });
                yield return new TestCaseData(InitStudentsWithDifferentDataPassed(), 2022).Returns(new string[]
                {
                    "Ivan Ivanov"
                });


            }
        }
        public static IEnumerable<TestCaseData> TestOfTestsTitlesNotPassedInYearData
        {
            get
            {
                yield return new TestCaseData(InitStudentsWithDifferentDataPassed(), 2021).Returns(new string[]
                {
                "SQL-100",
                "SQL-200"
                });
                yield return new TestCaseData(InitStudentsWithDifferentDataPassed(), 2022).Returns(new string[]
                {
                    "SQL-300"
                });
            }
        }
    }
}

