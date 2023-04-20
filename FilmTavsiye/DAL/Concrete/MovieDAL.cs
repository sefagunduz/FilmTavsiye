using CORE;
using DAL.Abrtract;
using Microsoft.EntityFrameworkCore;

namespace DAL.Concrete
{
    public class MovieDAL : Repository<Movie>, IMovieDAL
    {
        public MovieDAL(DataContext dataContext) : base(dataContext)
        {
        }

        public bool AddNote(MovieNote movieNote)
        {
            base.dataContext.MovieNotes.Add(movieNote);
            base.dataContext.SaveChanges();
            return true;
        }

        public override bool AddRange(IEnumerable<Movie> movies)
        {
            return base.AddRange(movies);
        }

        public Movie Get(int id)
        {
            Movie movie = base.dataContext.Movies.AsNoTracking().Where(x => x.Id == id).FirstOrDefault() ?? new Movie();
            return movie;
        }

        public override CustomResult<Movie> GetAll(int page = 1, int count = 10)
        {
            return base.GetAll(page, count);
        }

        public IEnumerable<int> GetAllIds()
        {
            List<int> ids = new List<int>();
            ids = base.dataContext.Movies.Select(x => x.TmdbId).ToList();
            return ids;
        }

        public Movie GetDetail(int id)
        {
            Movie movie = new Movie();
            movie = base.dataContext.Movies.Include(movie => movie.MovieNotes).Where(x => x.Id == id).AsNoTracking().FirstOrDefault();
            return movie;
        }
    }
}
