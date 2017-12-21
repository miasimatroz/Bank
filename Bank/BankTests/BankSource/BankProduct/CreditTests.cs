﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            Credit credit = new Credit("123", new InterestTenPercent(), 1000);
            Assert.AreEqual("123", credit.GetProductId());
        }

        [TestMethod()]
        public void GetSaldoTest()
        {
            Credit credit = new Credit("1", new InterestTenPercent(), 1000);
            Assert.AreEqual(1000, credit.GetSaldo());
        }

        [TestMethod()]
        public void ChangeSaldoTest()
        {
            Credit credit = new Credit("1", new InterestTenPercent(), 1000);
            credit.ChangeSaldo(100);
            Assert.AreEqual(1100, credit.GetSaldo());
            credit.ChangeSaldo(-400);
            Assert.AreEqual(700, credit.GetSaldo());
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception), "Saldo will be less than 0")]
        public void ChangeSaldoTest2()
        {
            Credit credit = new Credit("1", new InterestTenPercent(), 1000);
            credit.ChangeSaldo(-1100);
        }

        [TestMethod()]
        public void AddIterestTest()
        {
            Credit credit = new Credit("1", new InterestTenPercent(), 1000);
            credit.AddIterest();
            Assert.AreEqual(1100, credit.GetSaldo());
        }

        [TestMethod()]
        public void ChangeIterestTest()
        {
            Credit credit = new Credit("1", new InterestTenPercent(), 1000);
            credit.AddIterest();
            credit.ChangeIterest(new InterestFivePercent());
            credit.AddIterest();
            Assert.AreEqual(1155, credit.GetSaldo());
        }
    }
}