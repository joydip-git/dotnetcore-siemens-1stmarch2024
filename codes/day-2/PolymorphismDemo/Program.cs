using System.Threading.Channels;

namespace PolymorphismDemo
{
    internal class Program
    {
        static void Add(int a, int b) { }
        static void Add(int a, int b, int c) { }
        static void Add(int a, int b, long c) { }
        static void Add(int a, long b, int c) { }
        static void Main(string[] args)
        {
            Add(12, 13);
            Add(12, 13, 14);
            //up-casting

            B objB = new B();
            C objC = new C();

            Call(objB);
            Call(objC);
        }
        static void Call(A obj)
        {
            obj.Foo();
        }
        //static void Call(C objC)
        //{
        //    objC.Foo();
        //}
        //static void Call(B objB)
        //{
        //    objB.Foo();
        //}
    }
    class A
    {
        public virtual void Foo()
        {
            Console.WriteLine("A Foo");
        }
    }
    class B : A
    {
        public override void Foo()
        {
            Console.WriteLine("B Foo");
        }
    }
    class C : A
    {
        public override void Foo()
        {
            Console.WriteLine("C Foo");
        }
    }
}
