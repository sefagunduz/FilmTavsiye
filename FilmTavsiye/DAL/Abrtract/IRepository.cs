using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abrtract
{
    public interface IRepository<T> where T : class
    {
        bool AddRange(IEnumerable<T> t);
        IEnumerable<T> GetAll();
    }
}
