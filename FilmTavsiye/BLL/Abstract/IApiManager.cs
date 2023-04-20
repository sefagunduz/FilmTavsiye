namespace BLL.Abstract
{
    public interface IApiManager
    {
        Task<bool> SaveDatabaseAsync();
    }
}
