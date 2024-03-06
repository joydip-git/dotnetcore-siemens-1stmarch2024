namespace PMSApp.BL
{
    public interface IBusinessComponent<TInput,TOutput>
    {
        IEnumerable<TOutput> FetchAll();
        TOutput Fetch(int id);
        bool Insert(TInput entity);
        bool Modify(int id, TInput entity);
        bool Remove(int id);
    }
}
