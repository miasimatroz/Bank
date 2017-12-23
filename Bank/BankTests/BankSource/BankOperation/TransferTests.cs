using Bank.BankSource.BankOperation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bank.BankSource.BankProduct;
using Bank.BankSource.Interest;
using System;

namespace Bank.BankSource.BankOperation.Tests
{
    [TestClass()]
    public class TransferTests
    {
        [TestMethod()]
        public void ExecuteTest()
        {
            Client client1 = new Client("Jan", "Nowak", "01234567891");
            BankAccount bankAccount1 = new BankAccount("1", new InterestZero(), 1000, client1);
            Client client2 = new Client("Jan", "Kowalski", "01234567892");
            BankAccount bankAccount2 = new BankAccount("2", new InterestZero(), 1000,client2);
            Transfer transfer = new Transfer(bankAccount1, bankAccount2, 500);
            transfer.Execute();

            Assert.AreEqual(500, bankAccount1.GetSaldo());
            Assert.AreEqual(1500, bankAccount2.GetSaldo());
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception), "Don't enough saldo on source account")]
        public void ExecuteTest1()
        {
            Client client1 = new Client("Jan", "Nowak", "01234567891");
            BankAccount bankAccount1 = new BankAccount("1", new InterestZero(), 1000, client1);
            Client client2 = new Client("Jan", "Kowalski", "01234567892");
            BankAccount bankAccount2 = new BankAccount("2", new InterestZero(), 1000, client2);
            Transfer transfer = new Transfer(bankAccount1, bankAccount2, 1500);
            transfer.Execute();
        }
    }
}