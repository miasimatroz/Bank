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
            BankAccount bankAccount = new BankAccount("123", new InterestTenPercent(), 1000);
            Assert.AreEqual("123", bankAccount.GetProductId());
        }

        [TestMethod()]
        public void GetSaldoTest()
        {
            BankAccount bankAccount = new BankAccount("1", new InterestTenPercent(), 1000);
            Assert.AreEqual(1000, bankAccount.GetSaldo());
        }

        [TestMethod()]
        public void ChangeSaldoTest()
        {
            BankAccount bankAccount = new BankAccount("1", new InterestTenPercent(), 1000);
            bankAccount.ChangeSaldo(100);
            Assert.AreEqual(1100, bankAccount.GetSaldo());
            bankAccount.ChangeSaldo(-400);
            Assert.AreEqual(700, bankAccount.GetSaldo());
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception), "Saldo will be less than 0")]
        public void ChangeSaldoTest2()
        {
            BankAccount bankAccount = new BankAccount("1", new InterestTenPercent(), 1000);
            bankAccount.ChangeSaldo(-1100);
        }

        [TestMethod()]
        public void AddIterestTest()
        {
            BankAccount bankAccount = new BankAccount("1", new InterestTenPercent(), 1000);
            bankAccount.AddIterest();
            Assert.AreEqual(1100, bankAccount.GetSaldo());
        }

        [TestMethod()]
        public void ChangeIterestTest()
        {
            BankAccount bankAccount = new BankAccount("1", new InterestTenPercent(), 1000);
            bankAccount.AddIterest();
            bankAccount.ChangeIterest(new InterestFivePercent());
            bankAccount.AddIterest();
            Assert.AreEqual(1155, bankAccount.GetSaldo());
        }

    }
}