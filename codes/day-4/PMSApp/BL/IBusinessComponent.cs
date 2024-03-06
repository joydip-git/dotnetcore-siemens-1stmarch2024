namespace PMSApp.BL
{
    public interface IBusinessComponent<T>
    {
        IEnumerable<T> FetchAll();
        T Fetch(int id);
        bool Insert(T entity);
        bool Modify(int id, T entity);
        bool Remove(int id);
    }
}
