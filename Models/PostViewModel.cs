using BuffBlog.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
namespace BuffBlog.Models
{
    public class PostViewModel
    {
        public Post Post { get; set; } = new();
        public Tag Tag { get; set; } = new();

        public List<Post> Posts { get; set; } = new();
        public List<Tag> Tags { get; set; } = new();

    }
}