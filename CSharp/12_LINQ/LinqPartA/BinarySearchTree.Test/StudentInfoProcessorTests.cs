using NUnit.Framework;
using System.Collections.Generic;
using Student;
using System;
using BinaryTree.UI;

namespace BinarySearchTree.Test
{
    public class BinarySearchTreeTests
    {
        [TestCaseSource(typeof(StudentInfoProcessorData), nameof(StudentInfoProcessorData.TestOfFirstDatePassedTestData))]
        public DateTime TestOfFirstDatePassedTest_FirstDate_Success(IEnumerable<StudentData> students, string testTitle, int testLevel)
        {
            return StudentInfoProcessor.GetFirstDatePassedTest(students, testTitle, testLevel);
        }

        [TestCaseSource(typeof(StudentInfoProcessorData), nameof(StudentInfoProcessorData.TestOfCountPassedTestInYearData))]
        public int TestOfCountPassedTestInYear_CountOfStudents_Success(IEnumerable<StudentData> students, int year)
        {
            return StudentInfoProcessor.GetCountPassedTestInYear(students, year);
        }

        [TestCaseSource(typeof(StudentInfoProcessorData), nameof(StudentInfoProcessorData.TestOfThreeHigherMarksData))]
        public int[] TestOfThreeHigherMarks_MarksOfStudents_Success(IEnumerable<StudentData> students)
        {
            return StudentInfoProcessor.GetThreeHigherMarks(students);
        }

        [TestCaseSource(typeof(StudentInfoProcessorData), nameof(StudentInfoProcessorData.TestOfStudentsNamesPassedTestData))]
        public string[] TestOfStudentsNamesPassedTest_StudentsNames_Success(IEnumerable<StudentData> students)
        {
            return StudentInfoProcessor.GetStudentsNamesPassedTest(students);
        }

        [TestCaseSource(typeof(StudentInfoProcessorData), nameof(StudentInfoProcessorData.TestOfExelentAndGoodStudentsData))]
        public IEnumerable<string> TestOfExelentAndGoodStudents_StudentsWithMarkMoreThree_Success(IEnumerable<StudentData> students)
        {
            return StudentInfoProcessor.GetExelentAndGoodStudents(students);
        }

        [TestCaseSource(typeof(StudentInfoProcessorData), nameof(StudentInfoProcessorData.TestOfTitleTestWhichPassedOnTwoData))]
        public string[] TestOfTitleTestWhichPassedOnTwo_TestTitle_Success(IEnumerable<StudentData> students)
        {
            return StudentInfoProcessor.GetTitleTestWhichPassedOnTwo(students);
        }

        [TestCaseSource(typeof(StudentInfoProcessorData), nameof(StudentInfoProcessorData.TestOfAverageScoreOfStudentData))]
        public string[] TestOfAverageScoreOfStudent_StringsList_Success(IEnumerable<StudentData> students)
        {
            return StudentInfoProcessor.GetAverageScoreOfStudent(students);
        }

        [TestCaseSource(typeof(StudentInfoProcessorData), nameof(StudentInfoProcessorData.TestOfStudentsInfoOfDatePassedData))]
        public IEnumerable<StudentData> TestOfStudentsInfoOfDatePassed_StudentData_Success(IEnumerable<StudentData> students,
            int month, int year)
        {
            return StudentInfoProcessor.GetStudentsInfoOfDatePassed(students, month, year);
        }

        [TestCaseSource(typeof(StudentInfoProcessorData), nameof(StudentInfoProcessorData.TestOfIsTestTitleEqualPatternData))]
        public string[] TestOfIsTestTitleEqualPattern_CheckedOnEqual_Success(IEnumerable<StudentData> students)
        {
            return StudentInfoProcessor.GetTestTitleIsNotEqualPattern(students);
        }

        [TestCaseSource(typeof(StudentInfoProcessorData), nameof(StudentInfoProcessorData.TestOfStudentsWhichRepassedTestsData))]
        public string[] TestOfStudentsWhichRepassedTests_StudentDataAboutRepassed_Success(IEnumerable<StudentData> students)
        {
            return StudentInfoProcessor.GetStudentsWhichRepassedTests(students);
        }

        [TestCaseSource(typeof(StudentInfoProcessorData), nameof(StudentInfoProcessorData.TestOfStudentNotPassedInYearData))]
        public static string[] TestOfStudentNotPassedInYear_StudentsNotPassedInYear_Success(IEnumerable<StudentData> students,
            int year)
        {
            return StudentInfoProcessor.GetStudentNotPassedInYear(students, year);
        }

        [TestCaseSource(typeof(StudentInfoProcessorData), nameof(StudentInfoProcessorData.TestOfTestsTitlesNotPassedInYearData))]
        public static string[] TestOfTestsTitlesNotPassedInYear_StudentsNotPassedInYear_Success(IEnumerable<StudentData> students,
            int year)
        {
            return StudentInfoProcessor.GetTestsTitlesNotPassedInYear(students, year);
        }
    }
}