namespace EFCorePractice.DAO
{
    public interface ICustomerDao<TCreate,TRead> where TCreate : class where TRead : class
    {
        bool Add(TCreate customer);
        bool Delete(int id);
        TRead Get(int id);
        IEnumerable<TRead> GetAll();
        bool Update(int id, TCreate customer);
    }
}