using NUnit.Framework;
using FindWord;
using CheckPassword;

namespace ValidationMethodsTest
{
    public class ValidationMethodsTests
    {
        [TestCase("thRee twO thrEE two one Three", ExpectedResult = "three")]
        public string TestFindGetFrequentWordInString_FreequentWordString_Success(string inputMessage) =>
            StringProcessor.GetFrequentWordInString(inputMessage);

        [TestCase("1234", ExpectedResult = true, TestName = "TestPasswordLengthIsValid_StringOfDigitalPasswordValid_Success")]
        [TestCase("123", ExpectedResult = false, TestName = "TestPasswordLengthIsValid_StringOfDigitalPasswordInvalid_Success")]
        [TestCase("23345", ExpectedResult = false, TestName = "TestPasswordLengthIsValid_StringOfDigitalPasswordIndalid_Success")]
        public bool TestCheckPasswordIsValid_StringOfDigitalPassword_Success(string password) =>
            new PasswordLengthChecker().IsValid(password);

        [TestCase("1234", ExpectedResult = true, TestName = "TestStringOfDigitalPasswordIsValid_StringOfDigitalPasswordValid_Success")]
        [TestCase("123a", ExpectedResult = false, TestName = "TestStringOfDigitalPasswordIsValid_StringOfDigitalPasswordInvalid_Success")]
        [TestCase("23Ds", ExpectedResult = false, TestName = "TestStringOfDigitalPasswordIsValid_StringOfDigitalPasswordIndalid_Success")]
        public bool TestStringOfDigitalPasswordIsValid_StringOfDigitalPassword_Success(string password) =>
            new StringOfDigitalPasswordChecker().IsValid(password);

        [TestCase("1224", ExpectedResult = true, TestName = "TestPasswordNonRepeatedNumbersIsValid_StringOfDigitalPasswordValid_Success")]
        [TestCase("3336", ExpectedResult = false, TestName = "TestPasswordNonRepeatedNumbersIsValid_StringOfDigitalPasswordInvalid_Success")]
        [TestCase("4555", ExpectedResult = false, TestName = "TestPasswordNonRepeatedNumbersIsValid_StringOfDigitalPasswordIndalid_Success")]
        public bool TestPasswordNonRepeatedNumbersIsValid_StringOfDigitalPassword_Success(string password) =>
            new PasswordNonRepeatedNumbersChecker().IsValid(password);

        [TestCase("1212", ExpectedResult = true, TestName = "TestPasswordConsecutiveNumbersIsValid_StringOfDigitalPasswordValid_Success")]
        [TestCase("1234", ExpectedResult = false, TestName = "TestPasswordConsecutiveNumbersIsValid_StringOfDigitalPasswordInvalid_Success")]
        [TestCase("6543", ExpectedResult = false, TestName = "TestPasswordConsecutiveNumbersIsValid_StringOfDigitalPasswordIndalid_Success")]
        public bool TestPasswordConsecutiveNumbersIsValid_StringOfDigitalPassword_Success(string password) =>
            new PasswordConsecutiveNumbersChecker().IsValid(password);

    }
}