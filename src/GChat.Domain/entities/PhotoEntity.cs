
namespace GChat.Domain.entities;

public class PhotoEntity: Entity
{
    public string? Url { get; set; }

    // Relacion de 1 a muchos
    public ICollection<LikeEntity>? Likes { get; set; }


    public string? UserId { get; set; }
    public UserEntity? User { get; set; }
}
