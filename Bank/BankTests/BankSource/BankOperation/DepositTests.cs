using Bank.BankSource.BankOperation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bank.BankSource.BankProduct;
using Bank.BankSource.Interest;
using System;

namespace Bank.BankSource.BankOperation.Tests
{
    [TestClass()]
    public class DepositTests
    {
        [TestMethod()]
        public void ExecuteTest1()
        {
            Client client = new Client("Jan", "Nowak", "01234567891");
            BankAccount bankAccount = new BankAccount("1", new InterestZero(), 1000,client);
            Deposit deposit = new Deposit(bankAccount, 100);
            deposit.Execute();

            Assert.AreEqual(1100, bankAccount.GetSaldo());
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception), "Cannot deposit value less then 0")]
        public void ExecuteTest2()
        {
            Client client = new Client("Jan", "Nowak", "01234567891");
            BankAccount bankAccount = new BankAccount("1", new InterestZero(), 1000, client);
            Deposit deposit = new Deposit(bankAccount, -100);

            deposit.Execute();
        }
    }
}