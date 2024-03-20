namespace BuffBlog.Entity
{
    public class Post
    {
       public int? PostId { get; set; } 
       public string? PTitle { get; set; } 
       public string? PContent { get; set; } 
       public DateTime PPublishedOn { get; set; } 
       public bool PIsActive { get; set; }
       public string? PImage {get; set;}
       public int? UserId { get; set; } 


        //Every post need to have author & tags & comments(optional)
       public User Author {get; set;}=null!;
       public List<Tag> Tags  { get; set; }=new List<Tag>();
       public List<Comment>? Comments  { get; set; }=new List<Comment>();
    }
}