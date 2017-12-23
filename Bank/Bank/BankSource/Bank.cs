using System;
using System.Collections.Generic;
using Bank.BankSource.BankOperation;
using Bank.BankSource.Report;
using Bank.BankSource.BankProduct;

namespace Bank.BankSource
{
    public class Bank
    {
        static string _freeBankId = "00000000";
        string _freeBankProductId = "0000000000000000";

        string _bankId;
        public List<IBankOperation> _bankOperationsList;
        public List<IBankProduct> _bankProducts;

        public Bank(string id)
        {
            _bankOperationsList = new List<IBankOperation>();
            _bankProducts = new List<IBankProduct>();
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

        public void AddBankProduct(IBankProduct bankProduct)
        {
            _bankProducts.Add(bankProduct);
        }

        public BankProduct.IBankProduct GetBankProductById(string id)
        {
            BankProduct.IBankProduct tempProduct = null;
                foreach (BankProduct.IBankProduct bankProduct in _bankProducts)
                {
                    if (bankProduct.GetProductId() == id)
                    {
                        tempProduct = bankProduct;
                        break;
                    }
                }
            return tempProduct;
        }

        public List<IBankProduct> GetProducts()
        {
            return _bankProducts;
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

        public List<IBankProduct> DoReport(IReport report)
        {
            List<IBankProduct> result = new List<IBankProduct>();
            foreach (IBankProduct bankProduct in _bankProducts)
            {
                IBankProduct temp = bankProduct.Accept(report);
                if(temp != null)
                    result.Add(temp);
            }
            return result;
        }
    }
}
