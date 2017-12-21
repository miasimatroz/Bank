
namespace Bank.BankSource.BankOperation
{
    public class Withdraw : IBankOperation
    {
        BankProduct.IBankProduct _bankProduct;
        double _value;

        public Withdraw(BankProduct.IBankProduct bankProduct, double value)
        {
            _bankProduct = bankProduct;
            _value = value;
        }

        public void Execute()
        {
            if (_value < 0)
            {
                throw new System.Exception("Cannot withdraw value less then 0");
            }
            else
            {
                if(_value > _bankProduct.GetSaldo())
                {
                    throw new System.Exception("Don't enough saldo");
                }
                else
                {
                    _bankProduct.ChangeSaldo(-_value);
                }
            }
        }
    }
}
