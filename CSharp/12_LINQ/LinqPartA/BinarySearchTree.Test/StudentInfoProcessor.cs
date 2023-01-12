using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Student;

namespace BinaryTree.UI
{
    public class StudentInfoProcessor
    {
        private const int MinMonthValue = 1;
        private const int MaxMonthValue = 12;
        private const int MinYearValue = 1900;
        private const int MaxYearValue = 2022;

        private const string ErrorMessageMonth = "Month must be less {0} and more {1}";
        private const string ErrorMessageYear = "Year must be less {0} and more {1}";
        public static DateTime GetFirstDatePassedTest(IEnumerable<StudentData> students, string testTitle, int testLevel)
        {
            try
            {
                var studentsPassedTest = from student in students
                                         orderby student.DatePassed
                                         select student;

                var result = studentsPassedTest.FirstOrDefault(student => student.TestLevel.Equals(testLevel) &&
                                        student.TestTitle.Equals(testTitle)).DatePassed;

                return result;
            }
            catch (NullReferenceException ex)
            {

                return DateTime.Parse("00.00.0000",
                CultureInfo.GetCultureInfo("ru-Ru"));
            }
        }

        public static int GetCountPassedTestInYear(IEnumerable<StudentData> students, int year)
        {
            return students.Count(student => student.DatePassed.Year == year);
        }

        public static int[] GetThreeHigherMarks(IEnumerable<StudentData> students)
        {
            return students.OrderByDescending(student => student.Mark).Take(3).Select(student => student.Mark).ToArray();
        }

        public static string[] GetStudentsNamesPassedTest(IEnumerable<StudentData> students)
        {
            return students
                .OrderBy(student => student.FirstName)
                .ThenBy(student => student.LastName)
                .Select(student => $"{student.FirstName} {student.LastName}")
                .Distinct()
                .ToArray();
        }

        public static string[] GetExelentAndGoodStudents(IEnumerable<StudentData> students)
        {
            var excelentAndGoodStudents = students.GroupBy(student => $"{student.FirstName} {student.LastName}",
                student => student.Mark, (fullName, marks) =>
                new
                {
                    FullName = fullName,
                    GoodOrExelent = marks.All(mark => mark > 3)
                }).Where(student => student.GoodOrExelent).Select(student => student.FullName);

            return excelentAndGoodStudents.ToArray();
        }

        public static string[] GetTitleTestWhichPassedOnTwo(IEnumerable<StudentData> students)
        {
            return students
                .Where(student => student.Mark == 2)
                .Select(student => $"{student.TestTitle}-{student.TestLevel}")
                .Distinct()
                .ToArray();
        }

        public static string[] GetAverageScoreOfStudent(IEnumerable<StudentData> students)
        {
            Dictionary<string, double> averageScoreOfStudents = students
                .GroupBy(student => $"{student.FirstName} {student.LastName}",
                student => student.Mark, (fullName, marks) => new
                {
                    FullName = fullName,
                    Mark = marks.Average()
                }).ToDictionary(student => student.FullName, student => student.Mark);

            return averageScoreOfStudents
                .OrderBy(student => student.Key)
                .Select(student => $"{ student.Key}: {student.Value}").ToArray();
        }

        public static IEnumerable<StudentData> GetStudentsInfoOfDatePassed(IEnumerable<StudentData> students,
            int month, int year)
        {
            if (month < MinMonthValue || month > MaxMonthValue)
            {
                throw new ArgumentOutOfRangeException(nameof(month),
                    string.Format(ErrorMessageMonth, MinMonthValue, MaxMonthValue));
            }
            if (year < MinYearValue || year > MaxYearValue)
            {
                throw new ArgumentOutOfRangeException(nameof(year),
                    string.Format(ErrorMessageYear, MinYearValue, MaxYearValue));
            }

            var studentsInfoOfDatePassed = students.Where(student => student.DatePassed.Month.Equals(month)
            && student.DatePassed.Year.Equals(year));

            return studentsInfoOfDatePassed;
        }

        public static string[] GetTestTitleIsNotEqualPattern(IEnumerable<StudentData> students)
        {
            var incorectTestTitleStudents = students
                .Where(student => !Regex.IsMatch($"{student.TestTitle}-{student.TestLevel}", @"[A-Z]+-[1-3]00"))
                .Select(student => $"{student.TestTitle}-{student.TestLevel}");

            return incorectTestTitleStudents.ToArray();
        }

        public static (string, string[]) GetAllTestsOfStudent(IEnumerable<StudentData> students, string studentFirstName, string studentLastName)
        {
            Dictionary<string, string[]> studentsAndTests = students
                .GroupBy(student => $"{student.FirstName} {student.LastName}", tests => $"{tests.TestTitle}-{tests.TestLevel}",
                (fullName, tests) => new
                {
                    FullName = fullName,
                    Tests = tests.ToArray()
                }).ToDictionary(student => student.FullName, tests => tests.Tests);

            var fullName = $"{studentFirstName} {studentLastName}";
            return (fullName, studentsAndTests
                .Where(student => student.Key.Equals(fullName))
                .Select(tests => tests.Value.ToString())
                .ToArray());
        }

        public static string[] GetStudentsWhichRepassedTests(IEnumerable<StudentData> students)
        {
            Dictionary<string, string[]> studentsAndTests = students
                .GroupBy(student => $"{student.FirstName} {student.LastName}",
                tests => $"{tests.TestTitle}-{tests.TestLevel}", (fullName, tests) => new
                {
                    FullName = fullName,
                    Tests = tests.Where(test => tests.Count(studentTest => studentTest.Equals(test)) > 1).ToArray()
                }).ToDictionary(student => student.FullName, tests => tests.Tests);

            var repassedStudents = studentsAndTests.Where(student => student.Value.Count() > 0).OrderBy(student => student.Key);

            return repassedStudents.Select(student => student.Key).ToArray();
        }

        public static string[] GetStudentNotPassedInYear(IEnumerable<StudentData> students, int year)
        {
            var studentNotPassed = students
                .GroupBy(student => $"{student.FirstName} {student.LastName}", passedYear => passedYear.DatePassed.Year)
                .Where(student => !student.Contains(year))
                .Select(student => student.Key);

            return studentNotPassed.ToArray();
        }

        public static string[] GetTestsTitlesNotPassedInYear(IEnumerable<StudentData> students, int year)
        {
            var testNotPassed = students
                .GroupBy(test => $"{test.TestTitle}-{test.TestLevel}", passedYear => passedYear.DatePassed.Year)
                .Where(test => !test.Contains(year))
                .Select(test => test.Key);

            return testNotPassed.ToArray();
        }
    }
}

