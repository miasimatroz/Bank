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
    public class InterestTenPercentTests
    {
        [TestMethod()]
        public void getInterestTest()
        {
            InterestTenPercent fixture = new InterestTenPercent();
            Assert.AreEqual(10, fixture.GetInterest(100));
        }
    }
}