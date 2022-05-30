using MarsRover.Core.Domain;
using MarsRover.Core.Enums;
using MarsRover.Core.Services;

namespace MarsRover.Tests.IntegrationTests
{
    internal class RoverControllerTests
    {
        private IRoverController _roverController;

        [SetUp]
        public void Setup()
        {
            _roverController = new RoverController(new CommandTransformer(), new CommandValidator());
        }

        [TestCase("4,2,EAST", "FLFFFRFLB", 6, 4, Direction.North)]
        [TestCase("0,0,North", "LLLL", 0, 0, Direction.North)]
        [TestCase("-4,-4,south", "BBBBLFFFF", 0, 0, Direction.East)]
        [TestCase("-4 , -4 , south", " BBBBLFFFF ", 0, 0, Direction.East)]
        public void ExecuteCommands_WithValidCoordinates_ReturnsNewPosition(string startPosition, string commands, int expectedX, int expectedY, Direction expectedDirection)
        {
            // Arrange
            _roverController.SetStartPosition(startPosition);

            // Act
            _roverController.ExecuteCommands(commands);
            var endPosition = _roverController.GetEndPosition();

            // Assert
            Assert.That(endPosition, Is.EqualTo(new Coordinates(expectedX, expectedY, expectedDirection).ToString()));
        }

        [TestCase("2,East", typeof(ArgumentException))]
        [TestCase("0,1.1,North", typeof(ArgumentException))]
        [TestCase("-4,-4", typeof(ArgumentException))]
        [TestCase("North", typeof(ArgumentException))]
        [TestCase("ABCdef", typeof(ArgumentException))]
        [TestCase(" ", typeof(ArgumentNullException))]
        [TestCase("", typeof(ArgumentNullException))]
        [TestCase(null, typeof(ArgumentNullException))]
        public void ExecuteCommands_WithInvalidCoordinates_ThrowsException(string startPosition, Type exceptionType)
        {
            // Arrange

            // Act

            // Assert
            Assert.Throws(exceptionType, () => _roverController.SetStartPosition(startPosition));
        }

        [TestCase("0,0,North", "LOL")]
        [TestCase("0,0,North", "O")]
        [TestCase("0,0,North", "LFBRRRB1")]
        [TestCase("0,0,North", "41421")]
        [TestCase("0,0,North", "")]
        [TestCase("0,0,North", " ")]
        [TestCase("0,0,North", null)]
        public void ExecuteCommands_WithInvalidCommands_ThrowsException(string startPosition, string commands)
        {
            // Arrange
            _roverController.SetStartPosition(startPosition);

            // Act

            // Assert
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => _roverController.ExecuteCommands(commands));
        }
    }
}
