using CORE;
using DAL.Abrtract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    public class MovieDAL : Repository<Movie>, IMovieDAL
    {
        public MovieDAL(DataContext dataContext) : base(dataContext)
        {
        }

        public override bool AddRange(IEnumerable<Movie> movies)
        {
            return base.AddRange(movies);
        }

        public override IEnumerable<Movie> GetAll()
        {
            return base.GetAll();
        }

        public IEnumerable<int> GetAllIds()
        {
            List<int> ids = new List<int>();
            ids = base.dataContext.Movies.Select(x => x.tmdb_id).ToList();
            return ids;
        }
    }
}
