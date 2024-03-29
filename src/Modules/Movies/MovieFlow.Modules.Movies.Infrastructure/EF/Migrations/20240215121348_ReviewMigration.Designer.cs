﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieFlow.Modules.Movies.Infrastructure.EF.Context;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MovieFlow.Modules.Movies.Infrastructure.EF.Migrations
{
    [DbContext(typeof(MoviesWriteDbContext))]
    [Migration("20240215121348_ReviewMigration")]
    partial class ReviewMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("movies")
                .HasAnnotation("ProductVersion", "8.0.0-rc.2.23480.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("GenreMovie", b =>
                {
                    b.Property<Guid>("GenresId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("MoviesId")
                        .HasColumnType("uuid");

                    b.HasKey("GenresId", "MoviesId");

                    b.HasIndex("MoviesId");

                    b.ToTable("MovieGenres_Mapping", "movies");
                });

            modelBuilder.Entity("MovieFlow.Modules.Movies.Core.Movies.Entities.Director", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Country");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("CreatedAt");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("DateOfBirth");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("FirstName");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("LastName");

                    b.Property<int>("State")
                        .HasColumnType("integer")
                        .HasColumnName("State");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("UpdatedAt");

                    b.HasKey("Id");

                    b.ToTable("Directors", "movies");
                });

            modelBuilder.Entity("MovieFlow.Modules.Movies.Core.Movies.Entities.Genre", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("CreatedAt");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Name");

                    b.Property<int>("State")
                        .HasColumnType("integer")
                        .HasColumnName("State");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Genres", "movies");
                });

            modelBuilder.Entity("MovieFlow.Modules.Movies.Core.Movies.Entities.Movie", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("CreatedAt");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Description");

                    b.Property<Guid>("DirectorId")
                        .HasColumnType("uuid");

                    b.Property<double>("Rating")
                        .HasColumnType("double precision")
                        .HasColumnName("Rating");

                    b.Property<int>("ReleaseYear")
                        .HasColumnType("integer")
                        .HasColumnName("ReleaseYear");

                    b.Property<int>("State")
                        .HasColumnType("integer")
                        .HasColumnName("State");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Title");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("DirectorId");

                    b.ToTable("Movies", "movies");
                });

            modelBuilder.Entity("MovieFlow.Modules.Movies.Core.Movies.Entities.Review", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Content");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("CreatedAt");

                    b.Property<Guid>("MovieId")
                        .HasColumnType("uuid");

                    b.Property<double>("Rating")
                        .HasColumnType("double precision")
                        .HasColumnName("Rating");

                    b.Property<int>("State")
                        .HasColumnType("integer")
                        .HasColumnName("State");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Title");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("UpdatedAt");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("UserId");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.ToTable("Reviews", "movies");
                });

            modelBuilder.Entity("GenreMovie", b =>
                {
                    b.HasOne("MovieFlow.Modules.Movies.Core.Movies.Entities.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieFlow.Modules.Movies.Core.Movies.Entities.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MovieFlow.Modules.Movies.Core.Movies.Entities.Movie", b =>
                {
                    b.HasOne("MovieFlow.Modules.Movies.Core.Movies.Entities.Director", "Director")
                        .WithMany("Movies")
                        .HasForeignKey("DirectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Director");
                });

            modelBuilder.Entity("MovieFlow.Modules.Movies.Core.Movies.Entities.Review", b =>
                {
                    b.HasOne("MovieFlow.Modules.Movies.Core.Movies.Entities.Movie", "Movie")
                        .WithMany("Reviews")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("MovieFlow.Shared.Abstractions.Kernel.ValueObjects.Likes.Likes", "Likes", b1 =>
                        {
                            b1.Property<Guid>("ReviewId")
                                .HasColumnType("uuid");

                            b1.Property<long>("NegativeLikes")
                                .HasColumnType("bigint")
                                .HasColumnName("NegativeLikes");

                            b1.Property<long>("PositiveLikes")
                                .HasColumnType("bigint")
                                .HasColumnName("PositiveLikes");

                            b1.HasKey("ReviewId");

                            b1.ToTable("Reviews", "movies");

                            b1.WithOwner()
                                .HasForeignKey("ReviewId");
                        });

                    b.Navigation("Likes")
                        .IsRequired();

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("MovieFlow.Modules.Movies.Core.Movies.Entities.Director", b =>
                {
                    b.Navigation("Movies");
                });

            modelBuilder.Entity("MovieFlow.Modules.Movies.Core.Movies.Entities.Movie", b =>
                {
                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
