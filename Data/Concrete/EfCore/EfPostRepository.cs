using BuffBlog.Data.Abstract;
using BuffBlog.Data.Concrete.EfCore;
using BuffBlog.Entity;

namespace BuffBlog.Data.Concrete
{
    public class EfPostRepository : IPostRepository
    {
        private BlogContext _context;
        
        public EfPostRepository(BlogContext context){
            _context =context;
        }
        public IQueryable<Post> Posts => _context.Posts;
    }
}