using System;
using Odysseus.Framework.Randomizer;
using Xunit;

namespace Odysseus.Framework.RandomizerTest
{
    public class ConstraintRangeTest
    {
        [Fact]
        public void DefaultContructor_EmptyObject_EmptyProperties()
        {
            //Arrange
            var sut = new ConstraintRange<int>();

            //Act
            var (min, max) = sut;

            //Assert
            Assert.Equal(0, min);
            Assert.Equal(0, max);
        }

        [Fact]
        public void Contructor_ValidObject_ValidProperties()
        {
            //Arrange
            var sut = new ConstraintRange<int>(-4, 5);

            //Act
            var (min, max) = sut;

            //Assert
            Assert.Equal(-4, min);
            Assert.Equal(5, max);
        }

        [Fact]
        public void Contructor_InvalidValues_ArgumentException()
        {
            //Arrange
            Action sut = () => new ConstraintRange<int>(1, -1);

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(sut);
        }

        [Fact]
        public void Equals_TwoObjectsWithTheSameProperties_True()
        {
            //Arrange
            var sut1 = new ConstraintRange<int>(-4, 5);
            var sut2 = new ConstraintRange<int>(-4, 5);

            //Act
            var result1 = sut1.Equals(sut2);
            var result2 = sut2.Equals(sut1);

            //Assert
            Assert.True(result1);
            Assert.True(result2);
        }

        [Fact]
        public void Equals_TwoObjectsWithDifferentProperties_False()
        {
            //Arrange
            var sut1 = new ConstraintRange<int>(-4, 5);
            var sut2 = new ConstraintRange<int>(3, 5);

            //Act
            var result1 = sut1.Equals(sut2);
            var result2 = sut2.Equals(sut1);

            //Assert
            Assert.False(result1);
            Assert.False(result2);
        }
    }
}
