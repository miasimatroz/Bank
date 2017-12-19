using System;

namespace Bank.BankSource.Interest
{
    public class InterestTenPercent : IInterest
    {
        public Double GetInterest(Double value)
        {
            return value * 0.1;
        }
    }
}
