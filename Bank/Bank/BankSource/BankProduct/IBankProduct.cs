using Bank.BankSource.Interest;

namespace Bank.BankSource.BankProduct
{
    public interface IBankProduct
    {

        string GetProductId();

        double GetSaldo();

        void ChangeSaldo(double value);

        void AddIterest();

        void ChangeIterest(IInterest interest);

    }
}
