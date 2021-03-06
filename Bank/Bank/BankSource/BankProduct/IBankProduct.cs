﻿using Bank.BankSource.Interest;
using Bank.BankSource.Report;

namespace Bank.BankSource.BankProduct
{
    public interface IBankProduct
    {
        string GetProductId();

        double GetSaldo();

        void ChangeSaldo(double value);

        void AddIterest();

        void ChangeIterest(IInterest interest);

        Client GetClient();

        IBankProduct Accept(IReport report);
    }
}
