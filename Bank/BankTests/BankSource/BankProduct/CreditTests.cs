using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bank.BankSource.Interest;
using System;

namespace Bank.BankSource.BankProduct.Tests
{
    [TestClass()]
    public class CreditTests
    {

        [TestMethod()]
        public void GetProductIdTest()
        {
            Client client = new Client("Jan", "Nowak", "01234567891");
            Credit credit = new Credit("123", new InterestTenPercent(), 1000, client);
            Assert.AreEqual("123", credit.GetProductId());
        }

        [TestMethod()]
        public void GetSaldoTest()
        {
            Client client = new Client("Jan", "Nowak", "01234567891");
            Credit credit = new Credit("123", new InterestTenPercent(), 1000, client);
            Assert.AreEqual(1000, credit.GetSaldo());
        }

        [TestMethod()]
        public void ChangeSaldoTest()
        {
            Client client = new Client("Jan", "Nowak", "01234567891");
            Credit credit = new Credit("123", new InterestTenPercent(), 1000, client);
            credit.ChangeSaldo(100);
            Assert.AreEqual(1100, credit.GetSaldo());
            credit.ChangeSaldo(-400);
            Assert.AreEqual(700, credit.GetSaldo());
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception), "Saldo will be less than 0")]
        public void ChangeSaldoTest2()
        {
            Client client = new Client("Jan", "Nowak", "01234567891");
            Credit credit = new Credit("123", new InterestTenPercent(), 1000, client);
            credit.ChangeSaldo(-1100);
        }

        [TestMethod()]
        public void AddIterestTest()
        {
            Client client = new Client("Jan", "Nowak", "01234567891");
            Credit credit = new Credit("123", new InterestTenPercent(), 1000, client);
            credit.AddIterest();
            Assert.AreEqual(1100, credit.GetSaldo());
        }

        [TestMethod()]
        public void ChangeIterestTest()
        {
            Client client = new Client("Jan", "Nowak", "01234567891");
            Credit credit = new Credit("123", new InterestTenPercent(), 1000, client);
            credit.AddIterest();
            credit.ChangeIterest(new InterestFivePercent());
            credit.AddIterest();
            Assert.AreEqual(1155, credit.GetSaldo());
        }

        [TestMethod()]
        public void GetClientTest()
        {
            Client client = new Client("Jan", "Nowak", "01234567891");
            Credit credit = new Credit("123", new InterestTenPercent(), 1000, client);
            Assert.AreEqual("01234567891", credit.GetClient().GetClientNIP());
        }
    }
}