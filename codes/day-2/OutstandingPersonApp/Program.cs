namespace OutstandingPersonApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> list = new List<Person>
            {
                new Author("anil",4),
                new Trainee("sunil",89),
                new Author("mahesh",10),
                new Trainee("suresh",67)
            };
            foreach (var person in list)
            {
                if (person != null)
                {
                    if (person.IsOutstanding())
                        Console.WriteLine(
                            person.Name
                            + " is outstanding  "
                            + person.GetType().Name
                            );
                }
            }
        }
    }
}
