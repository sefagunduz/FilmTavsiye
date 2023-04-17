using BLL.Abstract;
using CORE;
using DAL.Abrtract;
using DAL.Concrete;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
    public class ApiManager : IApiManager
    {
        private readonly IApiService apiService;
        private readonly IMovieDAL movieDAL;
        public ApiManager(IApiService apiService, IMovieDAL movieDAL)
        {
            this.apiService = apiService;
            this.movieDAL = movieDAL;
        }

        public async Task<bool> SaveDatabaseAsync()
        {
            try
            {
                List<ApiResult_Result> apiResult_s = new List<ApiResult_Result>();
                ApiResult apiResult = await apiService.GetNowPlayingAsync(1);
                IEnumerable<int> ids = movieDAL.GetAllIds();

                apiResult_s.AddRange(apiResult.results);

                if(apiResult.total_pages > 1)
                {
                    for(int i = 2; i <= apiResult.total_pages; i++) {
                        ApiResult apiResult2 = await apiService.GetNowPlayingAsync(i);
                        apiResult_s.AddRange(apiResult2.results);
                    }
                }

                // convert to movie entity
                List<Movie> movieList = new List<Movie>();

                List<ApiResult_Result> _Results = apiResult_s.Where(x => !ids.Contains(x.id)).ToList();

                apiResult_s.Where(x => !ids.Contains(x.id)).ToList().ForEach(x =>
                {
                    Movie movie = new Movie();
                    movie.tmdb_id = x.id;
                    movie.title = x.title;
                    movie.release_date = x.release_date;
                    movie.poster_path = x.poster_path;
                    movie.backdrop_path = x.backdrop_path;
                    movie.popularity = x.popularity;
                    movie.adult = x.adult;
                    movie.genre_ids = x.genre_ids;
                    movie.original_language = x.original_language;
                    movie.original_title = x.original_title;
                    movie.video = x.video;
                    movie.vote_average = x.vote_average;
                    movie.vote_count = x.vote_count;
                    movie.overview = x.overview;

                    movieList.Add(movie);
                });

                bool reply = false;
                if (movieList != null && movieList.Any())
                     reply = movieDAL.AddRange(movieList);

                return reply;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
