
namespace GChat.Domain.entities;



public abstract class Entity
{
    public string? Id { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? CreatedAt { get; set; }
    public bool? IsActive { get; set; }
}
