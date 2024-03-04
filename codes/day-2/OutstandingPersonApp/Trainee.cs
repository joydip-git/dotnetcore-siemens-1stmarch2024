namespace OutstandingPersonApp
{
    public class Trainee : Person
    {
        public double Marks { get; set; }
        public Trainee()
        {
            
        }
        public Trainee(string name, double marks):base(name)
        {
            Marks = marks;
        }
        public override bool IsOutstanding()
        {
            return this.Marks > 85;
        }
    }
}
