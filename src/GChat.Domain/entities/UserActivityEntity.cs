
namespace GChat.Domain.entities;

public class UserActivityEntity
{
    public string? UserId { get; set; }
    public UserEntity? User { get; set; }

    public string? ActivityId { get; set; }
    public ActivityEntity? Activity { get; set; }
}
