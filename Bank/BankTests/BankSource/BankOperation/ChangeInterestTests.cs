using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bank;
using Bank.BankSource.BankProduct;
using Bank.BankSource.BankOperation;
using Bank.BankSource.Interest;

namespace BankTests.BankSource.BankOperation.Tests
{
    [TestClass()]
    public class ChangeInterestTests
    {
        [TestMethod()]
        public void ExecuteTest()
        {
            Client client = new Client("Jan", "Nowak", "01234567891");
            BankAccount bankAccount = new BankAccount("1", new InterestTenPercent(), 1000, client);

            AddInterest addInterest = new AddInterest(bankAccount);
            addInterest.Execute();
            Assert.AreEqual(1100, bankAccount.GetSaldo());

            ChangeInterest changeInterest = new ChangeInterest(bankAccount, new InterestFivePercent());
            changeInterest.Execute();

            addInterest.Execute();
            Assert.AreEqual(1155, bankAccount.GetSaldo());
        }
    }
}