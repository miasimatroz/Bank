using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bank.BankSource.BankProduct;
using Bank.BankSource.Interest;

namespace Bank.BankSource.BankOperation.Tests
{
    [TestClass()]
    public class TransferTests
    {
        [TestMethod()]
        public void ExecuteTest()
        {
            BankAccount bankAccount1 = new BankAccount("1", new InterestZero(), 1000);
            BankAccount bankAccount2 = new BankAccount("2", new InterestZero(), 1000);
            Transfer transfer = new Transfer(bankAccount1, bankAccount2, 500);
            transfer.Execute();

            Assert.AreEqual(500, bankAccount1.GetSaldo());
            Assert.AreEqual(1500, bankAccount2.GetSaldo());
        }
    }
}