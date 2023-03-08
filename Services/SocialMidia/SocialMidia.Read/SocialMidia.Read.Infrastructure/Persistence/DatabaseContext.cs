namespace SocialMidia.Read.Infrastructure.Persistence;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    public DbSet<PostEntity> Posts { get; set; }
    public DbSet<CommentEntity> Comments { get; set; }

}
