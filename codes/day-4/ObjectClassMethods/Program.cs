namespace ObjectClassMethods
{
    internal class Program
    {        
        static void Main(string[] args)
        {
            //int x = 10;
            //int y = 20;
            //if(x.Equals(y))
            //{
            //    Console.WriteLine("same");
            //}

            Person anilPerson = new Person(1, "anil");
            Person sunilPerson = new Person(1, "anil");

            if (anilPerson.Equals(sunilPerson))
            {
                Console.WriteLine("same");
            }else
                Console.WriteLine("not same");

            HashSet<int> numbers = new HashSet<int>();
            numbers.Add(1); //hash value is calculated using GetHashCode() method
            numbers.Add(2); //hash value is calculated using GetHashCode() method and compared with previous hash values. If the values are not same, the item is added. If the hash values are same, the Equals() method is used to check whether really bot the elements are same or not
            numbers.Add(1);

            foreach (var num in numbers)
            {
                Console.WriteLine(num);
            }

            HashSet<Person> list = new HashSet<Person>();
            list.Add(anilPerson);
            list.Add(sunilPerson);
            foreach (var person in list)
            {
                Console.WriteLine(person);
            }
        }
    }
}
