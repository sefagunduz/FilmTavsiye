using DAL.Abrtract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        protected readonly DataContext dataContext;
        public Repository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public virtual bool AddRange(IEnumerable<T> t)
        {
            dataContext.Set<T>().AddRange(t);
            dataContext.SaveChanges();
            return true;
        }

        public virtual IEnumerable<T> GetAll()
        {
            List<T> list = dataContext.Set<T>().ToList();
            return list;
        }
    }
}
