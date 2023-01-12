using System;

namespace Student
{
    [Serializable]
    public class StudentData : IComparable<StudentData>, IEquatable<StudentData>
    {
        private const int MaxValueMark = 5;
        private const int MinValueMark = 2;
        private const string ErrorMessageMark = "Mark must be less {0} and more {1}.";

        public StudentData()
        {
        }
        public StudentData(string firstName, string lastName, string testTitle, int testLevel, DateTime datePassed, int mark)
        {
            if (!CheckTestLevel(testLevel))
            {
                throw new ArgumentException(string.Format(ErrorMessageMark, nameof(testLevel)));
            }
            if (mark > MaxValueMark || mark < MinValueMark)
            {
                throw new ArgumentException(string.Format(ErrorMessageMark, MaxValueMark, MaxValueMark), nameof(mark));
            }

            FirstName = firstName;
            LastName = lastName;
            TestTitle = testTitle;
            TestLevel = testLevel;
            DatePassed = datePassed;
            Mark = mark;
        }

        private bool CheckTestLevel(int testLevel)
        {
            return testLevel == 100 || testLevel == 200 || testLevel == 300;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TestTitle { get; set; }
        public int TestLevel { get; set; }
        public DateTime DatePassed { get; set; }
        public int Mark { get; set; }

        public override string ToString() =>
            $"Student:{Environment.NewLine}{FirstName} {LastName}, {TestTitle}-{TestLevel}, {DatePassed}, {Mark}";

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(StudentData)) return false;

            return Equals(obj as StudentData);
        }

        public bool Equals(StudentData student)
        {
            if (ReferenceEquals(null, student)) return false;
            if (ReferenceEquals(this, student)) return true;

            return FirstName == student.FirstName && LastName == student.LastName &&
                TestTitle == student.TestTitle && DatePassed == student.DatePassed &&
                Mark == student.Mark;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FirstName, LastName, TestTitle, DatePassed, Mark);
        }

        public int CompareTo(StudentData student)
        {
            if (student == null)
            {
                return -1;
            }

            return GetResultCompareTo(student);
        }

        private int GetResultCompareTo(StudentData student)
        {
            var result = FirstName.CompareTo(student.FirstName);
            if (result == 0)
            {
                result = LastName.CompareTo(student.LastName);

                if (result == 0)
                {
                    result = TestTitle.CompareTo(student.TestTitle);

                    if (result == 0)
                    {
                        result = DatePassed.CompareTo(student.DatePassed);

                        if (result == 0)
                        {
                            result = Mark.CompareTo(student.Mark);

                            if (result == 0)
                            {
                                return 0;
                            }
                        }
                    }
                }
            }
            return result;
        }
    }

}
