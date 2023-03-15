namespace SocialMidia.Write.Api.Controllers;

[ApiController]
[Route("api/v1/")]
public class SocialMidiaWriteController : ControllerBase
{

    private readonly ILogger<SocialMidiaWriteController> _logger;
    private readonly ICommandDispatcher _commandDispatcher;

    public SocialMidiaWriteController(ILogger<SocialMidiaWriteController> logger, ICommandDispatcher commandDispatcher)
    {
        _logger = logger;
        _commandDispatcher = commandDispatcher;
    }

    [HttpPost("newpost")]
    public async Task<ActionResult> NewPostAsync(NewPostCommand command)
    {
        var id = Guid.NewGuid();
        try
        {
            command.Id = id;
            await _commandDispatcher.HandleAsync(command);

            return StatusCode(StatusCodes.Status201Created, new BaseResponse
            {
                Message = $"New post creation request completed successfully! ID {id}"
            });
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new BaseResponse
            {
                Message = ex.Message
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

    [HttpPut("editpost/{id}")]
    public async Task<ActionResult> EditMessageAsync(Guid id, EditMessageCommand command)
    {
        try
        {
            command.Id = id;
            await _commandDispatcher.HandleAsync(command);

            return Ok(new BaseResponse
            {
                Message = "Edit message request completed successfully!"
            });
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new BaseResponse
            {
                Message = ex.Message
            });
        }
        catch (AggregateNotFoundException ex)
        {           
            return BadRequest(new BaseResponse
            {
                Message = ex.Message
            });
        }
        catch (Exception ex)
        {
            const string SAFE_ERROR_MESSAGE = "Error while processing request to edit the message of a post!";
            return StatusCode(StatusCodes.Status500InternalServerError, new BaseResponse
            {
                Message = SAFE_ERROR_MESSAGE
            });
        }
    }

    [HttpPut("likepost/{id}")]
    public async Task<ActionResult> LikePostAsync(Guid id)
    {
        try
        {
            await _commandDispatcher.HandleAsync(new LikePostCommand { Id = id });

            return Ok(new BaseResponse
            {
                Message = "Like post request completed successfully!"
            });
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new BaseResponse
            {
                Message = ex.Message
            });
        }
        catch (AggregateNotFoundException ex)
        {
            return BadRequest(new BaseResponse
            {
                Message = ex.Message
            });
        }
        catch (Exception ex)
        {
            const string SAFE_ERROR_MESSAGE = "Error while processing request to like a post!";
            return StatusCode(StatusCodes.Status500InternalServerError, new BaseResponse
            {
                Message = SAFE_ERROR_MESSAGE
            });
        }
    }

    [HttpPut("addcomment/{id}")]
    public async Task<ActionResult> AddCommentAsync(Guid id, AddCommentCommand command)
    {
        try
        {
            command.Id = id;
            await _commandDispatcher.HandleAsync(command);

            return Ok(new BaseResponse
            {
                Message = "Add comment request completed successfully!"
            });
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new BaseResponse
            {
                Message = ex.Message
            });
        }
        catch (AggregateNotFoundException ex)
        {
            return BadRequest(new BaseResponse
            {
                Message = ex.Message
            });
        }
        catch (Exception ex)
        {
            const string SAFE_ERROR_MESSAGE = "Error while processing request to add a comment to a post!";
            return StatusCode(StatusCodes.Status500InternalServerError, new BaseResponse
            {
                Message = SAFE_ERROR_MESSAGE
            });
        }
    }

    [HttpPut("editcomment/{id}")]
    public async Task<ActionResult> EditCommentAsync(Guid id, EditCommentCommand command)
    {
        try
        {
            command.Id = id;
            await _commandDispatcher.HandleAsync(command);

            return Ok(new BaseResponse
            {
                Message = "Edit comment request completed successfully!"
            });
        }
        catch (InvalidOperationException ex)
        {
            _logger.Log(LogLevel.Warning, ex, "Client made a bad request!");
            return BadRequest(new BaseResponse
            {
                Message = ex.Message
            });
        }
        catch (AggregateNotFoundException ex)
        {
            _logger.Log(LogLevel.Warning, ex, "Could not retrieve aggregate, client passed an incorrect post ID targetting the aggregate!");
            return BadRequest(new BaseResponse
            {
                Message = ex.Message
            });
        }
        catch (Exception ex)
        {
            const string SAFE_ERROR_MESSAGE = "Error while processing request to edit a comment on a post!";
            _logger.Log(LogLevel.Error, ex, SAFE_ERROR_MESSAGE);

            return StatusCode(StatusCodes.Status500InternalServerError, new BaseResponse
            {
                Message = SAFE_ERROR_MESSAGE
            });
        }
    }

    [HttpDelete("removecomment/{id}")]
    public async Task<ActionResult> RemoveCommentAsync(Guid id, RemoveCommentCommand command)
    {
        try
        {
            command.Id = id;
            await _commandDispatcher.HandleAsync(command);

            return Ok(new BaseResponse
            {
                Message = "Remove comment request completed successfully!"
            });
        }
        catch (InvalidOperationException ex)
        {
            _logger.Log(LogLevel.Warning, ex, "Client made a bad request!");
            return BadRequest(new BaseResponse
            {
                Message = ex.Message
            });
        }
        catch (AggregateNotFoundException ex)
        {
            _logger.Log(LogLevel.Warning, ex, "Could not retrieve aggregate, client passed an incorrect post ID targetting the aggregate!");
            return BadRequest(new BaseResponse
            {
                Message = ex.Message
            });
        }
        catch (Exception ex)
        {
            const string SAFE_ERROR_MESSAGE = "Error while processing request to remove a comment from a post!";
            return StatusCode(StatusCodes.Status500InternalServerError, new BaseResponse
            {
                Message = SAFE_ERROR_MESSAGE
            });
        }
    }


    [HttpDelete("delete/{id}")]
    public async Task<ActionResult> DeletePostAsync(Guid id, DeletePostCommand command)
    {
        try
        {
            command.Id = id;
            await _commandDispatcher.HandleAsync(command);

            return Ok(new BaseResponse
            {
                Message = "Delete post request completed successfully!"
            });
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new BaseResponse
            {
                Message = ex.Message
            });
        }
        catch (AggregateNotFoundException ex)
        {
            return BadRequest(new BaseResponse
            {
                Message = ex.Message
            });
        }
        catch (Exception ex)
        {
            const string SAFE_ERROR_MESSAGE = "Error while processing request to delete a post!";
            return StatusCode(StatusCodes.Status500InternalServerError, new BaseResponse
            {
                Message = SAFE_ERROR_MESSAGE
            });
        }
    }

}
