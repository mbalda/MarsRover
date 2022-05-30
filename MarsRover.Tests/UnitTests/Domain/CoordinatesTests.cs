using MarsRover.Core.Domain;
using MarsRover.Core.Enums;
using MarsRover.Tests.Common;

namespace MarsRover.Tests.UnitTests.Domain
{
    internal class CoordinatesTests : TestsBase
    {
        [Test]
        public void Coordinates_WhenInitialized_ByData_AllPropertiesAreInitializedProperly()
        {
            // Arrange
            var coordinates = new Coordinates(1, 2, Direction.North);

            // Act

            // Assert
            Assert.That(coordinates.X, Is.EqualTo(1));
            Assert.That(coordinates.Y, Is.EqualTo(2));
            Assert.That(coordinates.Direction, Is.EqualTo(Direction.North));
        }

        [TestCase("4,7,North", 4, 7, Direction.North)]
        [TestCase("-4,7,West", -4, 7, Direction.West)]
        [TestCase("0,-1,East", 0, -1, Direction.East)]
        [TestCase("4,0,South", 4, 0, Direction.South)]
        [TestCase("8,0,south", 8, 0, Direction.South)]
        [TestCase("12,5,WEST", 12, 5, Direction.West)]
        [TestCase("-2,0,EaSt", -2, 0, Direction.East)]
        public void Coordinates_WhenInitialized_ByString_AllPropertiesAreInitializedProperly(string coordinatesString, int x, int y, Direction direction)
        {
            // Arrange
            var coordinates = new Coordinates(coordinatesString);

            // Act

            // Assert
            Assert.That(coordinates.X, Is.EqualTo(x));
            Assert.That(coordinates.Y, Is.EqualTo(y));
            Assert.That(coordinates.Direction, Is.EqualTo(direction));
        }

        [TestCase("4,7,ABCDE")]
        [TestCase("0.4,7,ABCDE")]
        [TestCase("4,0.7,ABCDE")]
        [TestCase("X,7,ABCDE")]
        [TestCase("4,Y,ABCDE")]
        [TestCase("ABCDE@542")]
        [TestCase("4,North")]
        [TestCase("4,6")]
        [TestCase("4")]
        public void Coordinates_WhenInitialized_ByInvalidString_ThrowsException(string coordinateString)
        {
            // Arrange

            // Act

            // Assert
            Assert.Throws(typeof(ArgumentException), () => new Coordinates(coordinateString) ,"Coordination must be in format: X,Y,Direction");
        }

        [Test]
        public void Coordinates_WhenInitialized_ByEmptyString_ThrowsException()
        {
            // Arrange
            var coordinates = string.Empty;

            // Act

            // Assert
            Assert.Throws(typeof(ArgumentNullException), () => new Coordinates(coordinates), "Coordination must be in format: X,Y,Direction");
        }

        [Test]
        public void Coordinates_WhenInitialized_ByNull_ThrowsException()
        {
            // Arrange

            // Act

            // Assert
            Assert.Throws(typeof(ArgumentNullException), () => new Coordinates(null), "Coordination must be in format: X,Y,Direction");
        }

        [TestCase(10, 0)]
        [TestCase(0, 10)]
        [TestCase(-10, 0)]
        [TestCase(0, -10)]
        [TestCase(10, -10)]
        [TestCase(-10, 10)]
        [TestCase(0, 0)]
        public void Coordinates_WhenUpdates_ThenXAndYPropertiesUpdated(int x, int y)
        {
            // Arrange
            var coordinates = Fixture.Create<Coordinates>();
            var startCoordinates = coordinates.Clone();

            // Act
            coordinates.UpdateCoordinates(x, y);

            // Assert
            Assert.That(coordinates.X, Is.EqualTo(startCoordinates.X + x));
            Assert.That(coordinates.Y, Is.EqualTo(startCoordinates.Y + y));
        }

        [TestCase(Direction.North)]
        [TestCase(Direction.West)]
        [TestCase(Direction.East)]
        [TestCase(Direction.South)]
        public void Coordinates_WhenUpdatesDirection_ThenNewDirectionSet(Direction direction)
        {
            // Arrange
            var coordinates = Fixture.Create<Coordinates>();

            // Act
            coordinates.UpdateDirection(direction);

            // Assert
            Assert.That(coordinates.Direction, Is.EqualTo(direction));
        }

        [TestCase(Direction.North, true)]
        [TestCase(Direction.West, false)]
        [TestCase(Direction.East, false)]
        [TestCase(Direction.South, true)]
        public void Coordinates_IsNorthSouthLine_ReturnsTrueIfIsNorthOrSouthDirection(Direction direction, bool isOnLine)
        {
            // Arrange
            var coordinates = Fixture.Create<Coordinates>();
                coordinates.UpdateDirection(direction);

            // Act

            // Assert
            Assert.That(coordinates.IsNorthSouthLine, Is.EqualTo(isOnLine));
        }

        [Test]
        public void Coordinates_ToString_ReturnsFormattedString()
        {
            // Arrange
            var coordinates = Fixture.Create<Coordinates>();

            // Act
            var result = coordinates.ToString();

            // Assert
            Assert.That(result, Is.EqualTo($"X = {coordinates.X}, Y = {coordinates.Y}, {coordinates.Direction}"));

        }

        [Test]
        public void Coordinates_WhenCloned_ReturnsNewInstanceWithTheSameValues()
        {
            // Arrange
            var coordinates = Fixture.Create<Coordinates>();

            // Act
            var clonedCoordinates = coordinates.Clone();

            // Assert
            Assert.That(coordinates, Is.EqualTo(clonedCoordinates));
            Assert.That(coordinates, Is.Not.SameAs(clonedCoordinates));
        }

        [Test]
        public void Coordinates_WhenEqualsToOther_ReturnsTrue()
        {
            // Arrange
            var coordinates = Fixture.Create<Coordinates>();
            var clonedCoordinates = coordinates.Clone();

            // Act
            var result = coordinates.Equals(clonedCoordinates);

            // Assert
            Assert.True(result);
        }

        [Test]
        public void Coordinates_WhenNull_ReturnsFalse()
        {
            // Arrange
            var coordinates = Fixture.Create<Coordinates>();

            // Act
            var result = coordinates.Equals(null);

            // Assert
            Assert.False(result);
        }
    }
}