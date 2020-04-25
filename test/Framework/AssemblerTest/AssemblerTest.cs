using System.Linq;
using System.Reflection;
using Xunit;

namespace Odysseus.Framework.AssemblerTest
{
    public interface InterfaceStub
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
        public void DoesImplement_AbstractClass_True()
        {
            //Arrange
            var testObject = typeof(ClassStub);

            //Act
            var result = Assembler.Assembler.DoesImplement<AbstractClassStub>(testObject);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void DoesImplement_Interface_True()
        {
            //Arrange
            var testObject = typeof(ClassStub);

            //Act
            var result = Assembler.Assembler.DoesImplement<InterfaceStub>(testObject);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void DoesImplement_NonImplementedType_False()
        {
            //Arrange
            var testObject = typeof(ClassStub);

            //Act
            var result = Assembler.Assembler.DoesImplement<int>(testObject);

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void GetTypes_AbstractClass_Class()
        {
            //Arrange
            var assembly = Assembly.GetAssembly(typeof(AbstractClassStub));

            //Act
            var result = Assembler.Assembler.GetTypes<AbstractClassStub>(assembly!).ToList();

            //Assert
            Assert.Contains(typeof(ClassStub), result);
        }

        [Fact]
        public void GetTypes_Interface_Class()
        {
            //Arrange
            var assembly = Assembly.GetAssembly(typeof(InterfaceStub));

            //Act
            var result = Assembler.Assembler.GetTypes<InterfaceStub>(assembly!).ToList();

            //Assert
            Assert.Contains(typeof(ClassStub), result);
        }

        [Fact]
        public void CreateImplementationOf_AbstractClass_NonEmptyCollection()
        {
            //Arrange
            var sut = Assembler.Assembler.CreateImplementationOf<AbstractClassStub>();

            //Act
            var result = sut.Select(implementation => implementation.GetType());

            //Assert
            Assert.Contains(typeof(ClassStub), result);
        }

        [Fact]
        public void CreateImplementationOf_Interface_NonEmptyCollection()
        {
            //Arrange
            var sut = Assembler.Assembler.CreateImplementationOf<InterfaceStub>();

            //Act
            var result = sut.Select(implementation => implementation.GetType());

            //Assert
            Assert.Contains(typeof(ClassStub), result);
        }

        [Fact]
        public void CreateImplementationOf_NonImplementedType_EmptyCollection()
        {
            //Act
            var sut = Assembler.Assembler.CreateImplementationOf<int>();

            //Assert
            Assert.Empty(sut);
        }
    }
}
