namespace PMSApp.Entities
{
    public class ProductDto
    {
        private readonly int _id;

        public int Id { get => _id; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public int? CategoryId { get; set; }
        public CategoryDto? Category { get; set; }

        public ProductDto()
        {

        }

        public ProductDto(int id, string name, decimal price, string description, int? categoryId = null, CategoryDto? category = null)
        {
            _id = id;
            Name = name;
            Price = price;
            Description = description;
            Category = category;
            CategoryId = categoryId;
        }

        public override bool Equals(object? obj)
        {
            if (obj != null)
            {
                if (obj is ProductDto)
                {
                    ProductDto other = obj as ProductDto;

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
