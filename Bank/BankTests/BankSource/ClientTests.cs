using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bank.BankSource.Interest;
using Bank.BankSource.BankProduct;

namespace Bank.Tests
{
    [TestClass()]
    public class ClientTests
    {
        [TestMethod()]
        public void GetNameTest()
        {
            Client client = new Client("Jan", "Nowak", "1");
            Assert.AreEqual("Jan", client.GetName());
        }

        [TestMethod()]
        public void GetSurnameTest()
        {
            Client client = new Client("Jan", "Nowak", "1");
            Assert.AreEqual("Nowak", client.GetSurname());
        }

        [TestMethod()]
        public void GetClientNIPTest()
        {
            Client client = new Client("Jan", "Nowak", "11234567891");
            Assert.AreEqual("11234567891", client.GetClientNIP());
        }

    }
}