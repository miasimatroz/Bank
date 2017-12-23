using Bank.BankSource.BankOperation;
using System;
using Bank.BankSource.BankProduct;
using Bank.BankSource.Interest;

namespace BankTests.BankSource.BankOperation
{
    public class ChangeInterest : IBankOperation
    {
        IBankProduct _bankProduct;
        IInterest _interest;

        public ChangeInterest(IBankProduct bankProduct, IInterest interest)
        {
            _bankProduct = bankProduct;
            _interest = interest;
        }

        public void Execute()
        {
            _bankProduct.ChangeIterest(_interest);
        }
    }
}
