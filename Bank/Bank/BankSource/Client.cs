using System;
using System.Collections.Generic;
using Bank.BankSource.BankProduct;

namespace Bank
{
    public class Client
    {
        string _clientId;
        string _clientName;
        string _clientSurname;
        DateTime _createDate;
        List<BankProduct> _bankProductsList = new List<BankProduct>();

        public Client(string clientName, string clientSurname, string clientId)
        {
            _clientId = clientId;
            _clientName = clientName;
            _clientSurname = clientSurname;
            _createDate = DateTime.Now;

        }

        public string GetName()
        {
            return _clientName;
        }

        public string GetSurname()
        {
            return _clientSurname;
        }

        public string GetClientId()
        {
            return _clientId;
        }

        public void AddBankProduct(BankProduct bankProduct)
        {
            _bankProductsList.Add(bankProduct);
        }

        public List<BankProduct> GetBankProducts()
        {
            return _bankProductsList;
        }

        public BankProduct GetBankProductById(string id)
        {
            BankProduct temp = null;
            foreach (BankProduct bankProduct in _bankProductsList)
            {
                if (bankProduct.GetProductId() == id)
                {
                    temp = bankProduct;
                }
            }
            return temp;
        }
    }
}
