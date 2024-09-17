
namespace GChat.Domain.entities;

public class ActivityEntity
{
    public string? Name { get; set; }

    public ICollection<UserActivityEntity>? UserActivities { get; set; }
    public ICollection<UserEntity>? UserEntities { get; set; }
}
