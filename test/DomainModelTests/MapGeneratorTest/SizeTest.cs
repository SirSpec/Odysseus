using System;
using Odysseus.DomainModel.MapGenerator;
using Xunit;

namespace Odysseus.DomainModel.MapGeneratorTest
{
    public class SizeTest
    {
        [Fact]
        public void DefaultContructor_EmptyObject_EmptyProperties()
        {
            //Arrange
            var sut = new Size();

            //Act
            var (width, height) = sut;

            //Assert
            Assert.Equal(0, width);
            Assert.Equal(0, height);
        }

        [Fact]
        public void Contructor_NegativeValues_ArgumentException()
        {
            //Arrange
            Action sut = () => new Size(-1, -1);

            //Assert
            Assert.Throws<ArgumentException>(sut);
        }

        [Fact]
        public void ParameterizedConstructor_ValidValues_ValidProperties()
        {
            //Arrange
            var sut = new Size(1, 2);

            //Act
            var (width, height) = sut;

            //Assert
            Assert.Equal(1, width);
            Assert.Equal(2, height);
        }

        [Fact]
        public void Equals_EmptyObjects_True()
        {
            //Arrange
            var sut1 = new Size();
            var sut2 = new Size();

            //Act
            var result1 = sut1.Equals(sut1);
            var result2 = sut1.Equals(sut2);
            var result3 = sut2.Equals(sut1);

            //Assert
            Assert.True(result1);
            Assert.True(result2);
            Assert.True(result3);
        }

        [Fact]
        public void Equals_SameParameters_True()
        {
            //Arrange
            var sut1 = new Size(1, 2);
            var sut2 = new Size(1, 2);

            //Act
            var result1 = sut1.Equals(sut1);
            var result2 = sut1.Equals(sut2);
            var result3 = sut2.Equals(sut1);

            //Assert
            Assert.True(result1);
            Assert.True(result2);
            Assert.True(result3);
        }

        [Fact]
        public void Equals_DifferentParameters_False()
        {
            //Arrange
            var sut1 = new Size(1, 3);
            var sut2 = new Size(1, 2);

            var sut3 = new Size(1, 2);
            var sut4 = new Size(2, 2);

            //Act
            var result1 = sut1.Equals(sut2);
            var result2 = sut2.Equals(sut1);

            var result3 = sut3.Equals(sut4);
            var result4 = sut4.Equals(sut3);

            //Assert
            Assert.False(result1);
            Assert.False(result2);

            Assert.False(result3);
            Assert.False(result4);
        }
    }
}
