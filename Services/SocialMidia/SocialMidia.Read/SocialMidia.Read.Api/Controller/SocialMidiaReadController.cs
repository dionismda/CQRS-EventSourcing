namespace SocialMidia.Read.Api.Controller;

public class SocialMidiaReadController : ControllerBase
{
    private readonly IQueryDispatcher _queryDispatcher;

    public SocialMidiaReadController(IQueryDispatcher queryDispatcher)
    {
        _queryDispatcher = queryDispatcher;
    }

    [HttpGet("post")]
    public async Task<ActionResult> GetAllPostsAsync()
    {
        try
        {
            var posts = await _queryDispatcher.HandleAsync<FindAllPostsQuery, IList<PostEntity>>(new FindAllPostsQuery());
            if (posts == null || !posts.Any())
                return NoContent();

            var count = posts.Count;
            return Ok(new PostLookupResponse
            {
                Posts = posts,
                Message = $"Successfully returned {count} post{(count > 1 ? "s" : string.Empty)}!"
            });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new BaseResponse
            {
                Message = ex.Message
            });
        }
    }


    [HttpGet("byId/{postId}")]
    public async Task<ActionResult> GetByPostIdAsync(Guid postId)
    {
        try
        {
            var posts = await _queryDispatcher.HandleAsync<FindPostByIdQuery, IList<PostEntity>>(new FindPostByIdQuery { Id = postId });

            if (posts == null || !posts.Any())
                return NoContent();

            return Ok(new PostLookupResponse
            {
                Posts = posts,
                Message = "Successfully returned post!"
            });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new BaseResponse
            {
                Message = ex.Message
            });
        }
    }

    [HttpGet("byAuthor/{author}")]
    public async Task<ActionResult> GetPostsByAuthorAsync(string author)
    {
        try
        {
            var posts = await _queryDispatcher.HandleAsync<FindPostsByAuthorQuery, IList<PostEntity>>(new FindPostsByAuthorQuery { Author = author });
            if (posts == null || !posts.Any())
                return NoContent();

            return Ok(new PostLookupResponse
            {
                Posts = posts,
                Message = "Successfully returned post!"
            });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new BaseResponse
            {
                Message = ex.Message
            });
        }
    }

    [HttpGet("withComments")]
    public async Task<ActionResult> GetPostsWithCommentsAsync()
    {
        try
        {
            var posts = await _queryDispatcher.HandleAsync<FindPostsWithCommentsQuery, IList<PostEntity>>(new FindPostsWithCommentsQuery());
            if (posts == null || !posts.Any())
                return NoContent();

            return Ok(new PostLookupResponse
            {
                Posts = posts,
                Message = "Successfully returned post!"
            });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new BaseResponse
            {
                Message = ex.Message
            });
        }
    }

    [HttpGet("withLikes/{numberOfLikes}")]
    public async Task<ActionResult> GetPostsWithLikesAsync(int numberOfLikes)
    {
        try
        {
            var posts = await _queryDispatcher.HandleAsync<FindPostsWithLikesQuery, IList<PostEntity>>(new FindPostsWithLikesQuery { NumberOfLikes = numberOfLikes });
            if (posts == null || !posts.Any())
                return NoContent();

            return Ok(new PostLookupResponse
            {
                Posts = posts,
                Message = "Successfully returned post!"
            });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new BaseResponse
            {
                Message = ex.Message
            });
        }
    }

}
