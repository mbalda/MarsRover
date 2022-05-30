using MarsRover.Core.Domain;
using MarsRover.Core.Enums;
using MarsRover.Tests.Common;

namespace MarsRover.Tests.UnitTests.Domain
{
    internal class RoverTests : TestsBase
    {
        Coordinates _coordinates;

        [SetUp]
        public void Setup()
        {
            _coordinates = Fixture.Create<Coordinates>();
        }

        [Test]
        public void Rover_WhenInitialized_WithoutStartPosition_IsInitializedByDefaultValues()
        {
            // Arrange
            Rover rover = new Rover();

            // Act

            // Assert
            Assert.That(rover.StartPosition, Is.EqualTo(new Coordinates(0, 0, Direction.North)));
        }

        [Test]
        public void Rover_WhenInitialized_WithStartPosition_IsInitializedProperly()
        {
            // Arrange
            Rover rover = new Rover(_coordinates);

            // Act

            // Assert
            Assert.That(rover.CurrentPosition, Is.EqualTo(_coordinates));
        }

        [Test]
        public void Rover_WhenInitialized_StartAndCurrentPositionAreEqual()
        {
            // Arrange
            Rover rover = new Rover();

            // Act

            // Assert
            Assert.That(rover.CurrentPosition, Is.EqualTo(rover.StartPosition));
        }

        [TestCase(Direction.North, Move.Forward, 1)]
        [TestCase(Direction.North, Move.Backward, -1)]
        [TestCase(Direction.South, Move.Forward, -1)]
        [TestCase(Direction.South, Move.Backward, 1)]
        public void Rover_WhenDirectionIsNorthSouth_WhenMovedOneStep_UpdatesCoordinatesProperly(Direction startDirection, Move move, int progress)
        {
            // Arrange
            var coordinates = Fixture.Create<Coordinates>();
            coordinates.UpdateDirection(startDirection);

            Rover rover = new Rover(coordinates);

            // Act
            rover.DoAction(new MoveAction(move));

            // Assert
            Assert.That(rover.CurrentPosition.Y, Is.EqualTo(rover.StartPosition.Y + progress));
        }

        [TestCase(Direction.East, Move.Forward, 1)]
        [TestCase(Direction.East, Move.Backward, -1)]
        [TestCase(Direction.West, Move.Forward, -1)]
        [TestCase(Direction.West, Move.Backward, 1)]
        public void Rover_WhenDirectionIsEastWest_WhenMovedOneStep_UpdatesCoordinatesProperly(Direction startDirection, Move move, int progress)
        {
            // Arrange
            var coordinates = Fixture.Create<Coordinates>();
            coordinates.UpdateDirection(startDirection);

            Rover rover = new Rover(coordinates);

            // Act
            rover.DoAction(new MoveAction(move));

            // Assert
            Assert.That(rover.CurrentPosition.X, Is.EqualTo(rover.StartPosition.X + progress));
        }

        [TestCase(Direction.North, Move.Forward, 1)]
        [TestCase(Direction.North, Move.Backward, -1)]
        [TestCase(Direction.South, Move.Forward, -1)]
        [TestCase(Direction.South, Move.Backward, 1)]
        public void Rover_WhenDirectionIsNorthSouth_WhenMovedManySteps_UpdatesCoordinatesProperly(Direction startDirection, Move move, int progress)
        {
            // Arrange
            int repeats = Random();
            progress *= repeats;

            var coordinates = Fixture.Create<Coordinates>();
            coordinates.UpdateDirection(startDirection);

            Rover rover = new Rover(coordinates);

            // Act
            Repeat(repeats, () => rover.DoAction(new MoveAction(move)));

            // Assert
            Assert.That(rover.CurrentPosition.Y, Is.EqualTo(rover.StartPosition.Y + progress));
        }

        [TestCase(Direction.East, Move.Forward, 1)]
        [TestCase(Direction.East, Move.Backward, -1)]
        [TestCase(Direction.West, Move.Forward, -1)]
        [TestCase(Direction.West, Move.Backward, 1)]
        public void Rover_WhenDirectionIsEastWest_WhenMovedManySteps_UpdatesCoordinatesProperly(Direction startDirection, Move move, int progress)
        {
            // Arrange
            int repeats = Random();
            progress *= repeats;

            var coordinates = Fixture.Create<Coordinates>();
            coordinates.UpdateDirection(startDirection);

            Rover rover = new Rover(coordinates);

            // Act
            Repeat(repeats, () => rover.DoAction(new MoveAction(move)));

            // Assert
            Assert.That(rover.CurrentPosition.X, Is.EqualTo(rover.StartPosition.X + progress));
        }

        [TestCase(Direction.North, Rotation.Right, Direction.East)]
        [TestCase(Direction.East, Rotation.Right, Direction.South)]
        [TestCase(Direction.South, Rotation.Right, Direction.West)]
        [TestCase(Direction.West, Rotation.Right, Direction.North)]
        public void Rover_RotateRight_UpdatesCoordinationsProperly(Direction startDirection, Rotation rotation, Direction destinationDirection)
        {
            // Arrange
            var coordinates = Fixture.Create<Coordinates>();
            coordinates.UpdateDirection(startDirection);

            Rover rover = new Rover(coordinates);

            // Act
            RotateAction action = new RotateAction(rotation);
            rover.DoAction(action);

            // Assert
            Assert.That(rover.CurrentPosition.Direction, Is.EqualTo(destinationDirection));
        }

        [TestCase(Direction.North, Rotation.Left, Direction.West)]
        [TestCase(Direction.East, Rotation.Left, Direction.North)]
        [TestCase(Direction.South, Rotation.Left, Direction.East)]
        [TestCase(Direction.West, Rotation.Left, Direction.South)]
        public void Rover_RotateLeft_UpdatesCoordinationsProperly(Direction startDirection, Rotation rotation, Direction destinationDirection)
        {
            // Arrange
            var coordinates = Fixture.Create<Coordinates>();
            coordinates.UpdateDirection(startDirection);

            Rover rover = new Rover(coordinates);

            // Act
            RotateAction action = new RotateAction(rotation);
            rover.DoAction(action);

            // Assert
            Assert.That(rover.CurrentPosition.Direction, Is.EqualTo(destinationDirection));
        }
        [Test]
        public void Rover_WhenEmptyAction_ThrowsException()
        {
            // Arrange
            var coordinates = Fixture.Create<Coordinates>();
            Rover rover = new Rover(coordinates);

            // Act
            RoverAction action = new DummyRoverAction();
            
            // Assert
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => rover.DoAction(action));
        }
    }
}
