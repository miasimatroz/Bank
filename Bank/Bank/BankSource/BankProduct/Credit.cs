using Bank.BankSource.Interest;
using System;
using Bank.BankSource.Report;

namespace Bank.BankSource.BankProduct
{
    public class Credit : IBankProduct
    {
        Client _client;
        string _productId;
        double _saldo;
        IInterest _interest;

        public Credit(string id, IInterest interest, double saldo, Client client)
        {
            _client = client;
            _productId = id;
            _saldo = saldo;
            _interest = interest;
        }

        public string GetProductId()
        {
            return _productId;
        }

        public double GetSaldo()
        {
            return _saldo;
        }

        public void ChangeSaldo(double value)
        {
            if (_saldo + value < 0)
            {
                throw new Exception("Saldo will be less than 0");
            }
            else
            {
                _saldo += value;
            }
        }

        public void AddIterest()
        {
            _saldo += _interest.GetInterest(_saldo);
        }

        public void ChangeIterest(IInterest interest)
        {
            _interest = interest;
        }

        public Client GetClient()
        {
            return _client;
        }

        public IBankProduct Accept(IReport report)
        {
            return report.Visit(this);
        }

    }
}
