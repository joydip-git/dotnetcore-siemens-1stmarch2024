using PMSApp.Entities;

namespace PMSApp.Data
{
    public class Inventory
    {
        private static readonly List<Product> products;        

        static Inventory()
        {
            products = new List<Product>();
            products.Add(new Product(1, "Dell XPS", 120000, "new 15 inch laptop from dell"));
            products.Add(new Product(2, "HP Envy", 140000, "new 13 inch laptop from hp"));
        }
        public ICollection<Product> Products { get => products; }
    }
}
