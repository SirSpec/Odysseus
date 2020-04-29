using System.Linq;
using Xunit;

namespace Odysseus.Framework.AssemblerTest
{
    public interface InterfaceStub
    {
    }

    public abstract class AbstractClassStubTest : InterfaceStub
    {
    }

    public abstract class AbstractClassStub
    {
    }

    public class ClassStub : AbstractClassStub, InterfaceStub
    {
    }

    public class AssemblerTest
    {
        [Fact]
        public void CreateImplementationOf_AbstractClass_ValidImplementation()
        {
            //Arrange
            var sut = Assembler.Assembler.CreateImplementationsOf<AbstractClassStub>();

            //Assert
            Assert.Single(sut);
            Assert.IsType<ClassStub>(sut.First());
        }

        [Fact]
        public void CreateImplementationOf_Interface_ValidImplementation()
        {
            //Arrange
            var sut = Assembler.Assembler.CreateImplementationsOf<InterfaceStub>();

            //Assert
            Assert.Single(sut);
            Assert.IsType<ClassStub>(sut.First());
        }

        [Fact]
        public void CreateImplementationOf_int_ValidImplementation()
        {
            //Act
            var sut = Assembler.Assembler.CreateImplementationsOf<int>();

            //Assert
            Assert.Single(sut);
            Assert.IsType<int>(sut.First());
            Assert.Equal(0, sut.First());
        }
    }
}
