using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieShop.Infrastructure.Data
{
    public class MovieShopDbContext : DbContext
    {
        public MovieShopDbContext(DbContextOptions<MovieShopDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Action<EntityTypeBuilder<TEntity>> buildAction
            modelBuilder.Entity<Movie>(ConfigureMovie);
            modelBuilder.Entity<Trailer>(ConfigureTrailer);
            modelBuilder.Entity<User>(u => {
                u.ToTable("User");
                u.HasKey(u => u.Id);
            });
            modelBuilder.Entity<Role>(r => {
                r.ToTable("Role");
                r.HasKey(r => r.Id);
            });      
            modelBuilder.Entity<Cast>(c => {
                c.ToTable("Cast");
                c.HasKey(c => c.Id);
            });
            //modelBuilder.Entity<Trailer>(t => {
            //    t.ToTable("Trailer");
            //    t.HasKey(t => t.Id);
            //    t.Property(t => t.TrailerUrl).HasMaxLength(2084);
            //    t.Property(t => t.Name).HasMaxLength(2084);

            //});
            modelBuilder.Entity<Movie>().HasMany(m => m.Genres).WithMany(g => g.Movies)
                .UsingEntity<Dictionary<string, object>>("MovieGenre",
                    m => m.HasOne<Genre>().WithMany().HasForeignKey("GenreId"),
                    g => g.HasOne<Movie>().WithMany().HasForeignKey("MovieId"));

            modelBuilder.Entity<User>().HasMany(u => u.Roles).WithMany(r => r.Users)
                .UsingEntity<Dictionary<string, object>>("UserRole",
                    r => r.HasOne<Role>().WithMany().HasForeignKey("RoleId"),
                    u => u.HasOne<User>().WithMany().HasForeignKey("UserId")
                );            
            
            modelBuilder.Entity<Movie>().HasMany(m => m.Casts).WithMany(c => c.Movies)
                .UsingEntity<Dictionary<string, object>>("MovieCast",
                    m => m.HasOne<Cast>().WithMany().HasForeignKey("CastId"),
                    c => c.HasOne<Movie>().WithMany().HasForeignKey("MovieId")
                );
                
        }
        private void ConfigureTrailer(EntityTypeBuilder<Trailer> builder)
        {
            builder.ToTable("Trailer");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.TrailerUrl).HasMaxLength(2084);
            builder.Property(t => t.Name).HasMaxLength(2084);
        }
        private void ConfigureMovie(EntityTypeBuilder<Movie> builder)
        {
            // we are gonna give rules to our Movie table/entity Fluent API
            builder.ToTable("Movie");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Title).HasMaxLength(256);
            builder.Property(m => m.Overview).HasMaxLength(4096);
            builder.Property(m => m.Tagline).HasMaxLength(512);
            builder.Property(m => m.ImdbUrl).HasMaxLength(2084);
            builder.Property(m => m.TmdbUrl).HasMaxLength(2084);
            builder.Property(m => m.PosterUrl).HasMaxLength(2084);
            builder.Property(m => m.BackdropUrl).HasMaxLength(2084);
            builder.Property(m => m.OriginalLanguage).HasMaxLength(64);
            builder.Property(m => m.Price).HasColumnType("decimal(5, 2)").HasDefaultValue(9.9m);
            builder.Property(m => m.CreatedDate).HasDefaultValueSql("getdate()");
        }
        // Many DbSets, they are reprensented as properties
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Trailer> Trailers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Cast> Casts { get; set; }


    }
}
