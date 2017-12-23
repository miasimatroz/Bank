using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bank.BankSource.BankOperation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.BankSource.BankProduct;
using Bank.BankSource.Interest;

namespace Bank.BankSource.BankOperation.Tests
{
    [TestClass()]
    public class AddInterestTests
    {
        [TestMethod()]
        public void ExecuteTest()
        {
            Client client = new Client("Jan", "Nowak", "01234567891");
            BankAccount bankAccount = new BankAccount("1", new InterestTenPercent(), 1000, client);
            AddInterest addInterest = new AddInterest(bankAccount);
            addInterest.Execute();

            Assert.AreEqual(1100, bankAccount.GetSaldo());
        }
    }
}