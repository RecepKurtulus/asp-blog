using BuffBlog.Entity;

namespace BuffBlog.Data.Abstract
{
    public interface IPostRepository
    {
        IQueryable<Post> Posts {get;}
        //Posltarı context üzerinden aldığında ekstradan filtrelemeye devam edebileceğim "IQueryable" sayesinde
        
        
    }
}