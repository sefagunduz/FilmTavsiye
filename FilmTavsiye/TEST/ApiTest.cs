using BLL.Abstract;
using BLL.Concrete;
using DAL;
using DAL.Concrete;
using Microsoft.EntityFrameworkCore;

namespace TEST
{
    public class ApiTest
    {
        private IApiManager apiManager;

        [SetUp]
        public void Setup()
        {
            string connString = "Host=localhost; Database=FilmTavsiye; Username=postgres; Password=***";

            var contextOptions = new DbContextOptionsBuilder<DataContext>()
                .UseNpgsql(connString)
                .Options;

            DataContext dataContext = new DataContext(contextOptions);

            string apikey = "***";

            // constructor for dependency injection
            apiManager = new ApiManager(new ApiService(apikey), new MovieDAL(dataContext));
        }

        [Test]
        public async Task SaveDatabaseAsync()
        {
            bool reply = await apiManager.SaveDatabaseAsync();
        }
    }
}