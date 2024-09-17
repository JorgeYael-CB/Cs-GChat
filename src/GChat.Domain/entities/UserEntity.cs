namespace GChat.Domain.entities;




public class UserEntity: Entity
{
    public string? Email { get; set; }
    public string? Name { get; set; }
    public string? Password { get; set; }
    public string? Description { get; set; }

    public ICollection<ServerEntity>? ServersCreated { get; set; }


    //? Relacion de 1 a muchos
    public ICollection<MessageEntity>? Messages { get; set; }
    public ICollection<PhotoEntity>? Photos { get; set; }

    public ICollection<UserServerEntity>? UserServers { get; set; }
    public ICollection<ServerEntity>? Servers { get; set; }


    //? Relacion de muchos a muchos
    public ICollection<UserActivityEntity>? UserActivities { get; set; }
    public ICollection<ActivityEntity>? Activities { get; set; }

    public string? SuscrtiptionId { get; set; }
    public ICollection<Suscription>? Suscriptions { get; set; }
}
