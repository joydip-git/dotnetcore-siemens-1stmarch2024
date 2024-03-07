namespace EFCorePractice.Repository
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal OrderAmount { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
