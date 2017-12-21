using System;
using System.Collections.Generic;
using Bank.BankSource.BankOperation;

namespace Bank.BankSource
{
    public class Bank
    {
        static string _freeBankId = "00000000";
        string _freeBankProductId = "0000000000000000";

        string _bankId;
        public List<Client> _clientsList;
        public List<IBankOperation> _bankOperationsList;

        public Bank(string id)
        {
            _clientsList = new List<Client>();
            _bankOperationsList = new List<IBankOperation>();
            _bankId = id;
        }

        static public string GetFreeBanktId()
        {
            Int64 freeBankId = Int64.Parse(_freeBankId);
            freeBankId++;
            _freeBankId = freeBankId.ToString().PadLeft(8, '0');
            return _freeBankId;
        }

        public string GetFreeBankProductId()
        {
            Int64 freeBankProductId = Int64.Parse(_freeBankProductId);
            freeBankProductId++;
            _freeBankProductId = freeBankProductId.ToString().PadLeft(16, '0');
            return _bankId + _freeBankProductId;
        }

        public string GetBankId()
        {
            return _bankId;
        }

        public BankProduct.IBankProduct GetBankProductById(string id)
        {
            BankProduct.IBankProduct tempProduct = null;
            foreach (Client client in _clientsList)
            {
                List<BankProduct.IBankProduct> listClientProduct = client.GetBankProduct();
                foreach (BankProduct.IBankProduct product in listClientProduct)
                {
                    if (product.GetProductId() == id)
                    {
                        tempProduct = product;
                        break;
                    }
                }
            }
            return tempProduct;
        }

        public void AddClient(Client client)
        {
            _clientsList.Add(client);
        }

        public List<Client> GetClients()
        {
            return _clientsList;
        }

        public Client GetClientById(string id)
        {
            Client tempClient = null;
            Console.WriteLine(_clientsList.Count);
            foreach (Client client in _clientsList)
            {
                Console.WriteLine(client.GetClientId());
                Console.WriteLine(id);
                if (client.GetClientId() == id)
                {
                    tempClient = client;
                }
            }
            return tempClient;
        }

        public void DoOperation(IBankOperation operation)
        {
            try
            {
                operation.Execute();
                _bankOperationsList.Add(operation);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public List<IBankOperation> GetOperationsList()
        {
            return _bankOperationsList;
        }
    }
}
