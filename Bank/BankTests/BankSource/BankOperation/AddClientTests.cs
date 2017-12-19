using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bank.BankSource.BankOperation;
using Bank.BankSource;
using System;

namespace Bank.BankSource.BankOperation.Tests
{
    [TestClass()]
    public class AddClientTests
    {

        [TestMethod()]
        public void AddClientClientIdTest()
        {
            string bankId = Bank.GetFreeBanktId();
            Bank bank = new Bank(bankId);
            string clientId1 = bank.GetFreeBankProductId();
            Client client1 = new Client("Jan", "Nowak", bankId + clientId1);
            string clientId2 = bank.GetFreeBankProductId();
            Client client2 = new Client("Jan", "Kowalski", bankId + clientId2);

            AddClient addClient1 = new AddClient(bank, client1);
            bank.DoOperation(addClient1);


            AddClient addClient2 = new AddClient(bank, client2);
            bank.DoOperation(addClient2);


            Assert.AreEqual("Kowalski", bank.GetClientById(bankId+clientId2).GetSurname());
        }

        [TestMethod()]
        public void AddClientExecuteTest()
        {
            Bank bank = new Bank(Bank.GetFreeBanktId());
            string clientId = bank.GetFreeBankProductId();
            Client client = new Client("Jan", "Nowak", clientId);
            AddClient addClient = new AddClient(bank, client);

            bank.DoOperation(addClient);

            Client BankClient = bank.GetClientById(clientId);

            if (BankClient == null)
            {
                Assert.Fail();
            }
            else
            {
                Assert.AreEqual("Jan", BankClient.GetName());
                Assert.AreEqual("Nowak", BankClient.GetSurname());
            }
        }
    }
}