using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bank.BankSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public void AddClientTest()
        {
            string bankId = Bank.GetFreeBanktId();
            Bank bank = new Bank(bankId);
            Assert.AreEqual(0, bank.GetClients().Count);

            string clientId = bank.GetFreeBankProductId();
            Client client = new Client("Jan", "Nowak",clientId);
            bank.AddClient(client);
            Assert.AreEqual(1, bank.GetClients().Count);
            Assert.AreEqual("Jan", bank.GetClientById(clientId).GetName());
            Assert.AreEqual("Nowak", bank.GetClientById(clientId).GetSurname());
        }
    }
}