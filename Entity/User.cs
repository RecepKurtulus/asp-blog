namespace BuffBlog.Entity
{
    public class User
    {
       public int? UserId { get; set; } 
       public string? UserName { get; set; }
       public string? UserMail { get; set; }
       public string? UserHash { get; set; }
       public string? UserSalt { get; set; }
       public string? UserPp { get; set; }
       public string? UserBio { get; set; }

        //User's posts and comments
       public List<Post>? UserPosts {get; set;}=new List<Post>();
       public List<Comment>? UserComments {get; set;}=new List<Comment>();
       
    }
}