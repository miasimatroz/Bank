
namespace Bank.BankSource.BankOperation
{
    public class Deposit : IBankOperation
    {

        BankProduct.BankProduct _bankProduct;
        double _value;
        
        public Deposit (BankProduct.BankProduct bankProduct, double value)
        {
            _bankProduct = bankProduct;
            _value = value;
        }

        public void Execute()
        {
            if(_value < 0)
            {
                throw new System.Exception("Cannot deposit value less then 0");
            } else
            {
                _bankProduct.ChangeSaldo(_value);
            }
        }
    }
}
