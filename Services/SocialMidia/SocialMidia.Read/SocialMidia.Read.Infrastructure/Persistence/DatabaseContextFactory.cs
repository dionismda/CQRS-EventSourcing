namespace SocialMidia.Read.Infrastructure.Persistence;

public class DatabaseContextFactory
{
    private readonly Action<DbContextOptionsBuilder> _configureDbContext;

    public DatabaseContextFactory(Action<DbContextOptionsBuilder> configureDbContext)
    {
        _configureDbContext = configureDbContext;
    }

    public DatabaseContext CreateDbContext()
    {
        DbContextOptionsBuilder<DatabaseContext> optionsBuilder = new();
        _configureDbContext(optionsBuilder);

        return new DatabaseContext(optionsBuilder.Options);
    }
}
