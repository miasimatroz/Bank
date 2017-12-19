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
        public void GetClientIdTest()
        {
            Client client = new Client("Jan", "Nowak", "1");
            Assert.AreEqual("1", client.GetClientId());
        }

        [TestMethod()]
        public void GetBankProductsTest()
        {
            Client client = new Client("Jan", "Nowak", "1");
            Assert.AreEqual(0, client.GetBankProducts().Count);

            BankAccount bankAccount = new BankAccount("2",new InterestTenPercent(), 100);
            client.AddBankProduct(bankAccount);

            Assert.AreEqual(1, client.GetBankProducts().Count);
            Assert.AreEqual(typeof(BankAccount), client.GetBankProductById("2").GetType());
        }
    }
}