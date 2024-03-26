using BuffBlog.Data.Abstract;
using BuffBlog.Data.Concrete.EfCore;
using BuffBlog.Entity;
using BuffBlog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        public IActionResult PostDetails(int id)
        {
            var Post =
                _postRepository.Posts.FirstOrDefault(p => p.PostId == id);

            return View("PostDetails", Post);
        }

        public async Task<IActionResult> GetPostsByTag(string ttext)
        {
            var posts = _postRepository.Posts;
            var tags =_tagRepository.Tags;
            Tag spesTag=null;
            
            if (ttext != null)
             {
                posts =  posts.Where(x => x.Tags.Any(t => t.TText == ttext));
                spesTag = await tags.FirstOrDefaultAsync(t => t.TText == ttext);
            }
            var postsList =await posts.ToListAsync();
            var viewModel =
                new PostViewModel {  Posts = postsList,Tag = spesTag };
            
            return View("PostsByTag", viewModel);
        }
    }

    
}
