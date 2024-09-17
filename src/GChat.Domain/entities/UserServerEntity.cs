
namespace GChat.Domain.entities;

public class UserServerEntity
{
    public string? UserId { get; set; }
    public UserEntity? User { get; set; }


    public string? ServerId { get; set; }
    public ServerEntity? Server { get; set; }
}
