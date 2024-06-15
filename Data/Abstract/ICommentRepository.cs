using BuffBlog.Entity;

namespace BuffBlog.Data.Abstract
{
    public interface ICommentRepository
    {
        IQueryable<Comment> Comments {get;}
        //Posltarı context üzerinden aldığında ekstradan filtrelemeye devam edebileceğim "IQueryable" sayesinde
        void CreateComment(Comment comment);
        
    }
}