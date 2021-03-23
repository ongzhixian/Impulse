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
            ////////////////////////////////////////

            // Strict mock (example)
            // Mock<IBank> strictMock = new Mock<IBank>(MockBehavior.Strict);

            // Dynamic\Loose Mock
            Mock<IBank> mockBank = new Mock<IBank>();
            Mock<IOwner> mockResultOwner = new Mock<IOwner>();

            // Mock<System.Collections.Generic.IList<IOwner>> mockOwnerList = 
            //     new Mock<System.Collections.Generic.IList<IOwner>>();
            
            // Another way to declare a dynamic/loose mock
            // Mock<IBank> looseMock = new Mock<IBank>(MockBehavior.Loose);
            
            // Partial Mock (example)
            // Mock<IBank> partialMock = new Mock<IBank>() { CallBase = true };

            
            // Setup results
            // When 
            mockResultOwner.Setup(r => r.Id).Returns("1");

            mockBank.Setup<IOwner>(r => r.RegisterAccountOwner(It.IsAny<IOwner>())).Returns(mockResultOwner.Object);
            mockBank.Setup(r => r.CustomerList.Count).Returns(1);
            

            // Stub - is simply an alternate implementation
            //mockWrapper.Setup(x => x.SomeMethod()).Returns(true);

            // Mock - mock sets up an expectation that
            // A specific method will be called
            // It will be called with the provided inputs
            // It will return the provided results
            //mockWrapper.Setup(x => x.SomeMethod()).Returns(true).Verifiable();
  

            // Act
            ////////////////////////////////////////
            IBank bank = mockBank.Object;
            IOwner owner = bank.RegisterAccountOwner(It.IsAny<IOwner>());
            
            // Assert
            ////////////////////////////////////////
            //Assert.Fail();
            //mockBank.Verify(r => r.RegisterAccountOwner(It.IsAny<IOwner>()));
            Assert.AreEqual(bank.CustomerList.Count, 1);
            Assert.AreEqual(owner.Id, "1");
  
        }
    }
}
