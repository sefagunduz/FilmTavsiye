using BLL.Abstract;
using CORE;
using DAL.Abrtract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
    public class MovieManager : IMovieManager
    {
        private readonly IMovieDAL movieDAL;
        public MovieManager(IRepository<Movie> repository)
        {
            this.movieDAL = (IMovieDAL)repository;
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
