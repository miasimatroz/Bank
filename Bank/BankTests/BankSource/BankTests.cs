using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bank.BankSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.BankSource.BankProduct;
using Bank.BankSource.Interest;
using Bank.BankSource.BankOperation;

namespace Bank.BankSource.Tests
{
    [TestClass()]
    public class BankTests
    {
        [TestMethod()]
        public void BankTest()
        {
            Bank bank1 = new Bank(Bank.GetFreeBanktId());
            Bank bank2 = new Bank(Bank.GetFreeBanktId());

            Assert.AreEqual("00000001", bank1.GetBankId());
            Assert.AreEqual("00000002", bank2.GetBankId());
        }

        [TestMethod()]
        public void GetFreeBankProductIdTest()
        {
            string bankId = Bank.GetFreeBanktId();
            Bank bank = new Bank(bankId);
            string bankProductId1 = bank.GetFreeBankProductId();
            string bankProductId2 = bank.GetFreeBankProductId();


            Assert.AreEqual(bankId + "0000000000000001", bankProductId1);
            Assert.AreEqual(bankId + "0000000000000002", bankProductId2);
        }

        [TestMethod()]
        public void GetBankIdTest()
        {
            string bankId = Bank.GetFreeBanktId();
            Bank bank = new Bank(bankId);

            Assert.AreEqual(bankId, bank.GetBankId());
        }

        [TestMethod()]
        public void AddProductTest()
        {
            string bankId = Bank.GetFreeBanktId();
            Bank bank = new Bank(bankId);
            Assert.AreEqual(0, bank.GetProducts().Count);

            Client client = new Client("Jan", "Nowak", "01234567891");
            IBankProduct bankProduct = new BankAccount("1", new InterestZero(), 100, client);

            bank.AddBankProduct(bankProduct);

            Assert.AreEqual(1, bank.GetProducts().Count);
            Assert.AreEqual(100, bank.GetBankProductById("1").GetSaldo());
        }

        [TestMethod()]
        public void DoOperationTest()
        {
            string bankId = Bank.GetFreeBanktId();
            Bank bank = new Bank(bankId);

            Client client = new Client("Jan", "Nowak", "01234567891");
            BankAccount bankAccount = new BankAccount("1", new InterestZero(), 1000,client);

            Deposit deposit = new Deposit(bankAccount, 100);

            bank.DoOperation(deposit);
            Assert.AreEqual(1100, bankAccount.GetSaldo());
        }

        [TestMethod()]
        public void DoOperationTest2()
        {
            string bankId = Bank.GetFreeBanktId();
            Bank bank = new Bank(bankId);

            Client client = new Client("Jan", "Nowak", "01234567891");
            BankAccount bankAccount = new BankAccount("1", new InterestZero(), 1000, client);
            Withdraw withdraw = new Withdraw(bankAccount, 100);
            Assert.AreEqual(0, bank.GetOperationsList().Count);
            bank.DoOperation(withdraw);
            Assert.AreEqual(1, bank.GetOperationsList().Count);
        }
    }
}