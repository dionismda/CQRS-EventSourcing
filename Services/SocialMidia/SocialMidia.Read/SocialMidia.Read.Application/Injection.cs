namespace SocialMidia.Read.Application;

public static class Injection
{
    public static IServiceCollection InjectSocialMidiaReadApplication(this IServiceCollection services)
    {
        services
            .RegisterQueryHandler<PostQueryHandler, FindAllPostsQuery, IList<PostEntity>>()
            .RegisterQueryHandler<PostQueryHandler, FindPostByIdQuery, IList<PostEntity>>()
            .RegisterQueryHandler<PostQueryHandler, FindPostsByAuthorQuery, IList<PostEntity>>()
            .RegisterQueryHandler<PostQueryHandler, FindPostsWithCommentsQuery, IList<PostEntity>>()
            .RegisterQueryHandler<PostQueryHandler, FindPostsWithLikesQuery, IList<PostEntity>>();

        services.AddScoped<IQueryDispatcher, QueryDispatcher>();

        return services;
    }
}
