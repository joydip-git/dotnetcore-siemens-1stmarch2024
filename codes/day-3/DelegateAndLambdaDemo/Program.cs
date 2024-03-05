using System.Reflection;

namespace DelegateAndLambdaDemo
{
    //declare a delegate which can the following type of method(s):
    //method(s) retun boolean and accepts an argument of type int
    //delegate bool Criteria(int value);
    //delegate bool Criteria<in TInput>(TInput value);

    //declare a delegate which can the following type of method(s):
    //method(s) retun int and accepts two arguments of type int and int
    //delegate int CalDel(int a, int b);
    delegate TResult CalDel<in TInput1,in TInput2, out TResult>(TInput1 a, TInput2 b);

    /*
    class Criteria: MulticastDelegate //:Delegate:Object
    {
        private MethodInfo _methodInfo;
        private Object _target;
        //private Delegate[] _invocationList;

        public Criteria(MethodInfo methodInfo, Object target)
        {
            _methodInfo = methodInfo;
            _target = target;
        }
        public bool Invoke(int value)
        {
            _methodInfo.Invoke(_target, new object[] { value });
        }
    }
    */
    internal class Program
    {
        //static List<int> Filter(List<int> list, Criteria<int> criteria)
        /*
        static List<T> Filter<T>(List<T> list, Criteria<T> criteria)
        {
            //create a list with even numbers, by filtering the inpu list, and return the same
            List<T> result = new List<T>();
            foreach (T item in list)
            {
                //criteria.Invoke(item);
                var status = criteria(item);
                if (status)
                    result.Add(item);
            }
            return result;
        }
        */
        static List<T> Filter<T>(List<T> list, Predicate<T> criteria)
        {
            //create a list with even numbers, by filtering the inpu list, and return the same
            List<T> result = new List<T>();
            foreach (T item in list)
            {
                //criteria.Invoke(item);
                var status = criteria(item);
                if (status)
                    result.Add(item);
            }
            return result;
        }
        static void Main()
        {
            //CalDel<int,int> addDel = (a, b) => a + b;
            Func<int, int,int> addDel = (a, b) => a + b;
            Console.WriteLine(addDel(12, 13));

            List<int> list = new List<int>()
            {
                3,1,4,2,6,7,5,8,0,9
            };

            //Criteria<int> evenDel = new Criteria<int>(Logic.IsEven);
            Predicate<int> evenDel = new Predicate<int>(Logic.IsEven);
            var evenNumbers = Filter(list, evenDel);
            foreach (int item in evenNumbers)
            {
                Console.WriteLine(item);
            }
            /*
            Console.WriteLine("\n\n");
            Criteria<int> oddDel = new Criteria<int>(new Logic().IsOdd);
            var oddNumbers = Filter(list, oddDel);
            foreach (int item in oddNumbers)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\n\n");
            //Criteria greaterThanFourDel = public bool IsGreaterThanFour(int num)
            //{
            //    return num > 4;
            //};

            //anonymous method and delegate
            Criteria<int> greaterThanFourDel = delegate(int num)
            {
                return num > 4;
            };
            var greaterNumbers = Filter(list, greaterThanFourDel);
            foreach (int item in greaterNumbers)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\n\n");
            //Lambda expression being used to write an anonymous method
            //Lambda expression: (arg1,arg2,...)=>expression body
            //
            //Criteria lessThanFourDel = (int num) => num < 4;

            //Lambda expression being used to write an anonymous method (with type inference)
            Criteria<int> lessThanFourDel = (num) => num < 4;
            var lesserNumbers = Filter(list, lessThanFourDel);
            foreach (int item in lesserNumbers)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\n\n");
            var greaterThanSixNumbers = Filter(list, (num) => num > 6);
            foreach (int item in greaterThanSixNumbers)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\n\n");
            List<string> people = new List<string>()
            {
                "arun","sunil","anil","mahesh"
            };
            Criteria<string> nameFilterDel = delegate (string name)
            {
                return name[0].Equals('a');
            };
            var filteredNames = Filter(people, nameFilterDel);
            foreach (var name in filteredNames)
            {
                Console.WriteLine(name);
            }
            */
        }
    }
}
