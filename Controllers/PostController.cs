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

        private readonly ICommentRepository _commentRepository;

        public PostController(
            IPostRepository postRepository,
            ITagRepository tagRepository,
            ICommentRepository commentRepository
        )
        {
            _postRepository = postRepository;
            _tagRepository = tagRepository;
            _commentRepository = commentRepository;
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

        public async Task<IActionResult> PostDetails(int id)
        {
            var postQuery =
                _postRepository
                    .Posts
                    .Include(x => x.Tags)
                    .Include(x => x.Comments)
                    .ThenInclude(x => x.User);
            var tagsQuery = _tagRepository.Tags;
            if (id != null)
            {
                var post =
                    await postQuery.FirstOrDefaultAsync(p => p.PostId == id);
                if (post != null)
                {
                    var viewModel = new PostViewModel { Post = post };
                    return View("PostDetails", viewModel);
                }
                else
                {
                    return View("~/Views/Shared/NotFound.cshtml"); // Return a 404 Not Found result
                }
            }
            else
            {
                // Handle the case where id is null, perhaps return a BadRequest result
                return NotFound("~/Views/Shared/NotFound.cshtml");
            }
        }

        public async Task<IActionResult> GetPostsByTag(string ttext)
        {
            var posts = _postRepository.Posts;
            var tags = _tagRepository.Tags;
            Tag spesTag = null;

            if (ttext != null)
            {
                var postsWithTag =
                    posts.Where(x => x.Tags.Any(t => t.TText == ttext));
                if (
                    postsWithTag.Any() // Check if there are any posts with the specified tag
                )
                {
                    spesTag =
                        await tags.FirstOrDefaultAsync(t => t.TText == ttext);
                    var postsList =
                        await postsWithTag
                            .OrderByDescending(p => p.PPublishedOn)
                            .ToListAsync();

                    var viewModel =
                        new PostViewModel { Posts = postsList, Tag = spesTag };

                    return View("PostsByTag", viewModel);
                }
                else
                {
                    return View("~/Views/Shared/NotFound.cshtml");
                }
            }
            else
            {
                return View("~/Views/Shared/NotFound.cshtml");
            }
        }

        [HttpPost]
        public JsonResult CreateComment(int PostId, string UserName, string CText)
        {
            var lastId =
                _commentRepository.Comments.Max(comment => comment.CommentId); // Get the last CommentId
            var newCommentId = lastId + 1; // Increment the last CommentId by one to get the new CommentId

            var entity =
                new Comment {
                    CommentId = newCommentId,
                    CText = CText,
                    CPublishedOn = DateTime.UtcNow,
                    Post =
                        _postRepository
                            .Posts
                            .FirstOrDefault(p => p.PostId == PostId),
                    User = new User { UserName = UserName }
                };

            _commentRepository.CreateComment (entity);

            return Json(new{
                UserName,
                CText,
                entity.CPublishedOn
                

        });
        }
    }
}
