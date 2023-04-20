using CORE;

namespace DAL.Abrtract
{
    public interface IApiService
    {
        Task<ApiResult> GetNowPlayingAsync(int page);
    }
}
