namespace DataApp
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public Employee()
        {

        }

        public Employee(string name, decimal salary, int id = 0)
        {
            Id = id;
            Name = name;
            Salary = salary;
        }
        public override string ToString()
        {
            return $"{this.Id}, {this.Name}, {this.Salary}";
        }
        public override int GetHashCode()
        {
            const int prime = 31;
            return this.Id.GetHashCode() * prime;
        }
        public override bool Equals(object? obj)
        {
            if (obj == null)
                throw new NullReferenceException("null");

            if (!(obj is Employee))
                throw new ArgumentException("not an employee");

            Employee objEmployee = (Employee)obj;
            if(!this.Id.Equals(objEmployee.Id))
                return false;

            return true;
        }
    }
}
