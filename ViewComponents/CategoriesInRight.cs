using BuffBlog.Data.Abstract;
using BuffBlog.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BuffBlog.ViewComponents
{
    public class CategoriesInRight : ViewComponent
    {
        //Post repoyu çektik 
        private ITagRepository _tagRepository;
        //Repoyu açtık
        public CategoriesInRight(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }
        //Başlar başlamaz son 6 postu getirdik
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var  tags =
               await _tagRepository
                    .Tags
                    .ToListAsync();

            return View("Default", tags);
        }
    }
}
