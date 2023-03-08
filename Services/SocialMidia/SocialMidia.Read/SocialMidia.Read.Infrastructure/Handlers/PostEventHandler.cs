namespace SocialMidia.Read.Infrastructure.Handlers;

public class PostEventHandler : IEventHandler<PostCreatedEvent>,
IEventHandler<MessageUpdatedEvent>, IEventHandler<PostLikedEvent>,
IEventHandler<PostRemovedEvent>
{
    private readonly IPostRepository _postRepository;

    public PostEventHandler(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task HandleAsync(PostCreatedEvent @event)
    {
        var post = new PostEntity
        {
            Id = @event.Id,
            Author = @event.Author,
            DatePosted = @event.DatePosted,
            Message = @event.Message
        };

        await _postRepository.CreateAsync(post);
    }

    public async Task HandleAsync(MessageUpdatedEvent @event)
    {
        var post = await _postRepository.GetByIdAsync(@event.Id);

        if (post == null) return;

        post.Message = @event.Message;
        await _postRepository.UpdateAsync(post);
    }

    public async Task HandleAsync(PostLikedEvent @event)
    {
        var post = await _postRepository.GetByIdAsync(@event.Id);

        if (post == null) return;

        post.Likes++;
        await _postRepository.UpdateAsync(post);
    }

    public async Task HandleAsync(PostRemovedEvent @event)
    {
        await _postRepository.DeleteAsync(@event.Id);
    }
}
