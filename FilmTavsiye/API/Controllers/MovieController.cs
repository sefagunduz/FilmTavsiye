using BLL.Abstract;
using CORE;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieManager movieManager;
        private readonly IMailManager mailManager;
        public MovieController(IMovieManager movieManager, IMailManager mailManager)
        {
            this.movieManager = movieManager;
            this.mailManager = mailManager;

        }

        [HttpGet]
        public CustomResult<Movie> Get(int page = 1, int count = 10)
        {
            CustomResult<Movie> result = movieManager.GetAll(page,count);
            return result;
        }

        [HttpGet]
        [Route("{id}")]
        public Movie Get(int id)
        {
            Movie movie = movieManager.GetDetail(id);
            return movie;
        }

        [HttpPost]
        [Route("Note")]
        public IActionResult AddNote(MovieNote movieNote)
        {
            return Ok(movieManager.AddNote(movieNote));
        }

        [HttpPost]
        [Route("Recommend")]
        public IActionResult Recommend(RecommendMail recommendMail)
        {
            return Ok(mailManager.Recommend(recommendMail));
        }
    }
}
