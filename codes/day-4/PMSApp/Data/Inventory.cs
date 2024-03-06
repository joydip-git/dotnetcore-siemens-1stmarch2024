using PMSApp.Entities;

namespace PMSApp.Data
{
    public class Inventory : IInventory
    {
        private static readonly HashSet<Product> products;
        private static readonly HashSet<Category> categories;

        static Inventory()
        {

            var laptop = new Category(1, "Laptop");
            var mobile = new Category(2, "Mobile");
            categories = new HashSet<Category>()
            {
                laptop, mobile
            };
            
            products = new HashSet<Product>();
            products.Add(new Product(1, "Dell XPS", 120000, "new 15 inch laptop from dell", laptop));
            products.Add(new Product(2, "HP Envy", 140000, "new 13 inch laptop from hp", laptop));

            //products[0].Category = categories[0];
            //products[1].Category = categories[0];
        }

        public ICollection<Product> Products { get => products; }
        public ICollection<Category> Categories { get => categories; }
    }
}
