namespace BuffBlog.Entity
{
    public class Tag
    {
       public int? TagId { get; set; } 
       public string? TText { get; set; } 
      

      public List<Post> Posts  { get; set; }=new List<Post>();
    }
}