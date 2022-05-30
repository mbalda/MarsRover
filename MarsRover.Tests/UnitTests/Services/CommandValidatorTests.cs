using MarsRover.Core.Services;
using MarsRover.Tests.Common;

namespace MarsRover.Tests.UnitTests.Services
{
    internal class CommandValidatorTests : TestsBase
    {
        private ICommandValidator _commandValidator;

        string[] ValidCommands = { "F", "B", "L", "R" };
        string[] InvalidCommands = { "A", "C", "X", "Z" };

        [SetUp]
        public void Initialize() 
        {
            _commandValidator = new CommandValidator();
        }

        [Test]
        public void ValidateCommand_WhenCommandValid_ReturnsTrue()
        {
            // Arrange
            bool result = true; 

            var allCommands = GenerateAllSubsets(ValidCommands)
                .Where(c => c is not null)
                .ToList();

            // Act
            allCommands.ForEach(c => result &= _commandValidator.Validate(c));

            // Assert
            Assert.True(result);
        }

        [Test]
        public void ValidateCommand_WhenCommandInvalid_ReturnsFalse()
        {
            // Arrange
            bool result = false;

            var allCommands = GenerateAllSubsets(InvalidCommands)
                .Where(c => c is not null)
                .ToList();

            // Act
            allCommands.ForEach(c => result |= _commandValidator.Validate(c));

            // Assert
            Assert.False(result);
        }

        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void ValidateCommand_WhenCommandIsNullOrEmpty_ReturnsFalse(string command)
        {
            // Arrange

            // Act
            var result = _commandValidator.Validate(command);

            // Assert
            Assert.False(result);
        }

        [TestCase("ABC", false)]
        [TestCase("BBF", true)]
        [TestCase("RRFLB", true)]
        [TestCase("RRFZSLB", false)]
        public void ValidateCommand_WhenCommandInvalidAndValid_ReturnsFalse(string command, bool expectedResult)
        {
            // Arrange

            // Act
            var result = _commandValidator.Validate(command);

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
