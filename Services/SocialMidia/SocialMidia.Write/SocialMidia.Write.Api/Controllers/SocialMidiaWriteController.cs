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
        try
        {
            await _commandDispatcher.Handle<NewPostCommand>(command);

            return StatusCode(StatusCodes.Status201Created, new BaseResponse
            {
                Message = "New post creation request completed successfully!"
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
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Error, ex, ex.Message);

            return StatusCode(StatusCodes.Status500InternalServerError, new BaseResponse
            {
                Message = ex.Message
            });
        }
    }

}
