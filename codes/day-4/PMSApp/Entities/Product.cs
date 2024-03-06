namespace PMSApp.Entities
{
    public class Product
    {
        private readonly int _id;

        public int Id { get => _id; }
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public Category? Category { get; set; }

        public Product()
        {

        }

        public Product(int id, string name, double price, string description, Category? category = null)
        {
            _id = id;
            Name = name;
            Price = price;
            Description = description;
            Category = category;
        }

        public override bool Equals(object? obj)
        {            
            if (obj != null)
            {
                if (obj is Product)
                {
                    Product other = obj as Product;

                    //if(ReferenceEquals(this, obj)) return true;
                    if (this == other)
                        return true;

                    if (!this.Id.Equals(other.Id))
                        return false;

                    if (!this.Name.Equals(other.Name))
                        return false;

                    if (!this.Price.Equals(other.Price))
                        return false;

                    if (!this.Description.Equals(other.Description))
                        return false;

                    if (!this.Category.Equals(other.Category))
                        return false;

                    return true;
                }
                else
                    throw new ArgumentException("obj must be of type Product");
            }
            else
                throw new NullReferenceException("obj is null");
        }
    }
}
