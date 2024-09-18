
using GChat.Domain.entities;
using Microsoft.EntityFrameworkCore;

namespace GChat.Infrastructure.persistence;



public class GChatDbContext: DbContext
{
    //? 4.-

    public DbSet<UserEntity> Users { get; set; }
    public DbSet<ActivityEntity> Activities { get; set; }
    public DbSet<ServerEntity> Servers { get; set; }
    public DbSet<MessageEntity> Messages { get; set; }
    public DbSet<Subscription> Subscriptions { get; set; }
    public DbSet<PhotoEntity> Photos { get; set; }
    public DbSet<LikeEntity> Likes { get; set; }


    //? 1.- Cadena de conexion
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=LocalDatabase.db")
            .LogTo(
                Console.WriteLine, // tipo de impresion
                new [] { DbLoggerCategory.Database.Command.Name }, // que va a imprimir
                Microsoft.Extensions.Logging.LogLevel.Information // tipo de loggin
            )
            .EnableSensitiveDataLogging();
    }

    //? 2.-
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Creacion de las tablas
        modelBuilder.Entity<ActivityEntity>().ToTable("activities");
        modelBuilder.Entity<LikeEntity>().ToTable("likes");
        modelBuilder.Entity<MessageEntity>().ToTable("messages");
        modelBuilder.Entity<PhotoEntity>().ToTable("images");
        modelBuilder.Entity<ServerEntity>().ToTable("servers");
        modelBuilder.Entity<Subscription>().ToTable("subscriptions");
        modelBuilder.Entity<TypeEntity>().ToTable("server_types");
        modelBuilder.Entity<UserActivityEntity>().ToTable("users_activities");
        modelBuilder.Entity<UserEntity>().ToTable("users");
        modelBuilder.Entity<UserServerEntity>().ToTable("users_servers");


        // Modificaciones a las tablas


        // Relaciones

        //? relacion de muchos a 1
        modelBuilder.Entity<PhotoEntity>()
            .HasMany( i => i.Likes )
            .WithOne( l => l.Image )
            .HasForeignKey( l => l.ImageId )
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade );

        modelBuilder.Entity<ServerEntity>()
            .HasMany( s => s.Messages )
            .WithOne( m => m.Server )
            .HasForeignKey( s => s.ServerId )
            .IsRequired()
            .OnDelete( DeleteBehavior.Cascade );

        modelBuilder.Entity<UserEntity>()
            .HasMany( u => u.Messages )
            .WithOne( m => m.User )
            .HasForeignKey( m => m.UserId )
            .OnDelete( DeleteBehavior.Restrict );

        modelBuilder.Entity<UserEntity>()
            .HasMany( u => u.Photos )
            .WithOne( i => i.User )
            .HasForeignKey( i => i.UserId )
            .IsRequired()
            .OnDelete( DeleteBehavior.Cascade );

        modelBuilder.Entity<Subscription>()
            .HasMany( s => s.Users )
            .WithOne( u => u.Subscription )
            .HasForeignKey( u => u.SubscriptionId )
            .OnDelete( DeleteBehavior.Restrict );


        //? relacion de muchos a muchos
        modelBuilder.Entity<UserEntity>()
            .HasMany( u => u.Servers )
            .WithMany( s => s.Users )
            .UsingEntity<UserServerEntity>(
                us => us.HasOne( us => us.Server )
                    .WithMany( s => s.UserServers)
                    .HasForeignKey( u => u.ServerId ),
                us => us.HasOne( us => us.User )
                    .WithMany( u => u.UserServers )
                    .HasForeignKey( u => u.UserId ),
                us => us.HasKey( us => new {us.UserId, us.Server} )
            );

        modelBuilder.Entity<UserEntity>()
            .HasMany( u => u.Activities )
            .WithMany( a => a.Users )
            .UsingEntity<UserActivityEntity>(
                ua => ua.HasOne( ua => ua.Activity )
                    .WithMany( a => a.UserActivities )
                    .HasForeignKey( ua => ua.ActivityId ),
                ua => ua.HasOne( ua => ua.User )
                    .WithMany( a => a.UserActivities )
                    .HasForeignKey( ua => ua.UserId )
            );
    }


}
