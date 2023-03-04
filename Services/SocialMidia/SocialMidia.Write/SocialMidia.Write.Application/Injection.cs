namespace SocialMidia.Write.Application;

public static class Injection
{
    public static IServiceCollection InjectSocialMidiaWriteApplication(this IServiceCollection services)
    {
        services
            .RegisterCommandHandler<PostCommandHandler, NewPostCommand>()
            .RegisterCommandHandler<PostCommandHandler, EditMessageCommand>()
            .RegisterCommandHandler<PostCommandHandler, LikePostCommand>()
            .RegisterCommandHandler<PostCommandHandler, AddCommentCommand>()
            .RegisterCommandHandler<PostCommandHandler, EditCommentCommand>()
            .RegisterCommandHandler<PostCommandHandler, RemoveCommentCommand>()
            .RegisterCommandHandler<PostCommandHandler, DeletePostCommand>();

        return services;
    }
}