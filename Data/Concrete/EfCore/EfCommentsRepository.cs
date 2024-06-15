using BuffBlog.Data.Abstract;
using BuffBlog.Data.Concrete.EfCore;
using BuffBlog.Entity;

namespace BuffBlog.Data.Concrete
{
    public class EfCommentsRepository : ICommentRepository
    {
        private BlogContext _context;
        
        public EfCommentsRepository(BlogContext context){
            _context =context;
        }
        public IQueryable<Comment> Comments => _context.Comments;
        public void CreateComment(Comment comment){
            _context.Comments.Add(comment);
            _context.SaveChanges();
        }
    }
}