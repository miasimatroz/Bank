using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bank.BankSource.Interest;
using Bank.BankSource.BankProduct;


namespace Bank.BankSource.BankOperation.Tests
{
    [TestClass()]
    public class AddBankProductToClientTests
    {
        [TestMethod()]
        public void ExecuteTest()
        {
            Bank bank = new Bank(Bank.GetFreeBanktId());

            string clientId = bank.GetFreeBankProductId();
            Client client = new Client("Jan", "Nowak", clientId);

            string accountId = bank.GetFreeBankProductId();
            BankAccount bankAccount = new BankAccount(accountId,new InterestTenPercent(),1000);

            AddBankProductToClient addBankProductToClient = new AddBankProductToClient(client, bankAccount);
            bank.DoOperation(addBankProductToClient);

            BankProduct.IBankProduct clientProduct = client.GetBankProductById(accountId);
            Assert.AreNotEqual(null, clientProduct);
        }
    }
}