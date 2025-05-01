using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Actor_Movie>().HasKey(
                (am) =>
                new
                {
                    am.MovieId,
                    am.ActorId,
                });

            modelBuilder.Entity<Actor_Movie>().HasOne((m) => m.Movie)
                .WithMany((am) => am.MovieActors)
                .HasForeignKey(am => am.MovieId);

            modelBuilder.Entity<Actor_Movie>().HasOne(am => am.Actor)
                .WithMany(a => a.MovieActors)
                .HasForeignKey(am => am.ActorId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Actor_Movie> Actors_Movies { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Producer> Producers { get; set; }


    }
}
