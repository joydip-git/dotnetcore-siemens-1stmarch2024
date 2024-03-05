namespace DIDemo
{
    public class BankingOperations : IBankingOperations
    {
        public BankingOperations()
        {
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
