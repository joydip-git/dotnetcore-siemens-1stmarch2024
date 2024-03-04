namespace PMSApp.Entities
{
    public class Product
    {
        private readonly int _id;

        public int Id { get => _id; }
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public string Description { get; set; } = string.Empty;

        public Product()
        {
            
        }

        public Product(int id, string name, double price, string description)
        {
            _id = id;
            Name = name;
            Price = price;
            Description = description;
        }
        //public override bool Equals(object? obj)
        //{
        //    return base.Equals(obj);
        //}
    }
}
