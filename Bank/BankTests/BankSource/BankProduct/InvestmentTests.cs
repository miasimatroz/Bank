using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bank.BankSource.Interest;
using System;

namespace Bank.BankSource.BankProduct.Tests
{
    [TestClass()]
    public class InvestmentTests
    {
        [TestMethod()]
        public void GetProductIdTest()
        {
            Client client = new Client("Jan", "Nowak", "01234567891");
            Investment investment = new Investment("123", new InterestTenPercent(), 1000, client);
            Assert.AreEqual("123", investment.GetProductId());
        }

        [TestMethod()]
        public void GetSaldoTest()
        {
            Client client = new Client("Jan", "Nowak", "01234567891");
            Investment investment = new Investment("123", new InterestTenPercent(), 1000, client);
            Assert.AreEqual(1000, investment.GetSaldo());
        }

        [TestMethod()]
        public void ChangeSaldoTest()
        {
            Client client = new Client("Jan", "Nowak", "01234567891");
            Investment investment = new Investment("123", new InterestTenPercent(), 1000, client);
            investment.ChangeSaldo(100);
            Assert.AreEqual(1100, investment.GetSaldo());
            investment.ChangeSaldo(-400);
            Assert.AreEqual(700, investment.GetSaldo());
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception), "Saldo will be less than 0")]
        public void ChangeSaldoTest2()
        {
            Client client = new Client("Jan", "Nowak", "01234567891");
            Investment investment = new Investment("123", new InterestTenPercent(), 1000, client);
            investment.ChangeSaldo(-1100);
        }

        [TestMethod()]
        public void AddIterestTest()
        {
            Client client = new Client("Jan", "Nowak", "01234567891");
            Investment investment = new Investment("123", new InterestTenPercent(), 1000, client);
            investment.AddIterest();
            Assert.AreEqual(1100, investment.GetSaldo());
        }

        [TestMethod()]
        public void ChangeIterestTest()
        {
            Client client = new Client("Jan", "Nowak", "01234567891");
            Investment investment = new Investment("123", new InterestTenPercent(), 1000, client);
            investment.AddIterest();
            investment.ChangeIterest(new InterestFivePercent());
            investment.AddIterest();
            Assert.AreEqual(1155, investment.GetSaldo());
        }

        [TestMethod()]
        public void GetClientTest()
        {
            Client client = new Client("Jan", "Nowak", "01234567891");
            Investment investment = new Investment("123", new InterestTenPercent(), 1000, client);
            Assert.AreEqual("01234567891", investment.GetClient().GetClientNIP());
        }

    }
}