using Bank.BankSource.Interest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.BankSource.Report;

namespace Bank.BankSource.BankProduct
{
    public class BankAccountDebet : IBankProduct
    {
        BankAccount _bankAccount;
        double _maxDebet;
        double _actualDebet;

        public BankAccountDebet(BankAccount bankAccount, double maxDebet)
        {
            _bankAccount = bankAccount;
            _maxDebet = maxDebet;
            _bankAccount.ChangeSaldo(_maxDebet);
            _actualDebet = 0;
        }

        public string GetProductId()
        {
            return _bankAccount.GetProductId();
        }

        public double GetSaldo()
        {
            return _bankAccount.GetSaldo();
        }

        public void ChangeSaldo(double value)
        {
            try
            {
                _bankAccount.ChangeSaldo(value);
                if (_bankAccount.GetSaldo() < _maxDebet)
                    _actualDebet = Math.Abs(_bankAccount.GetSaldo() - _maxDebet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddIterest()
        {
            _bankAccount.AddIterest();
        }

        public void ChangeIterest(IInterest interest)
        {
            _bankAccount.ChangeIterest(interest);
        }

        public Client GetClient()
        {
            return _bankAccount.GetClient();
        }

        public IBankProduct Accept(IReport report)
        {
            return report.Visit(this);
        }
        
    }
}
