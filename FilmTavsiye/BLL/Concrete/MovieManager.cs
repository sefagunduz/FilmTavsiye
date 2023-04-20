using BLL.Abstract;
using CORE;
using DAL.Abrtract;

namespace BLL.Concrete
{
    public class MovieManager : IMovieManager
    {
        private readonly IMovieDAL movieDAL;
        public MovieManager(IRepository<Movie> repository)
        {
            this.movieDAL = (IMovieDAL)repository;
        }

        public bool AddNote(MovieNote movieNote)
        {
            if (movieNote != null && movieNote.Score >= 1 && movieNote.Score <= 10)
            {
                movieNote.Id = 0;
                return movieDAL.AddNote(movieNote);
            }
            return false;
        }

        public CustomResult<Movie> GetAll(int page = 1, int count = 10)
        {
            return movieDAL.GetAll(page,count);
        }

        public Movie GetDetail(int id)
        {
            return movieDAL.GetDetail(id);
        }
    }
}
