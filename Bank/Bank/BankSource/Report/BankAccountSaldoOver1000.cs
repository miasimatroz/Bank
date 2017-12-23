using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.BankSource.BankProduct;

namespace Bank.BankSource.Report
{
    public class BankAccountSaldoOver1000 : IReport
    {
        public IBankProduct Visit(BankAccount bankAccount)
        {
            if (bankAccount.GetSaldo() > 1000)
                return bankAccount;
            return null;
        }

        public IBankProduct Visit(BankAccountDebet bankAccount)
        {
            if (bankAccount.GetSaldo() > 1000)
                return bankAccount;
            return null;
        }

        public IBankProduct Visit(Credit credit)
        {
            return null;
        }

        public IBankProduct Visit(Investment investment)
        {
            return null;
        }
    }
}
