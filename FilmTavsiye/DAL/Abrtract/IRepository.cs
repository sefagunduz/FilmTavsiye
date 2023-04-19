using CORE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abrtract
{
    public interface IRepository<T> where T : class, new()
    {
        bool AddRange(IEnumerable<T> t);
        CustomResult<T> GetAll(int page, int count);
    }
}
