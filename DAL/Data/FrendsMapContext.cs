using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Configuration;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

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
            modelBuilder.Entity<RankingOfFriend>(entity =>
            {
                entity.HasKey(p => new { p.TypeOfPlaceId, p.PersonId, p.FriendId });

                entity.HasOne(e => e.Person).WithMany(r => r.RankingOfFriends)
                 .HasForeignKey(fk => fk.PersonId)
                 .OnDelete(DeleteBehavior.ClientSetNull);


                entity.HasOne(e => e.Person1).WithMany(r => r.RankingOfFriends1)
                 .HasForeignKey(fk => fk.FriendId)
                 .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Ranking>()
                .Property(p => p.DateTimeOfAdding)
                .HasDefaultValueSql("GETUTCDATE()");

            modelBuilder.Entity<Comment>()
                .Property(p => p.DateTimeOfAdding)
                .HasDefaultValueSql("GETUTCDATE()");

            modelBuilder.Entity<Photo>()
                .Property(p => p.DateTimeOfAdding)
                .HasDefaultValueSql("GETUTCDATE()");

            modelBuilder.Entity<RankingOfFriend>()
                .Property(p => p.DateTimeOfAdding)
                .HasDefaultValueSql("GETUTCDATE()");

            modelBuilder.Entity<Place>()
                .Property(p => p.DateTimeOfAdding)
                .HasDefaultValueSql("GETUTCDATE()");

            modelBuilder.Entity<Photo>()
                .Property(p => p.IsAccepted)
                .HasDefaultValue(true);

            modelBuilder.Entity<Place>()
               .Property(p => p.IsAccepted)
               .HasDefaultValue(true);

            modelBuilder.Entity<Comment>()
               .Property(p => p.IsAccepted)
               .HasDefaultValue(true);

            modelBuilder.Entity<Person>()
                .HasIndex(i => i.IDUserOfGoogle)
                .IsUnique();

            modelBuilder.Entity<Person>()
                .HasIndex(i => i.NickName)
                .IsUnique();

            modelBuilder.Entity<Person>()
                .Property(p => p.Rating)
                .HasDefaultValue(1);
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
