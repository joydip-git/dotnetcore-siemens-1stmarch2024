using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMSApp.Entities
{
    public class ProductCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public int? CategoryId { get; set; }

        public ProductCreateDto()
        {

        }

        public ProductCreateDto(string name, decimal price, string description, int? categoryId = null)
        {
            Name = name;
            Price = price;
            Description = description;
            CategoryId = categoryId;
        }

        public override bool Equals(object? obj)
        {
            if (obj != null)
            {
                if (obj is ProductReadDto)
                {
                    ProductCreateDto other = (ProductCreateDto)obj;

                    //if(ReferenceEquals(this, obj)) return true;
                    if (this == other)
                        return true;

                   if (!this.Name.Equals(other.Name))
                        return false;

                    if (!this.Price.Equals(other.Price))
                        return false;

                    if (!this.Description.Equals(other.Description))
                        return false;

                    if (!this.CategoryId.Equals(other.CategoryId))
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
            return this.GetHashCode() * prime;
        }
    }
}
