using CORE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abrtract
{
    public interface IApiService
    {
        Task<ApiResult> GetNowPlayingAsync(int page);
    }
}
