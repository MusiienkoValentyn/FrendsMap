using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Configuration;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;


namespace DAL
{
    public class FrendsMapContext : DbContext
    {
        public FrendsMapContext()
        {
        }

        public FrendsMapContext(DbContextOptions<FrendsMapContext> options)
            : base(options)
        {
             //Database.EnsureDeleted();
            //Database.EnsureCreated();
           
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RankingOfFriend>()
             .HasOne(p => p.Person)
             .WithMany(b => b.RankingOfFriends)
             .HasForeignKey(p => p.PersonId);

            modelBuilder.Entity<RankingOfFriend>()
          .HasOne(p => p.Person1)
          .WithMany(b => b.RankingOfFriends1)
          .HasForeignKey(p => p.FriendId);

            modelBuilder.Seed();

        }

        public DbSet<TypeOfPlace> TypeOfPlace { get; set; }
        public DbSet<Place> Place { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<Photo> Photo { get; set; }
        public DbSet<Ranking> Ranking { get; set; }
        public DbSet<RankingOfFriend> RankingOfFriend { get; set; }
        public DbSet<Comment> Comment { get; set; }
    }
}
