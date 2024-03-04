namespace GCDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Write();
            Console.WriteLine("program's last line..");
            Console.WriteLine("Main Thread Id:  " + System.Threading.Thread.CurrentThread.ManagedThreadId);
            //WeakReference<Product> weakReference = new WeakReference<Product>(product);
            //product = null;
            //Console.WriteLine(GC.GetGeneration(product));
            //GC.Collect();
            //Console.WriteLine(GC.GetGeneration(product));
            //GC.Collect();
            //Console.WriteLine(GC.GetGeneration(product));
            //GC.Collect();
            //Console.WriteLine(GC.GetGeneration(product));
        }

        private static void Write()
        {
            using (Product? product = new Product() { Id = 1, Name = "jashjq" })
            {
                int x = 10;
                Console.WriteLine(x);
                Console.WriteLine(product);
                //to suppress the finalizer
                GC.SuppressFinalize(product);
                product?.WriteToFile();
                //product?.Dispose();
                Console.WriteLine("end of work");
            }
        }
    }
}
