using Bank.BankSource.BankProduct;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bank.BankSource.Interest;
using System;

namespace Bank.BankSource.BankProduct.Tests
{
    [TestClass()]
    public class BankAccountDebetTests
    {

        [TestMethod()]
        public void GetProductIdTest()
        {
            Client client = new Client("Jan", "Nowak", "01234567891");
            IBankProduct bankAccount = new BankAccount("123", new InterestTenPercent(), 1000, client);
            bankAccount = new BankAccountDebet((BankAccount)bankAccount, 100);
            Assert.AreEqual("123", bankAccount.GetProductId());
        }

        [TestMethod()]
        public void GetSaldoTest()
        {
            Client client = new Client("Jan", "Nowak", "01234567891");
            IBankProduct bankAccount = new BankAccount("123", new InterestTenPercent(), 1000, client);
            bankAccount = new BankAccountDebet((BankAccount)bankAccount, 100);
            Assert.AreEqual(1100, bankAccount.GetSaldo());
        }

        [TestMethod()]
        public void ChangeSaldoTest()
        {
            Client client = new Client("Jan", "Nowak", "01234567891");
            IBankProduct bankAccount = new BankAccount("123", new InterestTenPercent(), 1000, client);
            bankAccount = new BankAccountDebet((BankAccount)bankAccount, 100);
            bankAccount.ChangeSaldo(-150);
            Assert.AreEqual(950, bankAccount.GetSaldo());
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception), "Saldo will be less than 0")]
        public void ChangeSaldoTest2()
        {
            Client client = new Client("Jan", "Nowak", "01234567891");
            IBankProduct bankAccount = new BankAccount("123", new InterestTenPercent(), 1000, client);
            bankAccount = new BankAccountDebet((BankAccount)bankAccount, 100);
            bankAccount.ChangeSaldo(-1150);
        }

        [TestMethod()]
        public void AddIterestTest()
        {
            Client client = new Client("Jan", "Nowak", "01234567891");
            IBankProduct bankAccount = new BankAccount("123", new InterestTenPercent(), 1000, client);
            bankAccount = new BankAccountDebet((BankAccount)bankAccount, 100);
            bankAccount.AddIterest();
            Assert.AreEqual(1210, bankAccount.GetSaldo());
        }

        [TestMethod()]
        public void ChangeIterestTest()
        {

            Client client = new Client("Jan", "Nowak", "01234567891");
            IBankProduct bankAccount = new BankAccount("123", new InterestTenPercent(), 1000, client);
            bankAccount = new BankAccountDebet((BankAccount)bankAccount, 100);
            bankAccount.AddIterest();
            bankAccount.ChangeIterest(new InterestFivePercent());
            bankAccount.AddIterest();
            Assert.AreEqual(1270.5, bankAccount.GetSaldo());
        }

        [TestMethod()]
        public void BankAccountDebetTest()
        {
            Client client = new Client("Jan", "Nowak", "01234567891");
            IBankProduct bankAccount = new BankAccount("123", new InterestTenPercent(), 1000, client);
            bankAccount = new BankAccountDebet((BankAccount)bankAccount, 100);
            bankAccount.ChangeSaldo(-1050);
            Assert.AreEqual(50, bankAccount.GetSaldo());
        }

        [TestMethod()]
        public void GetClientTest()
        {
            Client client = new Client("Jan", "Nowak", "01234567891");
            IBankProduct bankAccount = new BankAccount("123", new InterestTenPercent(), 1000, client);
            bankAccount = new BankAccountDebet((BankAccount)bankAccount, 100);
            Assert.AreEqual("01234567891", bankAccount.GetClient().GetClientNIP());
        }

    }
}