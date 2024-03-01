namespace DelegateApp
{
    //1. delegate declaration should match the signature of the method you intend to store the reference of and call
    //a. return type of the method
    //b. number of arguments of the method
    //b. data type of arguments of the method
    //c. position of arguments of the method
    //note: name of method, name of parameters/arguments and whether the method is static ro not => does not matter
    //non-generic delegate
    //delegate void CalDel(int x, int y);

    //generic delegate
    delegate TResult CalDel<in T, out TResult>(T x, T y);// where T : struct;

    class Calculation
    {
        public int Add(int a, int b)
        {
            return (a + b);
        }
        public static int Subtract(int a, int b)
        {
            return (a - b);
        }
        public string Add(string a, string b)
        {
            return (a + " " + b);
        }
    }
    internal class Program
    {
        static void CallMethods<T1, T2>(CalDel<T1, T2> cd, T1 a, T1 b) //where T : struct
        {
            //3. call the method(s) using the delegate
            T2 result = cd.Invoke(a, b);
            Console.WriteLine(result);
        }
        static void Main(string[] args)
        {
            //2. store the reference of the method(s)
            Calculation calculation = new Calculation();

            //CalDel del = new CalDel(Calculation.Subtract);
            //CalDel<int, int> del = new CalDel<int, int>(Calculation.Subtract);
            //del += calculation.Add;
            //CallMethods<int, int>(del, 12, 3);

            CalDel<string, string> nameDel = new CalDel<string, string>(calculation.Add);
            CallMethods<string, string>(nameDel, "anil", "mishra");
            CalDel<int,int> addDel = new CalDel<int,int>(calculation.Add);
            CalDel<int, int> subDel = new CalDel<int, int>  (Calculation.Subtract);

            //addDel.Invoke(12, 13);
            //subDel.Invoke(12, 3);

            CallMethods(addDel, 12, 13);
            CallMethods(subDel, 12, 3);

        }
    }
}
