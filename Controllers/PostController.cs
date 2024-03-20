using BuffBlog.Data.Abstract;
using BuffBlog.Data.Concrete.EfCore;
using BuffBlog.Models;
using Microsoft.AspNetCore.Mvc;

namespace BuffBlog.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostRepository _postRepository;

        private readonly ITagRepository _tagRepository;

        public PostController(
            IPostRepository postRepository,
            ITagRepository tagRepository
        )
        {
            _postRepository = postRepository;
            _tagRepository = tagRepository;
        }

        public IActionResult Index()
        {
            // Blog gönderilerini ve etiketleri içeren bir PostViewModel örneği oluştur
            var viewModel =
                new PostViewModel {
                    Posts = _postRepository.Posts.ToList(),
                    Tags = _tagRepository.Tags.ToList()
                };
            return View(viewModel);
        }
        
    }
}
