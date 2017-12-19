using System;
using Bank.BankSource.Interest;

namespace Bank.BankSource.Interest
{
    public class InterestFivePercent : IInterest
    {

       public  Double GetInterest(Double value)
        {
            return value * 0.05;
        }

    }
}
