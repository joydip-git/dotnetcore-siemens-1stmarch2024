namespace DIDemo
{
    public class BankingOperations : IBankingOperations
    {
        public BankingOperations()
        {
            Console.WriteLine($"object of {this.GetType().Name} created");
        }
        public string CreditAmount(double amount)
        {
            return $"{amount} credited";
        }
        public string DebittAmount(double amount)
        {
            return $"{amount} debited";
        }
    }
}
