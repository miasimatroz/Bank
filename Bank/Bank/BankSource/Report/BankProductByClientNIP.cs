using Bank.BankSource.BankProduct;

namespace Bank.BankSource.Report
{
    public class BankProductByClientNIP : IReport
    {
        string _clientNIP;

        public BankProductByClientNIP(string clientNIP)
        {
            _clientNIP = clientNIP;
        }

        public IBankProduct Visit(BankAccount bankAccount)
        {
            if (bankAccount.GetClient().GetClientNIP() == _clientNIP)
                return bankAccount;
            return null;
        }

        public IBankProduct Visit(BankAccountDebet bankAccount)
        {
            if (bankAccount.GetClient().GetClientNIP() == _clientNIP)
                return bankAccount;
            return null;
        }

        public IBankProduct Visit(Credit credit)
        {
            if (credit.GetClient().GetClientNIP() == _clientNIP)
                return credit;
            return null;
        }

        public IBankProduct Visit(Investment investment)
        {
            if (investment.GetClient().GetClientNIP() == _clientNIP)
                return investment;
            return null;
        }
    }
}
