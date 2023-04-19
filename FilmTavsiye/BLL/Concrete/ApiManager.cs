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
                    movie.TmdbId = x.id;
                    movie.Title = x.title;
                    movie.ReleaseDate = x.release_date;
                    movie.PosterPath = x.poster_path;
                    movie.BackdropPath = x.backdrop_path;
                    movie.Popularity = x.popularity;
                    movie.Adult = x.adult;
                    movie.GenreIds = x.genre_ids;
                    movie.OriginalLanguage = x.original_language;
                    movie.OriginalTitle = x.original_title;
                    movie.Video = x.video;
                    movie.VoteAverage = x.vote_average;
                    movie.VoteCount = x.vote_count;
                    movie.Overview = x.overview;

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
