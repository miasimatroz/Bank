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
            Investment investment = new Investment("123", new InterestTenPercent(), 1000);
            Assert.AreEqual("123", investment.GetProductId());
        }

        [TestMethod()]
        public void GetSaldoTest()
        {
            Investment investment = new Investment("1", new InterestTenPercent(), 1000);
            Assert.AreEqual(1000, investment.GetSaldo());
        }

        [TestMethod()]
        public void ChangeSaldoTest()
        {
            Investment investment = new Investment("1", new InterestTenPercent(), 1000);
            investment.ChangeSaldo(100);
            Assert.AreEqual(1100, investment.GetSaldo());
            investment.ChangeSaldo(-400);
            Assert.AreEqual(700, investment.GetSaldo());
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception), "Saldo will be less than 0")]
        public void ChangeSaldoTest2()
        {
            Investment investment = new Investment("1", new InterestTenPercent(), 1000);
            investment.ChangeSaldo(-1100);
        }

        [TestMethod()]
        public void AddIterestTest()
        {
            Investment investment = new Investment("1", new InterestTenPercent(), 1000);
            investment.AddIterest();
            Assert.AreEqual(1100, investment.GetSaldo());
        }

        [TestMethod()]
        public void ChangeIterestTest()
        {
            Investment investment = new Investment("1", new InterestTenPercent(), 1000);
            investment.AddIterest();
            investment.ChangeIterest(new InterestFivePercent());
            investment.AddIterest();
            Assert.AreEqual(1155, investment.GetSaldo());
        }

    }
}