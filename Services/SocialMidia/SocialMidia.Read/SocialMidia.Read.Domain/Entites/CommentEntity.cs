namespace SocialMidia.Read.Domain.Entites;

public class CommentEntity : Entity
{
    public CommentEntity() : base()
    {
    }

    public string Username { get; set; }
    public DateTime CommentDate { get; set; }
    public string Comment { get; set; }
    public bool Edited { get; set; }
    public Guid PostId { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual PostEntity Post { get; set; }
}
