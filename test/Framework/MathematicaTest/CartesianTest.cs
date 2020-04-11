using Xunit;
using Odysseus.Framework.Mathematica;

namespace Odysseus.Framework.MathematicaTest
{
    public class CartesianTest
    {
        [Fact]
        public void Distance_TheSamePoints_Zero()
        {
            //Arrange
            (double x, double y) sut = (1, 2);

            //Act
            var result = Cartesian.Distance(sut, sut);

            //Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void Distance_TwoValidPoints_ValidDistance()
        {
            //Arrange
            (double x, double y) sut1 = (2, 3);
            (double x, double y) sut2 = (2, -1);

            //Act
            var result = Cartesian.Distance(sut1, sut2);

            //Assert
            Assert.Equal(4, result);
        }

        [Fact]
        public void Midpoint_TheSamePoints_TheSamePoint()
        {
            //Arrange
            (double x, double y) sut = (1, 2);

            //Act
            var result = Cartesian.Midpoint(sut, sut);

            //Assert
            Assert.Equal((1, 2), result);
        }

        [Fact]
        public void Midpoint_TwoValidPoints_ValidMidpoint()
        {
            //Arrange
            (double x, double y) sut1 = (1, 3);
            (double x, double y) sut2 = (-5, 6);

            //Act
            var result = Cartesian.Midpoint(sut1, sut2);

            //Assert
            Assert.Equal((-2, 4.5), result);
        }
    }
}