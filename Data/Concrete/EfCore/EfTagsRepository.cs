using BuffBlog.Data.Abstract;
using BuffBlog.Data.Concrete.EfCore;
using BuffBlog.Entity;

namespace BuffBlog.Data.Concrete
{
    public class EfTagsRepository : ITagRepository
    {
        private BlogContext _context;
        
        public EfTagsRepository(BlogContext context){
            _context =context;
        }
        public IQueryable<Tag> Tags => _context.Tags;
    }
}