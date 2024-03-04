namespace PayrollApp
{
    public class Developer : Employee
    {
        public decimal IncentivePay { get; set; }

        public Developer()
        {

        }

        public Developer(int id, string name, decimal basicPay, decimal daPay, decimal hraPay, decimal incentivePay) 
            : base(id, name, basicPay, daPay, hraPay)
        {
            IncentivePay = incentivePay;
        }

        public override decimal CalculateSalary()
        {
            return base.CalculateSalary() + this.IncentivePay;
        }
    }
}
