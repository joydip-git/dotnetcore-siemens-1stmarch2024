using PMSApp.Entities;

namespace PMSApp.BL
{
    public interface IProductBusinessComponent : IBusinessComponent<Product>
    {
        IEnumerable<Product> FilterByName(string productName);
        IEnumerable<Product> FetchAll(int choice);
    }
}
