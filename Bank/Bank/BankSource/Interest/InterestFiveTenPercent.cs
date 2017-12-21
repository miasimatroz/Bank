using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.BankSource.Interest
{
    public class InterestFiveTenPercent : IInterest
    {
        public double GetInterest(double value)
        {
            if(value < 1000)
            {
                return 0.05 * value;
            } else
            {
                return 0.10 * value;
            }
        }
    }
}
