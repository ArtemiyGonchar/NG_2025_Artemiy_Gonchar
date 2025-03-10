using BusinessLogicLayer.Models;
using BusinessLogicLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;
namespace Task4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoryService _categoryService;
        private readonly ICommentService _commentService;
        private readonly IProjectService _projectService;
        private readonly IUserService _userService;
        private readonly IVoteService _voteService;
        public HomeController(ILogger<HomeController> logger,
            ICategoryService categoryService,
            ICommentService commentService,
            IProjectService projectService,
            IUserService userService,
            IVoteService voteService)
        {
            _logger = logger;
            _categoryService = categoryService;
            _commentService = commentService;
            _projectService = projectService;
            _userService = userService;
            _voteService = voteService;
        }

        public IActionResult Index()
        {
            return Redirect("/swagger");
        }

        [HttpPost("createuser")]
        public async Task<IActionResult> CreateUser([FromBody] UserModel userModel)
        {
            var userId = await _userService.CreateAsync(userModel);
            return Ok(userId);
        }

        [HttpGet("getuserbyid")]
        public async Task<IActionResult> GetUserByIdAsync(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            return Ok(user);
        }

        [HttpPost("createcategory")]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryModel categoryModel)
        {
            var categoryId = await _categoryService.CreateAsync(categoryModel);
            return Ok(categoryId);
        }

        [HttpGet("getcategorybyid")]
        public async Task<IActionResult> GetCategoryByIdAsync(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            return Ok(category);
        }

        [HttpPost("createproject")]
        public async Task<IActionResult> CreateProject([FromBody] ProjectModel projectModel)
        {
            var projectId = await _projectService.CreateProjectAsync(projectModel);
            return Ok(projectId);
        }
        [HttpGet("getprojectbyid")]
        public async Task<IActionResult> GetProjectByIdAsync(int id)
        {
            var project = await _projectService.GetByIdAsync(id);
            return Ok(project);
        }

        [HttpPost("createcomment")]
        public async Task<IActionResult> CreateComment([FromBody] CommentModel commentModel)
        {
            var commentId = await _commentService.CreateAsync(commentModel);
            return Ok(commentId);
        }

        [HttpGet("getcommentbyid")]
        public async Task<IActionResult> GetCommentByIdAsync(int id)
        {
            var comment = await _commentService.GetByIdAsync(id);
            return Ok(comment);
        }

        [HttpPost("createvote")]
        public async Task<IActionResult> CreateVote([FromBody] VoteModel voteModel)
        {
            var voteId = await _voteService.CreateAsync(voteModel);
            return Ok(voteId);
        }

        [HttpGet("getvotebyid")]
        public async Task<IActionResult> GetVoteByIdAsync(int id)
        {
            var vote = await _voteService.GetByIdAsync(id);
            return Ok(vote);
        }
    }
}
