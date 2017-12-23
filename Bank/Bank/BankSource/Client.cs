using System;
using System.Collections.Generic;
using Bank.BankSource.BankProduct;

namespace Bank
{
    public class Client
    {
        string _clientNIP;
        string _clientName;
        string _clientSurname;

        public Client(string clientName, string clientSurname, string clientNIP)
        {
            _clientName = clientName;
            _clientSurname = clientSurname;
            _clientNIP = clientNIP;

        }

        public string GetName()
        {
            return _clientName;
        }

        public string GetSurname()
        {
            return _clientSurname;
        }

        public string GetClientNIP()
        {
            return _clientNIP;
        }

    }
}
