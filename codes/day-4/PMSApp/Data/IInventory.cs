using PMSApp.Entities;

namespace PMSApp.Data
{
    public interface IInventory
    {
        ICollection<ProductDto> Products { get; }
        ICollection<CategoryDto> Categories { get; }
    }
}