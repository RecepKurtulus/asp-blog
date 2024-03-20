using System.Diagnostics;
using BuffBlog.Data.Abstract;
using BuffBlog.Data.Concrete.EfCore;
using BuffBlog.Models;
using Microsoft.AspNetCore.Mvc;


namespace BuffBlog.Controllers;

public class HomeController : Controller
{
    private readonly IPostRepository _postRepository;

    private readonly ITagRepository _tagRepository;
    public HomeController(
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

    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

