using Bank.BankSource.Interest;

namespace Bank.BankSource.BankProduct
{
    public abstract class BankProduct
    {
        string _productId;
        double _saldo;
        IInterest _interest;

        public BankProduct(string id, IInterest interest, double saldo) {
            _productId = id;
            _saldo = saldo;
            _interest = interest;
            _saldo += interest.GetInterest(saldo);
        }

        public string GetProductId() {
            return _productId;
        }

        public double GetSaldo()
        {
            return _saldo;
        }

        public void ChangeSaldo(double value)
        {
            _saldo += value;
        }
    }
}
