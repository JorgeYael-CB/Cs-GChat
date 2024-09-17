
namespace GChat.Domain.entities;




public class MessageEntity: Entity
{
    public string? Content { get; set; }


    public string? UserId { get; set; }
    public UserEntity? User { get; set; }

    public string? ServerId { get; set; }
    public ServerEntity? Server { get; set; }
}
