using PMSApp.Entities;

namespace PMSApp.BL
{
    public interface IProductBusinessComponent : IBusinessComponent<ProductDto>
    {
        IEnumerable<ProductDto> FilterByName(string productName);
        IEnumerable<ProductDto> FetchAll(int choice);
    }
}
