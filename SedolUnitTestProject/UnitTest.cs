using SedolChecker;

namespace SedolUnitTestProject
{
    public class Tests
    {
        public SedolValidator sedolValidator;

        [SetUp]
        public void Setup()
        {
           sedolValidator= new SedolValidator();    
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("12")]
        [TestCase("123456789")]
        public void CheckValidInputStringLength(string input)
        {
            // Arrange


            // Act
            var result = sedolValidator.ValidateSedol(input);

            // Assert
#pragma warning disable NUnit2007 // The actual value should not be a constant
            Assert.That(ErrorMessages.INVALID_LENGTH, Is.EqualTo(result.ValidationDetails));
#pragma warning restore NUnit2007 // The actual value should not be a constant
        }
   
        [TestCase("1234567")]
        public void CheckValidCheckSum(string input)
        {
            // Arrange


            // Act
            var result = sedolValidator.ValidateSedol(input);

            // Assert
#pragma warning disable NUnit2007 // The actual value should not be a constant
            Assert.That(ErrorMessages.CHECKSUM_NOT_VALID, Is.EqualTo(result.ValidationDetails));
#pragma warning restore NUnit2007 // The actual value should not be a constant
        }

        [TestCase("0709954")]
        [TestCase("B0YBKJ7")]
        public void ValidUserNotDefinedSedol(string input)
        {
            // Arrange


            // Act
            var result = sedolValidator.ValidateSedol(input);

            // Assert
#pragma warning disable NUnit2007 // The actual value should not be a constant
            Assert.AreEqual(result.ValidationDetails != null ? result.ValidationDetails : null, null);
#pragma warning restore NUnit2007 // The actual value should not be a constant
        }

        [TestCase("9123451")]
        [TestCase("9ABCDE8")]
        public void CheckDigitDoesNotAgreeWithRestOfInput(string input)
        {
            // Arrange


            // Act
            var result = sedolValidator.ValidateSedol(input);

            // Assert
#pragma warning disable NUnit2007 // The actual value should not be a constant
            Assert.That(ErrorMessages.CHECKSUM_NOT_VALID, Is.EqualTo(result.ValidationDetails));
#pragma warning restore NUnit2007 // The actual value should not be a constant
        }


        [TestCase("9123_51")]
        [TestCase("VA.CDE8")]
        public void InvalidCharactersFound(string input)
        {
            // Arrange


            // Act
            var result = sedolValidator.ValidateSedol(input);

            // Assert
#pragma warning disable NUnit2007 // The actual value should not be a constant
            Assert.That(ErrorMessages.INVALIDCHARS, Is.EqualTo(result.ValidationDetails));
#pragma warning restore NUnit2007 // The actual value should not be a constant
        }

        [TestCase("9123458")]
        [TestCase("9ABCDE1")]
        public void ValidUsersDefindSedol(string input)
        {
            // Arrange


            // Act
            var result = sedolValidator.ValidateSedol(input);

            // Assert
#pragma warning disable NUnit2007 // The actual value should not be a constant
            Assert.AreEqual(result.ValidationDetails != null ? result.ValidationDetails : null, null);
#pragma warning restore NUnit2007 // The actual value should not be a constant
        }
    }
}