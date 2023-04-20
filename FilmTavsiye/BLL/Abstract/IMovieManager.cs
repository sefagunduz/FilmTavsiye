using CORE;

namespace BLL.Abstract
{
    public interface IMovieManager
    {
        CustomResult<Movie> GetAll(int page, int count);
        Movie GetDetail(int id);
        bool AddNote(MovieNote movieNote);
    }
}
