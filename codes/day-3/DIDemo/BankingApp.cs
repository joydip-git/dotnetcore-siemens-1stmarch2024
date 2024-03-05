namespace DIDemo
{
    public class BankingApp : IBankingApp
    {
        private readonly IBankingOperations _bankingOperations;

        public BankingApp(IBankingOperations bankingOperations)
        {
            _bankingOperations = bankingOperations;
            Console.WriteLine($"object of {this.GetType().Name} created");
        }

        public string TransferAmount(double amount)
        {
            _bankingOperations.CreditAmount(amount);
            _bankingOperations.DebittAmount(amount);
            return $"{amount} transferred";
        }
    }
}
