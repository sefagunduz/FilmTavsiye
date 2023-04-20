using BLL.Abstract;
using BLL.Concrete;
using CORE;
using DAL;
using DAL.Concrete;
using Microsoft.EntityFrameworkCore;

namespace TEST
{
    public class MovieTest
    {
        private IMovieManager movieManager;
        private IMailManager mailManager;

        [SetUp]
        public void Setup()
        {
            string connString = "Host=localhost; Database=FilmTavsiye; Username=postgres; Password=***";

            var contextOptions = new DbContextOptionsBuilder<DataContext>()
                .UseNpgsql(connString)
                .Options;

            DataContext dataContext = new DataContext(contextOptions);

            HostMail hostMail = new HostMail
            {
                Port = 587,
                SenderMail = "***@outlook.com.tr",
                SenderPassword = "***",
                HostMailServer = "smtp-mail.outlook.com"
            };

            // constructor for dependency injection
            movieManager = new MovieManager(new MovieDAL(dataContext));
            mailManager = new MailManager(new MovieDAL(dataContext), hostMail);
        }

        [Test]
        public async Task GetMovie()
        {
            CustomResult<Movie> result = movieManager.GetAll(1, 10);
            Assert.Greater(result.count, 0);
        }

        [Test]
        public async Task GetMovieDetail()
        {
            Movie movie = movieManager.GetDetail(2);
            Assert.IsNotNull(movie);
        }

        [Test]
        public async Task AddNote()
        {
            MovieNote movieNote = new MovieNote { MovieId = 2, Note = "test note", Score = 10};
            Assert.IsTrue(movieManager.AddNote(movieNote));
        }

        [Test]
        public async Task RecommendMail()
        {
            RecommendMail recommendMail = new RecommendMail { MailAddress = "sefagndz99@gmail.com", MovieId = 2 };
            Assert.IsTrue(mailManager.Recommend(recommendMail));
        }
    }
}
