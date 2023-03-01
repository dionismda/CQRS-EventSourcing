namespace SocialMidia.Write.Api;

public class Startup
{
    private IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services
            .InjectSocialMidiaWriteApplication()
            .InjectSocialMidiaWriteDomain()
            .InjectSocialMidiaWriteInfrastructure()
            .InjectShared();
    }

    public void Configure(IApplicationBuilder app,IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
            app.UseDeveloperExceptionPage();


        app.UseRouting();
        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapDefaultControllerRoute();
        });
    }
}
