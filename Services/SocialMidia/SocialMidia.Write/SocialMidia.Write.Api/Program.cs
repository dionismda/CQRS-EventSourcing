namespace SocialMidia.Write.Api;

public static class Program
{
    public static int Main(string[] args)
    {
        try
        {
            CreateHostBuilder(args).Build().Run();
            return 0;
        }
        catch (Exception ex)
        {
            return 1;
        }
        finally
        {
        }
    }

    private static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); })
        ;
}
