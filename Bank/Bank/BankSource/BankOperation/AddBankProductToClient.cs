using Bank.BankSource.BankOperation;
using Bank.BankSource.BankProduct;
using Bank.BankSource.Interest;
using System;

namespace Bank.BankSource.BankOperation
{
    public class AddBankProductToClient : IBankOperation
    {

        Client _client;
        BankProduct.BankProduct _bankProduct;

        public AddBankProductToClient(Client client, BankProduct.BankProduct bankProduct)
        {
            _client = client;
            _bankProduct = bankProduct;
        }

        public void Execute()
        {
            _client.AddBankProduct(_bankProduct);
        }
    }
}
