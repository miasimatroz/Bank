using Bank.BankSource.Interest;

namespace Bank.BankSource.BankProduct
{
    public class BankAccount : BankProduct
    {

        public BankAccount(string id, IInterest interest, double saldo) : base(id,interest,saldo)
        {

        }

    }
}
