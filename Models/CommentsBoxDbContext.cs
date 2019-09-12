using Microsoft.EntityFrameworkCore;

namespace Book_Link.Models
{
    public class CommentsBoxDbContext: DbContext
    {
        public DbSet<Book> Books { get; set; }

        public CommentsBoxDbContext(DbContextOptions<CommentsBoxDbContext> options)
                :base(options)
        {
        }
    }
}