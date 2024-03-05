namespace LINQDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1. Func 2. Action 3. Predicate
            List<int> list = new List<int>()
            {
                3,1,4,2,6,7,5,8,0,9
            };
            /*
            Func<int, bool> evenFilter = (num) => num % 2 == 0;
            var evenNumbers = list.Where(evenFilter);  

            Action<int> printDel = (num)=>Console.WriteLine(num);
            evenNumbers.ToList<int>().ForEach(printDel);
            */

            //Language Integrated Query (LINQ)
            list
                .Where(num => num % 2 == 0)
                .OrderByDescending(num => num)
                .ToList()
                .ForEach(num => { Console.WriteLine(num); });

            List<string> people = new List<string>()
            {
                "arun","sunil","anil","mahesh"
            };

            //LINQ: Method query syntax (immediate execution)
            var result = people
                .OrderBy(name => name)
                .Where(name => name[0].Equals('a'))
                .ToList<string>();

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            //LINQ: Query Operator Syntax (delayed execution)
            var query = (from name in people
                        orderby name
                        where name[0].Equals ('a')
                        select name).ToList<string>();

            foreach (var item in query)
            {
                Console.WriteLine(item);
            }

        }
    }
}
