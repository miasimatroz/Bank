using Bank.BankSource.BankOperation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bank.BankSource.Interest;
using Bank.BankSource.BankProduct;


namespace Bank.BankSource.BankOperation.Tests
{
    [TestClass()]
    public class AddBankProductTests
    {
        [TestMethod()]
        public void ExecuteTest()
        {
            Bank bank = new Bank(Bank.GetFreeBanktId());

            string clientId = bank.GetFreeBankProductId();
            Client client = new Client("Jan", "Nowak", "01234567891");

            string accountId = bank.GetFreeBankProductId();
            BankAccount bankAccount = new BankAccount(accountId, new InterestTenPercent(), 1000, client);

            AddBankProduct addBankProduct = new AddBankProduct(bank, bankAccount);
            bank.DoOperation(addBankProduct);

            BankProduct.IBankProduct product = bank.GetBankProductById(accountId);
            Assert.AreNotEqual(null, product);
        }
    }
}