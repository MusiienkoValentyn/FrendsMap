﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FrendsMap.Migrations
{
    [DbContext(typeof(FrendsMapContext))]
    partial class FrendsMapContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DAL.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateTimeOfAdding")
                        .HasColumnType("datetime2");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<int?>("PlaceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.HasIndex("PlaceId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("DAL.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Gmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NickName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Person");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            NickName = "Pogrib",
                            Rating = 0
                        },
                        new
                        {
                            Id = 2,
                            NickName = "Meska",
                            Rating = 0
                        });
                });

            modelBuilder.Entity("DAL.Entities.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateTimeOfAdding")
                        .HasColumnType("datetime2");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<int?>("PlaceId")
                        .HasColumnType("int");

                    b.Property<string>("URL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.HasIndex("PlaceId");

                    b.ToTable("Photo");
                });

            modelBuilder.Entity("DAL.Entities.Place", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateTimeOfAdding")
                        .HasColumnType("datetime2");

                    b.Property<string>("Geolocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<int>("TypeOfPlaceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.HasIndex("TypeOfPlaceId");

                    b.ToTable("Place");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateTimeOfAdding = new DateTime(2020, 4, 2, 23, 48, 52, 825, DateTimeKind.Local).AddTicks(3895),
                            Geolocation = "124/24.12",
                            Name = "Gurtogitok 7",
                            PersonId = 1,
                            TypeOfPlaceId = 2
                        },
                        new
                        {
                            Id = 2,
                            DateTimeOfAdding = new DateTime(2020, 4, 2, 23, 48, 52, 825, DateTimeKind.Local).AddTicks(5005),
                            Geolocation = "124/24.13",
                            Name = "Hata",
                            PersonId = 2,
                            TypeOfPlaceId = 1
                        });
                });

            modelBuilder.Entity("DAL.Entities.Ranking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateTimeOfAdding")
                        .HasColumnType("datetime2");

                    b.Property<int>("Mark")
                        .HasColumnType("int");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<int?>("PlaceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.HasIndex("PlaceId");

                    b.ToTable("Ranking");
                });

            modelBuilder.Entity("DAL.Entities.RankingOfFriend", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateTimeOfAdding")
                        .HasColumnType("datetime2");

                    b.Property<int?>("FriendId")
                        .HasColumnType("int");

                    b.Property<int>("Mark")
                        .HasColumnType("int");

                    b.Property<int?>("PersonId")
                        .HasColumnType("int");

                    b.Property<int?>("TypeOfPlaceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FriendId");

                    b.HasIndex("PersonId");

                    b.HasIndex("TypeOfPlaceId");

                    b.ToTable("RankingOfFriend");
                });

            modelBuilder.Entity("DAL.Entities.TypeOfPlace", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TypeOfPlace");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Park"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Stadion"
                        });
                });

            modelBuilder.Entity("DAL.Entities.Comment", b =>
                {
                    b.HasOne("DAL.Entities.Person", "Person")
                        .WithMany("Comments")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Entities.Place", "Place")
                        .WithMany("Comments")
                        .HasForeignKey("PlaceId");
                });

            modelBuilder.Entity("DAL.Entities.Photo", b =>
                {
                    b.HasOne("DAL.Entities.Person", "Person")
                        .WithMany("Photos")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Entities.Place", "Place")
                        .WithMany("Photos")
                        .HasForeignKey("PlaceId");
                });

            modelBuilder.Entity("DAL.Entities.Place", b =>
                {
                    b.HasOne("DAL.Entities.Person", "Person")
                        .WithMany("Places")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Entities.TypeOfPlace", "TypeOfPlace")
                        .WithMany("Places")
                        .HasForeignKey("TypeOfPlaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DAL.Entities.Ranking", b =>
                {
                    b.HasOne("DAL.Entities.Person", "Person")
                        .WithMany("Rankings")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Entities.Place", "Place")
                        .WithMany("Rankings")
                        .HasForeignKey("PlaceId");
                });

            modelBuilder.Entity("DAL.Entities.RankingOfFriend", b =>
                {
                    b.HasOne("DAL.Entities.Person", "Person1")
                        .WithMany("RankingOfFriends1")
                        .HasForeignKey("FriendId");

                    b.HasOne("DAL.Entities.Person", "Person")
                        .WithMany("RankingOfFriends")
                        .HasForeignKey("PersonId");

                    b.HasOne("DAL.Entities.TypeOfPlace", "TypeOfPlace")
                        .WithMany()
                        .HasForeignKey("TypeOfPlaceId");
                });
#pragma warning restore 612, 618
        }
    }
}
