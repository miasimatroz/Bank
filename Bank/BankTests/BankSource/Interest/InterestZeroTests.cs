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
    public class InterestZeroTests
    {
        [TestMethod()]
        public void getInterestTest()
        {
            InterestZero fixture = new InterestZero();
            Assert.AreEqual(0, fixture.GetInterest(100));
        }
    }
}