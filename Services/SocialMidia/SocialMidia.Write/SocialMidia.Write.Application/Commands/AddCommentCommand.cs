namespace SocialMidia.Write.Application.Commands;

public class AddCommentCommand : BaseCommand
{
    public string Comment { get; set; }
    public string Username { get; set; }
}
