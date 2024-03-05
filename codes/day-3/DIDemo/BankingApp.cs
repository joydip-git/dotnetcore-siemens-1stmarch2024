namespace DIDemo
{
    public class BankingApp
    {
        private readonly IBankingOperations _bankingOperations;

        public BankingApp(IBankingOperations bankingOperations)
        {
            _bankingOperations = bankingOperations;
        }

        public string TransferAmount(double amount)
        {            
            _bankingOperations.CreditAmount(amount);
            _bankingOperations.DebittAmount(amount);
            return $"{amount} transferred";
        }
    }
}
