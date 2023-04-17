using BLL.Abstract;
using BLL.Concrete;
using DAL;
using DAL.Concrete;
using Microsoft.EntityFrameworkCore;

namespace TEST
{
    public class Tests
    {
        private IApiManager apiManager;

        [SetUp]
        public void Setup()
        {
            string connString = "Host=localhost; Database=movies; Username=postgres; Password=root";

            var contextOptions = new DbContextOptionsBuilder<DataContext>()
                .UseNpgsql(connString)
                .Options;

            DataContext dataContext = new DataContext(contextOptions);

            // constructor for dependency injection
            string apikey = "7b4d37c0a543c015a64cd469a09ba23e";
            apiManager = new ApiManager(new ApiService(apikey), new MovieDAL(dataContext));
        }

        [Test]
        public async Task SaveDatabaseAsync()
        {
            bool reply = await apiManager.SaveDatabaseAsync();
        }
    }
}