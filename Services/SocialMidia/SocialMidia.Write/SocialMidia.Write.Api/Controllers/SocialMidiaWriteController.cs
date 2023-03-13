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
            await _commandDispatcher.Handle(command);

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

}
