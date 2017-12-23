using System;
using Bank.BankSource.BankProduct;

namespace Bank.BankSource.BankOperation
{
    public class AddInterest : IBankOperation
    {

        IBankProduct _bankProduct;

        public AddInterest(IBankProduct bankProduct)
        {
            _bankProduct = bankProduct;
        }

        public void Execute()
        {
            _bankProduct.AddIterest();
        }
    }
}
