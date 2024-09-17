
namespace GChat.Domain.entities;


public class TypeEntity: Entity
{
    public string? Type { get; set; }

    public ICollection<ServerEntity>? Servers { get; set; }
}
