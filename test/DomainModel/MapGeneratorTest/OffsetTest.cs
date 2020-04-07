using Odysseus.DomainModel.MapGenerator;
using Xunit;

namespace Odysseus.DomainModel.MapGeneratorTest
{
    public class OffsetTest
    {
        [Fact]
        public void DefaultContructor_EmptyObject_EmptyProperties()
        {
            //Arrange
            var sut = new Offset();

            //Act
            var (x, y) = sut;

            //Assert
            Assert.Equal(0, x);
            Assert.Equal(0, y);
        }

        [Fact]
        public void DefaultContructor_ValidValues_ValidProperties()
        {
            //Arrange
            var sut = new Offset(1, -1);

            //Act
            var (x, y) = sut;

            //Assert
            Assert.Equal(1, x);
            Assert.Equal(-1, y);
        }

        [Fact]
        public void LeftBy_PositiveValue_NegativeX()
        {
            //Arrange
            var sut = Offset.LeftBy(1);

            //Act
            var (x, y) = sut;

            //Assert
            Assert.Equal(-1, x);
            Assert.Equal(0, y);
        }

        [Fact]
        public void LeftBy_NegativeValue_PositiveX()
        {
            //Arrange
            var sut = Offset.LeftBy(-1);

            //Act
            var (x, y) = sut;

            //Assert
            Assert.Equal(1, x);
            Assert.Equal(0, y);
        }

        [Fact]
        public void RightBy_PositiveValue_PositiveX()
        {
            //Arrange
            var sut = Offset.RightBy(1);

            //Act
            var (x, y) = sut;

            //Assert
            Assert.Equal(1, x);
            Assert.Equal(0, y);
        }

        [Fact]
        public void RightBy_NegativeValue_NegativeX()
        {
            //Arrange
            var sut = Offset.RightBy(-1);

            //Act
            var (x, y) = sut;

            //Assert
            Assert.Equal(-1, x);
            Assert.Equal(0, y);
        }

        [Fact]
        public void TopBy_PositiveValue_PositiveY()
        {
            //Arrange
            var sut = Offset.TopBy(1);

            //Act
            var (x, y) = sut;

            //Assert
            Assert.Equal(0, x);
            Assert.Equal(1, y);
        }

        [Fact]
        public void TopBy_NegativeValue_NegativeY()
        {
            //Arrange
            var sut = Offset.TopBy(-1);

            //Act
            var (x, y) = sut;

            //Assert
            Assert.Equal(0, x);
            Assert.Equal(-1, y);
        }

        [Fact]
        public void BottomBy_PositiveValue_NegativeY()
        {
            //Arrange
            var sut = Offset.BottomBy(1);

            //Act
            var (x, y) = sut;

            //Assert
            Assert.Equal(0, x);
            Assert.Equal(-1, y);
        }

        [Fact]
        public void BottomBy_NegativeValue_PositiveY()
        {
            //Arrange
            var sut = Offset.BottomBy(-1);

            //Act
            var (x, y) = sut;

            //Assert
            Assert.Equal(0, x);
            Assert.Equal(1, y);
        }

        [Fact]
        public void Equals_TheSameObject_True()
        {
            //Arrange
            var sut = new Offset();

            //Act
            var result = sut.Equals(sut);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void Equals_TwoObjectsWithTheSameValues_True()
        {
            //Arrange
            var sut1 = new Offset(1, -1);
            var sut2 = new Offset(1, -1);

            //Act
            var result1 = sut1.Equals(sut2);
            var result2 = sut2.Equals(sut1);

            //Assert
            Assert.True(result1);
            Assert.True(result2);
        }

        [Fact]
        public void Equals_TwoObjectsWithTheSameValues_False()
        {
            //Arrange
            var sut1 = new Offset(-1, 1);
            var sut2 = new Offset(1, -1);

            //Act
            var result1 = sut1.Equals(sut2);
            var result2 = sut2.Equals(sut1);

            //Assert
            Assert.False(result1);
            Assert.False(result2);
        }
    }
}
