using BuffBlog.Entity;

namespace BuffBlog.Data.Abstract
{
    public interface ITagRepository
    {
        IQueryable<Tag> Tags {get;}
        //Posltarı context üzerinden aldığında ekstradan filtrelemeye devam edebileceğim "IQueryable" sayesinde
        
        
    }
}