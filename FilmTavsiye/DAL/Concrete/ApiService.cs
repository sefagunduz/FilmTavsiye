using CORE;
using DAL.Abrtract;
using System.Text.Json;

namespace DAL.Concrete
{
    public class ApiService : IApiService
    {
        private readonly string ApiKey;

        public ApiService(string Apikey)
        {
            this.ApiKey = Apikey;
        }
        public async Task<ApiResult> GetNowPlayingAsync(int page)
        {
            ApiResult apiResult = new ApiResult();
            try
            {
                string nowPlayingUrl = string.Format("https://api.themoviedb.org/3/movie/now_playing?api_key={0}&language=tr&region=TR&page={1}", ApiKey, page);
                
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage res = await client.GetAsync(nowPlayingUrl))
                    {
                        using (HttpContent content = res.Content)
                        {
                            var data = await content.ReadAsStringAsync();

                            if (!string.IsNullOrEmpty(data))
                            {
                                apiResult = JsonSerializer.Deserialize<ApiResult>(data);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return apiResult;
        }
    }
}
