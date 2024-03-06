using PMSApp.Entities;

namespace PMSApp.BL
{
    public interface IProductBusinessComponent : IBusinessComponent<ProductCreateDto,ProductReadDto>
    {
        IEnumerable<ProductReadDto> FilterByName(string productName);
        IEnumerable<ProductReadDto> FetchAll(int choice);
    }
}
