namespace ProductManagentSystem.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public Category? Category { get; set; }

        public Product()
        {
            
        }
        public Product(int id, string name, string description, decimal price, Category? category = null)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Price = price;
            Category = category;
        }
    }
}
