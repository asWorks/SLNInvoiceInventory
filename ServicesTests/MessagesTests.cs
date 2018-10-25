using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ServicesTests
{
    [TestClass]
    public class MessagesTests
    {
        [TestMethod]
        public void TestMessageBoxTest_ShouldShowAMessageOnTheUI()
        {
            var m = new Services.Implementations.MessageBoxMessage("Hallo, hallo", "Test");
            Services.MessageToUIService.Message(m);
            Assert.AreEqual(m.Titel, "Test");

        }
    }
}
