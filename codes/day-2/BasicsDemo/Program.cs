namespace BasicsDemo
{
    internal class Program
    {
        //static void Main(string[] args){}
        //static int Main(string[] args){ return 0;}
        //static int Main(){ return 0;}
        static void Main()
        {
            Product? product = new Product() { Id = 1, Name = "jashjq" };
            product = null;
            Console.WriteLine(GC.GetGeneration(product));
            GC.Collect();
            Console.WriteLine(GC.GetGeneration(product));
            GC.Collect();
            Console.WriteLine(GC.GetGeneration(product));
            GC.Collect();
            Console.WriteLine(GC.GetGeneration(product));


            int x = 10;
            Console.WriteLine(x);

        }
    }
}
