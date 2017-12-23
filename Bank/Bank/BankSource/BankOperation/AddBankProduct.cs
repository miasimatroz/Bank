using Bank.BankSource.BankOperation;
using Bank.BankSource.BankProduct;
using Bank.BankSource.Interest;
using System;

namespace Bank.BankSource.BankOperation
{
    public class AddBankProduct : IBankOperation
    {

        Bank _bank;
        BankProduct.IBankProduct _bankProduct;

        public AddBankProduct(Bank bank, BankProduct.IBankProduct bankProduct)
        {
            _bank = bank;
            _bankProduct = bankProduct;
        }

        public void Execute()
        {
            _bank.AddBankProduct(_bankProduct);
        }
    }
}
