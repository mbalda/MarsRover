using MarsRover.Core.Domain;
using MarsRover.Core.Enums;
using MarsRover.Core.Services;
using MarsRover.Tests.Common;

namespace MarsRover.Tests.UnitTests.Services
{
    internal class CommandTransformerTests : TestsBase
    {
        private ICommandTransformer _commandTransformer;

        [SetUp]
        public void Initialize() 
        {
            _commandTransformer = new CommandTransformer();
        }

        [TestCase("B", Move.Backward)]
        [TestCase("F", Move.Forward)]
        public void TransformCommand_WhenMoveCommandValid_ReturnsMoveAction(string command, Move expectedMove)
        {
            // Arrange
            var expectedRoverAction = new MoveAction(expectedMove);

            // Act
            var roverActions = _commandTransformer.Transform(command);

            // Assert
            Assert.That(expectedRoverAction, Is.EqualTo(roverActions.First()));
        }

        [TestCase("L", Rotation.Left)]
        [TestCase("R", Rotation.Right)]
        public void TransformCommand_WhenRotateCommandValid_ReturnsRotateAction(string command, Rotation expectedRotation)
        {
            // Arrange
            var expectedRoverAction = new RotateAction(expectedRotation);

            // Act
            var roverActions = _commandTransformer.Transform(command);

            // Assert
            Assert.That(expectedRoverAction, Is.EqualTo(roverActions.First()));
        }

        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void TransformCommand_WhenCommandIsEmpty_ReturnsEmptyQueue(string emptyCommand)
        {
            // Arrange
            var emptyQueue = new Queue<RoverAction>();

            // Act
            var roverActions = _commandTransformer.Transform(emptyCommand);

            // Assert
            Assert.That(emptyQueue, Is.EqualTo(roverActions));
        }
    }
}
