using System.Collections.Generic;
using Bank.BankSource.BankProduct;
using Bank.BankSource.BankOperation;

namespace Bank.BankSource.KIR
{
    public class KIR
    {
        Dictionary<string, Bank> bankDictionary = new Dictionary<string, Bank>();

        public void addBank(Bank bank)
        {
            System.Console.WriteLine(bank.GetBankId());
            bankDictionary.Add(bank.GetBankId(), bank);
        }

        public void Send(string sourceAccountId, string destinationAccountId, int saldo)
        {
            Withdraw withdraw = null;
            Deposit deposit = null;
            Bank sourceBank = null;
            Bank destinationBank = null;
            foreach (Bank bank in bankDictionary.Values)
            {
                if (bank.GetBankProductById(sourceAccountId) != null)
                {
                    System.Console.WriteLine("Znalazlem");
                    BankProduct.IBankProduct bankProduct = bank.GetBankProductById(sourceAccountId);

                    if (typeof(BankAccount) == bankProduct.GetType())
                    {
                        withdraw = new Withdraw((BankProduct.BankAccount)bankProduct, saldo);
                        sourceBank = bank;
                    }
                }

                if (bank.GetBankProductById(destinationAccountId) != null)
                {
                    BankProduct.IBankProduct bankProduct = bank.GetBankProductById(destinationAccountId);
                    if (typeof(BankAccount) == bankProduct.GetType())
                    {
                        deposit = new Deposit((BankProduct.BankAccount)bankProduct, saldo);
                        destinationBank = bank;
                    }
                }
            }

            if ((destinationBank != null) && (sourceBank != null))
            {
                System.Console.WriteLine("Poszlo");
                sourceBank.DoOperation(withdraw);
                destinationBank.DoOperation(deposit);
            }

        }
    }
}
