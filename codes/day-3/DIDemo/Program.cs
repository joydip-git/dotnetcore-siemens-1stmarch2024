using Microsoft.Extensions.DependencyInjection;

namespace DIDemo
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            //Factory factory = Factory.CreateInstance();
            //IBankingOperations operations = factory.Create<IBankingOperations, BankingOperations>();

            var collectionOfServices = new ServiceCollection();

            var providerOfOperations = collectionOfServices
                .AddSingleton<IBankingOperations, BankingOperations>()
                .BuildServiceProvider();

            var providerOfApp = collectionOfServices
                //.AddSingleton<IBankingOperations,BankingOperations>()
                .AddSingleton<IBankingApp, BankingApp>()
                .BuildServiceProvider();

            //var operations = providerOfOperations.GetRequiredService<IBankingOperations>();

            //var operations = providerOfApp.GetRequiredService<IBankingOperations>();
            var app = providerOfApp.GetRequiredService<IBankingApp>();

            //BankingApp app = new BankingApp(operations);
            if (app != null )
            {               
                Console.WriteLine(app.TransferAmount(1000));
            }           
        }
    }
}
