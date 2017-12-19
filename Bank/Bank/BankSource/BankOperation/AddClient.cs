
using System;

namespace Bank.BankSource.BankOperation
{
    public class AddClient : IBankOperation
    {
        Bank _bank;
        Client _client;

        public AddClient(Bank bank, Client client)
        {
            _bank = bank;
            _client = client;
        }

        public void Execute()
        {
            _bank.AddClient(_client);
        }

    }
}
