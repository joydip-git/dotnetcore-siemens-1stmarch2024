using PMSApp.Entities;

namespace PMSApp.Data
{
    public class Inventory : IInventory
    {
        private static readonly List<Product> products;
        private static readonly List<Category> categories;

        static Inventory()
        {
            products = new List<Product>();
            products.Add(new Product(1, "Dell XPS", 120000, "new 15 inch laptop from dell"));
            products.Add(new Product(2, "HP Envy", 140000, "new 13 inch laptop from hp"));

            categories = new List<Category>()
            {
                new Category(1,"Laptop"),
                new Category(2,"Mobile")
            };
        }

        public ICollection<Product> Products { get => products; }
        public ICollection<Category> Categories { get => categories; }
    }
}
