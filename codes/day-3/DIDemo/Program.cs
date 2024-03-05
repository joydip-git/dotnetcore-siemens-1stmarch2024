namespace DIDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Factory factory = Factory.CreateInstance();
            IBankingOperations operations = factory.Create<IBankingOperations,BankingOperations>();
            if(operations != null )
            {
                BankingApp bankingApp = new BankingApp(operations);
                Console.WriteLine(bankingApp.TransferAmount(1000));
            }           
        }
    }
}
