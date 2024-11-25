using backend2.DTOs;

namespace backend2.Services
{
    public interface IPostsService
    {
        public Task<IEnumerable<PostDto>> Get();

    }
}
