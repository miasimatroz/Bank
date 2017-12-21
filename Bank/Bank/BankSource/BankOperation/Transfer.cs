using System;
using Bank.BankSource.BankProduct;

namespace Bank.BankSource.BankOperation
{
    public class Transfer : IBankOperation
    {
        BankAccount _sourceAccount;
        BankAccount _destinaionAccount;
        Double _value;

        public Transfer(BankAccount sourceAccount, BankAccount destinationAccount, Double value)
        {
            _sourceAccount = sourceAccount;
            _destinaionAccount = destinationAccount;
            _value = value;
        }

        public void Execute()
        {
            if (_sourceAccount.GetSaldo() > _value)
            {
                _sourceAccount.ChangeSaldo(-_value);
                _destinaionAccount.ChangeSaldo(_value);
            }
            else
            {
                throw new System.Exception("Don't enough saldo on source account");
            }

        }
    }
}
