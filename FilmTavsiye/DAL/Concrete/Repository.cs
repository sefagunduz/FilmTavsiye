using CORE;
using DAL.Abrtract;
using Microsoft.EntityFrameworkCore;

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

        public virtual CustomResult<T> GetAll(int page = 1, int count = 10)
        {
            CustomResult<T> result = new CustomResult<T>();
            int totalcount = dataContext.Set<T>().AsNoTracking().Count();
            int skip = (page - 1) * count;
            IQueryable<T> list = dataContext.Set<T>().AsNoTracking().Skip(skip).Take(count).ToList().AsQueryable();

            result.list = list;
            result.count = count;
            result.resultCount = list.Count();
            result.page = page;
            result.totalCount = totalcount;
            result.totalPage = totalcount % count > 0 ? (totalcount % count + 1) : (totalcount % count);
            return result;
        }
    }
}
