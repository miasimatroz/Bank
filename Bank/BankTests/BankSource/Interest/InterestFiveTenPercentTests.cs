using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bank.BankSource.Interest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.BankSource.Interest.Tests
{
    [TestClass()]
    public class InterestFiveTenPercentTests
    {
        [TestMethod()]
        public void GetInterestTest()
        {
            IInterest interest = new InterestFiveTenPercent();
            Assert.AreEqual(4, interest.GetInterest(80));
            Assert.AreEqual(150, interest.GetInterest(1500));
        }
    }
}