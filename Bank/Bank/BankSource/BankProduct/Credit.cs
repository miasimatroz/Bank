using Bank.BankSource.Interest;

namespace Bank.BankSource.BankProduct
{
    public class Credit : BankProduct
    {
        public Credit(string id, IInterest interest, double saldo) : base(id,interest,saldo)
        {

        }
    }
}
