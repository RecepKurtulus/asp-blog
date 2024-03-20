namespace BuffBlog.Entity
{
    public class Comment
    {
       public int? CommentId { get; set; } 
       public string? CText { get; set; }
       public DateTime CPublishedOn { get; set; } 

        //Post area 
       public int PostId { get; set; } 
       public Post Post  { get; set; }=new Post();
        //Comment owner area
       public int? UserId { get; set; } 
       public User User  { get; set; }=new User();

    }
}