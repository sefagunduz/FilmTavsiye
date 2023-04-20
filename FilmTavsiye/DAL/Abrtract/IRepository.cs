using CORE;

namespace DAL.Abrtract
{
    public interface IRepository<T> where T : class, new()
    {
        bool AddRange(IEnumerable<T> t);
        CustomResult<T> GetAll(int page, int count);
    }
}
