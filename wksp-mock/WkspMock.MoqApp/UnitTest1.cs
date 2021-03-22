using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WkspIdl.Handcraft;

namespace WkspMock.MoqApp
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            //WkspIdl.Handcraft.IBank
            //MockRepository mocks = new MockRepository();

            Mock<IBank> mockBank = new Mock<IBank>();

            IBank mockedObject = mockBank.Object;
            
            // var mock = mocks.DynamicMock<ISomethingUseful>();
            // SetupResult.For(mock.CalculateSomething(0)).IgnoreArguments().Return(1);
            // mocks.ReplayAll();

  

            // Act
            
            // Assert
            Assert.Fail();

            // var myClass = new MyClass(mock);
            // Assert.AreEqual(2, myClass.MethodUnderTest(123));
  
        }
    }
}
