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
        List<IBankProduct> _bankProductsList = new List<IBankProduct>();

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

        public void AddBankProduct(IBankProduct bankProduct)
        {
            _bankProductsList.Add(bankProduct);
        }

        public List<IBankProduct> GetBankProducts()
        {
            return _bankProductsList;
        }

        public IBankProduct GetBankProductById(string id)
        {
            IBankProduct temp = null;
            foreach (IBankProduct bankProduct in _bankProductsList)
            {
                if (bankProduct.GetProductId() == id)
                {
                    temp = bankProduct;
                }
            }
            return temp;
        }

        public List<IBankProduct> GetBankProduct()
        {
            return _bankProductsList;
        }

    }
}
