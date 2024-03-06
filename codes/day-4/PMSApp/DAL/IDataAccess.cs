namespace PMSApp.DAL
{
    public interface IDataAccess<T>
    {
        bool Add(T data);
        bool Delete(int id);
        bool Update(int id, T data);
        IEnumerable<T> GetAll();
        T Get(int id);
    }
}
