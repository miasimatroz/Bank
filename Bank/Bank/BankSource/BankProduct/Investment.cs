using Bank.BankSource.Interest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.BankSource.BankProduct
{
    public class Investment : IBankProduct
    {

        string _productId;
        double _saldo;
        IInterest _interest;

        public Investment(string id, IInterest interest, double saldo)
        {
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
    }
}
