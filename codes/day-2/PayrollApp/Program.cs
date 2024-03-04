namespace PayrollApp
{
    internal class Program
    {
        static void Main()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Developer(1,"anil",1000,2000,3000,4000));
            employees.Add(new Hr(2, "sunil", 2000, 3000, 4000, 5000));
            foreach (Employee employee in employees)
            {
                Console.WriteLine($"Salary of {employee.Name} is {employee.CalculateSalary()}");
            }
        }
    }
}
