using BuffBlog.Data.Abstract;
using BuffBlog.Entity;
using Microsoft.AspNetCore.Mvc;

namespace BuffBlog.ViewComponents
{
    public class TopSlider : ViewComponent
    {
        private IPostRepository _postRepository;

        public TopSlider(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public IViewComponentResult Invoke()
        {
            var latestPosts =
                _postRepository
                    .Posts
                    .OrderByDescending(post => post.PPublishedOn)
                    .Take(6)
                    .ToList();

            return View("Default", latestPosts);
        }
    }
}
