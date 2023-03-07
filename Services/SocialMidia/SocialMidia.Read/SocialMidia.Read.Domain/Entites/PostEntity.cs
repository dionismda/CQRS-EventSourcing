namespace SocialMidia.Read.Domain.Entites;

public class PostEntity : Entity
{
    public PostEntity() : base()
    {
    }

    public string Author { get; set; }
    public DateTime DatePosted { get; set; }
    public string Message { get; set; }
    public int Likes { get; set; }
    public virtual ICollection<CommentEntity> Comments { get; set; }
}
