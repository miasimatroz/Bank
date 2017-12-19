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
    public class InterestFivePercentTests
    {
        [TestMethod()]
        public void getInterestTest()
        {
            InterestFivePercent fixture = new InterestFivePercent();
            Assert.AreEqual(5, fixture.GetInterest(100));
        }
    }
}