using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using WkspIdl.Handcraft;

namespace WkspMock.RhinoMocksApp
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Strict mock
            IBank strictMockBank = MockRepository.GenerateStrictMock<IBank>();

            // Dynamic\Loose Mock
            IBank mockBank = MockRepository.GenerateMock<IBank>();

            // Partial Mock
            IBank partialMockBank = MockRepository.GeneratePartialMock<IBank>();



            // Stub 
            //mockBank.Stub(x => x.SomeMethod()).Return(true);

            // Mock
            //mockBank.Expect(x => x.SomeMethod()).Return(true);


        }
    }
}
