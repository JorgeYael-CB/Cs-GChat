

namespace GChat.Domain.entities;



public class ServerEntity: Entity
{
    public ICollection<UserServerEntity>? UserServers { get; set; }
    public ICollection<UserEntity>? Users { get; set; }

    public string? UserOwnedId { get; set; }
    public UserEntity? Owner { get; set; }

    public string? TypeId { get; set; }
    public TypeEntity? Type { get; set; }

    public int UserLimit { get; set; }
}
