using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bank.BankSource.Interest;


namespace Bank.BankSource.BankProduct.Tests
{
    [TestClass()]
    public class CreditTests
    {
        [TestMethod()]
        public void CreditTest()
        {
            Credit credit = new Credit("1", new InterestTenPercent(), 1000);
            Assert.AreEqual(1100, credit.GetSaldo());
        }
    }
}