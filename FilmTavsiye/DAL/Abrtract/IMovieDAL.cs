using CORE;

namespace DAL.Abrtract
{
    public interface IMovieDAL : IRepository<Movie>
    {
        IEnumerable<int> GetAllIds();
        Movie GetDetail(int id);
        bool AddNote(MovieNote movieNote);
        Movie Get(int id);
    }
}
