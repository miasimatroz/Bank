using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bank.BankSource.KIR;
using Bank.BankSource.BankProduct;
using Bank.BankSource.Interest;
using Bank.BankSource.BankOperation;

namespace Bank.BankSource.KIR.Tests
{
    [TestClass()]
    public class KIRTests
    {
        [TestMethod()]
        public void SendTest()
        {
            Bank bank1 = new Bank("1");
            Bank bank2 = new Bank("2");

            System.Console.WriteLine(bank1.GetBankId());
            System.Console.WriteLine(bank2.GetBankId());

            string bank1ClientId = bank1.GetFreeBankProductId();
            Client bank1Client = new Client("Jan", "Nowak", "1234567891");

            string bank2ClientId = bank2.GetFreeBankProductId();
            Client bank2Client = new Client("Jan", "Nowak", "1234567892");

            string bank1AccountId = bank1.GetFreeBankProductId();
            string bank2AccountId = bank2.GetFreeBankProductId();

            BankAccount bank1Account = new BankAccount(bank1AccountId, new InterestZero(), 1000,bank1Client);
            BankAccount bank2Account = new BankAccount(bank2AccountId, new InterestZero(), 1000,bank2Client);

            AddBankProduct addBa1 = new AddBankProduct(bank1, bank1Account);
            AddBankProduct addBa2 = new AddBankProduct(bank2, bank2Account);
            bank1.DoOperation(addBa1);
            bank2.DoOperation(addBa2);

            KIR kir = new KIR();
            kir.addBank(bank1);
            kir.addBank(bank2);

            kir.Send(bank1Account.GetProductId(), bank2Account.GetProductId(), 500);

            System.Console.WriteLine(bank1Account.GetSaldo());
            System.Console.WriteLine(bank2Account.GetSaldo());

            Assert.AreEqual(bank1Account.GetSaldo(), 500);
            Assert.AreEqual(bank2Account.GetSaldo(), 1500);
        }
    }
}