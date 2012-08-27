using System.Data.Entity;

namespace WcfDataServices101.UsingTheNotMappedAttribute
{
    public class FileContext : DbContext
    {
        public DbSet<File> Files { get; set; }
    }
}