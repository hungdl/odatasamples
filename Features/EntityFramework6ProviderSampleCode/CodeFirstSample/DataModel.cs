using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace CodeFirstSample
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string BlogName { get; set; }
        public virtual List<Post> Posts { get; set; }
    }

    public class Post
    {
        public int PostId { get; set; }
        public string PostName { get; set; }

        public PostContent Content { get; set; }

        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }
    }

    [ComplexType]
    public class PostContent
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Body { get; set; }
    }

    public class BlogContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}