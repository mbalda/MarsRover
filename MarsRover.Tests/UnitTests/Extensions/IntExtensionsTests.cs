using MarsRover.Core.Extensions;
using MarsRover.Tests.Common;

namespace MarsRover.Tests.UnitTests.Extensions
{
    internal class IntExtensionsTests : TestsBase
    {
        [TestCase(1, 3, 1)]
        [TestCase(6, 3, 0)]
        [TestCase(4, 3, 1)]
        [TestCase(-1, 3, 2)]
        [TestCase(-5, 3, 1)]
        [TestCase(0, 7, 0)]
        public void Modulo_CalculatesProperValue(int value, int modulo, int result)
        {
            // Arrange

            // Act 
            var calculatedModuloValue = value.Modulo(modulo);

            // Assert
            Assert.That(calculatedModuloValue, Is.EqualTo(result));
        }

        public void Modulo_CalculatesProperValue()
        {
            // Arrange
            int value = -1;

            // Act 

            // Assert
            Assert.Throws(typeof(DivideByZeroException), () => value.Modulo(0), "Divide by zero");
        }
    }
}
