using PMSApp.Entities;

namespace PMSApp.Data
{
    public interface IInventory
    {
        ICollection<Product> Products { get; }
        ICollection<Category> Categories { get; }
    }
}