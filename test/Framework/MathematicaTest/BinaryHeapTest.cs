using Xunit;
using Odysseus.Framework.Mathematica;
using System.Collections.Generic;

namespace Odysseus.Framework.MathematicaTest
{
    public class BinaryHeapTest
    {
        [Fact]
        public void Constructor_ValidHeap_ValidHeap()
        {
            //Arrange
            var sut = new BinaryHeap<int, int>(new List<Node<int, int>>
            {
                new Node<int, int>(5, 50),
                new Node<int, int>(3, 30),
                new Node<int, int>(2, 20),
                new Node<int, int>(3, 60),
                new Node<int, int>(4, 40),
            });

            //Act
            var result = sut.ExtractMinimum();

            //Assert
            Assert.Equal(2, result.Key);
            Assert.Equal(20, result.Value);
        }

        [Fact]
        public void ExtractMinimum_ValidHeap_Minimum()
        {
            //Arrange
            var sut = new BinaryHeap<int, int>();

            //Act
            sut.Insert(5, 50);
            sut.Insert(3, 30);
            sut.Insert(2, 20);
            sut.Insert(3, 60);
            sut.Insert(4, 40);

            var result = sut.ExtractMinimum();

            //Assert
            Assert.Equal(2, result.Key);
            Assert.Equal(20, result.Value);
        }
    }
}