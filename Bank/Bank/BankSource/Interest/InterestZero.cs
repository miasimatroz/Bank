using System;

namespace Bank.BankSource.Interest
{
    public class InterestZero : IInterest
    {
        public Double GetInterest(Double value)
        {
            return 0;
        }

    }
}
