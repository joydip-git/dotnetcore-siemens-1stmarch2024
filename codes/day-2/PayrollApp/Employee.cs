namespace PayrollApp
{
    public class Employee
    {
        private readonly int _id;
        public int Id { get => _id; }

        public string Name { get; set; } = string.Empty;
        public decimal BasicPay { get; set; }
        public decimal DaPay { get; set; }
        public decimal HraPay { get; set; }
        //public static decimal YearEndPay { get; private set; } = 3000;
        public static decimal YearEndPay { get; }

        static Employee()
        {
            YearEndPay = 3000;
        }

        public Employee()
        {
            
        }

        public Employee(int id, string name, decimal basicPay, decimal daPay, decimal hraPay)
        {
            _id = id;
            Name = name;
            BasicPay = basicPay;
            DaPay = daPay;
            HraPay = hraPay;
        }

        public virtual decimal CalculateSalary()
        {
            return this.BasicPay+this.DaPay+this.HraPay;
        }
    }
}
