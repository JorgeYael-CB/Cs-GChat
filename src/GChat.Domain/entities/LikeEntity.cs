
namespace GChat.Domain.entities;



public class LikeEntity: Entity
{
    public string? UserId { get; set; }

    public string? ImageId { get; set; }
    public PhotoEntity? Image { get; set; }
}
