using PMSApp.Entities;

namespace PMSApp.Data
{
    public class Inventory : IInventory
    {
        private static readonly HashSet<ProductDto> products;
        private static readonly HashSet<CategoryDto> categories;

        static Inventory()
        {

            var laptop = new CategoryDto(1, "Laptop");
            var mobile = new CategoryDto(2, "Mobile");
            categories = new HashSet<CategoryDto>()
            {
                laptop, mobile
            };
            
            products = new HashSet<ProductDto>();
            products.Add(new ProductDto(1, "Dell XPS", 120000, "new 15 inch laptop from dell",1, laptop));
            products.Add(new ProductDto(2, "HP Envy", 140000, "new 13 inch laptop from hp",1, laptop));

            //products[0].Category = categories[0];
            //products[1].Category = categories[0];
        }

        public ICollection<ProductDto> Products { get => products; }
        public ICollection<CategoryDto> Categories { get => categories; }
    }
}
