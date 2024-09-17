

namespace GChat.Domain.entities;


public class UserSuscription
{
    public string? SuscriptionId { get; set; }
    public Suscription? Suscription { get; set; }

    public string? UserId { get; set; }
    public UserEntity? User { get; set; }
}
