namespace SocialMidia.Read.Application.Responses;

public class PostLookupResponse : BaseResponse
{
    public IList<PostEntity> Posts { get; set; }
}
