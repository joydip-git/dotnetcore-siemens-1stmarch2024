namespace PMSApp.Entities
{
    public class ProductReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public int? CategoryId { get; set; }
        public CategoryReadDto? Category { get; set; }

        public ProductReadDto()
        {

        }

        public ProductReadDto(int id, string name, decimal price, string description, int? categoryId = null, CategoryReadDto? category = null)
        {
            Id = id;
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
                if (obj is ProductReadDto)
                {
                    ProductReadDto other = (ProductReadDto)obj;

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

                    if (!this.CategoryId.Equals(other.CategoryId)) 
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

        public override int GetHashCode()
        {
            const int prime = 31;
            return this.Id.GetHashCode() * prime;
        }
    }
}
