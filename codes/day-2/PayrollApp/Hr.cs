namespace PayrollApp
{
    public class Hr : Employee
    {
        public decimal GratuityPay { get; set; }

        public Hr()
        {

        }

        public Hr(int id, string name, decimal basicPay, decimal daPay, decimal hraPay, decimal gratuityPay) : base(id, name, basicPay, daPay, hraPay)
        {
            GratuityPay = gratuityPay;
        }

        public override decimal CalculateSalary()
        {
            return base.CalculateSalary()+this.GratuityPay;
        }
    }
}
