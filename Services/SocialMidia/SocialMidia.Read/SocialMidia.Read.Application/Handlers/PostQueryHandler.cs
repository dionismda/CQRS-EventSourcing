namespace SocialMidia.Read.Application.Handlers;

public class PostQueryHandler : IQueryHandler<FindAllPostsQuery, IList<PostEntity>>,
    IQueryHandler<FindPostByIdQuery, IList<PostEntity>>,
    IQueryHandler<FindPostsByAuthorQuery, IList<PostEntity>>,
    IQueryHandler<FindPostsWithCommentsQuery, IList<PostEntity>>,
    IQueryHandler<FindPostsWithLikesQuery, IList<PostEntity>>
{

    private readonly IPostRepository _postRepository;

    public PostQueryHandler(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task<IList<PostEntity>> HandleAsync(FindAllPostsQuery query)
    {
        return await _postRepository.ListAllAsync();
    }

    public async Task<IList<PostEntity>> HandleAsync(FindPostByIdQuery query)
    {
        var post = await _postRepository.GetByIdAsync(query.Id);
        return new List<PostEntity> { post };
    }

    public async Task<IList<PostEntity>> HandleAsync(FindPostsByAuthorQuery query)
    {
        return await _postRepository.ListByAuthorAsync(query.Author);
    }

    public async Task<IList<PostEntity>> HandleAsync(FindPostsWithCommentsQuery query)
    {
        return await _postRepository.ListWithCommentsAsync();
    }

    public async Task<IList<PostEntity>> HandleAsync(FindPostsWithLikesQuery query)
    {
        return await _postRepository.ListWithLikesAsync(query.NumberOfLikes);
    }
}
