using Bank.BankSource.BankProduct;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bank.BankSource.Interest;
using System;

namespace Bank.BankSource.BankProduct.Tests
{
    [TestClass()]
    public class BankAccountTests
    {

        [TestMethod()]
        public void GetProductIdTest()
        {
            Client client = new Client("Jan", "Nowak", "01234567891");
            BankAccount bankAccount = new BankAccount("123", new InterestTenPercent(), 1000, client);
            Assert.AreEqual("123", bankAccount.GetProductId());
        }

        [TestMethod()]
        public void GetSaldoTest()
        {
            Client client = new Client("Jan", "Nowak", "01234567891");
            BankAccount bankAccount = new BankAccount("123", new InterestTenPercent(), 1000, client);
            Assert.AreEqual(1000, bankAccount.GetSaldo());
        }

        [TestMethod()]
        public void ChangeSaldoTest()
        {
            Client client = new Client("Jan", "Nowak", "01234567891");
            BankAccount bankAccount = new BankAccount("123", new InterestTenPercent(), 1000, client);
            bankAccount.ChangeSaldo(100);
            Assert.AreEqual(1100, bankAccount.GetSaldo());
            bankAccount.ChangeSaldo(-400);
            Assert.AreEqual(700, bankAccount.GetSaldo());
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception), "Saldo will be less than 0")]
        public void ChangeSaldoTest2()
        {
            Client client = new Client("Jan", "Nowak", "01234567891");
            BankAccount bankAccount = new BankAccount("123", new InterestTenPercent(), 1000, client);
            bankAccount.ChangeSaldo(-1100);
        }

        [TestMethod()]
        public void AddIterestTest()
        {
            Client client = new Client("Jan", "Nowak", "01234567891");
            BankAccount bankAccount = new BankAccount("123", new InterestTenPercent(), 1000, client);
            bankAccount.AddIterest();
            Assert.AreEqual(1100, bankAccount.GetSaldo());
        }

        [TestMethod()]
        public void ChangeIterestTest()
        {
            Client client = new Client("Jan", "Nowak", "01234567891");
            BankAccount bankAccount = new BankAccount("123", new InterestTenPercent(), 1000, client);
            bankAccount.AddIterest();
            bankAccount.ChangeIterest(new InterestFivePercent());
            bankAccount.AddIterest();
            Assert.AreEqual(1155, bankAccount.GetSaldo());
        }

        [TestMethod()]
        public void GetClientTest()
        {
            Client client = new Client("Jan", "Nowak", "01234567891");
            BankAccount bankAccount = new BankAccount("123", new InterestTenPercent(), 1000, client);
            Assert.AreEqual("01234567891", bankAccount.GetClient().GetClientNIP());
        }
    }
}