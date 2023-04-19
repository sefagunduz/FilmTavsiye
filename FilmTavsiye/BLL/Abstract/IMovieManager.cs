using CORE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
    public interface IMovieManager
    {
        CustomResult<Movie> GetAll(int page, int count);
        Movie GetDetail(int id);
    }
}
