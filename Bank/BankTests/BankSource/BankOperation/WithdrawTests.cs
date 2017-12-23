using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Bank.BankSource.BankProduct;
using Bank.BankSource.Interest;

namespace Bank.BankSource.BankOperation.Tests
{
    [TestClass()]
    public class WithdrawTests
    {
        [TestMethod()]
        public void ExecuteTest()
        {
            Client client = new Client("Jan", "Nowak", "01234567891");
            BankAccount bankAccount = new BankAccount("1", new InterestZero(), 1000, client);
            Withdraw withdraw = new Withdraw(bankAccount, 100);
            withdraw.Execute();

            Assert.AreEqual(900, bankAccount.GetSaldo());
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception), "Don't enough saldo")]
        public void ExecuteTest2()
        {
            Client client = new Client("Jan", "Nowak", "01234567891");
            BankAccount bankAccount = new BankAccount("1", new InterestZero(), 1000, client);
            Withdraw withdraw = new Withdraw(bankAccount, 1140);

            withdraw.Execute();
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception), "Cannot withdraw value less then 0")]
        public void ExecuteTest3()
        {
            Client client = new Client("Jan", "Nowak", "01234567891");
            BankAccount bankAccount = new BankAccount("1", new InterestZero(), 1000, client);
            Withdraw withdraw = new Withdraw(bankAccount, -10);

            withdraw.Execute();
        }
    }
}