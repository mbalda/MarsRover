using MarsRover.Core.Domain;
using MarsRover.Core.Enums;
using MarsRover.Tests.Common;

namespace MarsRover.Tests.UnitTests.Domain
{
    internal class RoverActionsTests : TestsBase
    {
        [TestCase(Move.Forward)]
        [TestCase(Move.Backward)]
        public void MoveAction_WhenInitialized_IsInitializedProperly(Move move)
        {
            // Arrange
            MoveAction action = new MoveAction(move);

            // Act 

            // Assert
            Assert.That(action.Move, Is.EqualTo(move));
        }

        [TestCase(Rotation.Left)]
        [TestCase(Rotation.Right)]
        public void RotateAction_WhenInitialized_IsInitializedProperly(Rotation rotation)
        {
            // Arrange
            RotateAction action = new RotateAction(rotation);

            // Act

            // Assert
            Assert.That(action.Rotation, Is.EqualTo(rotation));
        }

        [TestCase(Move.Forward)]
        [TestCase(Move.Backward)]
        public void MoveAction_WhenEqualsToOther_ReturnsTrue(Move move)
        {
            // Arrange
            MoveAction action = new MoveAction(move);
            MoveAction otherAction = new MoveAction(move);

            // Act
            var result = action.Equals(otherAction);

            // Assert
            Assert.True(result);
        }

        [Test]
        public void MoveAction_WhenNotEqualToOther_ReturnsFalse()
        {
            // Arrange
            MoveAction action = new MoveAction(Move.Forward);
            MoveAction otherAction = new MoveAction(Move.Backward);

            // Act
            var result = action.Equals(otherAction);

            // Assert
            Assert.False(result);
        }

        [Test]
        public void MoveAction_WhenNull_ReturnsFalse()
        {
            // Arrange
            MoveAction action = new MoveAction(Move.Backward);
            MoveAction otherAction = null;

            // Act
            var result = action.Equals(otherAction);

            // Assert
            Assert.False(result);
        }

        [TestCase(Rotation.Left)]
        [TestCase(Rotation.Right)]
        public void RotateAction_WhenEqualsToOther_ReturnsTrue(Rotation rotation)
        {
            // Arrange
            RotateAction action = new RotateAction(rotation);
            RotateAction otherAction = new RotateAction(rotation);

            // Act
            var result = action.Equals(otherAction);

            // Assert
            Assert.True(result);
        }

        [Test]
        public void RotateAction_WhenNotEqualToOther_ReturnsFalse()
        {
            // Arrange
            RotateAction action = new RotateAction(Rotation.Left);
            RotateAction otherAction = new RotateAction(Rotation.Right);

            // Act
            var result = action.Equals(otherAction);

            // Assert
            Assert.False(result);
        }

        [Test]
        public void RotateAction_WhenNull_ReturnsFalse()
        {
            // Arrange
            RotateAction action = new RotateAction(Rotation.Left);
            RotateAction otherAction = null;

            // Act
            var result = action.Equals(otherAction);

            // Assert
            Assert.False(result);
        }
    }
}
