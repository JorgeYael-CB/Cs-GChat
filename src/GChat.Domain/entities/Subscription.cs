
namespace GChat.Domain.entities;



public class Subscription: Entity
{
    public string? Type { get; set; }

    public int DaysDuration { get; set; }

    public ICollection<UserEntity>? Users { get; set; }
}
