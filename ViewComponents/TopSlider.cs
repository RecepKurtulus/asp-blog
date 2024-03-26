using BuffBlog.Data.Abstract;
using BuffBlog.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BuffBlog.ViewComponents
{
    public class TopSlider : ViewComponent
    {
        //Post repoyu çektik 
        private IPostRepository _postRepository;
        //Repoyu açtık
        public TopSlider(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        //Başlar başlamaz son 6 postu getirdik
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var  latestPosts =
               await _postRepository
                    .Posts
                    .OrderByDescending(post => post.PPublishedOn)
                    .Take(6)
                    .ToListAsync();

            return View("Default", latestPosts);
        }
    }
}
