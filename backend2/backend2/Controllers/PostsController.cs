using backend2.DTOs;
using backend2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {


        IPostsService _titleService;

        public PostsController(IPostsService titleService)
        {
            _titleService = titleService;
        }

        [HttpGet]
        public async Task<IEnumerable<PostDto>> Get() =>
            await _titleService.Get();

    }
}
