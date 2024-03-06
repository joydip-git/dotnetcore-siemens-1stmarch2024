namespace PMSApp.DAL
{
    public interface IDataAccess<TInput,TOutput>
    {
        bool Add(TInput data);
        bool Delete(int id);
        bool Update(int id, TInput data);
        IEnumerable<TOutput> GetAll();
        TOutput Get(int id);
    }
}
