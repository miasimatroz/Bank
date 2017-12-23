using Bank.BankSource.BankProduct;

namespace Bank.BankSource.Report
{
    public interface IReport
    {
        IBankProduct Visit(BankAccount bankAccount);

        IBankProduct Visit(BankAccountDebet bankAccount);

        IBankProduct Visit(Credit bankAccount);

        IBankProduct Visit(Investment bankAccount);
    }
}
