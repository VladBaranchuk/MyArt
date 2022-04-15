﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyArt.DataAccess;

#nullable disable

namespace MyArt.DataAccess.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MyArt.Domain.Entities.Art", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("BrightColor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DarkColor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2022, 4, 15, 10, 39, 24, 747, DateTimeKind.Local).AddTicks(8534));

                    b.Property<int>("Moderation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int?>("Month")
                        .HasColumnType("int");

                    b.Property<string>("MutedColor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("SellingAvailability")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int?>("ShareCount")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("Visible")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<string>("Year")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Art", (string)null);
                });

            modelBuilder.Entity("MyArt.Domain.Entities.ArtComments", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("ArtId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2022, 4, 15, 10, 39, 24, 747, DateTimeKind.Local).AddTicks(4557));

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "ArtId");

                    b.HasIndex("ArtId");

                    b.ToTable("ArtComments", (string)null);
                });

            modelBuilder.Entity("MyArt.Domain.Entities.ArtForm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ArtForm", (string)null);
                });

            modelBuilder.Entity("MyArt.Domain.Entities.ArtFormToArt", b =>
                {
                    b.Property<int>("ArtFormId")
                        .HasColumnType("int");

                    b.Property<int>("ArtId")
                        .HasColumnType("int");

                    b.HasKey("ArtFormId", "ArtId");

                    b.HasIndex("ArtId");

                    b.ToTable("ArtFormToArt", (string)null);
                });

            modelBuilder.Entity("MyArt.Domain.Entities.ArtFormToBoard", b =>
                {
                    b.Property<int>("ArtFormId")
                        .HasColumnType("int");

                    b.Property<int>("BoardId")
                        .HasColumnType("int");

                    b.HasKey("ArtFormId", "BoardId");

                    b.HasIndex("BoardId");

                    b.ToTable("ArtFormToBoard", (string)null);
                });

            modelBuilder.Entity("MyArt.Domain.Entities.ArtToBoard", b =>
                {
                    b.Property<int>("BoardId")
                        .HasColumnType("int");

                    b.Property<int>("ArtId")
                        .HasColumnType("int");

                    b.HasKey("BoardId", "ArtId");

                    b.HasIndex("ArtId");

                    b.ToTable("ArtToBoard", (string)null);
                });

            modelBuilder.Entity("MyArt.Domain.Entities.Board", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2022, 4, 15, 10, 39, 24, 749, DateTimeKind.Local).AddTicks(3637));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ShareCount")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("Visible")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Board", (string)null);
                });

            modelBuilder.Entity("MyArt.Domain.Entities.BoughtFilms", b =>
                {
                    b.Property<int>("FilmId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("FilmId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("BoughtFilms", (string)null);
                });

            modelBuilder.Entity("MyArt.Domain.Entities.Exhibition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("AnnounceDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Announcement")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Moderation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Release")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<DateTime?>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ShareCount")
                        .HasColumnType("int");

                    b.Property<int>("Visible")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("Id");

                    b.ToTable("Exhibition", (string)null);
                });

            modelBuilder.Entity("MyArt.Domain.Entities.ExhibitionComments", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("ExhibitionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2022, 4, 15, 10, 39, 24, 750, DateTimeKind.Local).AddTicks(479));

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "ExhibitionId");

                    b.HasIndex("ExhibitionId");

                    b.ToTable("ExhibitionComments", (string)null);
                });

            modelBuilder.Entity("MyArt.Domain.Entities.ExhibitionToArt", b =>
                {
                    b.Property<int>("ExhibitionId")
                        .HasColumnType("int");

                    b.Property<int>("ArtId")
                        .HasColumnType("int");

                    b.HasKey("ExhibitionId", "ArtId");

                    b.HasIndex("ArtId");

                    b.ToTable("ExhibitionToArt", (string)null);
                });

            modelBuilder.Entity("MyArt.Domain.Entities.ExhibitionToArtForm", b =>
                {
                    b.Property<int>("ExhibitionId")
                        .HasColumnType("int");

                    b.Property<int>("ArtFormId")
                        .HasColumnType("int");

                    b.HasKey("ExhibitionId", "ArtFormId");

                    b.HasIndex("ArtFormId");

                    b.ToTable("ExhibitionToArtForm", (string)null);
                });

            modelBuilder.Entity("MyArt.Domain.Entities.Film", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Announcement")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int>("Country")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Duration")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("Producer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Release")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ShareCount")
                        .HasColumnType("int");

                    b.Property<int>("Visible")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("Id");

                    b.ToTable("Film", (string)null);
                });

            modelBuilder.Entity("MyArt.Domain.Entities.FilmComments", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("FilmId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2022, 4, 15, 10, 39, 24, 751, DateTimeKind.Local).AddTicks(982));

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "FilmId");

                    b.HasIndex("FilmId");

                    b.ToTable("FilmComments", (string)null);
                });

            modelBuilder.Entity("MyArt.Domain.Entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genre", (string)null);
                });

            modelBuilder.Entity("MyArt.Domain.Entities.GenreToFilm", b =>
                {
                    b.Property<int>("FilmId")
                        .HasColumnType("int");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.HasKey("FilmId", "GenreId");

                    b.HasIndex("GenreId");

                    b.ToTable("GenreToFilm", (string)null);
                });

            modelBuilder.Entity("MyArt.Domain.Entities.LikeArts", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("ArtId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "ArtId");

                    b.HasIndex("ArtId");

                    b.ToTable("LikeArts", (string)null);
                });

            modelBuilder.Entity("MyArt.Domain.Entities.LikeBoards", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("BoardId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "BoardId");

                    b.HasIndex("BoardId");

                    b.ToTable("LikeBoards", (string)null);
                });

            modelBuilder.Entity("MyArt.Domain.Entities.LikeExhibitions", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("ExhibitionId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "ExhibitionId");

                    b.HasIndex("ExhibitionId");

                    b.ToTable("LikeExhibitions", (string)null);
                });

            modelBuilder.Entity("MyArt.Domain.Entities.LikeFilms", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("FilmId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "FilmId");

                    b.HasIndex("FilmId");

                    b.ToTable("LikeFilms", (string)null);
                });

            modelBuilder.Entity("MyArt.Domain.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Role", (string)null);
                });

            modelBuilder.Entity("MyArt.Domain.Entities.RoleToUser", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleToUser", (string)null);
                });

            modelBuilder.Entity("MyArt.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("MyArt.Domain.Entities.Art", b =>
                {
                    b.HasOne("MyArt.Domain.Entities.User", "User")
                        .WithMany("Arts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MyArt.Domain.Entities.ArtComments", b =>
                {
                    b.HasOne("MyArt.Domain.Entities.Art", "Art")
                        .WithMany("ArtComments")
                        .HasForeignKey("ArtId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyArt.Domain.Entities.User", "User")
                        .WithMany("ArtComments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Art");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MyArt.Domain.Entities.ArtFormToArt", b =>
                {
                    b.HasOne("MyArt.Domain.Entities.ArtForm", "ArtForm")
                        .WithMany("ArtFormToArts")
                        .HasForeignKey("ArtFormId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyArt.Domain.Entities.Art", "Art")
                        .WithMany("ArtFormToArts")
                        .HasForeignKey("ArtId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Art");

                    b.Navigation("ArtForm");
                });

            modelBuilder.Entity("MyArt.Domain.Entities.ArtFormToBoard", b =>
                {
                    b.HasOne("MyArt.Domain.Entities.ArtForm", "ArtForm")
                        .WithMany("ArtFormToBoards")
                        .HasForeignKey("ArtFormId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyArt.Domain.Entities.Board", "Board")
                        .WithMany("ArtFormToBoards")
                        .HasForeignKey("BoardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ArtForm");

                    b.Navigation("Board");
                });

            modelBuilder.Entity("MyArt.Domain.Entities.ArtToBoard", b =>
                {
                    b.HasOne("MyArt.Domain.Entities.Board", "Board")
                        .WithMany("ArtToBoards")
                        .HasForeignKey("ArtId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("MyArt.Domain.Entities.Art", "Art")
                        .WithMany("ArtToBoards")
                        .HasForeignKey("BoardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Art");

                    b.Navigation("Board");
                });

            modelBuilder.Entity("MyArt.Domain.Entities.Board", b =>
                {
                    b.HasOne("MyArt.Domain.Entities.User", "User")
                        .WithMany("Boards")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MyArt.Domain.Entities.BoughtFilms", b =>
                {
                    b.HasOne("MyArt.Domain.Entities.Film", "Film")
                        .WithMany("BoughtFilms")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyArt.Domain.Entities.User", "User")
                        .WithMany("BoughtFilms")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Film");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MyArt.Domain.Entities.ExhibitionComments", b =>
                {
                    b.HasOne("MyArt.Domain.Entities.Exhibition", "Exhibition")
                        .WithMany("ExhibitionComments")
                        .HasForeignKey("ExhibitionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyArt.Domain.Entities.User", "User")
                        .WithMany("ExhibitionComments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exhibition");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MyArt.Domain.Entities.ExhibitionToArt", b =>
                {
                    b.HasOne("MyArt.Domain.Entities.Art", "Art")
                        .WithMany("ExhibitionToArts")
                        .HasForeignKey("ArtId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyArt.Domain.Entities.Exhibition", "Exhibition")
                        .WithMany("ExhibitionToArts")
                        .HasForeignKey("ExhibitionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Art");

                    b.Navigation("Exhibition");
                });

            modelBuilder.Entity("MyArt.Domain.Entities.ExhibitionToArtForm", b =>
                {
                    b.HasOne("MyArt.Domain.Entities.ArtForm", "ArtForm")
                        .WithMany("ExhibitionToArtForms")
                        .HasForeignKey("ArtFormId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyArt.Domain.Entities.Exhibition", "Exhibition")
                        .WithMany("ExhibitionToArtForms")
                        .HasForeignKey("ExhibitionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ArtForm");

                    b.Navigation("Exhibition");
                });

            modelBuilder.Entity("MyArt.Domain.Entities.FilmComments", b =>
                {
                    b.HasOne("MyArt.Domain.Entities.Film", "Film")
                        .WithMany("FilmComments")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyArt.Domain.Entities.User", "User")
                        .WithMany("FilmComments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Film");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MyArt.Domain.Entities.GenreToFilm", b =>
                {
                    b.HasOne("MyArt.Domain.Entities.Film", "Film")
                        .WithMany("GenreToFilms")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyArt.Domain.Entities.Genre", "Genre")
                        .WithMany("GenreToFilms")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Film");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("MyArt.Domain.Entities.LikeArts", b =>
                {
                    b.HasOne("MyArt.Domain.Entities.Art", "Art")
                        .WithMany("LikeArts")
                        .HasForeignKey("ArtId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyArt.Domain.Entities.User", "User")
                        .WithMany("LikeArts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Art");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MyArt.Domain.Entities.LikeBoards", b =>
                {
                    b.HasOne("MyArt.Domain.Entities.Board", "Board")
                        .WithMany("LikeBoards")
                        .HasForeignKey("BoardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyArt.Domain.Entities.User", "User")
                        .WithMany("LikeBoards")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Board");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MyArt.Domain.Entities.LikeExhibitions", b =>
                {
                    b.HasOne("MyArt.Domain.Entities.Exhibition", "Exhibition")
                        .WithMany("LikeExhibitions")
                        .HasForeignKey("ExhibitionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyArt.Domain.Entities.User", "User")
                        .WithMany("LikeExhibitions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exhibition");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MyArt.Domain.Entities.LikeFilms", b =>
                {
                    b.HasOne("MyArt.Domain.Entities.Film", "Film")
                        .WithMany("LikeFilms")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyArt.Domain.Entities.User", "User")
                        .WithMany("LikeFilms")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Film");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MyArt.Domain.Entities.RoleToUser", b =>
                {
                    b.HasOne("MyArt.Domain.Entities.Role", "Role")
                        .WithMany("RoleToUsers")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyArt.Domain.Entities.User", "User")
                        .WithMany("RoleToUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MyArt.Domain.Entities.Art", b =>
                {
                    b.Navigation("ArtComments");

                    b.Navigation("ArtFormToArts");

                    b.Navigation("ArtToBoards");

                    b.Navigation("ExhibitionToArts");

                    b.Navigation("LikeArts");
                });

            modelBuilder.Entity("MyArt.Domain.Entities.ArtForm", b =>
                {
                    b.Navigation("ArtFormToArts");

                    b.Navigation("ArtFormToBoards");

                    b.Navigation("ExhibitionToArtForms");
                });

            modelBuilder.Entity("MyArt.Domain.Entities.Board", b =>
                {
                    b.Navigation("ArtFormToBoards");

                    b.Navigation("ArtToBoards");

                    b.Navigation("LikeBoards");
                });

            modelBuilder.Entity("MyArt.Domain.Entities.Exhibition", b =>
                {
                    b.Navigation("ExhibitionComments");

                    b.Navigation("ExhibitionToArtForms");

                    b.Navigation("ExhibitionToArts");

                    b.Navigation("LikeExhibitions");
                });

            modelBuilder.Entity("MyArt.Domain.Entities.Film", b =>
                {
                    b.Navigation("BoughtFilms");

                    b.Navigation("FilmComments");

                    b.Navigation("GenreToFilms");

                    b.Navigation("LikeFilms");
                });

            modelBuilder.Entity("MyArt.Domain.Entities.Genre", b =>
                {
                    b.Navigation("GenreToFilms");
                });

            modelBuilder.Entity("MyArt.Domain.Entities.Role", b =>
                {
                    b.Navigation("RoleToUsers");
                });

            modelBuilder.Entity("MyArt.Domain.Entities.User", b =>
                {
                    b.Navigation("ArtComments");

                    b.Navigation("Arts");

                    b.Navigation("Boards");

                    b.Navigation("BoughtFilms");

                    b.Navigation("ExhibitionComments");

                    b.Navigation("FilmComments");

                    b.Navigation("LikeArts");

                    b.Navigation("LikeBoards");

                    b.Navigation("LikeExhibitions");

                    b.Navigation("LikeFilms");

                    b.Navigation("RoleToUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
