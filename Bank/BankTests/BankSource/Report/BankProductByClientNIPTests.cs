using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bank.BankSource.BankProduct;
using Bank.BankSource.BankOperation;
using Bank.BankSource.Interest;
using System.Collections.Generic;

namespace Bank.BankSource.Report.Tests
{
    [TestClass()]
    public class BankProductByClientNIPTests
    {
        [TestMethod()]
        public void VisitTest()
        {
            Bank bank = new Bank("1");
            Client client1 = new Client("Jan", "Nowak", "01234567891");
            BankAccount bankAccount1 = new BankAccount("1", new InterestZero(), 1100, client1);
            Client client2 = new Client("Jan", "Kowalski", "01234567892");
            BankAccount bankAccount2 = new BankAccount("2", new InterestZero(), 500, client2);

            AddBankProduct addBankProduct1 = new AddBankProduct(bank, bankAccount1);
            bank.DoOperation(addBankProduct1);

            AddBankProduct addBankProduct2 = new AddBankProduct(bank, bankAccount2);
            bank.DoOperation(addBankProduct2);

            IReport report = new BankProductByClientNIP("01234567891");
            List<IBankProduct> bankProdusts = new List<IBankProduct>();

            bankProdusts = bank.DoReport(report);

            Assert.AreEqual(1, bankProdusts.Count);

            Assert.AreEqual("Nowak", bankProdusts[0].GetClient().GetSurname());
        }

        [TestMethod()]
        public void VisitTest2()
        {
            Bank bank = new Bank("1");
            Client client1 = new Client("Jan", "Nowak", "01234567891");
            IBankProduct bankAccount1 = new BankAccount("1", new InterestZero(), 1100, client1);
            bankAccount1 = new BankAccountDebet((BankAccount)bankAccount1, 100);
            Client client2 = new Client("Jan", "Kowalski", "01234567892");
            IBankProduct bankAccount2 = new BankAccount("2", new InterestZero(), 500, client2);
            bankAccount2 = new BankAccountDebet((BankAccount)bankAccount2, 100);

            AddBankProduct addBankProduct1 = new AddBankProduct(bank, bankAccount1);
            bank.DoOperation(addBankProduct1);

            AddBankProduct addBankProduct2 = new AddBankProduct(bank, bankAccount2);
            bank.DoOperation(addBankProduct2);

            IReport report = new BankProductByClientNIP("01234567892");
            List<IBankProduct> bankProdusts = new List<IBankProduct>();

            bankProdusts = bank.DoReport(report);

            Assert.AreEqual(1, bankProdusts.Count);

            Assert.AreEqual("Kowalski", bankProdusts[0].GetClient().GetSurname());
        }

        [TestMethod()]
        public void VisitTest3()
        {
            Bank bank = new Bank("1");
            Client client1 = new Client("Jan", "Nowak", "01234567891");
            Credit credit1 = new Credit("1", new InterestZero(), 1100, client1);
            Client client2 = new Client("Jan", "Kowalski", "01234567892");
            Credit credit2 = new Credit("2", new InterestZero(), 500, client2);

            AddBankProduct addBankProduct1 = new AddBankProduct(bank, credit1);
            bank.DoOperation(addBankProduct1);

            AddBankProduct addBankProduct2 = new AddBankProduct(bank, credit2);
            bank.DoOperation(addBankProduct2);

            IReport report = new BankProductByClientNIP("01234567891");
            List<IBankProduct> bankProdusts = new List<IBankProduct>();

            bankProdusts = bank.DoReport(report);

            Assert.AreEqual(1, bankProdusts.Count);

            Assert.AreEqual("Nowak", bankProdusts[0].GetClient().GetSurname());
        }

        [TestMethod()]
        public void VisitTest4()
        {
            Bank bank = new Bank("1");
            Client client1 = new Client("Jan", "Nowak", "01234567891");
            Investment investment1 = new Investment("1", new InterestZero(), 1100, client1);
            Client client2 = new Client("Jan", "Kowalski", "01234567892");
            Investment investment2 = new Investment("2", new InterestZero(), 500, client2);

            AddBankProduct addBankProduct1 = new AddBankProduct(bank, investment1);
            bank.DoOperation(addBankProduct1);

            AddBankProduct addBankProduct2 = new AddBankProduct(bank, investment2);
            bank.DoOperation(addBankProduct2);

            IReport report = new BankProductByClientNIP("01234567891");
            List<IBankProduct> bankProdusts = new List<IBankProduct>();

            bankProdusts = bank.DoReport(report);

            Assert.AreEqual(1, bankProdusts.Count);

            Assert.AreEqual("Nowak", bankProdusts[0].GetClient().GetSurname());
        }
    }
}